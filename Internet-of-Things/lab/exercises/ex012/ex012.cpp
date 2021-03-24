//find the greatest number among 3
#include <iostream>
using namespace std;
int main()
{
    float n1, n2, n3;
    cout << "Enter three numbers: ";
    cin >> n1 >> n2 >> n3;
    if (n1 >= n2 && n1 >= n3)
        cout << "Largest number: " << n1 << endl;
    if (n2 >= n1 && n2 >= n3)
        cout << "Largest number: " << n2 << endl;
    if (n3 >= n1 && n3 >= n2)
        cout << "Largest number: " << n3 << endl;
    return 0;
}