#!/bin/bash
echo "setting up host veth"

sudo ip link del veth1 type veth
sudo ip link add veth1 type veth
sudo ip addr flush veth0
sudo ip addr add $1 dev veth0
bridge="kt-b376438d70f3"

echo "\n attaching veth1 to bridge: ${bridge}"

sudo ip link set veth1 master ${bridge}

sudo ip link set veth0 up
sudo ip link set veth1 up
ip addr show dev veth1
ip addr show dev veth0

 
