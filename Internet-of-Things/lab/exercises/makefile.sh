#!/bin/bash
read -p "Enter filename (without cpp): " filename
if [ -d "$filename" ]; then
    echo "$filename exists."
    exit 1
fi
mkdir $filename
touch $filename/$filename.cpp
touch $filename/Makefile
cat > $filename/Makefile <<EOL
all: build

build:
	 g++ -std=c++0x ${filename}.cpp -o ${filename}
     
clean:
	 @rm -rf ${filename}
EOL
echo Done.