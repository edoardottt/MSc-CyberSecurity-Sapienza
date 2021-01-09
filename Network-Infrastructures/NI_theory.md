# Network Infrastructures Q&A

(16/23 completed)

### DNS and recursive queries

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

### How public key and private key authentication works in ssh? (Make an example)

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

### Which are the fields of an IP Routing Table and how these are used to route a packet toward a destination (make an example).

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
In this example, it is more efficient to communicate with the computer itself through the use of address 127.0.0.1 (called “localhost”) than it would be through 192.168.0.100 (the IP address of the local network card). (WikiPedia)

### Key features of LTE and LTE-A

LTE has a number of features that enable the operation of the instant conditions of radio channel with a very high efficient. The result is a significant increase in system capacity by optimizing the required power.  
In return the simulation of such systems gets more difficult. It requires a different approach to that used in other mobile systems to address the planning of such networks.  

The **Key Features of LTE** are:

- Adaptive Modulation & Coding (AMC)
- Hybrid ARQ (HARQ)
- Spectrum flexibility. The existence of different regulatory frameworks depending on the geographical area of deployment, together with the co-existence with other operators or other services and systems, make it necessary the flexibility in the bandwidth used within the band of deployment.

	- Using of OFDMA (Orthogonal Frequency Division Multiplexing Access) in the downlink. This technology allows multiple access by dividing channel into a set of orthogonal subcarriers that are distributed into groups depending on the needs of each user.
	- Using of SC-FDMA (Single-Carrier OFDMA) in the uplink. A disadvantage of OFDMA is the existence of significant variations of power in output signals. It is therefore necessary to use especially linear amplifiers, which have a low efficiency. Since the power consumption is especially important for the uplink, SC-FDMA is used, as a more efficient alternative in terms of power that preserves most of the OFDMA advantages.  
- MIMO trasmission

Ideally, any bandwidth can be used within this band (in steps of 180 kHz, corresponding to the bandwidth of a PRB).  
LTE defines possible nominal bandwidths of 1.4 MHz, 3 MHz, 5 MHz, 10 MHz, 15 MHz and 20 MHz.  
LTE is also capable of operating in both bands paired (FDD) and unpaired (TDD).

The **Key Features of LTE-A** are:

- Carrier aggregation
- Enhanced MIMO for LTE-A
- Coordinated MIMO & CoMP
- Relays
- Machine to Machine (M2M) Communication
- Heterogenous Network

### Traffic engineering in PON for downstream and upstream
		
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

### Discuss different architectures of FTTX and discuss the differences

Fiber in the loop: Various proposed solutions; they are the results from the trade-off between production cost given to copper substitution (fiber installation) and economic income given to the increment of performance.  
The name of the solutions is determined by the **EOI**'s location (Electro-Optical Interface).

![fttx](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/fttx.png)

### Differences between direct and indirect routing in mobile IP

- Indirected routing: 
	The communication from the corrispondent to the mobile device goes through the home agent e then  forwarded to the visited network where the device is.
	
![](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/ind-routing.png)

- Direct routing: 
	The correspondent obtains the care-of-address of the mobile device, e
	directly establishes communication with it.
	
![](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/dir-routing.png)

### Describe how it works and give an example of use of the Local Port Forwarding.

In computer networking, port forwarding or port mapping is an application of network address translation (NAT) that redirects a communication request from one address and port number combination to another while the packets are traversing a network gateway, such as a router or firewall.  
This technique is most commonly used to make services on a host residing on a protected or masqueraded (internal) network available to hosts on the opposite side of the gateway (external network), by remapping the destination IP address and port number of the communication to an internal host. (Wikipedia)

Command: `ssh -L local_port:destination_server_ip:remote_port ssh_server_hostname`  
Example: `ssh -L 80:intra.example.com:80 gw.example.com`

### PON architecture and how they work

The PON technology uses **P**assive **O**ptical **S**plitters to split the data flowing through the fiber and these elements propagate data to different branches.  
![POS](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/pon1.png)  
These devices can split the light to different endpoints. The *passive* here means the fact that they are not actively doing something, but just *copying* the data.  
Combining pos we can achieve a kind of multiplexer.  
Every time the signal pass through a pos it reduces its power of 3dB, but this is not important given the fact we are using the fiber; anyway the loss can't be huge because we want to cover big distances.  
We have three differents types of architectures:
	
