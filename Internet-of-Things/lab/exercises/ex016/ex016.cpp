/*
Write a program that finds the smallest and largest element
of a given array. E.g., if a[5]={6, 13, 8, 25, 100} then smallest
number is a[0]=6 and largest number is a[4]=100.
*/
#include <iostream>
using namespace std;
int main()
{
    int num[5] = {6, 13, 8, 25, 100};
    int largest = 0, smallest = 100;
    for (int i = 0; i < 5; ++i)
    {
        if (num[i] > largest)
            largest = num[i];
        if (num[i] < smallest)
            smallest = num[i];
    }
    cout << "Smallest number is: " << smallest << endl;
    cout << "Largest number is: " << largest << endl;
    return 0;
}