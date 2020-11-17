#include <stdio.h>
#include <stdlib.h>

void main() {

    char strInput[500];
    char strOutput[500];
    FILE * from, *to;
    char * line = NULL;
    size_t len = 0;
    ssize_t read;

    /*
    * Read input file
    */
    printf("Enter input file:");
    scanf("%s", strInput);

    /*
	 * Check input
	 */
	if ((from = fopen(strInput, "r")) == NULL) {
		perror("ERROR");
		exit(1);
	}

    /*
    * Read output file
    */
    printf("Enter output file:");
    scanf("%s", strOutput);

    /*
	 * Check output
	 */
	if ((from = fopen(strOutput, "w")) == NULL) {
		perror("ERROR");
		exit(1);
	}

    // Print inputs
    printf("You entered: %s %p\n", strInput, from);
    printf("You entered: %s %p\n", strOutput, to);

    // MAIN procedure
    from = NULL;
    to = NULL;
    // here

    if (from != NULL) fclose(from);
    if (to != NULL)  fclose(to);
}