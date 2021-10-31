#include <stdio.h>
#include <string.h>

void test()
{
    int len;
    read(1263, &len, 1);
    printf("%d\n", len);
}

int main()
{
    test();
    return(0);
}
