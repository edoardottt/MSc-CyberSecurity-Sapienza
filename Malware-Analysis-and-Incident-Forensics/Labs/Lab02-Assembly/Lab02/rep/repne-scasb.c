#include <stdio.h>

asm(
    ".intel_syntax\n"
    ".global _my_memchr\n"
    "_my_memchr:\n"
    "push ebp\n"
    "mov ebp, esp\n"
    "push edi\n"
    "mov edi, [ebp+8]\n"
    "mov al, [ebp+12]\n"
    "mov ecx, [ebp+16]\n"
    "repne scasb\n"
    "test ecx, ecx\n"
    "jnz FOUND\n"
    "mov eax, 0\n"
    "jmp EXIT\n"
    "FOUND: dec edi\n" 
    "mov eax, edi\n"
    "EXIT: pop edi\n"
    "leave\n"
    "ret\n"
    ".att_syntax"
);

char* my_memchr(char* buf, char value, int n);

int main() {
    char buf[] = {'a', 'b', 'c', 'd', 'e', 'f', '\0'};
    printf("String: %s\n", buf);
    char* p = my_memchr(buf, 'c', 6);
    if (p != NULL) printf("Found ['c']: %s\n", p);
    p = my_memchr(buf, 'g', 6);
    if (p == NULL) printf("Not found ['g']\n");
    return 0;
}