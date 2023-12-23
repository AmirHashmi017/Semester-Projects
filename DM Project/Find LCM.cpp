#include<iostream>
using namespace std;
int findGCD(int num1,int num2);
int findLCM(int GCD,int num1,int num2);
main()
{
	int num1,num2;
	int GCD;
	int result;
	cout<<"Enter 1st number: ";
	cin>>num1;
	cout<<"Enter 2nd number: ";
	cin>>num2;
	GCD=findGCD(num1,num2);
	result=findLCM(GCD,num1,num2);
	cout<<"LCM of "<<num1<<" and "<<num2<<" is: "<<result;
}
//This function will GCD using Euclidean Algorithm.
int findGCD(int num1,int num2)
{
	int dividend,divisor,gcd;
	int calculate=0;
	/*These if statements will check which number from two enter numbers is greater.
    And assign the greater number to dividend and smaller one to divisor.*/
    if(num1>num2&&num1%num2==0)
	{
		gcd=num2;
		calculate=1;	
	}
	else if(num1>num2)
	{
		dividend=num1;
		divisor=num2;
	}
	else if(num1<num2&&num2%num1==0)
	{
		gcd=num1;
		calculate=1;
	}
	else if(num1<num2)
	{
		dividend=num2;
		divisor=num1;
	}
	else if(num1=num2)
	{
		gcd=num1;
		calculate=1;
	}
	//This while loop will calculate GCD.
	while(dividend%divisor!=0&&calculate==0)
	{
	gcd=dividend%divisor;
	dividend=divisor;
	divisor=gcd;	
	}
	return gcd;
}
//This function will calculate LCM using formula LCM=(a*b)/gcd(a,b).
int findLCM(int GCD,int num1,int num2)
{
	int lcm;
	lcm=(num1*num2)/GCD;
	return lcm;
}
