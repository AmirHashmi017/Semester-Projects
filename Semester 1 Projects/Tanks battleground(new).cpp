#include<iostream>
#include<windows.h>
#include<conio.h>
using namespace std;
void gotoxy(int x,int y);
void printmaze();
void printplayertank();
void removeplayertank();
void printenemytank1();
void removeenemytank1();
void printenemytank2();
void removeenemytank2();
void printenemytank3();
void removeenemytank3();
void moveplayertankup();
void moveplayertankdown();
void moveenemytank1();
void moveenemytank2();
void moveenemytank3();
void fireenemytank1();
void fireenemytank2();
void fireenemytank3();
void fireplayertank();
char getCharAtxy(short int x, short int y);
void printhealth();
int score=0;
int ptx=2;
int pty=15;
int etx=55;
int ety=14;
int etx2=50;
int ety2=40;
int etx3=35;
int ety3=3;
int strike1=0;
int strike2=0;
int strike3=0;
int health=100;
main()
{
	system("cls");
	system("Color 04");
	//printmaze()
	printplayertank();
	printenemytank1();
	printenemytank2();
	printenemytank3();
	printhealth();
	while(true)
	{
	Sleep(120);
	if (GetAsyncKeyState(VK_UP))
	{
	moveplayertankup();
	}
	if (GetAsyncKeyState(VK_DOWN))
	{
	moveplayertankdown();
	}
	if (GetAsyncKeyState(VK_RETURN) & 0x8001)
	{
	fireplayertank();
	}
	moveenemytank1();
	moveenemytank2();
	moveenemytank3();
	if(ptx==2&&pty==7)
	{
	health=150;
	gotoxy(2,7);
	cout<<" ";
	}
	gotoxy(65,3);
	cout<<"HEALTH="<<health;
	gotoxy(65,5);
	cout<<"SCORE="<<score;
	}
}
void printhealth()
{
	gotoxy(2,7);
	cout<<"H";
}
void gotoxy(int x,int y)
{
COORD coordinates;
coordinates.X = x;
coordinates.Y = y;
SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coordinates);
}
char getCharAtxy(short int x, short int y)
{
	CHAR_INFO ci;
	COORD xy = {0, 0};
	SMALL_RECT rect = {x, y, x, y};
	COORD coordBufSize;
	coordBufSize.X = 1;
	coordBufSize.Y = 1;
	return ReadConsoleOutput(GetStdHandle(STD_OUTPUT_HANDLE), &ci, coordBufSize, xy, &rect) ? ci.Char.AsciiChar
	: ' ';
}
void printmaze()
{
	cout << "################################################################################################"<< endl;
	cout << "#                     									        #"<< endl;
	cout << "#		     									       	#" << endl;
	cout << "# 		      									        #" << endl;
	cout << "#                    									      	#" << endl;
	cout << "#                    									       	#" << endl;
	cout << "#                    									      	#" << endl;
	cout << "#                     									        #" << endl;
	cout << "#                     									       	#"<< endl;
	cout << "#		     									      	#" << endl;
	cout << "# 		      									        #" << endl;
	cout << "#                    									       	#" << endl;
	cout << "#                    									        #" << endl;
	cout << "#                    									       	#" << endl;
    	cout << "#           									                #" << endl;
	cout << "#		     									       	#" << endl;
	cout << "# 		      									       	#" << endl;
	cout << "#                    									        #" << endl;
	cout << "#                    									       	#" << endl;
	cout << "#                    									       	#" << endl;
    	cout << "#                    									      	#" << endl;
	cout << "#                    									        #" << endl;
    	cout << "#           									               	#" << endl;
	cout << "#		     									       	#" << endl;
	cout << "# 		      									      	#" << endl;
	cout << "#                    									       	#" << endl;
	cout << "#                    									      	#" << endl;
	cout << "#                    									      	#" << endl;
	cout << "#                    									       	#" << endl;
	cout << "#                    									        #" << endl;
	cout << "################################################################################################" << endl;
}

