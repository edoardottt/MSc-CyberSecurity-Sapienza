/* Instructions
 *
 * Open CygWin and move to the folder containing the code:
 * cd /cygdrive/c/Users/students/Desktop/lab01
 * 
 * Then compile using MinGW (32-bit):
 * mingw32-gcc.exe smc.c -masm=intel -o smc.exe
 * 
 * We use an additional flag to indicate Intel syntax for
 * inline assembly (MinGW uses AT&T by default as in gcc)
 */
#include <stdio.h>
#define WIN32_LEAN_AND_MEAN
#include <windows.h> // for VirtualProtect

void sc() {
    __asm__(
    	".intel_syntax noprefix\n"
		"call $+5\n"
        "pop eax\n"
        "add eax, 30\n" // address of same later instruction
        "mov edx, eax\n"
	    "add edx, 36\n" // bytes to be manipulated - 4
        "cmp eax, edx\n"
        "L1: mov ecx, DWORD PTR [edx]\n"
        "xchg ch, cl\n"
        "ror ecx, 16\n"
        "xchg ch, cl\n"
        "mov DWORD PTR [edx], ecx\n"
        "sub edx, 4\n"
        "cmp edx, eax\n"
        "jge L1\n"
        "nop\n"
        "pop ebp\n"
        "ret\n"
        ".word 0xeb02\n" // try endianness :-)
        ".long 0x53BA1400\n"
        ".long 0x0000BB00\n"
        ".long 0x000000B9\n"
        ".long 0x01000000\n"
        ".long 0xEB0289C1\n"
        ".long 0x8D041989\n"
        ".long 0xCB83EA01\n"
        ".long 0x75F45B5D\n"
        ".long 0x909090C3\n"
	);
}

typedef int(*fptr_t)();

int main(int argc, char* argv[]) {
    DWORD oldP;
    VirtualProtect(sc, 1, PAGE_EXECUTE_READWRITE, &oldP);
    fptr_t f = (fptr_t)sc;
	int a = f();
	printf("Welcome to lecture number %d!\n", a);
	return 0;
}