printf "%s" "Waiting for OSPF to propagate ..."
while ! ping -c 1 8.8.8.8 &> /dev/null
do
    printf "%c" "."
    sleep 1
done
printf "\n%s\n"  "Done!"
