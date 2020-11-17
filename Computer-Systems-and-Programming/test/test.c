#include <stdio.h>
#include <stdlib.h>

#define ROWS 2
#define COLS 3

void main() {
	/*
	int array[ROWS][COLS];
	for (int j=0; j < ROWS; j++) {
		for (int i = 0; i < COLS; i++) {
			array[j][i] = j + i;
		}
	}

	for (int j = 0; j < ROWS; j++) {
		for (int i = 0; i < COLS; i++) {
		 	printf("%d\n",array[j][i]);
		}
	}
	*/
	int rollNum[30][4];
	int (*p)[4] = rollNum;
	int *q[5];	
	printf("%ld\n", sizeof(rollNum)/sizeof(int));
}