- multiple fiber cables from Central Office to single users (uncomfortable but high speed).  
- single cable from C.O to the curb and then multiple cables from curb to single users.  
- single cable splitted with POS to every single user (cheaper, but we have loss of privacy).

### VDSL vectoring

Crosstalk cancelling by injecting an “anti-signal” on each crosstalk-impaired line  

- Requires full synchronization over the full vectored system
- All data samples are shared between all the lines
- Requires calculation of the “anti-signals”
- Requires a crosstalk estimating mechanism to derive the crosstalk coefficients

![VDSL](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/vdsl.png)

### Describe how the modulation of the ADSL allows to use, in an efficient way, copper cables.

We use a frequency band for the upstream and one for the downstrwam, on those we transmit the digital signal.  
With ADSL we have two different modulation standards: **CAP**(Carrier-less Amplitude/Phase modulation) and **DMT** (Discrete Multi-Tone).  
- **CAP**
It's a version of QAM, where incoming data are modulated with an unique carrier and then they are transmitted on phone line.  
The *carrier* is the principal frequency where the modulation is applied. The carrier frequency is suppressed before transmission (contains no information and therefore can be reconstructed in the receiver), hence the name “carrier-less” of this scheme of modulation.  
In this case I don't need to send the principal sinusoid, but it's not a good modulation scheme.

- **DMT**
Instead of using the whole frequency spectrum with only one signal, we divide the band in little pieces.  
Various channels are created, everyone with 4Khz -> whole band of ~ 1.1 Mhz.  
Discrete carriers are used on every sub-band.  
Then these sub-bands are used to independently transmit data in every sub-channels.  
This allows us to use efficiently sub-bands with high SNR, while we don't use too much unlucky (low SNR, attenuation) sub-bands.  
With this scheme we can have 1.5 Mbps on upstream and 15 Mbps on downstream.

![DMT](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/dmt.png)

### How the frequency band is used in the ADSL and how this is reflected in the ADSL architecture.

ADSL standard supports 8 Mbps in downstream with a typical distance from C.O. of 2 Km.  
ADSL technology is based on data-over-voice approach, in which the frequencies used for data transmission is above the POTS and/or ISDN basic access channel.  
The available bandwidth is divided up into upstream and downstream.  
The region between 4kHz and 40kHz is called the guard band which separates the POTS from ADSL frequencies.  
There are two methods of creating the separate channels:

- Frequency Division Multiplexing (FDM). FDM assigns one band for upstream and another band for downstream. The two channels are further divided by Time Division Multiplexing (TDM).

- Echo Cancellation. The upstream and downstream channels overlap and are separated by using echo cancellation techniques, Echo cancellation is necessary to minimise the reflection of signals that occurs in the common channel.  
As we have described above, the downstream is the part of the data transmitted by the C.O. towards the user.  
If I transmit the downstream in the same band as the upstream, the C.O. it can erase its own transmission.  
The C.O. it knows the transmission it sends (downstream) and it knows the one it receives (the upstream), and consequently can remove the interference generated between these two streams. This process is called echo cancellation.  
In practice, to increase the downstream data rate, the C.O. delete the upstream part (it does not send data).

![ADSL-ARCH](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/adsl-arch.png)

### Difference between IP static routing and dynamic routing

- **Static Routing**

Static routing is a form of routing that occurs when a router uses a manually-configured routing entry, rather than information from dynamic routing traffic. In many cases, static routes are manually configured by a network administrator by adding in entries into a routing table, though this may not always be the case. Unlike dynamic routing, static routes are fixed and do not change if the network is changed or reconfigured. Static routing and dynamic routing are not mutually exclusive. Both dynamic routing and static routing are usually used on a router to maximise routing efficiency and to provide backups in the event that dynamic routing information fails to be exchanged. (Wikipedia)

- **Dynamic Routing**

