# Network Infrastructures Q&A

#### DNS and recursive queries

DNS is an acronym that stands for Domain Name System.  
The main scope of DNS is to resolve aliases/domains with IP addresses.  
When I would like to get some resources from Google.com I don't know where Google.com is located on Internet, the thing I can do is query a DNS to give me the IP address of Google.com.  
DNS is a hierarchical system, so we have dns servers with different 'levels'.  
The domain name space consists of a tree data structure. Each node or leaf in the tree has a label and zero or more resource records (RR), which hold information associated with the domain name.  
The root level (top-level) is the most important (.com, .it, .eu) and it delegates to second-level servers the subdomains (google.com, amazon.com) and so on...  
There are two types of dsn query: an iterative and recursive one.  
In the iterative scenario a client wants to get the IP address of maps.google.com. It has to query the top-level domain .com, this one will answer 'IDK, asks to Google.com'; so it has to perform another request to Google.com asking same question, finally Google.com will gives you the resource record.  
In the second one, the recursive, the client will perform just a single request, the top-level domain server then will ask it to Google.com, it will wait the response, and It will send you the response back. This disgregation of data and processes is called 'delegation'.  
The most common types of records stored in the DNS database are for Start of Authority (SOA), IP addresses (A and AAAA), SMTP mail exchangers (MX), name servers (NS), pointers for reverse DNS lookups (PTR), and domain name aliases (CNAME).

#### How public key and private key authentication works in ssh? (Make an example)

SSH is an acronym standing for Secure SHell. It allows you to connect remotely servers with a shell exchanging data on a secure channel.  
The ssh server has to run a ssh server (daemon), while we must have a ssh client on our machine.  
We have two ways to authenticate ourselves to the target server:  

 1. Username/password  
 2. Private Key  
 
Regarding the first type, simply the client has to connect itself to the server (`ssh user@target_ip`) and it has to enter the password (sent encrypted of course).  
Because of botnets / malicious users it's good practice to use the second method.  
With the asymmetric authentication we need to deal first with private and public keys. To authenticate with keys I should have a (matching) pair of key, specifically a public key (cryptographically secure) which I can share with anyone; and a private key that I have to guard.  
My public key has to be inside the `~/.ssh` folder of the server in the file `authorized_keys`. This file contains a list of public keys, one-per-line, that are authorized to log into this account.  
If I want to connect then, I just have to execute `ssh user@target_ip` and then ssh will use my private key to authorize myself.  

#### Which are the fields of an IP Routing Table and how these are used to route a packet toward a destination (make an example).

Example routing table contents:  
	
| Network destination | Netmask | Gateway     | Interface     | Metric |
|---------------------|---------|-------------|---------------|--------|
| 0.0.0.0             | 0.0.0.0 | 192.168.0.1 | 192.168.0.100 | 10     |

The columns Network destination and Netmask together describe the Network identifier as mentioned earlier.  
For example, destination 192.168.0.0 and netmask 255.255.255.0 can be written as 192.168.0.0/24.  
The Gateway column contains the same information as the Next hop, i.e. it points to the gateway through which the network can be reached.  
The Interface indicates what locally available interface is responsible for reaching the gateway. In this example, gateway 192.168.0.1 (the internet router) can be reached through the local network card with address 192.168.0.100.  
Finally, the Metric indicates the associated cost of using the indicated route.  
This is useful for determining the efficiency of a certain route from two points in a network.  
In this example, it is more efficient to communicate with the computer itself through the use of address 127.0.0.1 (called “localhost”) than it would be through 192.168.0.100 (the IP address of the local network card).  

								(WikiPedia)

#### Key features of LTE and LTE-A

LTE has a number of features that enable the operation of the instant conditions of radio channel with a very high efficient. The result is a significant increase in system capacity by optimizing the required power.  
In return the simulation of such systems gets more difficult. It requires a different approach to that used in other mobile systems to address the planning of such networks.  
The main characteristics of LTE are:

- Using of OFDMA (Orthogonal Frequency Division Multiplexing Access) in the downlink. This technology allows multiple access by dividing channel into a set of orthogonal subcarriers that are distributed into groups depending on the needs of each user.
- Using of SC-FDMA (Single-Carrier OFDMA) in the uplink. A disadvantage of OFDMA is the existence of significant variations of power in output signals. It is therefore necessary to use especially linear amplifiers, which have a low efficiency. Since the power consumption is especially important for the uplink, SC-FDMA is used, as a more efficient alternative in terms of power that preserves most of the OFDMA advantages.
- Spectrum flexibility. One of the key features of LTE. The existence of different regulatory frameworks depending on the geographical area of ​​deployment, together with the co-existence with other operators or other services and systems, make it necessary the flexibility in the bandwidth used within the band of deployment.
	- The use of multiple antennas.
	- MIMO trasmission

