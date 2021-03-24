/*
Write a program that promts the user to input a float
to be stored as a string, converts it to float and prints it.
*/

#include <iostream>
#include <string>
#include <sstream>
using namespace std;

int main()
{
    string mystr;
    float num = 0;
    cout << "Enter a float value: ";
    getline(cin, mystr);
    stringstream(mystr) >> num;
    cout << "You entered " << num << ".\n";
    return 0;
}