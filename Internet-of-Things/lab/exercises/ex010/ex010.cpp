#include <iostream>
using namespace std;

int main()
{
    int number = 0;
    cout << "Enter an integer: ";
    cin >> number;
    // checks if the number is positive
    if (number > 0)
    {
        cout << "Positive integer: " << number << endl;
    }
    else if (number < 0)
    {
        cout << "Negative integer: " << number << endl;
    }
    else
    {
        cout << "You entered 0. " << number << endl;
    }
}