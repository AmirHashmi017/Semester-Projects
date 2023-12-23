#include <iostream>
using namespace std;
void primefactorization(int number);
main() 
{
    int number;
    cout << "Enter a positive integer: ";
    cin >>number;
    primefactorization(number);
}
//This function will calculate the prime factors.
void primefactorization(int number) 
{
	int count=0;
	int primefactors[50];
	//This for loop will calculate the prime factor 2.
    for(int i=0;number%2==0;i++) 
	{
	primefactors[i]=2;
    number=number/2;
    count++;
    }
    //This for loop will calculate the odd prime factors from 3 to 9.
    for(int x=3;x<9;x=x+2) 
	{
	for(int i=count;number%x==0;i++)
	{
    primefactors[i]=x;
    number=number/x;
    count++;
    break;
    }
    }
    /*This if statement will check that if the entered number is still greater than 2,
    then the remaining number is itself a prime factor.*/
    if(number>2) 
	{
    primefactors[count]=number;
    count++;
    }
    cout<<"Prime Factorization: ";
    //This for loop will print the prime factorization.
    for (int i=0;i<count;i++) 
	{
	if(i<count-1)
    cout<<primefactors[i]<<"x";
    else
    cout<<primefactors[i];
    }
}
