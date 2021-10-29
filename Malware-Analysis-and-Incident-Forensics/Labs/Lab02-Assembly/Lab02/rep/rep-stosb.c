#include <stdio.h>

asm(
    ".intel_syntax\n"
    ".global _my_memset\n"
    "_my_memset:\n"
    "push ebp\n"
    "mov ebp, esp\n"
    "push edi\n"
    "mov edi, [ebp+8]\n"
    "mov al, [ebp+12]\n"
    "mov ecx, [ebp+16]\n"
    "rep stosb\n"
    "pop edi\n"
    "leave\n"
    "ret\n"
    ".att_syntax"
);

void my_memset(char* dest, char value, int n);

int main() {
    char buf[] = {'t', 'e', 's', 't', '\0'};
    printf("%s\n", buf);
    my_memset(buf, 'a', 4);
    printf("%s\n", buf);
    return 0;
}