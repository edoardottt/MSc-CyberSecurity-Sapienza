## PacketTracer Useful Commands

- [Fundamentals](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#fundamentals)
- [Basic Router Configuration](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#basic-router-configuration)
- [RIPv1](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#ripv1)
- [RIPv2](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#ripv2)
- [OSPF](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#ospf)
- [DHCP](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#dhcp)
- [NAT](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#nat)
- [VLAN](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#vlan)
- [InterVLAN routing](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#intervlan-routing)
- [ACL](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#acl)
- [LAN Security](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#lan-security)
- [VPN](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#vpn)
- [Useful tips](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Laboratory-of-Network-Design-and-Configuration/Bible.md#useful-tips)


### Fundamentals

- [Introduction to Networking | Network Fundamentals Part 1 by Network Direction](https://www.youtube.com/watch?v=cNwEVYkx2Kk)
- [200-125 CCNA v3.0 | Day 1: Network Fundamentals Free Cisco Video Training 2017 | Networking by NetworKing](https://www.youtube.com/watch?v=n2D1o-aM-2s)
- [Computer Networking Complete Course - Beginner to Advanced](https://www.youtube.com/watch?v=QKfk7YFILws)



### Basic Router Configuration

- Enter Privileged mode: `enable`
- Exit from current configuration: `exit`
- Enter the global configuration mode: `conf t` (short for `configure terminal`)
- List a set of available commands: `?`
- Assign or change a Router name (in config mode): `hostname NAME`
- Assign a password for the console access: `line console 0`, `password PASSWORD`, `login`
- Assign a password for the Telnet access to a **router**: `line vty 0 4`, `password PASSWORD`, `login`
- Assign a password for the Privileged mode (stored in plaintext): `enable password PASSWORD`
- Assign a password for the Privileged mode (encrypted): `enable password PASSWORD`, `service password-encryption`
- Assign a password for the Privileged mode (encrypted, more robust): `enable secret PASSWORD`
- Show statistics about interfaces: `show interfaces`
- Show Hardware level info about interfaces: `show controllers serial`
- Show info about Router clock: `show clock`
- Show list of devices known by the router: `show hosts`
- Show users connected to the router: `show users`
- Show list of commands used in the past: `show history`
- Show info about flash memory and available IOS image files: `show flash`
- Show hardware level features of the router and running IOS: `show version`
- Show ARP table of the router: `show ARP`
- Show Layer 3 protocols configured at router level and at interface level: `show protocol`
- Show startup configuration file (saved into the NVRAM): `show startup-configuration`
- Show running configuration file (saved into the RAM): `show running-configuration`
- To save the actual configuration in the NVRAM: `copy running-config startup-config`
- Reload the startup configuration file from NVRAM: `copy startup-config running-config`
- Serial Interface Configuration:

    - `interface Serial 0/0`
    - `ip address ADDRESS NETMASK`
    - `clock rate 56000` (only on the side responsible for the clock)
    - `no shutdown`
- Ethernet Interface Configuration:

    - `interface FastEthernet0/0`
    - `ip address ADDRESS NETMASK`
    - `no shutdown`   
- Set Interface Description:

    - `interface Serial 0/0` (also with `FastEthernet X/X` of course)
    - `description DESCRIPTION`
- Configure a static route:

    - `ip route DEST_IP_ADDR NETMASK OUT_INTERFACE/NEXT_HOP_ROUTER`
    - example: `ip route 10.0.0.0 255.0.0.0 192.168.0.253`
- Increase the Administrative Distance (1 by default):

    - `ip route DEST_IP_ADDR NETMASK OUT_INTERFACE/NEXT_HOP_ROUTER AD`
    - example: `ip route 10.0.0.0 255.0.0.0 192.168.0.253 2`

### RIPv1

- Enable RIP: `router rip`
- Define the interfaces running: `network ADDRESS`
- Show info about protocols running`show ip protocols`
- Set a router as border router: `default-information originate`
- Distribute static routes: `redistribute static`
- Avoid sending RIP messages through a specific interface (and so into a network): `Passive-Interface Fa0/0`

### RIPv2

- Enable RIPv2: `router rip`, `version 2`
- Deactivate network auo-summarization: `no auto-summary`
- Set a router as border router: `default-information originate`
- Distribute static routes: `redistribute static`

### OSPF

- Enable OSPF: `router ospf ID` (use `1` as ID)
- Interfaces on which enable OSPF: `network NETWORK_ADDRESS WILDCARD_MASK area AREA_NUMBER`
- Set a router as border router: `default-information originate`
- Distribute static routes: `redistribute static`
- Change OSPF link cost:

    - `interface Serial 0/0`
    - `ip ospf cost COST`

### DHCP

- Start DHCP configuration: `ip dhcp pool POOL_NAME`
- Definition of the address pool to be assigned dinamically: `network NETWORK_ADDRESS NETMASK`
- Exclude addresses to be dinamically assigned: `ip dhcp excluded-address IPADDRESS(ES)`
- Configure default router: `default-router IP_ADDRESS`
- Configure DNS server: `dns-server IP_ADDRESS`

### NAT

- Set inside NAT: `ip nat inside`
- Set outside NAT: `ip nat outside`
- Static NAT configuration (used for servers): `ip nat inside source static PRIVATE_ADDRESS PUBLIC_ADDRESS`
- Dynamic NAT configuration (pool of IP addresses):

     - Private IP addresses definition: `access-list ACL_NUMBER permit SOURCE_ADDRESS WILDCARD`
     - Pool of public IP addresses: `ip nat pool POOL_NAME START_IP_ADDRESS END_IP_ADDRESS netmask NETMASK`
     - Translation rule: `ip nat inside source list ACL_NUMBER pool POOL_NAME`
- Dynamic NAT configuration (overload): 
     
     - Private IP addresses definition: `access-list ACL_NUMBER permit SOURCE_ADDRESS WILDCARD`
     - `ip nat inside source list ACL_NUMBER interface INTERFACE overload`

### VLAN

- Configure a VLAN in a switch: `vlan X`
- Assign a name to a VLAN: `name NAME`
- Assign an IP address to the switch: 

    - `interface vlan 99`
    - `ip address IP_ADDRESS NETMASK`
    - `no shutdown`
- Configure an interface as an access port:

    - `interface Fa X/Y`
    - `switchport mode access`
    - `switchport access vlan X`
- Configure an interface as a trunk port:

    - `interface Fa X/Y`
    - `switchport mode trunk`
    - `switchport trunk native vlan 99`
- Allow only a subset of VLANs to access a trunk port: `switchport trunk allowed vlan X`
- List all the VLANs configured and associated *access* interfaces: `show vlan brief`
- Check the mode of an interface: `show interface Fa X/Y switchport`
- Assign a password for the Telnet access to a **switch**: `line vty 0 15`, `password PASSWORD`, `login`
- Assign a password for the **configurable** Telnet access to a **switch**: 

    - `line vty 0 15`, `password PASSWORD`, `login`
    - `enable password PASSWORD`

### InterVLAN routing

##### Traditional way

   - Add as many (copper-straight) links on router to the switch as many VLAN we would like to connect. 
   - Assign an IP address to the router interfaces (belonging to the VLAN network).
   - Set as access mode the new interfaces on the switch:

        - `switchport mode access`
        - `switchport access vlan X`
   - Assign the IP default gateway on the PCs (the router IP address belonging to the same VLAN).

##### The smart way

   - Add one (copper-straight) link on router to the switch
   - Configure Router interfaces:
        
        - `interface Fa X/Y.ZZ` (where `ZZ` is the ID of the VLAN)
        - `encapsulation dot1Q ZZ`
        - `ip address ADDRESS NETMASK`
        - `no shutdown`
   - Turn up the physical interface:
        
        - `interface Fa X/Y`
        - `no shutdown`
   - Configure the switch interface with trunk mode:

        - `interface Fa X/Y`
        - `switchport mode trunk`

- Assign a native vlan to trunk interface: `switchport trunk native vlan 99`
- To show ARP cache: `arp -a`
- To delete ARP cache: `arp -d`

### ACL

#### Standard ACL

- `access-list <0-99> <deny | permit> IP WILDCARD_MASK`

- Verifying the ACL:
    
    - `show ip interface`
    - `show access-list X`
    - `show runnning-config`
- Removing an access-list: `no access-list X`
- `X` always between 0 and 99!
- Block telnet access with a standard ACL:

    - Write the standard ACL inserting the proper rules.
    - `line vty 0 4` (remember `4` is for router)
    - `login`
    - `password PASSWORD`
    - `access-class NUMBER in`

#### Extended ACL

- It's better to type `access-list ?` in the CLI and follow the suggestions.
- `X` always between 100 and 199!

#### Named ACL

- To define a named ACL: `ip access-list {extended|standard} NAME`
- Each rule is defined with a number associated (`10`, `20`, `30`...)
- It's possible to remove or add a specific rule in any position.
- To add a rule in a specific point of the rules list: `NUMBER RULE`, e.g. `25 udp deny any any`

### LAN Security

### VPN

- Configure a vpn tunnel on one router side:

    - `interface Tunnel X`
    - `tunnel mode gre ip`
    - `ip address TUNNEL_IP NETMASK` (`NETMASK` = `255.255.255.252`)
    - `tunnel source INTERFACE`
    - `tunnel destination IP_ADDRESS` (`IP_ADDRESS` is the address of the other router)
    - `ip route LAN_NETWORK LAN_NETMASK IP_ADDRESS` (`IP_ADDRESS` is the address of the other router)

- Repeat this sequence on the other router. 

### Useful tips

- Avoid CLI stops when a wrong command is typed: `no ip domain-lookup`.
- If you're having trouble with interVLAN routing, try to delete the ARP cache (from PC CLI): `arp -d`.
- The standard ACLs should be put as close as possible to the destination.
- The extended ACLs should be put as close as possible to the source.
