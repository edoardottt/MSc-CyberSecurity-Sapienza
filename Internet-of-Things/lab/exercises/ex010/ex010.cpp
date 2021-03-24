#include <iostream>
using namespace std;

int main()
{
    int number = 0;
    cout << "Enter an integer: ";
    cin >> number;
    // checks if the number is positive
    if (number >= 0)
    {
        cout << "Positive integer: " << number << endl;
    }
    else
    {
        cout << "Negative integer: " << number << endl;
    }
}