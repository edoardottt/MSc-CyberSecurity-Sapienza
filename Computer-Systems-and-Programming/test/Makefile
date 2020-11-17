filename = test

run: $(filename).o
	gcc $(filename).o
	./a.out

$(filename).o: $(filename).c
	gcc -c $(filename).c

a.out: $(filename).o
	gcc $(filename).o

clean:
	rm -rf *.o  *.out