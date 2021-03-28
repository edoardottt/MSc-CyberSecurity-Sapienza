A lan with a host, a server, a router. There is also an external lan
for connecting the host machine.
You have to experiment with iptables.


### 1. Playing with iptables

- Start the lab with `kathara lstart`.
- Execute the command `./connect.sh 192.168.10.2/24 external`.
- Then `sudo ip route add 192.168.100.0/24 via 192.168.10.1`.
- Try if this works with `ping 192.168.100.80`. 
- Also visit `http://192.168.100.80/` with your browser.
- Try also with ssh. From pc1 or your shell (outside kathara) `ssh user@192.168.100.80` and enter `password`.
- Start capturing packets with Wireshark.
- Send ome ping requests from your external shell to pc1.
- Apply this rule on pc1 `iptables -A INPUT -p icmp --icmp-type echo-request -j DROP`.
- Then retry to ping the internal host.
- I can't reach pc1 using ping, but I still reach the server (pinging).
- If I go into pc1 and execute `tcpdump -nt` I can see the echo requests arriving, but pc1 doesn't send responses.
- Still while pinging if I remove the firewall rule with `iptables -F`, I can see pc1 restart answering.
- If I change the rule (reapplying it) on pc1 but instead of using `DROP` I use `REJECT` I see from my shell `Destination POrt Unreachable`.
- Now Apply a different rule: `iptables -A INPUT -p tcp --destination-port 80 -j ACCEPT` and `iptables -A INPUT -j REJECT`.
- We can't ping the Server s1, we can reach it using a browser on port 80, but we can't also reach it using ssh.
- Clean the iptables rules with `iptables -F`.
- Remember to clean the route rule with `sudo ip route del 192.168.100.0/24 via 192.168.10.1`.

### 2. Exercise1 - Configure r1 in order to accept only http traffic to S1.
