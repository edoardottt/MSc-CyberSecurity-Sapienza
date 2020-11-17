run: test4.o test4
	./a.out

test4.o:
	gcc -c test4.c

test4: test4.o
	gcc test4.o

clean:
	r -rf *.o *.out