void printplayertank()
{
	gotoxy(ptx,pty);
	cout<<"#############|";
	gotoxy(ptx,pty+1);
	cout<<"#            |";
	gotoxy(ptx,pty+2);
	cout<<"#      |##############)";
	gotoxy(ptx,pty+3);
	cout<<"#      |##############)";
	gotoxy(ptx,pty+4);
	cout<<"#            |";
	gotoxy(ptx,pty+5);
	cout<<"#############|";
}	
void removeplayertank()
{
	gotoxy(ptx,pty);
	cout<<"              ";
	gotoxy(ptx,pty+1);
	cout<<"              ";
	gotoxy(ptx,pty+2);
	cout<<"                       ";
	gotoxy(ptx,pty+3);
	cout<<"                       ";
	gotoxy(ptx,pty+4);
	cout<<"              ";
	gotoxy(ptx,pty+5);
	cout<<"              ";	
}
void moveplayertankup()
{
	if (getCharAtxy(ptx,pty-1) != '#')
	{
	removeplayertank();
	pty=pty-1;
	printplayertank();
	} 
}
void moveplayertankdown() 
{
	if (getCharAtxy(ptx,pty+6) != '#')
	{
	removeplayertank();
	pty = pty+1;
	printplayertank();
	} 
}
void printenemytank1()
{
	gotoxy(etx,ety);
	cout<<"           |#########";
	gotoxy(etx,ety+1);
	cout<<"           |        #";
	gotoxy(etx,ety+2);
	cout<<"  (#######|         #";
	gotoxy(etx,ety+3);
	cout<<"  (#######|         #";
	gotoxy(etx,ety+4);
	cout<<"           |        #";
	gotoxy(etx,ety+5);
	cout<<"           |#########";
}
void removeenemytank1()
{
	gotoxy(etx,ety);
	cout<<"                   			";
	gotoxy(etx,ety+1);
	cout<<"                   			";
	gotoxy(etx,ety+2);
	cout<<"                   			";
	gotoxy(etx,ety+3);
	cout<<"                   			";
	gotoxy(etx,ety+4);
	cout<<"                  	        ";
	gotoxy(etx,ety+5);
	cout<<"                   			";
}
void printenemytank2()
{
	gotoxy(etx2,ety2);
	cout<<"           |#########";
	gotoxy(etx2,ety2+1);
	cout<<"           |        #";
	gotoxy(etx2,ety2+2);
	cout<<"  (########|        #";
	gotoxy(etx2,ety2+3);
	cout<<"  (#######|         #";
	gotoxy(etx2,ety2+4);
	cout<<"           |        #";
	gotoxy(etx2,ety2+5);
	cout<<"           |#########";
}
void removeenemytank2()
{
	gotoxy(etx2,ety2);
	cout<<"                   			";
	gotoxy(etx2,ety2+1);
	cout<<"                   			";
	gotoxy(etx2,ety2+2);
	cout<<"                   			";
	gotoxy(etx2,ety2+3);
	cout<<"                   			";
	gotoxy(etx2,ety2+4);
	cout<<"                  	        ";
	gotoxy(etx2,ety2+5);
	cout<<"                   			";
}
void printenemytank3()
{
	gotoxy(etx3,ety3);
	cout<<"           |#########";
	gotoxy(etx3,ety3+1);
	cout<<"           |        #";
	gotoxy(etx3,ety3+2);
	cout<<"  (#######|         #";
	gotoxy(etx3,ety3+3);
	cout<<"  (########|        #";
	gotoxy(etx3,ety3+4);
	cout<<"           |        #";
	gotoxy(etx3,ety3+5);
	cout<<"           |#########";
}
void removeenemytank3()
{
	gotoxy(etx3,ety3);
	cout<<"                   			";
	gotoxy(etx3,ety3+1);
	cout<<"                   			";
	gotoxy(etx3,ety3+2);
	cout<<"                   			";
	gotoxy(etx3,ety3+3);
	cout<<"                   			";
	gotoxy(etx3,ety3+4);
	cout<<"                  	        ";
	gotoxy(etx3,ety3+5);
	cout<<"                   			";
}
void moveenemytank1()
{	
	removeenemytank1();
	if(strike1==0)
	{
	ety=ety+1;
	}
	if(ety==33)
	{
	strike1=1;
	}
	if(strike1==1)
	ety=ety-1;
	if(ety==14)
	strike1=0;
	printenemytank1();
	//fireenemytank1();
}
void moveenemytank2()
{
	removeenemytank2();
	if(strike2==0)
	etx2=etx2-1;
	if(etx2==25)
	{
	strike2=1;
	}
	if(strike2==1)
	etx2=etx2+1;
	if(etx2==50)
	strike2=0;
	printenemytank2();
	//fireenemytank2();
}
void moveenemytank3()
{
	removeenemytank3();
	if(strike3==0)
	{
	etx3=etx3-1;
	ety3=ety3+1;
	}
	if(etx3==25||ety3==15)
	{
	strike3=1;
	}
	if(strike3==1)
	{
	etx3=etx3+1;
	ety3=ety3-1;
	}
	if(etx3==35||ety3==3)
	strike3=0;
	printenemytank3();
	//fireenemytank3();
}
void fireenemytank1()
{
	if(etx==55&&ety==26){
	int n=etx-1;
	while(n>3){
	gotoxy(n,ety+2);
	cout<<"(==";
	Sleep(20);
	gotoxy(n,ety+2);
	cout<<"   ";
	n--;
	}
	}
}
void fireenemytank2()
{
	if(etx2==37&&ety2==40){
	int n=etx2-1;
	while(n>3){
	gotoxy(n,ety2+2);
	cout<<"(==";
	Sleep(20);
	gotoxy(n,ety2+2);
	cout<<"   ";
	n--;
	}
	}
}
void fireenemytank3()
{
	if(ety3==8){
	int n=etx3-1;
	while(n>3){
	gotoxy(n,ety3+2);
	cout<<"(==";
	Sleep(20);
	gotoxy(n,ety3+2);
	cout<<"   ";
	n--;
	}
	}
}
void fireplayertank()
{
	int n=ptx+23;
	int l=pty+2;
	while(n<70){
	gotoxy(n,l);
	cout<<"==)";
	Sleep(20);
	gotoxy(n,l);
	cout<<"   ";
	gotoxy(65,3);
	cout<<"HEALTH="<<health;
	gotoxy(65,5);
	cout<<"SCORE="<<score;
	if (GetAsyncKeyState(VK_UP))
	{
	moveplayertankup();
	}
	if (GetAsyncKeyState(VK_DOWN))
	{
	moveplayertankdown();
	}
	//if (GetAsyncKeyState(VK_RETURN) & 0x8001)
	//{
	//fireplayertank();
	//}
	moveenemytank1();
	moveenemytank2();
	moveenemytank3();
	n++;
	if(ptx==2&&pty==7)
	{
	health=150;
	gotoxy(2,7);
	cout<<" ";
	}
	Sleep(50);
	}
}
