#include<iostream>
using namespace std;
void findBezoutCoefficients(int num1, int num2); 
main() 
{
    int num1, num2;
    cout << "Enter 1st number: ";
    cin >> num1;
    cout << "Enter 2nd number: ";
    cin >> num2;
    findBezoutCoefficients(num1,num2); 
}
//This function will calculate the bezout coefficients.
void findBezoutCoefficients(int num1, int num2) 
{
    int dividend, divisor,gcd,s,t;
    int olds,oldt,quotient,bez;
    /*These if statements will check which number from two enter numbers is greater.
    And assign the greater number to dividend and smaller one to divisor.*/
    if (num1 > num2) 
	{
    dividend = num1;
    divisor = num2;
    } 
	else if (num1 < num2) 
	{
    dividend = num2;
    divisor = num1;
    } 
    else if(num1=num2)
	{
		gcd=num1;
	}
    s=0;
    olds=1;
    t=1;
    oldt=0;
    //This while loop will calculate both GCD and bezout coefficients.
    while(dividend%divisor!=0&&num1!=num2)
	{
        quotient=dividend/divisor;
        bez= s;
        s=olds-quotient*s;
        olds=bez;
        bez=t;
        t=oldt-quotient*t;
        oldt=bez;
        gcd=dividend%divisor;
        dividend=divisor;
        divisor=gcd;
    }
	cout << "Bezout coefficients are: "<<s<<" and "<<t;	
}

