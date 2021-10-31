#include <stdlib.h>
#include <string.h>
#include <stdio.h>

void func1(char *src) {
    char *dst = malloc(sizeof(src) * sizeof(char));
    strlcpy(dst, src, sizeof(src) * sizeof(char));
    dst[sizeof(dst)-1] = 0;
}

void func2(int fd) {
    char *buf;
    size_t len;
    read(fd, &len, sizeof(len)); //flawfinder: ignore

    if (len > 1024) return;
    buf = malloc(len+1); 
    read(fd, buf, len); //flawfinder: ignore
    buf[len] = '\0';
}

void func3() {  
    char *buffer = malloc(1024 * sizeof(char));
    printf("Please enter your user id :");
    fgets(buffer, 1024, stdin);
    if (!isalpha(buffer[0])) {
        char *errormsg = malloc(1044 * sizeof(char));
        strlcpy(errormsg, buffer, 1024);
        strlcat(errormsg, " is not  a valid ID", 1044);
    }
}

void func4(char *foo) {
    char *buffer = (char *)malloc(10 * sizeof(char));
    strlcpy(buffer, foo, 10);
}

int main() {
    int y=9;
    int a[10];
    func4("fooooooooooooooooooooooooooooooooooooooooooooooooooo");

    try {
        func3();
    } catch(char *message) {
        fprintf(stderr, "%s", message);
    }

    fprintf(aFile, "%s", "hello world");

    while (y>=0) {
        a[y]=y;
        y=y-1;
    }
    return 0;
}