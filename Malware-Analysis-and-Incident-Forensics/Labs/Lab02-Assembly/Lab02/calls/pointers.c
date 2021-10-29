/* Instructions
 *
 * Open CygWin and move to the folder containing the code:
 * cd /cygdrive/c/Users/student/Desktop/lab02/calls
 * 
 * Then compile and strip it using MinGW (32-bit):
 * mingw32-gcc.exe pointers.c -o pointers.exe
 * 
 */
#include <stdio.h>

int glob;

void mysum(int a, int b, int* result) {
    *result = a + b;
}

int main() {
    int result;
    int a = 20, b = 30;
    mysum(a, b, &result);
    mysum(b, a, &glob);
    printf("Pointer addresses for result and glob: %x %x\n", &result, &glob);
    printf("Computed values: %d %d\n", result, glob);
    return 0;
}