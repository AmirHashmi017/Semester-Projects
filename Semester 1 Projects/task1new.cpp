#include <iostream>
#include <windows.h>
#include<conio.h>
using namespace std;
void moveplayerleft(char board[][50]);
void moveplayerright(char board[][50]);
void moveenemy(char board[][50],char direction);
bool enemystrike(char board[][50],char direction);
void printboard(char board[][50]);
void printfireplayer(char board[][50]);
void movefireplayer(char board[][50],int a,int &b);
void removefireplayer(char board[][50],int b,int c);
void printenemyfire(char board[][50]);
void moveenemyfire(char board[][50],int a,int &b);
void removeenemyfire(char board[][50],int b,int c);
bool detectplayerdeath(char board[][50]);
bool detectenemydeath(char board[][50]);
main()
{
	char direction='l';
	char board[10][50] = {
        "#######################################",
        "#               e                     #",
        "#                                     #",
        "#                                     #",
        "#                                     #",
        "#                                     #",
        "#                                     #",
        "#                  p                  #",
        "#                                     #",
        "#######################################"};
	system("cls");
	printboard(board);
	while(true)
	{
		Sleep(50);
		if (GetAsyncKeyState(VK_LEFT)& 0x8001)
		{
			moveplayerleft(board);
		}
		if (GetAsyncKeyState(VK_RIGHT)& 0x8001)
		{
			moveplayerright(board);
		}
		if (GetAsyncKeyState(VK_RETURN) & 0x8001)
		{
		printfireplayer(board);
		}
		if(enemystrike(board,direction))
		{
			if(direction=='l')
			direction='r';
			else if(direction=='r')
			direction='l';
		}
		moveenemy(board,direction);
		system("cls");
		printboard(board);
		if(detectplayerdeath(board)||detectenemydeath(board))
		{
		system("cls");
		break;
		}	
	}
}
void printboard(char board[][50])
{
 	for(int i=0;i<10;i++)
	{
	for(int j=0;j<40;j++)
	{
	cout<<board[i][j];
	}
	cout<<endl;
	}
}
void moveplayerright(char board[][50])
{
	for (int i=0; i<10;i++)
    {
    for (int j=0;j<40;j++)
    {
    if(board[i][j]=='p')
    {
    board[i][j]=' ';
    if(j<37)
    {
    board[i][j+1]='p';
	}
	else{
	board[i][j]='p';}
    break;
    }
	}
    }
}
void moveplayerleft(char board[][50])
{
	for (int i=0;i<10;i++)
    {
    for (int j=0;j<40;j++)
    {
    if(board[i][j]=='p')
    {
    board[i][j]=' ';
	if(j>1)
    {
    board[i][j-1]='p';
	}
	else{
	board[i][j]='p';}
	break;
    }
	}
    }
}
void printfireplayer(char board[][50])
{
	int a,b,c;
	for (int i=0;i<10;i++)
    {
    for (int j=0;j<40;j++)
    {
    if(board[i][j]=='p')
    {
    board[i-1][j]='=';
    c=i-1;
    a=i-1;
    b=j;
    break;
	}
	}
	}
	while(a>1)
	{
	movefireplayer(board,a,b);
	a--;
	c--;
	system("cls");
	printboard(board);
	}
	removefireplayer(board,b,c);
}
void movefireplayer(char board[][50],int a,int &b)
{
	if(board[a-1][b]!='e'){
	board[a][b]=' ';
	board[a-1][b]='=';
	}
	else
	{
	board[a][b]=' ';
	a=0;	
	}	
}
void removefireplayer(char board[][50],int b,int c)	
{
	board[c][b]=' ';
	system("cls");
	printboard(board);
}
void moveenemy(char board[][50],char direction)
{
	for (int i=0;i<10;i++)
    {
    for (int j=0;j<40;j++)
    {
    if(board[i][j]=='e')
    {
    board[i][j]=' ';
	if(direction=='l'){
	board[i][j-1]='e';
	if(i==1&&j==4||i==1&&j==20||i==1&&j==10)
	printenemyfire(board);}
	else if(direction=='r'){
	board[i][j+1]='e';
	if(i==1&&j==34||i==1&&j==20||i==1&&j==30)
	printenemyfire(board);}
	break;
	}
	}
	}
}
bool enemystrike(char board[][50],char direction)
{
	for (int i=0;i<10;i++)
    {
    for (int j=0;j<40;j++)
    {
    if(board[i][j]=='e')
    {
    if(direction=='l')
    {
    if(board[i][j-1]==' ')
    return false;
    else
    return true;
	}
	else if(direction=='r')
    {
    if(board[i][j+1]==' ')
    return false;
    else
    return true;
	}
	break;
	}
	}
	}
}
void printenemyfire(char board[][50])
{
	int a,b,c;
	for (int i=0;i<10;i++)
    {
    for (int j=0;j<40;j++)
    {
    if(board[i][j]=='e')
    {
    board[i+1][j]='=';
    c=i+1;
    a=i+1;
    b=j;
    break;
	}
	}
	}
	while(a<8)
	{
	moveenemyfire(board,a,b);
	a++;
	c++;
	system("cls");
	printboard(board);
	}
	removeenemyfire(board,b,c);
}
void moveenemyfire(char board[][50],int a,int &b)
{
	if(board[a+1][b]!='p'){
	board[a][b]=' ';
	board[a+1][b]='=';
	}
	else
	{
	board[a][b]=' ';
	a=10;	
	}		
}
void removeenemyfire(char board[][50],int b,int c)
{
	board[c][b]=' ';
	system("cls");
	printboard(board);
}
bool detectplayerdeath(char board[][50])
{
	for (int i=0;i<10;i++)
    {
    for (int j=0;j<40;j++)
    {
    if(board[i][j]=='p')
    {
	return false;
	}
}
} 
return true;
}
bool detectenemydeath(char board[][50])
{
	for (int i=0;i<10;i++)
    {
    for (int j=0;j<40;j++)
    {
    if(board[i][j]=='e')
    {
	return false;
	}
}
} 
return true;
}

