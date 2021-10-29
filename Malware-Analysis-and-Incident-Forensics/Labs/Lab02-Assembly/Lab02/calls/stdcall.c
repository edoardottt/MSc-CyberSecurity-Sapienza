/* Instructions
 *
 * Open CygWin and move to the folder containing the code:
 * cd /cygdrive/c/Users/student/Desktop/lab02/calls
 * 
 * Then compile and strip it using MinGW (32-bit):
 * mingw32-gcc.exe stdcall.c -s -o stdcall.exe
 * 
 */
#include <stdio.h>

int __attribute__((stdcall)) mysum(int a, int b, int c) {
    return a + b + c;
}

void test() {
    int result = mysum(32, 64, 96);
    int expected = 32 + 64 + 96;
    printf("%d == %d\n", result, expected);
}

int main() {
    test();

    return 0;
}