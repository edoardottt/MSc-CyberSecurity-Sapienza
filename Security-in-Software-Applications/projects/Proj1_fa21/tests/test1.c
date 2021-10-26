#include <stdio.h>
#include <string.h>

void test()
{
    char buffer[19];
    buffer[0] = 'a';
    buffer[1] = 'b';
    buffer[2] = 'c';
    buffer[3] = 'd';
    buffer[4] = 'e';
    buffer[5] = 'f';
    printf("sizeof buffer: %d", sizeof(buffer));
}

int main()
{
    test();
    return(0);
}
