#!/bin/bash
echo "setting up host veth"

sudo ip link del veth1 type veth
sudo ip link add veth1 type veth
sudo ip addr flush veth0
sudo ip addr add $1 dev veth0
if [ -z "$2" ]
then
   echo "Network name not provided: assume only one lan exists..."
   bridge="$(docker network ls | grep -o '^[a-z0-9]*')"
else
   bridge="$(docker network ls | grep $2 | grep -o '^[a-z0-9]*')"
fi

echo "\n attaching veth1 to bridge: kt-${bridge}"

sudo ip link set veth1 master kt-${bridge}

sudo ip link set veth0 up
sudo ip link set veth1 up
ip addr show dev veth1
ip addr show dev veth0

 
