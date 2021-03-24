//factorial
#include <iostream>
using namespace std;
long factorial(long a)
{
    if (a > 1)
        return (a * factorial(a - 1));
    else
        return 1;
}
int main()
{
    int number = 0;
    cout << "Enter a number: ";
    cin >> number;
    long fact;
    fact = factorial(number);
    cout << number << "! = " << fact << "\n ";
}