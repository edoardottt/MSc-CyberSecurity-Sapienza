#include <stdio.h>

asm(
    ".intel_syntax\n"
    ".global _my_memcpy\n"
    "_my_memcpy:\n"
    "push ebp\n"
    "mov ebp, esp\n"
    "push edi\n"
    "push esi\n"
    "mov edi, [ebp+8]\n"
    "mov esi, [ebp+12]\n"
    "mov ecx, [ebp+16]\n"
    "rep movsb\n"
    "pop esi\n"
    "pop edi\n"
    "leave\n"
    "ret\n"
    ".att_syntax"
);

void my_memcpy(char* dest, char* src, int n);

int main() {
    char buf1[] = {'t', 'e', 's', 't', '\0'};
    char buf2[5] = { 'a', 'b', 'c', 'd', 'e' };
    my_memcpy(buf2, buf1, 5);
    printf("%s\n", buf1);
    printf("%s\n", buf2);
    return 0;
}