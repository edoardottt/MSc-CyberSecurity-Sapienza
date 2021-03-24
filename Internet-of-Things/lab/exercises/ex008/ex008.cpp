/*
Write a program that promts the user to input the sentence
"This is my first sentence.", and prints that sentence.
*/

#include <iostream>
#include <string>
using namespace std;

int main()
{
    string mystr;
    cout << "Enter a sentence: ";
    getline(cin, mystr);
    cout << "You entered " << mystr << " \n";
    return 0;
}