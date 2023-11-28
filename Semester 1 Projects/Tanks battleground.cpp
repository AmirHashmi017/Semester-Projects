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
char getCharAtxy(short int x, short int y);
void printhealth();
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
	int health=100;
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
	moveenemytank1();
	moveenemytank2();
	moveenemytank3();
	if(ptx==2&&pty==7)
	{
	health=150;
	gotoxy(2,7);
	cout<<" ";
	}
	gotoxy(60,3);
	cout<<"HEALTH="<<health;
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
{	if (getCharAtxy(ptx,pty+6) != '#')
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
}	
		

