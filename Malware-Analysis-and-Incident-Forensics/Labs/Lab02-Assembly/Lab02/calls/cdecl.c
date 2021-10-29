/* Instructions
 *
 * Open CygWin and move to the folder containing the code:
 * cd /cygdrive/c/Users/student/Desktop/lab02/calls
 * 
 * Then compile and strip it using MinGW (32-bit):
 * mingw32-gcc.exe cdecl.c -masm=intel -s -o cdecl.exe
 * 
 */
#include <stdio.h>

int expected;

int mysum(int a, int b) {
    // the C compiler will insert prologue (push ebp;
    // mov ebp, esp) and epilogue (leave; ret)
   __asm__(
    	".intel_syntax noprefix\n"
		"mov eax, [ebp+8]\n"
        "mov edx, [ebp+12]\n"
        "add eax, edx"
	);
}

int test() {
    // we ask the compiler to place variables a and b in
    // registers instead of performing stack allocation
    register int a, b;
    a = 32, b = 60;
    int result = mysum(a,b);
    expected = a + b;
    return result;
}

int main() {
    int result = test();
    printf("Result: %d\n", result);
    printf("Expected: %d\n", expected);
    return 0;
}