Ideally, any bandwidth can be used within this band (in steps of 180 kHz, corresponding to the bandwidth of a PRB).  
LTE defines possible nominal bandwidths of 1.4 MHz, 3 MHz, 5 MHz, 10 MHz, 15 MHz and 20 MHz.  
LTE is also capable of operating in both bands paired (FDD) and unpaired (TDD).

The main characteristics of LTE-A are:

- Carrier aggregation
- Enhanced MIMO for LTE-A
- ?

#### Traffic engineering in PON for downstream and upstream

The PON technology uses **P**assive **O**ptical **S**plitters to split the data flowing through the fiber and these elements propagate data to different branches.  
![POS](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/pon1.png)  
These devices can split the light to different endpoints. The *passive* here means the fact that they are not actively doing something, but just *copying* the data.  
Combining pos we can achieve a kind of multiplexer.  
Every time the signal pass through a pos it reduces its power of 3dB, but this is not important given the fact we are using the fiber; anyway the loss can't be huge because we want to cover big distances.  
We have three differents types of architectures:
	
- multiple fiber cables from Central Office to single users (uncomfortable but high speed).  
- single cable from C.O to the curb and then multiple cables from curb to single users.  
- single cable splitted with POS to every single user (cheaper, but we have loss of privacy).

Talking about downstream and upstream:
		
- Downstream:  
	Network configuration point to  multipoint, we don't have problems in downstream because **O**ptical **L**ine **T**erminal manages all the traffic. The signal is propagated to all the end users (Privacy problem)
- Upstream:  
	In the upstream all the **O**ptical **N**etwork **U**sers use different cables until when they reach the POS, when all the users use the same cable.
	The *topology* is important, if I use a **Ring** Network topology I can use CSMA/CD.  
	In a general topology I can use **T**ime **D**ivision **M**ultiple **A**ccess.  
	In this case the OLT perform a synchronization of end-devices and it can manage all the timeslots for them.  
	Another problem is the different distances between users and POS.
	![Attenuation](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/pon2.png)
	
	The solution is **Automatic gain control**, so OLT *probes* the users and record the Attenuation level.  
	Then the user just send the data with the signal strength suggested by OLT. 

#### Discuss different architectures of FTTX and discuss the differences

Fiber in the loop: Various proposed solutions; they are the results from the trade-off between production cost given to copper substitution (fiber installation) and economic income given to the increment of performance.  
The name of the solutions is determined by the **EOI**'s location (Electro-Optical Interface).

![fttx](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/fttx.png)

#### Differences between direct and indirect routing in mobile IP

- Indirected routing: 
	The communication from the corrispondent to the mobile device goes through the home agent e then  forwarded to the visited network where the device is.

- Direct routing: 
	The correspondent obtains the care-of-address of the mobile device, e
	directly establishes communication with it.
	
# TO BE FINISHED

#### Describe how it works and give an example of use of the Local Port Forwarding.

In computer networking, port forwarding or port mapping is an application of network address translation (NAT) that redirects a communication request from one address and port number combination to another while the packets are traversing a network gateway, such as a router or firewall.  
This technique is most commonly used to make services on a host residing on a protected or masqueraded (internal) network available to hosts on the opposite side of the gateway (external network), by remapping the destination IP address and port number of the communication to an internal host.

									(Wikipedia)

Command: `ssh -L local_port:destination_server_ip:remote_port ssh_server_hostname`  
Example: `ssh -L 80:intra.example.com:80 gw.example.com`

#### Which are the key differences of the old use of the copper wire to provide data (analog voice band modem) and the digital one.

#### PON architecture and how they work

#### Netfilter and how is it used in firewall

#### VDSL vectoring

#### Difference between IP static routing and dynamic routing

#### In the computation of the capacity that a channel can provide both the effects of the bandwidth and of the SNR are present. Discuss how there have an impact and how they can be managed to improve the channel capacity.

#### How the frequency band is used in the ADSL and how this is reflected in the ADSL architecture.

#### Describe the possible noise effects in a digital signal and how they are combatted

#### Describe with an example how traceroute can discover the path taken from a packet toward a particular destination.

#### What is MIMO and how it is used in the LTE and future generations cellular systems (5G)

#### Describe how the modulation of the ADSL allows to use, in an efficient way, copper cables.

#### Describe the functions that are performed in the different functional areas of a network and the main network topologies used in that areas.

#### Provide a description of the fragmentation service in IPv6, explaining the pros and cons of the used approach.

#### Describe the security services provided by the Encapsulating Security Payload protocol, specifying the differences between the case in which is used in transport or in tunnel mode.

#### With reference to the SDN architecture, provide a description of the data-control plane interaction generated by an application that provides the NAT service.
