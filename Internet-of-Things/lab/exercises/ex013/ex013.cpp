//find the sum of digits of a given number
#include <iostream>
using namespace std;
int main()
{
    int num = 0, val = 0, sum = 0;
    cout << "Enter a number: ";
    cin >> val;
    num = val;
    while (num != 0)
    {
        sum += num % 10;
        num /= 10;
    }
    cout << "The sum of the digits of " << val << " is ";
    cout << sum << ".\n ";
    return 0;
}