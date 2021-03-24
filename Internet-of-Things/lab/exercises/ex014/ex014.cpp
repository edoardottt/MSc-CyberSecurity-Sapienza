//passing parameters by reference
#include <iostream>
using namespace std;
void duplicate(int &a, int &b)
{
    a *= 2;
    b *= 3;
}
int main()
{
    int x = 1, y = 3;
    duplicate(x, y);
    cout << "x=" << x << ", y=" << y << "\n";
    return 0;
}