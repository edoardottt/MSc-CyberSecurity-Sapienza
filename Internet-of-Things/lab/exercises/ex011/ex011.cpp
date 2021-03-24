#include <iostream>
using namespace std;
int main()
{
    string str;
    do
    {
        cout << "Enter text: ";
        getline(cin, str);
        cout << "You entered: " << str << "\n";
    } while (str != "ciao" || str != "exit");
}