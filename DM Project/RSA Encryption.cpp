#include <iostream>
#include <cmath>
#include <string>
using namespace std;
void calculateEncryptedNumbers(int n, int e, string messagecode);
void convertIntoNumbers(string message, int n, int e, int blocknum1, int blocknum2);
string numbers[26] = {"00","01","02","03","04","05","06","07","08","09","10","11","12","13","14","15","16","17","18","19","20","21","22","23","24","25"};
string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
string resultfinal;
int resultcount=0;
main() 
{
    string entermessage;
    string message;
    int n, e;
    cout << "Enter message you want to encrypt: ";
    cin >> entermessage;
    cout << "Enter n: ";
    cin >> n;
    cout << "Enter e: ";
    cin >> e;
    /*This for loop will break the entered message into blocks of two alphabets,
     and pass these blocks to functions one by one.*/
    for(int i=0;entermessage[i]!='\0';i+=2)
    {
     message = string(1, entermessage[i]);
     message += entermessage[i+1];  
    convertIntoNumbers(message, n, e, 0, 1);
	}
	cout<<resultfinal;
}
//This function will convert the message into numbers using the globally declared arrays.
void convertIntoNumbers(string message, int n, int e, int blocknum1, int blocknum2) {
    string messagecode;
    for (int i = 0; i < 25; i++) {
        if (message[blocknum1] == alphabets[i]) {
            messagecode = numbers[i];
            break;
        }
    }
    for (int i = 0; i < 25; i++) {
        if (message[blocknum2] == alphabets[i]) {
            messagecode += numbers[i];
            break;
        }
    }
    calculateEncryptedNumbers(n, e, messagecode);
}
//This function will calculate the encrypted numeric message by using RSA formula C=M^e mod n.
void calculateEncryptedNumbers(int n, int e, string messagecode) {
    int base = stoi(messagecode);
    int exponent = e;
    int modulus = n;
    int result = 1;
    for (int i = 0; i < exponent; i++) {
        result = (result * base) % modulus;
    }
    string res=to_string(result);
    if(res.length()==4)
    resultfinal+=res;
    else{
    resultfinal+="0";
    resultfinal+=res;}
    resultfinal+=" ";
    resultcount++;
    
}
