#include <iostream>
#include <windows.h>
#include <conio.h>
using namespace std;
const int enemyheight1 = 5;
const int enemywidth1 = 25;
const int enemyheight2 = 5;
const int enemywidth2 = 25;
const int enemyheight3 = 4;
const int enemywidth3 = 17;
const int playerHeight = 6;
const int playerWidth = 25;
const int boardHeight = 43, boardWidth = 150;
string printheader();
void print1level();
void print2level();
void fireplayerboss(char enemy1[enemyheight1][enemywidth1],char enemy2[enemyheight2][enemywidth2],char enemy3[enemyheight3][enemywidth3],int &fpX,int &fpY,int &pX,int &pY,int &eX1,int &eY1,int &eX2,int &eY2,int &eX3,int &eY3,int &score,int &healthp,int &healthe1,int &healthe2,int &healthe3,int &firep,int &enemycount);
void moveenemyboss(char board[][boardWidth],char enemy1[enemyheight1][enemywidth1],char enemydirection1,int &eX1,int &eY1,int enemywidth1,int enemyheight1);
bool enemystrikeboss(char enemydirection1,char board[][boardWidth],int &pX,int &pY,int &eX1,int &eY1,int & eX2,int &eY2,int &eX3,int &eY3);
string printlevel1won(int score);
string printlevel1lost(int score);
string selectedplayer();
void gotoxy(int x, int y);
void erasePlayer(char player2D[playerHeight][playerWidth], int &pX, int &pY, int playerWidth, int playerHeight, string selectplayer);
void printPlayer(char player2D[playerHeight][playerWidth], int &pX, int &pY, int playerWidth, int playerHeight, string selectplayer);
void eraseenemy1(char enemy1[enemyheight1][enemywidth1], int &eX1, int &eY1, int enemywidth1, int enemyheight1);
void printenemy1(char enemy1[enemyheight1][enemywidth1], int &eX1, int &eY1, int enemywidth1, int enemyheight1);
void eraseenemy2(char enemy2[enemyheight2][enemywidth2], int &eX2, int &eY2, int enemywidth2, int enemyheight2);
void printenemy2(char enemy2[enemyheight2][enemywidth2], int &eX2, int &eY2, int enemywidth2, int enemyheight2);
void eraseenemy3(char enemy3[enemyheight3][enemywidth3], int &eX3, int &eY3, int enemywidth3, int enemyheight3);
void printenemy3(char enemy3[enemyheight3][enemywidth3], int &eX3, int &eY3, int enemywidth3, int enemyheight3);
void drawBoard(char board[][boardWidth], char player2D[][playerWidth], char enemy1[][enemywidth1], char enemy2[][enemywidth2], char enemy3[][enemywidth3], int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3, string selectplayer);
void moveenemy1(char board[][boardWidth], char enemy1[enemyheight1][enemywidth1], char enemydirection1, int &eX1, int &eY1, int enemywidth1, int enemyheight1);
bool enemystrike1(char enemydirection1, char board[][boardWidth], int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3);
void moveenemy2(char board[][boardWidth], char enemy2[enemyheight2][enemywidth2], char enemydirection2, int &eX2, int &eY2, int enemywidth2, int enemyheight2);
bool enemystrike2(char enemydirection2, char board[][boardWidth], int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3);
void moveenemy3(char board[][boardWidth], char enemy3[enemyheight3][enemywidth3], char enemydirection3, int &eX3, int &eY3, int enemywidth3, int enemyheight3);
bool enemystrike3(char enemydirection3, char board[][boardWidth], int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3);
void fireplayer(char enemy1[enemyheight1][enemywidth1], char enemy2[enemyheight2][enemywidth2], char enemy3[enemyheight3][enemywidth3], int &fpX, int &fpY, int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3, int &score, int &healthp, int &healthe1, int &healthe2, int &healthe3, int &firep, int &enemycount);
void fireenemy1(char player2D[playerHeight][playerWidth], int pX, int pY, int &eX1, int &eY1, int &feX1, int &feY1, int &healthp, int &firee1, string selectplayer);
void fireenemy2(char player2D[playerHeight][playerWidth], int pX, int pY, int &eX2, int &eY2, int &feX2, int &feY2, int &healthp, int &firee2, string selectplayer);
void fireenemy3(char player2D[playerHeight][playerWidth], int pX, int pY, int &eX3, int &eY3, int &feX3, int &feY3, int &healthp, int &firee3, string selectplayer);
void firehitenemy(char enemy1[enemyheight1][enemywidth1], char enemy2[enemyheight2][enemywidth2], char enemy3[enemyheight3][enemywidth3], int fpX, int fpY, int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3, int &score, int &healthp, int &healthe1, int &healthe2, int &healthe3, int &enemycount);
char getCharAtxy(short int x, short int y);
string setcolor(unsigned short color)
{
    HANDLE hcon = GetStdHandle(STD_OUTPUT_HANDLE);
    SetConsoleTextAttribute(hcon, color);
    return "";
}
int main()
{
	int enemycount = 3;
	int eX1 = 37, eY1 = 119;
	int eX2 = 21, eY2 = 119;
	int eX3 = 5, eY3 = 119;
	int pX = 24, pY = 6;
	int fpX = 0, fpY = 1;
	int feX1 = 0, feY1 = 1;
	int feX2 = 0, feY2 = 1;
	int feX3 = 0, feY3 = 1;
	int score = 0;
	int healthp = 300;
	int healthe1 = 200;
	int healthe2 = 200;
	int healthe3 = 200;
	int firep = 0;
	int firee1 = 0;
	int firee2 = 0;
	int firee3 = 0;
	string selectplayer = "1";
	string result;
	int healthexist = 0;
	int healthcount = 0;
	char enemydirection1 = 'u';
	char enemydirection2 = 'l';
	char enemydirection3 = 'l';
	// This 2D array store game maze.
	char board[boardHeight][boardWidth] = {
		"##############################################################################################################################################",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                              l                             #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                              e                             #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#     p                                                                                                                                      #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                              x                             #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"##############################################################################################################################################"};

	char board2[boardHeight][boardWidth] = {
		"##############################################################################################################################################",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                              l                             #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                              e                             #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#     p                                                                                                                                      #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                              x                             #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"#                                                                                                                                            #",
		"##############################################################################################################################################"};

char board3[boardHeight][boardWidth] = {
	"##############################################################################################################################################",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                              e                             #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#     p                                                                                                                                      #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"#                                                                                                                                            #",
	"##############################################################################################################################################"};
	// This 2D array store player character.
	char player2D[playerHeight][playerWidth] = {
		"		      _\______   ",
		"      /  PAK   \========",
		" ____|__________\\_____ ",
		"/ ___________________ \ ",
		"\/ _===============_ \/ ",
		" |-===============-|    "};

	// This 2D array store enemy1 character.
	char enemy1[enemyheight1][enemywidth1] = {
		"	       _\--__        ",
		"_______ / 1   \\        ",
		"------|_______|__      ",
		"	//------------\\\\  ",
		"	\\____________/.... "};

	// This 2D array store enemy2 character.
	char enemy2[enemyheight2][enemywidth2] = {
		"	       _\--__        ",
		"_______ / 2   \\        ",
		"------|_______|__      ",
		"	//------------\\\\  ",
		"	\\____________/.... "};

	// This 2D array store enemy3 character.
	char enemy3[enemyheight3][enemywidth3] = {
		"       ____     ",
		"======/3___ |_ ",
		" / / _______ |  ",
		"\0 | 0 | 0 | 0|"};
	system("cls");
	result = printheader();
	// This if statement will exit the program.
	if (result == "3")
	{
		system("cls");
		return 0;
	}
	// This if statement will take user to selectplayer() function.
	if (result == "2")
	{
		system("cls");
		selectplayer = selectedplayer();
		cout << " \n\n Press any key to continue..";
		getch();
		result = 1;
	}
	system("cls");
	print1level();
	Sleep(2000);
	system("cls");
	drawBoard(board, player2D, enemy1, enemy2, enemy3, pX, pY, eX1, eY1, eX2, eY2, eX3, eY3, selectplayer);
	gotoxy(1, 2);
	cout << "*******************************************************************************************************************************************";
	gotoxy(2, 1);
	cout << "Player Health=" << healthp;
	gotoxy(30, 1);
	cout << "Score=" << score;
	gotoxy(70, 1);
	cout << "Enemy1 Health=" << healthe1;
	gotoxy(95, 1);
	cout << "Enemy2 Health=" << healthe2;
	gotoxy(123, 1);
	cout << "Enemy3 Health=" << healthe3;
	printPlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
	printenemy1(enemy1, eX1, eY1, enemywidth1, enemyheight1);
	while (true)
	{
		// This if statement will move the player up
		if (GetAsyncKeyState(VK_UP) && pX > 3)
		{
			erasePlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
			board[pX][pY] = ' ';
			pX = pX - 1;
			board[pX][pY] = 'p';
			printPlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
		}
		// This if statement will move the player down.
		if (GetAsyncKeyState(VK_DOWN) && pX < 36)
		{
			erasePlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
			board[pX][pY] = ' ';
			pX = pX + 1;
			board[pX][pY] = 'p';
			printPlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
		}
		// With this if statement the player will fire.
		if (GetAsyncKeyState(VK_SPACE) && fpY == 1)
		{
			firep = 1;
			fireplayer(enemy1, enemy2, enemy3, fpX, fpY, pX, pY, eX1, eY1, eY1, eY2, eX3, eY3, score, healthp, healthe1, healthe2, healthe3, firep, enemycount);
		}
		if (firep == 1)
		{
			fireplayer(enemy1, enemy2, enemy3, fpX, fpY, pX, pY, eX1, eY1, eY1, eY2, eX3, eY3, score, healthp, healthe1, healthe2, healthe3, firep, enemycount);
		}
		// This if statement will check that the player won the game or not.
		if (enemycount <= 0)
		{
			string rep;
			system("cls");
			rep = printlevel1won(score);
			if (rep == "1")
			{
				system("cls");
				print2level();
				Sleep(1500);
				system("cls");
	eX1 = 21; 
	eY1 = 119;
	feX1=0;
	feY1=1;
	firee1=0;
	healthp=300;
	healthe1=500;
	enemydirection1='u';
	fpX=0;
	fpY=1;
	enemycount=1;
				drawBoard(board3,player2D,enemy1,enemy2,enemy3,pX,pY,eX1,eY1,eX2,eY2,eX3,eY3,selectplayer);
	gotoxy(1, 2);
	cout << "*******************************************************************************************************************************************";
	gotoxy(2, 1);
	cout << "Player Health=" << healthp;
	gotoxy(30, 1);
	cout << "Score=" << score;
	gotoxy(95, 1);
	cout << "Enemy Health=" << healthe1;
	printPlayer(player2D,pX,pY,playerWidth,playerHeight,selectplayer);
    printenemy1(enemy1,eX1,eY1,enemywidth1,enemyheight1);
	break;
			}
			if (rep == "2")
			{
				system("cls");
				return 0;
			}
		}
		if ((getCharAtxy(10, 5) != 'H' && healthcount == 0 && healthexist > 0) || (getCharAtxy(10, 20) != 'H' && healthcount == 1 && healthexist > 1))
		{
			healthp = healthp + 100;
			gotoxy(2, 1);
			cout << "Player Health=" << healthp;
			healthcount++;
		}
		// This if statement will check that enemy 1 exist or not.
		if (healthe1 > 0)
		{
			// This if statement decide the direction for player movement.
			if (enemystrike1(enemydirection1, board, pX, pY, eX1, eY1, eX2, eY2, eX3, eY3))
			{
				if (enemydirection1 == 'u')
					enemydirection1 = 'd';
				else if (enemydirection1 == 'd')
					enemydirection1 = 'u';
			}
			moveenemy1(board, enemy1, enemydirection1, eX1, eY1, enemywidth1, enemyheight1);
		}
		// This if statement will check that enemy 1 exist or not.
		if (healthe2 > 0)
		{
			// This if statement decide the direction for player movement.
			if (enemystrike2(enemydirection2, board, pX, pY, eX1, eY1, eX2, eY2, eX3, eY3))
			{
				if (enemydirection2 == 'l')
					enemydirection2 = 'r';
				else if (enemydirection2 == 'r')
					enemydirection2 = 'l';
			}
			moveenemy2(board, enemy2, enemydirection2, eX2, eY2, enemywidth2, enemyheight2);
		}
		else
			eraseenemy2(enemy2, eX2, eY2, enemywidth2, enemyheight2);
		// This if statement will check that enemy 1 exist or not.
		if (healthe3 > 0)
		{
			// This if statement decide the direction for player movement.
			if (enemystrike3(enemydirection3, board, pX, pY, eX1, eY1, eX2, eY2, eX3, eY3))
			{
				if (enemydirection3 == 'l')
					enemydirection3 = 'r';
				else if (enemydirection3 == 'r')
					enemydirection3 = 'l';
			}
			moveenemy3(board, enemy3, enemydirection3, eX3, eY3, enemywidth3, enemyheight3);
		}
		// With this if statement enemy1 will fire.
		if (healthe1 > 0)
		{
			if (eX1 == 26 && feY1 == 1)
			{
				firee1 = 1;
				fireenemy1(player2D, pX, pY, eX1, eY1, feX1, feY1, healthp, firee1, selectplayer);
			}
		}
		if (firee1 == 1)
		{
			fireenemy1(player2D, pX, pY, eX1, eY1, feX1, feY1, healthp, firee1, selectplayer);
		}
		// With this if statement enemy2 will fire.
		if (healthe2 > 0)
		{
			if (eY2 == 75 && feY2 == 1)
			{
				firee2 = 1;
				fireenemy2(player2D, pX, pY, eX2, eY2, feX2, feY2, healthp, firee2, selectplayer);
			}
		}
		if (firee2 == 1)
		{
			fireenemy2(player2D, pX, pY, eX2, eY2, feX2, feY2, healthp, firee2, selectplayer);
		}
		// With this if statement enemy3 will fire.
		if (healthe3 > 0)
		{
			if (eY3 == 85 && feY3 == 1)
			{
				firee3 = 1;
				fireenemy3(player2D, pX, pY, eX3, eY3, feX3, feY3, healthp, firee3, selectplayer);
			}
		}
		if (firee3 == 1)
		{
			fireenemy3(player2D, pX, pY, eX3, eY3, feX3, feY3, healthp, firee3, selectplayer);
		}
		// This if statement will detect that the player lost the game or not.
		if (healthp == 0)
		{
			string res;
			system("cls");
			res = printlevel1lost(score);
			if (res == "1")
			{
				system("cls");
				drawBoard(board2, player2D, enemy1, enemy2, enemy3, pX, pY, eX1, eY1, eX2, eY2, eX3, eY3, selectplayer);
				enemycount = 3;
				score = 0;
				eX1 = 20, eY1 = 110;
				eX2 = 36, eY2 = 112;
				eX3 = 5, eY3 = 119;
				pX = 24, pY = 6;
				fpX = 0, fpY = 1;
				feX1 = 0, feY1 = 1;
				feX2 = 0, feY2 = 1;
				feX3 = 0, feY3 = 1;
				healthp = 300;
				healthe1 = 200;
				healthe2 = 200;
				healthe3 = 200;
				firep = 0;
				firee1 = 0;
				firee2 = 0;
				firee3 = 0;
				result;
				healthexist = 0;
				healthcount = 0;
				enemydirection1 = 'u';
				enemydirection2 = 'l';
				enemydirection3 = 'l';
				gotoxy(1, 2);
				cout << "*******************************************************************************************************************************************";
				gotoxy(2, 1);
				cout << "Player Health=" << healthp;
				gotoxy(30, 1);
				cout << "Score=" << score;
				gotoxy(70, 1);
				cout << "Enemy1 Health=" << healthe1;
				gotoxy(95, 1);
				cout << "Enemy2 Health=" << healthe2;
				gotoxy(123, 1);
				cout << "Enemy3 Health=" << healthe3;
				printPlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
				printenemy1(enemy1, eX1, eY1, enemywidth1, enemyheight1);
				continue;
			}
			if (res == "2")
			{
				system("cls");
				break;
			}
		}
		if (eY3 == 30 && healthexist == 0)
		{
			gotoxy(10, 5);
			cout << "H";
			healthexist++;
		}
		if (eY3 == 30 && healthcount == 1)
		{
			gotoxy(10, 20);
			cout << "H";
			healthexist++;
		}
	}
	while(true)
    {
    if (GetAsyncKeyState(VK_UP) && pX >3) {
			erasePlayer(player2D,pX,pY,playerWidth,playerHeight,selectplayer);
			board[pX][pY] = ' ';
			pX = pX - 1;
			board[pX][pY]= 'p';
			printPlayer(player2D,pX,pY,playerWidth,playerHeight,selectplayer);
		}
		if (GetAsyncKeyState(VK_DOWN) && pX<35) {
			erasePlayer(player2D,pX,pY,playerWidth,playerHeight,selectplayer);
			board[pX][pY] = ' ';
			pX = pX + 1;
			board[pX][pY] = 'p';
			printPlayer(player2D,pX,pY,playerWidth,playerHeight,selectplayer);
		}
		if (GetAsyncKeyState(VK_SPACE)&&fpY==1)
		{
			firep=1;
			fireplayerboss(enemy1,enemy2,enemy3,fpX,fpY,pX,pY,eX1,eY1,eY1,eY2,eX3,eY3,score,healthp,healthe1,healthe2,healthe3,firep,enemycount);
		}
		if(firep==1){
			fireplayerboss(enemy1,enemy2,enemy3,fpX,fpY,pX,pY,eX1,eY1,eY1,eY2,eX3,eY3,score,healthp,healthe1,healthe2,healthe3,firep,enemycount);
		}
		if(healthe1>0){
		if (enemystrikeboss(enemydirection1,board,pX,pY,eX1,eY1,eX2,eY2,eX3,eY3))
		{
			if (enemydirection1 == 'u')
				enemydirection1 = 'l';
			else if (enemydirection1 == 'l')
				enemydirection1 = 'd';
				else if (enemydirection1 == 'd')
				enemydirection1 = 'r';
				else if (enemydirection1 == 'r')
				enemydirection1 = 'u';
		}
		moveenemyboss(board,enemy1,enemydirection1,eX1,eY1,enemywidth1,enemyheight1);}
		else
		{
			system("cls");
			setcolor(2);
			cout<<R"(
	
	
		 __     ______  _    _  __          ______  _   _ 
 		 \ \   / / __ \| |  | | \ \        / / __ \| \ | |
 		  \ \_/ / |  | | |  | |  \ \  /\  / / |  | |  \| |
		   \   /| |  | | |  | |   \ \/  \/ /| |  | | . ` |
 		    | | | |__| | |__| |    \  /\  / | |__| | |\  |
		    |_|  \____/ \____/      \/  \/   \____/|_| \_|
                                                  
                                                  
													)";;
score+=100;
cout<<"\n\n\n";
cout<<"\t\tYour Score is: "<<score;
Sleep(1500);
system("cls");
return 0;
			
		}
		if(healthe1>0){
		if((eX1==15||eX1==33||eY1==55)&&feY1==1){
		firee1=1;
		fireenemy1(player2D,pX,pY,eX1,eY1,feX1,feY1,healthp,firee1,selectplayer);}}	
		if(firee1==1){
			fireenemy1(player2D,pX,pY,eX1,eY1,feX1,feY1,healthp,firee1,selectplayer);
		}
		if(healthp==0){
		system("cls");
		setcolor(4);
		cout<<R"(
 __     __           _               _   
 \ \   / /          | |             | |  
  \ \_/ /__  _   _  | |     ___  ___| |_ 
   \   / _ \| | | | | |    / _ \/ __| __|
    | | (_) | |_| | | |___| (_) \__ \ |_ 
    |_|\___/ \__,_| |______\___/|___/\__|
                                         													)";;
cout<<"\n\n\n";
cout<<"  Your Score is: "<<score;
Sleep(1500);
system("cls");
		return 0;}
		Sleep(30);
	}
	return 0;
}
// This function will print header of game and input choice from user.
string printheader()
{
	setcolor(6);
	string option;
	while (true)
	{
		cout << R"(
 _____           _          ____        _   _   _         ____                           _
|_   _|_ _ _ __ | | _____  | __ )  __ _| |_| |_| | ___   / ___|_ __ ___  _   _ _ __   __| |
  | |/ _` | '_ \| |/ / __| |  _ \ / _` | __| __| |/ _ \ | |  _| '__/ _ \| | | | '_ \ / _` |
  | | (_| | | | |   <\__ \ | |_) | (_| | |_| |_| |  __/ | |_| | | | (_) | |_| | | | | (_| |
  |_|\__,_|_| |_|_|\_\___/ |____/ \__,_|\__|\__|_|\___|  \____|_|  \___/ \__,_|_| |_|\__,_|
																										)";
		;
		cout << "\n \n ";

		cout << R"(
  __     _____  _             
 /_ |   |  __ \| |            
  | |   | |__) | | __ _ _   _ 
  | |   |  ___/| |/ _` | | | |
  | |_  | |    | | (_| | |_| |
  |_(_) |_|    |_|\__,_|\__, |
                         __/ |
                        |___/ 

                         )";
		;
		cout << R"(

  ___       _____      _           _     _____  _                       
 |__ \     / ____|    | |         | |   |  __ \| |                      
    ) |   | (___   ___| | ___  ___| |_  | |__) | | __ _ _   _  ___ _ __ 
   / /     \___ \ / _ \ |/ _ \/ __| __| |  ___/| |/ _` | | | |/ _ \ '__|
  / /_ _   ____) |  __/ |  __/ (__| |_  | |    | | (_| | |_| |  __/ |   
 |____(_) |_____/ \___|_|\___|\___|\__| |_|    |_|\__,_|\__, |\___|_|   
                                                         __/ |          
                                                        |___/           
																			)";
		;
		cout << R"(


  ____     ______      _ _   
 |___ \   |  ____|    (_) |  
   __) |  | |__  __  ___| |_ 
  |__ <   |  __| \ \/ / | __|
  ___) |  | |____ >  <| | |_ 
 |____(_) |______/_/\_\_|\__|
                             
                             )";
		;
		cout << "\n\n Enter Option Number.";
		cin >> option;
		if (option == "1" || option == "2" || option == "3")
			return option;
		else
		{
			cout << "Invalid Input..";
			Sleep(500);
			system("cls");
		}
	}
	setcolor(7);
}
// This function will print the header of level 1.
void print1level()
{
	setcolor(2);
	cout << "\n \n ";
	cout << R"(
			 .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------.
			 | .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
			 | |   _____      | || |  _________   | || | ____   ____  | || |  _________   | || |   _____      | || |     __       | |
			 | |  |_   _|     | || | |_   ___  |  | || ||_  _| |_  _| | || | |_   ___  |  | || |  |_   _|     | || |    /  |      | |
			 | |    | |       | || |   | |_  \_|  | || |  \ \   / /   | || |   | |_  \_|  | || |    | |       | || |    `| |      | |
			 | |    | |   _   | || |   |  _|  _   | || |   \ \ / /    | || |   |  _|  _   | || |    | |   _   | || |     | |      | |
			 | |   _| |__/ |  | || |  _| |___/ |  | || |    \ ' /     | || |  _| |___/ |  | || |   _| |__/ |  | || |    _| |_     | |
			 | |  |________|  | || | |_________|  | || |     \_/      | || | |_________|  | || |  |________|  | || |   |_____|    | |
			 | |              | || |              | || |              | || |              | || |              | || |              | |
			 | '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
			  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'
																																		)";
	;
	cout << "\n \n ";
	setcolor(6);
	cout << R"(
							   _
			|   _  _  _| o __ (_|
			|__(_)(_|(_| | | |__| o  o  o
											)";
	;
setcolor(7);
	cout << "\n \n ";
}
//This function will print the header of level 2.
void print2level()
{
	setcolor(2);
 cout<<"\n \n ";
 cout<<R"(
 .----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .----------------. 
| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
| |   _____      | || |  _________   | || | ____   ____  | || |  _________   | || |   _____      | || |    _____     | |
| |  |_   _|     | || | |_   ___  |  | || ||_  _| |_  _| | || | |_   ___  |  | || |  |_   _|     | || |   / ___ `.   | |
| |    | |       | || |   | |_  \_|  | || |  \ \   / /   | || |   | |_  \_|  | || |    | |       | || |  |_/___) |   | |
| |    | |   _   | || |   |  _|  _   | || |   \ \ / /    | || |   |  _|  _   | || |    | |   _   | || |   .'____.'   | |
| |   _| |__/ |  | || |  _| |___/ |  | || |    \ ' /     | || |  _| |___/ |  | || |   _| |__/ |  | || |  / /____     | |
| |  |________|  | || | |_________|  | || |     \_/      | || | |_________|  | || |  |________|  | || |  |_______|   | |
| |              | || |              | || |              | || |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------' 
																																		)";;
 cout<<"\n \n ";
 setcolor(6);
