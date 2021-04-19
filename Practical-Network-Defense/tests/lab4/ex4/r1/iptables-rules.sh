# NAT with MASQUERADE
iptables -t nat -A POSTROUTING -p TCP -j MASQUERADE --to-ports 1024-31000

# REJECT everything destinated to LAN
iptables -P FORWARD REJECT

# ICMP allowed to LAN
iptables -A FORWARD -i eth1 -p icmp --icmp-type 8 -j ACCEPT
iptables -A FORWARD -o eth0 -p icmp --icmp-type 0 -j ACCEPT
