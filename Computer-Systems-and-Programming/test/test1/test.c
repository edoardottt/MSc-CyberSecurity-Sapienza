#include <stdio.h>
/*
Add `int max_of_four(int a, int b, int c, int d)` here.
*/

int max_of_four(int a, int b, int c, int d) {
    int max = a;
    int arra[] = {a, b, c, d};
    for (int i = 0; i < 4; i++) {
        if (i != 3) {
            if (arra[i+1] > max) max = arra[i+1];
        }
        else {
            if (arra[i] > max) max = arra[i];
        }
    }
    return max;
}

int main() {
    int a, b, c, d;
    scanf("%d %d %d %d", &a, &b, &c, &d);
    int ans = max_of_four(a, b, c, d);
    printf("%d", ans);
    
    return 0;
}
