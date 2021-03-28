iptables -F

iptables -P FORWARD DROP

iptables -A FORWARD -p tcp --destination-port 80 -d 192.168.100.80 -m state --state NEW,ESTABLISHED -j ACCEPT
iptables -A FORWARD -p tcp --source-port 80 -s 192.168.100.80 -m state --state ESTABLISHED -j ACCEPT
