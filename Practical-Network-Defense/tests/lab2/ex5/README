Three routers connecting two lans with one pc each. The assignment
is: to configure the topology to use static addressing for the
routers and SLAAC IPv6 addresses for the two lans. Moreover, you have
to play with the MTU of the links between the routers to generate and 
capture ICMPv6 packets (Packet too big or MTU discovery). 

The routers have to be configured as such:
- r1.eth0 2001:db8:cafe:1::1/64
- r1.eth1 2001:db8:cafe:2::1/64
- r2.eth0 2001:db8:cafe:2::2/64
- r2.eth1 2001:db8:cafe:3::1/64
- r3.eth0 2001:db8:cafe:3::2/64
- r3.eth1 2001:db8:cafe:4::1/64

- All the pcs of the topology must have GUA addresses via SLAAC.

- Remember to add static routes for the networks.

- You can use ping or tracepath to generate traffic in the network.

- To change the mtu of a link you can use the ip link set mtu command
  on both the end points of the link.