Dynamic routing, also called adaptive routing, is a process where a router can forward data via a different route or given destination based on the current conditions of the communication circuits within a system.  
The term is most commonly associated with data networking to describe the capability of a network to 'route around' damage, such as loss of a node or a connection between nodes, so long as other path choices are available.  
Dynamic routing allows as many routes as possible to remain valid in response to the change.  
There are several protocols that can be used for dynamic routing.  
Routing Information Protocol (RIP) is a distance-vector routing protocols that prevents routing loops by implementing a limit on the number of hops allowed in a path from source to destination.  
Open Shortest Path First (OSPF) uses a link state routing (LSR) algorithm and falls into the group of interior gateway protocols (IGPs).  
Other commonly used dynamic routing protocols are the RIPv2 and the Border Gateway Protocol (BGP).  
OSPF detects changes in the topology, such as link failures, and converges on a new loop-free routing structure within seconds.  
It implements Dijkstra's algorithm, also known as the shortest path first (SPF) algorithm.  
OSPF calculate the shortest route to a destination through the network based on an algorithm. The first routing protocol that was widely implemented, the Routing Information Protocol (RIP), calculated the shortest route based on hops, that is the number of routers that an IP packet had to traverse to reach the destination host. RIP successfully implemented dynamic routing, where routing tables change if the network topology changes. But RIP did not adapt its routing according to changing network conditions, such as data-transfer rate. Demand grew for a dynamic routing protocol that could calculate the fastest route to a destination. OSPF was developed so that the shortest path through a network was calculated based on the cost of the route, taking into account bandwidth, delay and load. Therefore, OSPF undertakes route cost calculation on the basis of link-cost parameters, which can be weighted by the administrator. OSPF was quickly adopted because it became known for reliably calculating routes through large and complex local area networks.  
An OSPF network can be structured, or subdivided, into routing areas to simplify administration and optimize traffic and resource utilization. Areas are identified by 32-bit numbers, expressed either simply in decimal, or often in the same dot-decimal notation used for IPv4 addresses. By convention, area 0 (zero), or 0.0.0.0, represents the core or backbone area of an OSPF network.

### Describe the possible noise effects in a digital signal and how they are combatted

The available bandwidth is divided up into upstream and downstream.  
There are two methods of creating the separate channels, if we use:  
- **Echo Cancellation**. The upstream and downstream channels overlap and are separated by using echo cancellation techniques, Echo cancellation is necessary to minimise the reflection of signals that occurs in the common channel.  
As we have described above, the downstream is the part of the data transmitted by the C.O. towards the user.  
If I transmit the downstream in the same band as the upstream, the C.O. it can erase its own transmission.  
The C.O. it knows the transmission it sends (downstream) and it knows the one it receives (the upstream), and consequently can remove the interference generated between these two streams. This process is called echo cancellation.  
In practice, to increase the downstream data rate, the C.O. delete the upstream part (it does not send data).

Another problem is **Cross-Talk**.  
The fact that the downstream and upstream are broadcast simultaneously on the same cable and overlapping each other, causes interference.  
The cables, even if they are different, travel together in the same grouping, called *Binder Group*.  
The quality of the ADSL transmission therefore also depends on the characteristics of the other cables.  
Crosstalk = Electromagnetic interference caused by the bundling in a single cable (binder group) of several pairs.  
In optical communications, this problem does not exist.  
There are two types of crosstalk noises in ADSL:

- Far-End cross-talk (**FEXT**)

	Crosstalk between transmitters and receivers which are both on opposite sides of the cable.  
	The FEXT signal traverses the entire length of the channel.  
	The signal transmitted by one transmitter interferes with the signal transmitted by the other transmitter.  
	If the cable is long, then the interference that is created is low, because the interfering signal arrives attenuated.  

- Near-End cross-talk (**NEXT**)

	Crosstalk between transmitters and receivers placed on the same side of the cable.  
	Considering the same part of the cable, the signal arriving at the receiver, since it comes from further away, is weaker than that sent by the transmitter.  
	So there is a strong interference, which reduces the quality of the received data. It is strong because it happens at a short distance.  
	NEXT is a more critical interference than FEXT.  
	For example, we can have this kind of interference in the C.O .. In that case, the C.O. can exploit the echo cancellation technique and cancel the interfering transmission (because it knows it, being generated by itself).  
	However, if the interference happened at the end user level, it would not be possible to cancel it.  
	For this reason, NEXT is one of the reasons for the frequency division for upstream and downstream in ADSL (i.e. the two bands are not overlapped).  

### Describe the functions that are performed in the different functional areas of a network and the main network topologies used in that areas.

We can see three differents Network Functional Areas: *Access Network*, *Edge Network* and *Core Network* (or *Backbone*).
 
In the **Access Network** there are all the users that want to enter the network, so this part connects subscribers to their immediate provider.  
Some examples are:

