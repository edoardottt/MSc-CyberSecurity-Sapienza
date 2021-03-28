iptables -F
ip6tables -F

iptables -P FORWARD DROP
ip6tables -P FORWARD DROP

## INTERNAL ##

iptables -A FORWARD -p tcp -s 192.168.100.10 -dport 22,25,80,443 -m state --state NEW,ESTABLISHED -j ACCEPT
iptables -A FORWARD -p tcp -d 192.168.100.10 -sport 22,25,80,443 -m state --state ESTABLISHED -j ACCEPT

ip6tables -A FORWARD -p tcp -s 2001:db8:cafe:1::10 -dport 22,25,80,443 -m state --state NEW,ESTABLISHED -j ACCEPT
ip6tables -A FORWARD -p tcp -d 2001:db8:cafe:1::10 -sport 22,25,80,443 -m state --state ESTABLISHED -j ACCEPT


## DMZ ##

# - tcp ingoing -
iptables -A FORWARD -p tcp -d 203.0.113.80 -dport 80,443 -m state --state NEW,ESTABLISHED -j ACCEPT
ip6tables -A FORWARD -p tcp -d 2001:db8:cafe:2::80 -dport 80,443 -m state --state NEW,ESTABLISHED -j ACCEPT
iptables -A FORWARD -p tcp -d 203.0.113.25 -dport 25 -m state --state NEW,ESTABLISHED -j ACCEPT
ip6tables -A FORWARD -p tcp -d 2001:db8:cafe:2::25 -dport 25 -m state --state NEW,ESTABLISHED -j ACCEPT

# - tcp outgoing -
iptables -A FORWARD -p tcp -s 203.0.113.80 -sport 80,443 -m state --state ESTABLISHED -j ACCEPT
ip6tables -A FORWARD -p tcp -s 2001:db8:cafe:2::80 -sport 80,443 -m state --state ESTABLISHED -j ACCEPT
iptables -A FORWARD -p tcp -s 203.0.113.25 -sport 25 -m state --state ESTABLISHED -j ACCEPT
ip6tables -A FORWARD -p tcp -s 2001:db8:cafe:2::25 -sport 25 -m state --state ESTABLISHED -j ACCEPT

# - ping -
iptables -A FORWARD -p icmp -o eth1 --icmp-type echo-request -j ACCEPT
iptables -A FORWARD -p icmp -i eth1 --icmp-type echo-reply -j ACCEPT
ip6tables -A FORWARD -p icmp -o eth1 --icmp-type echo-request -j ACCEPT
ip6tables -A FORWARD -p icmp -i eth1 --icmp-type echo-reply -j ACCEPT

