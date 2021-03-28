ip6tables -F

ip6tables -P FORWARD DROP

ip6tables -A FORWARD -p tcp --source-port 80 -s 2001:db8:cafe:1::80 -m state --state ESTABLISHED -j ACCEPT
ip6tables -A FORWARD -p tcp --destination-port 80 -d 2001:db8:cafe:1::80 -m state --state NEW,ESTABLISHED -j ACCEPT


