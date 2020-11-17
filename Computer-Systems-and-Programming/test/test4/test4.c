#include <stdio.h>
#include <stdlib.h>

void main(int args, char *argv[]) {

	FILE *from, *to;
	int c;
		
	/*
	 * Check input arguments
	 */
	if (args != 3) {
		fprintf(stderr, "[ERROR] - You should insert as input two filenames (where read, the first; and where write, the second)\n");
		exit(1);
	}

	/*
	 * Check first input
	 */
	if ((from = fopen(argv[1], "r")) == NULL) {
		perror("COCCODIO from");
		exit(1);
	}

	/*
	 * Check second input
	 */
	if ((to = fopen(argv[2], "w")) == NULL) {
		perror("COCCODIO to");
		exit(1);	
	}

	/*
	 * Copy char by char
	 */
	while ((c = getc(from)) != EOF) {
		putc(c, to);
	}
	
	fclose(from);
	fclose(to);
	exit(0);
}