- *Fixed Wireless Access*, a network where the communication is done using wireless access, but the devices are fixed.
- *Copper Based*, The copper is the material that was used in the telephone network and it's still used in the XDSL family, so in this case we use this kind of cables to provide the access network from the peipheral part of the nework and the core.
- *Fiber Access*, It's the same as copper, but instead of using copper we use fiber. 
- *Cellular Access*, It's instead mobile by using cellular information to connect the end users to the core.

These four are quite different one in respect to others, for different reasons, the kind of media that they use (copper/wire), the kind of length (short with copper, longer in case of fiber, medium in cellular access and fixed wireless access), the reliability, security, cost, coverage, data rate...  


The **Edge Network**, also referred as **Metropolitan Area**, is composed by devices called *Edge devices*, in the particular case of routers *Edge routers*.  
The role of these devices is becoming important (relatively to access and core) also because we are giving them some capabilities (computing cap.).  
An example of this is the Quality Of Service (**QOS**). It may happen that in a network, mostly in the bigger ones, there is the interest in having different capacities and different services for different users. So, while the core network is a sort of Highway of our data; where we can differentiate the services and  allow or give priority to different users in order to access the core network while this happens at the edge so in the edge we can perfrom control of the informations that happens that cross the network.  
This can be easily done by operate at the edge, we can control the traffic that we inject to the network like also the kind of the operation that is done on this traffic. Also called *Edge Computing*, so when we move some networking processes at the edge we can refer at this networking process as E.C.  

What about technologies used in the areas? In the access part we have may different technologies used, while the core part evolved during the time toward the fiber-based. The access part is composed by Copper-based and Fiber-based.  
Now we want to achieve the full fiber-based network, and this is referred to the Access part because the Core part is already built with fiber.

**Topologies**: 

- The *Backbone* (in general) is mostly composed by using *Rings* (ring has lower cost in respect to a mesh).
- In the *Access* part we have Central office connected to users using a *Star* topology and then a Central Tandem Office (Y) with a sort of hierarchy until reaching the core part.

### Provide a description of the fragmentation service in IPv6, explaining the pros and cons of the used approach.

IP fragmentation is an Internet Protocol (IP) process that breaks packets into smaller pieces (fragments), so that the resulting pieces can pass through a link with a smaller maximum transmission unit (MTU) than the original packet size. The fragments are reassembled by the receiving host.  

In the IPv4 protocol every intermediate nodes can perform fragmentation when it encounters a smaller MTU.  
Unlike IPv4, fragmentation in IPv6 is performed only by source nodes, not by routers along a packet's delivery path.  

   - **pros**: less processing, less delay, overhead reduction
   - **cons**: security threts, need of path MTU discovery procedure
   
IPv6 attempts to minimise the use of fragmentation  

   - minimising the supported MTU size
   - allowing only the hosts to fragment datagrams

IPv6 requess that evey link in the Internet have an MTU of 1280 octets or greater.  

![IPV6-FRAGMENT](https://github.com/edoardottt/MSc-CyberSecurity-Sapienza/blob/main/Network-Infrastructures/images/ipv6-fragment-1.png)

**Reassembly**: PL.orig = PL.first - FL.first - 8 + (8 * FO.last) + FL.last

Security Threats:

- If insufficient fragments are received to complete reassembly of a packet within 60 seconds of the reception of the first arriving fragment of that packet: reassembly must be abandoned, all received fragments are discarded.
- The length of a fragment is not a multiple of 8 octects and the M flag is 1: discard the frame and send an ICMP Parameter problem to the source
- Fragments of a packet are overlapped: reassembly of that packet must be abandoned, all the received fragments must be discarded, no ICMP error messages should be sent.


### Which are the key differences of the old use of the copper wire to provide data (analog voice band modem) and the digital one.

### What is MIMO and how it is used in the LTE and future generations cellular systems (5G)

### In the computation of the capacity that a channel can provide both the effects of the bandwidth and of the SNR are present. Discuss how there have an impact and how they can be managed to improve the channel capacity.

### Describe with an example how traceroute can discover the path taken from a packet toward a particular destination.

### Netfilter and how is it used in firewall

### Describe the security services provided by the Encapsulating Security Payload protocol, specifying the differences between the case in which is used in transport or in tunnel mode.

### With reference to the SDN architecture, provide a description of the data-control plane interaction generated by an application that provides the NAT service.
