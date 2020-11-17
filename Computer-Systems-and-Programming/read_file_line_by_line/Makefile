read.c: read.o
	gcc read.o

read.o:
	gcc -c read.c

run: read.c read.o 
	./a.out

clean:
	rm -rf *.o *.out