cout<<R"(
							   _
			|   _  _  _| o __ (_|
			|__(_)(_|(_| | | |__| o  o  o
											)";;

 cout<<"\n \n ";
 setcolor(7);
}
// This function will print the header of level 1 won and take input.
string printlevel1won(int score)
{
	setcolor(6);
	string res;
	cout << "\n";
	while (true)
	{
		cout << R"(
	
	
		 __     ______  _    _  __          ______  _   _ 
 		 \ \   / / __ \| |  | | \ \        / / __ \| \ | |
 		  \ \_/ / |  | | |  | |  \ \  /\  / / |  | |  \| |
		   \   /| |  | | |  | |   \ \/  \/ /| |  | | . ` |
 		    | | | |__| | |__| |    \  /\  / | |__| | |\  |
		    |_|  \____/ \____/      \/  \/   \____/|_| \_|
                                                  
                                                  
													)";;
		cout << "\n\n\n";
		cout << "\t\t\t\tYour Score is: " << score;
		cout << "\n\n\n";
	cout<<R"(

    __     _____  _               _   _           _     _                    _ 
   /_ |   |  __ \| |             | \ | |         | |   | |                  | |
    | |   | |__) | | __ _ _   _  |  \| | _____  _| |_  | |     _____   _____| |
    | |   |  ___/| |/ _` | | | | | . ` |/ _ \ \/ / __| | |    / _ \ \ / / _ \ |
    | |_  | |    | | (_| | |_| | | |\  |  __/>  <| |_  | |___|  __/\ V /  __/ |
    |_(_) |_|    |_|\__,_|\__, | |_| \_|\___/_/\_\\__| |______\___| \_/ \___|_|
                           __/ |                                               
                          |___/                                                
)";;
		cout << "\n";
		cout << R"(

  ___      ______      _ _   
 |__ \    |  ____|    (_) |  
    ) |   | |__  __  ___| |_ 
   / /    |  __| \ \/ / | __|
  / /_ _  | |____ >  <| | |_ 
 |____(_) |______/_/\_\_|\__|
                             
                             
)";;
		cout << "\n\n\n";
		cout << "\t Enter Option Number: ";
		cin >> res;
		if (res == "1" || res == "2")
			return res;
		else
		{
			cout << "Invalid Input..";
			Sleep(500);
			system("cls");
		}
	}
	setcolor(7);
}
// This function will print the header of level 1 lost and take input.
string printlevel1lost(int score)
{
	setcolor(6);
	string res;
	cout << "\n";
	while (true)
	{
		cout << R"(
 __     __           _               _   
 \ \   / /          | |             | |  
  \ \_/ /__  _   _  | |     ___  ___| |_ 
   \   / _ \| | | | | |    / _ \/ __| __|
    | | (_) | |_| | | |___| (_) \__ \ |_ 
    |_|\___/ \__,_| |______\___/|___/\__|
                                         													)";
		;
		cout << "\n\n\n";
		cout << "\t\tYour Score is: " << score;
		cout << "\n\n\n";
		cout << R"(

  __     _____  _                                   _       
 /_ |   |  __ \| |                 /\              (_)      
  | |   | |__) | | __ _ _   _     /  \   __ _  __ _ _ _ __  
  | |   |  ___/| |/ _` | | | |   / /\ \ / _` |/ _` | | '_ \ 
  | |_  | |    | | (_| | |_| |  / ____ \ (_| | (_| | | | | |
  |_(_) |_|    |_|\__,_|\__, | /_/    \_\__, |\__,_|_|_| |_|
                         __/ |           __/ |              
                        |___/           |___/               
)";
		;
		cout << "\n";
		cout << R"(

  ___      ______      _ _   
 |__ \    |  ____|    (_) |  
    ) |   | |__  __  ___| |_ 
   / /    |  __| \ \/ / | __|
  / /_ _  | |____ >  <| | |_ 
 |____(_) |______/_/\_\_|\__|
                             
                             
)";
		;
		cout << "\n\n\n";
		cout << "\t Enter Option Number: ";
		cin >> res;
		if (res == "1" || res == "2")
			return res;
		else
		{
			cout << "Invalid Input..";
			Sleep(500);
			system("cls");
		}
	}
	setcolor(7);
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
// This function will draw maze of game.
void drawBoard(char board[][boardWidth], char player2D[][playerWidth], char enemy1[][enemywidth1], char enemy2[][enemywidth2], char enemy3[][enemywidth3], int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3, string selectplayer)
{
	SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 6);
	for (int i = 0; i < boardHeight; i++)
	{
		for (int j = 0; j < boardWidth; j++)
		{
			if (board[i][j] == 'p')
			{
				pX = i;
				pY = j;
				printPlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
			}
			if (board[i][j] == 'e')
			{
				eX1 = i;
				eY1 = j;
				printenemy1(enemy1, eX1, eY1, enemywidth1, enemyheight1);
			}
			if (board[i][j] == 'x')
			{
				eX2 = i;
				eY2 = j;
				printenemy2(enemy2, eX2, eY2, enemywidth2, enemyheight2);
			}
			if (board[i][j] == 'l')
			{
				eX3 = i;
				eY3 = j;
				printenemy3(enemy3, eX3, eY3, enemywidth3, enemyheight3);
			}
			else
			{
				gotoxy(j, i);
				cout << board[i][j];
			}
		}
	}
}

void gotoxy(int x, int y)
{
	COORD coordinates;
	coordinates.X = x;
	coordinates.Y = y;
	SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coordinates);
}
// This function will erase player.
void erasePlayer(char player2D[playerHeight][playerWidth], int &pX, int &pY, int playerWidth, int playerHeight, string selectplayer)
{
	for (int i = 0; i < playerHeight; i++)
	{
		for (int j = 0; j < playerWidth; j++)
		{
			gotoxy(pY + j, pX + i);
			cout << "        ";
		}
	}
}
// This function will print player.
void printPlayer(char player2D[playerHeight][playerWidth], int &pX, int &pY, int playerWidth, int playerHeight, string selectplayer)
{
	setcolor(2);
	for (int i = 0; i < playerHeight; i++)
	{
		for (int j = 0; j < playerWidth; j++)
		{
			gotoxy(pY + j, pX + i);
			cout << player2D[i][j];
		}
	}
	setcolor(7);
}
// This function will erase enemy1.
void eraseenemy1(char enemy1[enemyheight1][enemywidth1], int &eX1, int &eY1, int enemywidth1, int enemyheight1)
{
	for (int i = 0; i < enemyheight1; i++)
	{
		for (int j = 0; j < enemywidth1; j++)
		{
			gotoxy(eY1 + j, eX1 + i);
			cout << "   ";
		}
	}
}
// This function will print enemy1.
void printenemy1(char enemy1[enemyheight1][enemywidth1], int &eX1, int &eY1, int enemywidth1, int enemyheight1)
{
	setcolor(6);
	for (int i = 0; i < enemyheight1; i++)
	{
		for (int j = 0; j < enemywidth1; j++)
		{
			gotoxy(eY1 + j, eX1 + i);
			cout << enemy1[i][j];
		}
	}
	setcolor(7);
}
// This function will move enemy1.
void moveenemy1(char board[][boardWidth], char enemy1[enemyheight1][enemywidth1], char enemydirection1, int &eX1, int &eY1, int enemywidth1, int enemyheight1)
{
	if (enemydirection1 == 'u')
	{
		eraseenemy1(enemy1, eX1, eY1, enemywidth1, enemyheight1);
		board[eX1][eY1] = ' ';
		eX1 = eX1 - 1;
		board[eX1][eY1] = 'e';
	}
	else if (enemydirection1 == 'd')
	{
		eraseenemy1(enemy1, eX1, eY1, enemywidth1, enemyheight1);
		board[eX1][eY1] = ' ';
		eX1 = eX1 + 1;
		board[eX1][eY1] = 'e';
	}
	printenemy1(enemy1, eX1, eY1, enemywidth1, enemyheight1);
}
// This function will decide the direction of enemy1 depending on collision.
bool enemystrike1(char enemydirection1, char board[][boardWidth], int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3)
{
	if (eX3 > (eX1 - (enemyheight1 + 2)) && enemydirection1 == 'u')
		return true;
	else if (eX2 < (eX1 + enemyheight1 + 3) && enemydirection1 == 'd')
		return true;
	else
		return false;
}
//This function will move the enemy of level 2.
void moveenemyboss(char board[][boardWidth],char enemy1[enemyheight1][enemywidth1],char enemydirection1,int &eX1,int &eY1,int enemywidth1,int enemyheight1)
{
	if(enemydirection1=='u')
	{
		eraseenemy1(enemy1,eX1,eY1,enemywidth1,enemyheight1);
        board[eX1][eY1]=' ';
        eX1 = eX1 - 1;
        board[eX1][eY1]='e';
	}
	else if(enemydirection1=='d')
	{
		eraseenemy1(enemy1,eX1,eY1,enemywidth1,enemyheight1);
        board[eX1][eY1]=' ';
        eX1 = eX1 + 1;
        board[eX1][eY1]='e';
	}
	else if(enemydirection1=='l')
	{
		eraseenemy1(enemy1,eX1,eY1,enemywidth1,enemyheight1);
		board[eX1][eY1]=' ';
        eY1 = eY1 - 1;
        board[eX1][eY1]='e';
	}
	else if(enemydirection1=='r')
	{
		eraseenemy1(enemy1,eX1,eY1,enemywidth1,enemyheight1);
		board[eX1][eY1]=' ';
        eY1 = eY1 + 1;
        board[eX1][eY1]='e';
	}
	printenemy1(enemy1,eX1,eY1,enemywidth1,enemyheight1);
}
//This function will decide the directioon of movement of enemy of level2.
bool enemystrikeboss(char enemydirection1,char board[][boardWidth],int &pX,int &pY,int &eX1,int &eY1,int & eX2,int &eY2,int &eX3,int &eY3)
{
	if(eX1<4&&enemydirection1=='u')
	return true;
	if(eX1>35&&enemydirection1=='d')
	return true;
	if(eY1<45&&enemydirection1=='l')
	return true;
	if(eY1>111&&enemydirection1=='r')
	return true;
	else
	return false;	
}
//This function is used for firing of player in level2.
void fireplayerboss(char enemy1[enemyheight1][enemywidth1],char enemy2[enemyheight2][enemywidth2],char enemy3[enemyheight3][enemywidth3],int &fpX,int &fpY,int &pX,int &pY,int &eX1,int &eY1,int &eX2,int &eY2,int &eX3,int &eY3,int &score,int &healthp,int &healthe1,int &healthe2,int &healthe3,int &firep,int &enemycount)
{
	if(fpX==0){
	fpX = pX + 1;
	fpY = pY + playerWidth;
	gotoxy(fpY,fpX);
	cout<<"#";
	gotoxy(fpY,fpX);
	cout<<" ";
	fpY++;	
	}
	if(getCharAtxy(fpY, fpX) == ' '){
		gotoxy(fpY-1, fpX);
		cout << " ";
		gotoxy(fpY, fpX);
		cout << "#";
		fpY++;}
		else
		{
		gotoxy(fpY-1,fpX);
		cout<<" ";
		if (getCharAtxy(fpY, fpX) != '#'){
		healthe1-=100;
		gotoxy(95,1);
    cout<<"Enemy Health="<<healthe1;}
		fpX=0;
		fpY=1;
		firep=0;
	}
}
// This function will erase enemy2.
void eraseenemy2(char enemy2[enemyheight2][enemywidth2], int &eX2, int &eY2, int enemywidth2, int enemyheight2)
{
	for (int i = 0; i < enemyheight2; i++)
	{
		for (int j = 0; j < enemywidth2; j++)
		{
			gotoxy(eY2 + j, eX2 + i);
			cout << " ";
		}
	}
}
// This function will print enemy2.
void printenemy2(char enemy2[enemyheight2][enemywidth2], int &eX2, int &eY2, int enemywidth2, int enemyheight2)
{
	setcolor(4);
	for (int i = 0; i < enemyheight2; i++)
	{
		for (int j = 0; j < enemywidth2; j++)
		{
			gotoxy(eY2 + j, eX2 + i);
			cout << enemy2[i][j];
		}
	}
	setcolor(7);
}
// This function will move enemy2.
void moveenemy2(char board[][boardWidth], char enemy2[enemyheight2][enemywidth2], char enemydirection2, int &eX2, int &eY2, int enemywidth2, int enemyheight2)
{
	if (enemydirection2 == 'l')
	{
		eraseenemy2(enemy2, eX2, eY2, enemywidth2, enemyheight2);
		board[eX2][eY2] = ' ';
		eY2 = eY2 - 1;
		board[eX2][eY2] = 'e';
	}
	else if (enemydirection2 == 'r')
	{
		eraseenemy2(enemy2, eX2, eY2, enemywidth2, enemyheight2);
		board[eX2][eY2] = ' ';
		eY2 = eY2 + 1;
		board[eX2][eY2] = 'e';
	}
	printenemy2(enemy2, eX2, eY2, enemywidth2, enemyheight2);
}
// This function will decide the direction of enemy2 depending on collision.
bool enemystrike2(char enemydirection2, char board[][boardWidth], int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3)
{
	if (eY2 < (playerWidth + 12) && enemydirection2 == 'l')
		return true;
	else if (board[eX2][eY2 + enemywidth2 + 1] != ' ' && enemydirection2 == 'r')
		return true;
	else
		return false;
}
// This function will erase enemy3.
void eraseenemy3(char enemy3[enemyheight3][enemywidth3], int &eX3, int &eY3, int enemywidth3, int enemyheight3)
{
	for (int i = 0; i < enemyheight3; i++)
	{
		for (int j = 0; j < enemywidth3; j++)
		{
			gotoxy(eY3 + j, eX3 + i);
			cout << "  ";
		}
	}
}
// This function will print enemy3.
void printenemy3(char enemy3[enemyheight3][enemywidth3], int &eX3, int &eY3, int enemywidth3, int enemyheight3)
{
	setcolor(1);
	for (int i = 0; i < enemyheight3; i++)
	{
		for (int j = 0; j < enemywidth3; j++)
		{
			gotoxy(eY3 + j, eX3 + i);
			cout << enemy3[i][j];
		}
	}
	setcolor(7);
}
// This function will move enemy3.
void moveenemy3(char board[][boardWidth], char enemy3[enemyheight3][enemywidth3], char enemydirection3, int &eX3, int &eY3, int enemywidth3, int enemyheight3)
{
	if (enemydirection3 == 'l')
	{
		eraseenemy3(enemy3, eX3, eY3, enemywidth3, enemyheight3);
		board[eX3][eY3] = ' ';
		eY3 = eY3 - 1;
		board[eX3][eY3] = 'e';
	}
	else if (enemydirection3 == 'r')
	{
		eraseenemy3(enemy3, eX3, eY3, enemywidth3, enemyheight3);
		board[eX3][eY3] = ' ';
		eY3 = eY3 + 1;
		board[eX3][eY3] = 'e';
	}
	printenemy3(enemy3, eX3, eY3, enemywidth3, enemyheight3);
}
// This function will decide the direction of enemy3 depending on collision.
bool enemystrike3(char enemydirection3, char board[][boardWidth], int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3)
{
	if (eY3 < (playerWidth + 12) && enemydirection3 == 'l')
		return true;
	else if (board[eX3][eY3 + enemywidth3 + 1] != ' ' && enemydirection3 == 'r')
		return true;
	else
		return false;
}
// With this function player1 will fire.
void fireplayer(char enemy1[enemyheight1][enemywidth1], char enemy2[enemyheight2][enemywidth2], char enemy3[enemyheight3][enemywidth3], int &fpX, int &fpY, int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3, int &score, int &healthp, int &healthe1, int &healthe2, int &healthe3, int &firep, int &enemycount)
{
	if (fpX == 0)
	{
		fpX = pX + 1;
		fpY = pY + playerWidth;
		gotoxy(fpY, fpX);
		cout << "#";
		gotoxy(fpY, fpX);
		cout << " ";
		fpY++;
	}
	if (getCharAtxy(fpY, fpX) == ' ')
	{
		gotoxy(fpY - 1, fpX);
		cout << " ";
		gotoxy(fpY, fpX);
		cout << "#";
		fpY++;
	}
	else
	{
		gotoxy(fpY - 1, fpX);
		cout << " ";
		if (getCharAtxy(fpY, fpX) != '#')
			firehitenemy(enemy1, enemy2, enemy3, fpX, fpY, pX, pY, eX1, eY1, eY1, eY2, eX3, eY3, score, healthp, healthe1, healthe2, healthe3, enemycount);
		fpX = 0;
		fpY = 1;
		firep = 0;
	}
}
// With this function enemy1 will fire.
void fireenemy1(char player2D[playerHeight][playerWidth], int pX, int pY, int &eX1, int &eY1, int &feX1, int &feY1, int &healthp, int &firee1, string selectplayer)
{
	if (feX1 == 0)
	{
		feX1 = eX1 + 2;
		feY1 = eY1 - 2;
		gotoxy(feY1, feX1);
		cout << "#";
		gotoxy(feY1, feX1);
		cout << " ";
		feY1--;
	}
	if (getCharAtxy(feY1, feX1) == ' ')
	{
		gotoxy(feY1 + 1, feX1);
		cout << " ";
		gotoxy(feY1, feX1);
		cout << "#";
		feY1--;
	}
	else
	{
		gotoxy(feY1 + 1, feX1);
		cout << " ";
		if (getCharAtxy(feY1, feX1) != '#')
		{
			healthp = healthp - 100;
			gotoxy(1, 1);
			cout << "Player Health= " << healthp;
		}
		if (healthp == 0)
			erasePlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
		feX1 = 0;
		feY1 = 1;
		firee1 = 0;
	}
}
// With this function enemy2 will fire.
void fireenemy2(char player2D[playerHeight][playerWidth], int pX, int pY, int &eX2, int &eY2, int &feX2, int &feY2, int &healthp, int &firee2, string selectplayer)
{
	if (feX2 == 0)
	{
		feX2 = eX2 + 2;
		feY2 = eY2 - 2;
		gotoxy(feY2, feX2);
		cout << "#";
		gotoxy(feY2, feX2);
		cout << " ";
		feY2--;
	}
	if (getCharAtxy(feY2, feX2) == ' ')
	{
		gotoxy(feY2 + 1, feX2);
		cout << " ";
		gotoxy(feY2, feX2);
		cout << "#";
		feY2--;
	}
	else
	{
		gotoxy(feY2 + 1, feX2);
		cout << " ";
		if (getCharAtxy(feY2, feX2) != '#')
		{
			healthp = healthp - 100;
			gotoxy(1, 1);
			cout << "Player Health= " << healthp;
		}
		if (healthp == 0)
			erasePlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
		feX2 = 0;
		feY2 = 1;
		firee2 = 0;
	}
}
// With this function enemy3 will fire.
void fireenemy3(char player2D[playerHeight][playerWidth], int pX, int pY, int &eX3, int &eY3, int &feX3, int &feY3, int &healthp, int &firee3, string selectplayer)
{
	if (feX3 == 0)
	{
		feX3 = eX3 + 1;
		feY3 = eY3 - 2;
		gotoxy(feY3, feX3);
		cout << "#";
		gotoxy(feY3, feX3);
		cout << " ";
		feY3--;
	}
	if (getCharAtxy(feY3, feX3) == ' ')
	{
		gotoxy(feY3 + 1, feX3);
		cout << " ";
		gotoxy(feY3, feX3);
		cout << "#";
		feY3--;
	}
	else
	{
		gotoxy(feY3 + 1, feX3);
		cout << " ";
		if (getCharAtxy(feY3, feX3) != '#' && getCharAtxy(feY3, feX3) != 'H')
		{
			healthp = healthp - 100;
			gotoxy(1, 1);
			cout << "Player Health= " << healthp;
		}
		if (healthp == 0)
			erasePlayer(player2D, pX, pY, playerWidth, playerHeight, selectplayer);
		feX3 = 0;
		feY3 = 1;
		firee3 = 0;
	}
}
// This function will detect that the fire of player hits which enemy.
void firehitenemy(char enemy1[enemyheight1][enemywidth1], char enemy2[enemyheight2][enemywidth2], char enemy3[enemyheight3][enemywidth3], int fpX, int fpY, int &pX, int &pY, int &eX1, int &eY1, int &eX2, int &eY2, int &eX3, int &eY3, int &score, int &healthp, int &healthe1, int &healthe2, int &healthe3, int &enemycount)
{
	if (fpX > 3 && fpX < 9)
	{
		healthe3 -= 100;
		gotoxy(123, 1);
		cout << "Enemy3 Health=" << healthe3;
		if (healthe3 == 0)
		{
			score += 100;
			gotoxy(30, 1);
			cout << "Score=" << score;
			eraseenemy3(enemy3, eX3, eY3, enemywidth3, enemyheight3);
			enemycount--;
		}
	}
	else if (fpX > 36 && fpX < 46)
	{
		healthe2 -= 100;
		gotoxy(95, 1);
		cout << "Enemy2 Health=" << healthe2;
		if (healthe2 == 0)
		{
			score += 100;
			gotoxy(30, 1);
			cout << "Score=" << score;
			eraseenemy2(enemy2, eX2, eY2, enemywidth2, enemyheight2);
			enemycount--;
		}
	}
	else if (fpX > 9 && fpX < 36)
	{
		healthe1 -= 100;
		gotoxy(70, 1);
		cout << "Enemy1 Health=" << healthe1;
		if (healthe1 == 0)
		{
			score += 100;
			gotoxy(30, 1);
			cout << "Score=" << score;
			eraseenemy1(enemy1, eX1, eY1, enemywidth1, enemyheight1);
			enemycount--;
		}
	}
}
// This function will allow user to select favourite player
string selectedplayer()
{
	setcolor(2);
	string player;
	while (true)
	{
		cout << "\n\n";
		cout << R"(
    _____      _           _     _____  _                       
   / ____|    | |         | |   |  __ \| |                      
  | (___   ___| | ___  ___| |_  | |__) | | __ _ _   _  ___ _ __ 
   \___ \ / _ \ |/ _ \/ __| __| |  ___/| |/ _` | | | |/ _ \ '__|
   ____) |  __/ |  __/ (__| |_  | |    | | (_| | |_| |  __/ |   
  |_____/ \___|_|\___|\___|\__| |_|    |_|\__,_|\__, |\___|_|   
                                                 __/ |          
                                                |___/           
                                                )";
		;
		cout << "\n\n";
		cout << "	\t\t_\______   \n";
		cout << " \t\t     /  1     \========\n";
		cout << "\t\t ____|__________\\_____ \n";
		cout << "\t\t/ ___________________ \ \n";
		cout << "\t\t\/ _===============_ \/ \n";
		cout << " \t\t|-===============-|    \n";
		cout << "\n\n";
		cout << "\t\t	 _\--__        \n";
		cout << "\t\t      // 2    \\_______        \n";
		cout << "\t\t     __|_______|_ _ _ _|      \n";
		cout << "\t\t	///------------\\  \n";
		cout << "\t\t....\\____________/ \n";
		cout << "\n\n";
		cout << "\t\t    ____     \n";
		cout << "\t\t  _|___3|====== \n";
		cout << "\t\t| _______\\ \\  \n";
		cout << "\t\t| 0 | 0| \\0\n";
		cout << "\n\n\n";
		cout << "Enter the number of player you want to select: ";
		cin >> player;
		if (player == "1" || player == "2" || player == "3")
			return player;
		else
			cout << "Invalid Input";
		Sleep(1500);
		setcolor(7);
		system("cls");
	}
}

