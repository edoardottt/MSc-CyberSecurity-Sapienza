#include <iostream>
using namespace std;
struct product
{
    char name[20];
    float price;
} pr[5];
int main()
{
    for (int i = 0; i < 5; i++)
    {
        cout << "Enter the name of product " << i + 1 << ":";
        cin >> pr[i].name;
        cout << "Enter the price of product " << i + 1 << ":";
        cin >> pr[i].price;
        cout << endl;
    }
    cout << "Product Name"
         << "\t \t"
         << "Price (Euro)" << endl;
    for (int i = 0; i < 5; i++)
        cout << pr[i].name << "\t \t \t" << pr[i].price << endl;
    return 0;
}