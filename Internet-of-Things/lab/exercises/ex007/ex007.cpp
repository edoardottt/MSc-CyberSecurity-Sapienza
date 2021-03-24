/*
Write a program that prompts the user to input two
integer numbers, then performs their sum, and prints
result.
*/
#include <iostream>
using namespace std;

int main()
{
    int a = 0;
    cout << "Enter the first value: ";
    cin >> a;
    int b = 0;
    cout << "Enter the second value: ";
    cin >> b;
    cout << "The sum is " << a + b << ". \n";
}