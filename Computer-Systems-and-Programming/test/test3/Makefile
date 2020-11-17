filename = test3

run: $(filename).o
	gcc -lm $(filename).o
	./a.out

$(filename).o: 
	gcc -c $(filename).c -lm

clean:
	rm -rf *.o a.out