#include <stdio.h>

asm(
    ".intel_syntax\n"
    ".global _my_memcmp\n"
    "_my_memcmp:\n"
    "push ebp\n"
    "mov ebp, esp\n"
    "push edi\n"
    "push esi\n"
    "mov esi, [ebp+8]\n"
    "mov edi, [ebp+12]\n"
    "mov ecx, [ebp+16]\n"
    "repe cmpsb\n"
    "jne DIFF\n"
    "mov eax, 0\n"
    "jmp EXIT\n"
    "DIFF: mov eax, 1\n"
    "EXIT: pop esi\n"
    "pop edi\n"
    "leave\n"
    "ret\n"
    ".att_syntax"
);

int my_memcmp(char* buf1, char* buf2, int n);

int main() {
    char buf1[] = {'t', 'e', 's', 't'};
    char buf2[] = {'T', 'e', 's', 't'};
    char buf3[] = {'t', 'e', 's', 'T'};
    printf("%d\n", my_memcmp(buf1, buf2, 4));
    printf("%d\n", my_memcmp(buf1, buf3, 4));
    printf("%d\n", my_memcmp(buf1, buf1, 4));
    return 0;
}