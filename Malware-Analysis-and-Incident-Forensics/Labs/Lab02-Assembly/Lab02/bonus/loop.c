#include <stdio.h>

asm(
    ".intel_syntax\n"
    ".global _my_loop\n"
    "_my_loop:\n"
    "push ebp\n"
    "mov ebp, esp\n"
    "mov ecx, [ebp+8]\n"
    "mov edx, [ebp+12]\n"
    "xor eax, eax\n"
    "L: add eax, edx\n"
    "loop L\n"
    "leave\n"
    "ret\n"
    ".att_syntax"
);

int my_loop(int a, int b);

int loop(int a, int b) {
    int result = 0;
    do {
        result += b;
    } while (--a > 0);
    return result;
}

int main() {
    printf("%d\n", loop(2, 10));
    printf("%d\n", my_loop(2, 10));
    return 0;
}