#include<iostream>
#include<stdio.h>
#include<conio.h>
#include<sstream>
#include<fstream>
#include<windows.h>
#include<iomanip>
#include <cstdlib>
#include<string>
using namespace std;
bool signinhead(string name[],int password[],string role[],string &option,int &s,int &i,int &c);
bool signin(string name[],int password[],string role[],int &s,int &i,int &c,string signinname,int signinpassword);
void signuphead(string name[],int password[],string role[],string &option,int &s,int &i,int &c);
void signup(string name[],int password[],string role[],int &s,int &i,int &c,string signupname,int signuppassword);
bool checkvalidation(string enter);
bool checkvalid(string na);
bool checkvpass(string enter);
string manager();
string client();
bool viewaccounts(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c);
void viewtotal(string name[],int password[],string role[],int balance[],int loan[],int &s,int &i,int &c);
bool openaccount(string name[],int password[],string role[],int &s,int &i,int &c);
bool deleteaccount(string name[],int password[],string role[],int balance[],int loan[],string debit[],int &s,int &i,int &c);
bool hirestaff(string staff[],string des[],int &s,int &i,int &c);
void header();
bool expelstaff(string staff[],string des[],int &s,int &i,int &c);
bool viewstaff(string staff[],string des[],int &s,int &i,int &c);
bool blockdebit(string name[],int password[],string role[],string debit[],int &s,int &i,int &c);
bool viewcomplaints(string name[],int password[],string role[],string complaints[],int &s,int &i,int &c);
void viewrecord(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c);
bool depositmoney(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c);
bool withdrawmoney(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c);
void exchangecurrency();
bool transfermoney(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],string &welfare,int &s,int &i,int &c);
bool debitcard(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c);
bool getloan(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c);
void payloan(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c);
bool submitcomplaint(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c);
bool exit();
void saverecordstofile(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],string staff[],string des[],int s,int i,int c);
void loadrecords(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],string staff[],string des[],int &s,int &i,int &c);
string getField(string record, int field);
main()
{
	int s=0;
	string name[10];
	int i=0;
	int c=0;
	string resc;
	string resm;
	string welfare;
	string option;
	string staff[10];
	string des[10];
	int password[10];
	string role[10];
	int balance[10]={0,0,0,0,0,0,0,0,0,0};
	int loan[10]={0,0,0,0,0,0,0,0,0,0};
	string debit[10]={"N/A","N/A","N/A","N/A","N/A","N/A","N/A","N/A","N/A","N/A"};
	string complaints[10];
	loadrecords(name,password,role,balance,loan,complaints,debit,staff,des,s,i,c);
	//This loop will continuously display user their respective menu and take input from user until the user press exit.
	while(1)
	{
	system("cls");
	header();
	cout << endl << endl;
	while(true){
	 cout <<"\t\t\t\t\t\t  _     _     ___   ____ ___ _   _           "<<endl;
    cout <<"\t\t\t\t\t\t / |   | |   / _ \\ / ___|_ _| \\ | |          "<<endl;
    cout <<"\t\t\t\t\t\t | |   | |  | | | | |  _ | ||  \\| |          "<<endl;
    cout <<"\t\t\t\t\t\t | |_  | |__| |_| | |_| || || |\\  |          "<<endl;
    cout <<"\t\t\t\t\t\t |_(_) |_____\\___/ \\____|___|_| \\_|         "<<endl;
    cout << endl;
    cout <<"\t\t\t\t\t\t ____      ____  _               _   _       "<<endl;  
    cout <<"\t\t\t\t\t\t|___ \\    / ___|(_) __ _ _ __   | | | |_ __  "<<endl;
    cout <<"\t\t\t\t\t\t  __) |   \\___ \\| |/ _` | '_ \\  | | | | '_ \\ "<<endl;
    cout <<"\t\t\t\t\t\t / __/ _   ___) | | (_| | | | | | |_| | |_) |"<<endl;
    cout <<"\t\t\t\t\t\t|_____(_) |____/|_|\\__, |_| |_|  \\___/| .__/ "<<endl;
    cout <<"\t\t\t\t\t\t                   |___/              |_|    "<<endl;
    cout << endl;
    cout <<"\t\t\t\t\t\t _____    _____      _ _                   "<<endl;
    cout <<"\t\t\t\t\t\t|___ /   | ____|_  _(_) |_                   "<<endl;
    cout <<"\t\t\t\t\t\t  |_ \\   |  _| \\ \\/ / | __|                  "<<endl;
    cout <<"\t\t\t\t\t\t ___) |  | |___ >  <| | |_                   "<<endl;
    cout <<"\t\t\t\t\t\t|____(_) |_____/_/\\_\\_|\\__|                  "<<endl;
    cout <<"\t\t\t\t\t\t                                             "<<endl;
    cout << endl << endl;
	cout<<" \t\t\t\t\t\tEnter Option: ";
	cin>>option;
	if(option=="1"||option=="2"||option=="3")
	break;
	else{
	cout<<" Invalid Input.";
	cout<<" \n\nPress any key to continue.";
	getch();
	system("cls");
	}
	}
	system("cls");
	if(option=="1")
	{
	 cout <<"\t\t\t\t\t\t _     _     ___   ____ ___ _   _           "<<endl;
    cout <<"\t\t\t\t\t\t / |   | |   / _ \\ / ___|_ _| \\ | |          "<<endl;
    cout <<"\t\t\t\t\t\t | |   | |  | | | | |  _ | ||  \\| |          "<<endl;
    cout <<"\t\t\t\t\t\t | |_  | |__| |_| | |_| || || |\\  |          "<<endl;
    cout <<"\t\t\t\t\t\t |_(_) |_____\\___/ \\____|___|_| \\_|         "<<endl;
    cout << endl;
		cout<<"\n\n";
		if(signinhead(name,password,role,option,s,i,c))
		{
		cout<<" Congratulations! "<<name[c] <<" You are signed in successfully.";
			if(role[c]=="Client"||role[c]=="client")
			{
			//This if statement will take user to Client menu.
			Sleep(1500);
			system("cls");
			while(true)
			{
			resc=client();
				if(resc=="1")
				{
				system("cls");
		cout<<R"(
   __      __ _                                                              _      _____  _           _               
   \ \    / /(_)                     /\                                     | |    / ____|| |         | |              
    \ \  / /  _   ___ __      __    /  \     ___   ___   ___   _   _  _ __  | |_  | (___  | |_   __ _ | |_  _   _  ___ 
     \ \/ /  | | / _ \\ \ /\ / /   / /\ \   / __| / __| / _ \ | | | || '_ \ | __|  \___ \ | __| / _` || __|| | | |/ __|
      \  /   | ||  __/ \ V  V /   / ____ \ | (__ | (__ | (_) || |_| || | | || |_   ____) || |_ | (_| || |_ | |_| |\__ \
       \/    |_| \___|  \_/\_/   /_/    \_\ \___| \___| \___/  \__,_||_| |_| \__| |_____/  \__| \__,_| \__| \__,_||___/
                                                                                                                    
                                                                                                                    				     	)";;
				cout<<"\n\n\n";	
				viewrecord(name,password,role,balance,loan,complaints,debit,s,i,c);
				}
				if(resc=="2")
				{
				system("cls");
		cout<<R"(
   				   	    _____                            _  _     __  __                            
   				   	   |  __ \                          (_)| |   |  \/  |                           
   				   	   | |  | |  ___  _ __    ___   ___  _ | |_  | \  / |  ___   _ __    ___  _   _ 
   				   	   | |  | | / _ \| '_ \  / _ \ / __|| || __| | |\/| | / _ \ | '_ \  / _ \| | | |
   				   	   | |__| ||  __/| |_) || (_) |\__ \| || |_  | |  | || (_) || | | ||  __/| |_| |
   				   	   |_____/  \___|| .__/  \___/ |___/|_| \__| |_|  |_| \___/ |_| |_| \___| \__, |
   				   	                 | |                                                       __/ |
   				   	                 |_|                                                      |___/ 
										   																		)";;
				cout<<"\n\n\n";						
				if(depositmoney(name,password,role,balance,loan,complaints,debit,s,i,c))
				cout<<" Your Amount is successfully deposited.Now your Current Balance is: "<<balance[c];
				}
				if(resc=="3")
				{
				system("cls");
		cout<<R"(
__          __ _  _    _          _                          __  __                            
\ \        / /(_)| |  | |        | |                        |  \/  |                           
 \ \  /\  / /  _ | |_ | |__    __| | _ __   __ _ __      __ | \  / |  ___   _ __    ___  _   _ 
  \ \/  \/ /  | || __|| '_ \  / _` || '__| / _` |\ \ /\ / / | |\/| | / _ \ | '_ \  / _ \| | | |
   \  /\  /   | || |_ | | | || (_| || |   | (_| | \ V  V /  | |  | || (_) || | | ||  __/| |_| |
    \/  \/    |_| \__||_| |_| \__,_||_|    \__,_|  \_/\_/   |_|  |_| \___/ |_| |_| \___| \__, |
                                                               				  _/ |
                                                              			  	 |___/ 

										   																		)";;
				cout<<"\n\n\n";	
				if(withdrawmoney(name,password,role,balance,loan,complaints,debit,s,i,c))
				cout<<" Your Amount is successfully withdraw.Now your Current Balance is: "<<balance[c];
				else
				cout<<" Sorry! You don't have enough balance.";
				}
				if(resc=="4")
				{
				system("cls");
				cout<<R"(
 _______                            __               __  __                            
|__   __|                          / _|             |  \/  |                           
   | |    _ __   __ _  _ __   ___ | |_   ___  _ __  | \  / |  ___   _ __    ___  _   _ 
   | |   | '__| / _` || '_ \ / __||  _| / _ \| '__| | |\/| | / _ \ | '_ \  / _ \| | | |
   | |   | |   | (_| || | | |\__ \| |  |  __/| |    | |  | || (_) || | | ||  __/| |_| |
   |_|   |_|    \__,_||_| |_||___/|_|   \___||_|    |_|  |_| \___/ |_| |_| \___| \__, |
                                                        			 __/ |
                                                       				|___/ 


										   																				)";;
				cout<<"\n\n\n";	
				if(transfermoney(name,password,role,balance,loan,complaints,debit,welfare,s,i,c))
				cout<<" Your donations is successfully transfered to "<<welfare<<". Now your Current Balance is: "<<balance[c];
				else
				cout<<" Sorry! You don't have enough balance.";
				}
				if(resc=="5")
				{
				system("cls");
				cout<<R"(
   _____        _     _____         _      _  _      _____                   _ 
  / ____|      | |   |  __ \       | |    (_)| |    / ____|                 | |
 | |  __   ___ | |_  | |  | |  ___ | |__   _ | |_  | |       __ _  _ __   __| |
 | | |_ | / _ \| __| | |  | | / _ \| '_ \ | || __| | |      / _` || '__| / _` |
 | |__| ||  __/| |_  | |__| ||  __/| |_) || || |_  | |____ | (_| || |   | (_| |
  \_____| \___| \__| |_____/  \___||_.__/ |_| \__|  \_____| \__,_||_|    \__,_|
                                                                              


										   																				)";;
				cout<<"\n\n\n";	
				if(debitcard(name,password,role,balance,loan,complaints,debit,s,i,c))
				cout<<" Congratulations!Your "<<debit[c]<<" card has been issued.";
				else
				cout<<" Sorry! Your monthly salary is insufficient.";
				}
				if(resc=="6")
				{
				system("cls");
				cout<<R"(
   				   	                 _____        _     _                           
   				   	                / ____|      | |   | |                          
   				   	               | |  __   ___ | |_  | |       ___    __ _  _ __  
   				   	               | | |_ | / _ \| __| | |      / _ \  / _` || '_ \ 
   				   	               | |__| ||  __/| |_  | |____ | (_) || (_| || | | |
   				   	                \_____| \___| \__| |______| \___/  \__,_||_| |_|
                                                 


										   																				)";;
				cout<<"\n\n\n";
				if(getloan(name,password,role,balance,loan,complaints,debit,s,i,c))
				cout<<" Congratulations!Your "<<loan[c]<<" loan has been approved.";
				else
				cout<<" Sorry! Your monthly salary is insufficient.";
				}
				if(resc=="7")
				{
				system("cls");
				cout<<R"(
                         _____                  _                           
                        |  __ \                | |                          
                        | |__) |  __ _  _   _  | |       ___    __ _  _ __  
                        |  ___/  / _` || | | | | |      / _ \  / _` || '_ \ 
                        | |     | (_| || |_| | | |____ | (_) || (_| || | | |
                        |_|      \__,_| \__, | |______| \___/  \__,_||_| |_|
 	                                 __/ |                              
                                        |___/                               

                                                 


										   																				)";;
				cout<<"\n\n\n";
				payloan(name,password,role,balance,loan,complaints,debit,s,i,c);
				}
				if(resc=="8")
				{
				system("cls");
				cout<<R"(
 ______              _                                   _____                                              
|  ____|            | |                                 / ____|                                             
| |__   __  __  ___ | |__    __ _  _ __    __ _   ___  | |      _   _  _ __  _ __   ___  _ __    ___  _   _ 
|  __|  \ \/ / / __|| '_ \  / _` || '_ \  / _` | / _ \ | |     | | | || '__|| '__| / _ \| '_ \  / __|| | | |
| |____  >  < | (__ | | | || (_| || | | || (_| ||  __/ | |____ | |_| || |   | |   |  __/| | | || (__ | |_| |
|______|/_/\_\ \___||_| |_| \__,_||_| |_| \__, | \___|  \_____| \__,_||_|   |_|    \___||_| |_| \___| \__, |
   	                                    / |                                                       __/ |
   	                                  |___/                                                       |___/ 


                                                 																									)";;
				cout<<"\n\n";
				exchangecurrency();
				}
				if(resc=="9")
				{
				system("cls");
				cout<<R"(
 _____          _                 _  _      _____                           _         _         _        
/ ____|        | |               (_)| |    / ____|                         | |       (_)       | |       
| (___   _   _ | |__   _ __ ___   _ | |_  | |       ___   _ __ ___   _ __  | |  __ _  _  _ __  | |_  ___ 
 \___ \ | | | || '_ \ | '_ ` _ \ | || __| | |      / _ \ | '_ ` _ \ | '_ \ | | / _` || || '_ \ | __|/ __|
___) || |_| || |_) || | | | | | | || |_ |  |____  |  (_) || | | | | || |_) |||| (_| || || | | || |_ \_ _\
|_____/  \__,_||_.__/ |_| |_| |_||_| \__|  \_____| \___/ |_| |_| |_|| .__/ |_| \__,_||_||_| |_| \__||___/
                                                                    | |                                  
                                                                    |_|                                  
 

																																							)";;
				cout<<"\n\n";
				if(submitcomplaint(name,password,role,balance,loan,complaints,debit,s,i,c))
				cout<<" Your Complaint has been submitted. We will try to resolve it as early as possible.";
				}
				if(resc=="10")
				{
				system("cls");
				if(exit())
				break;
				}
			cout<<" \n\n Press any key to continue: "<<endl;
			getch();
			system("cls");
			}
		}
			else if(role[c]=="Manager"||role[c]=="manager")
			{
			//This if statement will take user to Manager menu.
			Sleep(1500);
			system("cls");
			while(true)
			{	
			resm=manager();
				if(resm=="1")
				{
				system("cls");
			cout<<R"(
__      __ _                                                              _        
\ \    / /(_)                     /\                                     | |       
 \ \  / /  _   ___ __      __    /  \     ___   ___   ___   _   _  _ __  | |_  ___ 
  \ \/ /  | | / _ \\ \ /\ / /   / /\ \   / __| / __| / _ \ | | | || '_ \ | __|/ __|
   \  /   | ||  __/ \ V  V /   / ____ \ | (__ | (__ | (_) || |_| || | | || |_ \__ \
    \/    |_| \___|  \_/\_/   /_/    \_\ \___| \___| \___/  \__,_||_| |_| \__||___/
                                                                                   
																						)";;

				cout<<"\n\n";
				if(viewaccounts(name,password,role,balance,loan,complaints,debit,s,i,c))
				cout<<" No Clients available.";
				}
				if(resm=="2")
				{
				system("cls");
			cout<<R"(
   			           ____                                                                   _   
   				   	  / __ \                          /\                                     | |  
   				   	 | |  | | _ __    ___  _ __      /  \     ___   ___   ___   _   _  _ __  | |_ 
   				   	 | |  | || '_ \  / _ \| '_ \    / /\ \   / __| / __| / _ \ | | | || '_ \ | __|
   				   	 | |__| || |_) ||  __/| | | |  / ____ \ | (__ | (__ | (_) || |_| || | | || |_ 
   				   	  \____/ | .__/  \___||_| |_| /_/    \_\ \___| \___| \___/  \__,_||_| |_| \__|
   				   	         | |                                                                  
   				   	         |_|                                                              
                                                                                   
																																				)";;

				cout<<"\n\n";
				if(openaccount(name,password,role,s,i,c)){
				cout<<" Account of Client "<<name[c]<<" is  successfully Opened. ";
				}
				}
				if(resm=="3")
				{
				system("cls");
				cout<<R"(
   				 _____         _        _                                                      _   
   				|  __ \       | |      | |             /\                                     | |  
   				| |  | |  ___ | |  ___ | |_   ___     /  \     ___   ___   ___   _   _  _ __  | |_ 
   				| |  | | / _ \| | / _ \| __| / _ \   / /\ \   / __| / __| / _ \ | | | || '_ \ | __|
   				| |__| ||  __/| ||  __/| |_ |  __/  / ____ \ | (__ | (__ | (_) || |_| || | | || |_ 
   				|_____/  \___||_| \___| \__| \___| /_/    \_\ \___| \___| \___/  \__,_||_| |_| \__|
                                                                                   

                                                                                   
																																				)";;

				cout<<"\n\n";
				if(deleteaccount(name,password,role,balance,loan,debit,s,i,c))
				cout<<" Sorry! The client you want to delete does not exist.";
				}
				if(resm=="4")
				{
				system("cls");
				cout<<R"(
				__      __ _                   _______         _           _   ____          _                           
				\ \    / /(_)                 |__   __|       | |         | | |  _ \        | |                          
				 \ \  / /  _   ___ __      __    | |     ___  | |_   __ _ | | | |_) |  __ _ | |  __ _  _ __    ___   ___ 
				  \ \/ /  | | / _ \\ \ /\ / /    | |    / _ \ | __| / _` || | |  _ <  / _` || | / _` || '_ \  / __| / _ \
				   \  /   | ||  __/ \ V  V /     | |   | (_) || |_ | (_| || | | |_) || (_| || || (_| || | | || (__ |  __/
				    \/    |_| \___|  \_/\_/      |_|    \___/  \__| \__,_||_| |____/  \__,_||_| \__,_||_| |_| \___| \___|
                                                                                   

                                                                                   
																																				)";;
				viewtotal(name,password,role,balance,loan,s,i,c);
				}
				if(resm=="5")
				{
				system("cls");
				cout<<R"(
	            __      __ _                    _____                           _         _         _        
				\ \    / /(_)                  / ____|                         | |       (_)       | |       
				 \ \  / /  _   ___ __      __ | |       ___   _ __ ___   _ __  | |  __ _  _  _ __  | |_  ___ 
				  \ \/ /  | | / _ \\ \ /\ / / | |      / _ \ | '_ ` _ \ | '_ \ | | / _` || || '_ \ | __|/ __|
				   \  /   | ||  __/ \ V  V /  | |____ | (_) || | | | | || |_) || || (_| || || | | || |_ \__ \
				    \/    |_| \___|  \_/\_/    \_____| \___/ |_| |_| |_|| .__/ |_| \__,_||_||_| |_| \__||___/
                                                       					| |                                  
                                                        				|_| 
                                                                                                         
                                                                                   

                                                                                   
																																							)";;

				cout<<"\n\n";
				if(viewcomplaints(name,password,role,complaints,s,i,c))
				cout<<" No Complaints available.";
				}
				if(resm=="6")
				{
				system("cls");
				cout<<R"(
                           ____   _               _      _____         _      _  _   
                          |  _ \ | |             | |    |  __ \       | |    (_)| |  
                          | |_) || |  ___    ___ | | __ | |  | |  ___ | |__   _ | |_ 
                          |  _ < | | / _ \  / __|| |/ / | |  | | / _ \| '_ \ | || __|
                          | |_) || || (_) || (__ |   <  | |__| ||  __/| |_) || || |_ 
                          |____/ |_| \___/  \___||_|\_\ |_____/  \___||_.__/ |_| \__|       

                                                                                   

                                                                                   
																																				)";;
				cout<<"\n\n";
				if(blockdebit(name,password,role,debit,s,i,c))
				cout<<" The Client whose debit card you want to block does not exist.";
				}
				if(resm=="7")
				{
				system("cls");
				cout<<R"(
                                _    _  _                _____  _            __   __ 
                               | |  | |(_)              / ____|| |          / _| / _|
                               | |__| | _  _ __   ___  | (___  | |_   __ _ | |_ | |_ 
                               |  __  || || '__| / _ \  \___ \ | __| / _` ||  _||  _|
                               | |  | || || |   |  __/  ____) || |_ | (_| || |  | |  
                               |_|  |_||_||_|    \___| |_____/  \__| \__,_||_|  |_|  
                                                             

                                                                                   

                                                                                   
																																				)";;
				cout<<"\n\n";
				hirestaff(staff,des,s,i,c);
				}
				if(resm=="8")
				{
				system("cls");
				cout<<R"(
                            ______                     _    _____  _            __   __ 
                           |  ____|                   | |  / ____|| |          / _| / _|
                           | |__   __  __ _ __    ___ | | | (___  | |_   __ _ | |_ | |_ 
                           |  __|  \ \/ /| '_ \  / _ \| |  \___ \ | __| / _` ||  _||  _|
                           | |____  >  < | |_) ||  __/| |  ____) || |_ | (_| || |  | |  
                           |______|/_/\_\| .__/  \___||_| |_____/  \__| \__,_||_|  |_|  
                                         | |                                            
                                         |_|                                            
       

                                                                                   

                                                                                   
																																				)";;
				cout<<"\n\n";
				if(expelstaff(staff,des,s,i,c))
				cout<<" Sorry! The employee you want to expell does not exist.";
				}
				if(resm=="9")
				{
				system("cls");
				cout<<R"(
                           __      __ _                    _____  _            __   __ 
                           \ \    / /(_)                  / ____|| |          / _| / _|
                            \ \  / /  _   ___ __      __ | (___  | |_   __ _ | |_ | |_ 
                             \ \/ /  | | / _ \\ \ /\ / /  \___ \ | __| / _` ||  _||  _|
                              \  /   | ||  __/ \ V  V /   ____) || |_ | (_| || |  | |  
                               \/    |_| \___|  \_/\_/   |_____/  \__| \__,_||_|  |_|  
                                                                  

                                                                                   

                                                                                   
																																				)";;
				cout<<"\n\n";
				if(viewstaff(staff,des,s,i,c))
				cout<<" No more staff available.";
				}
				if(resm=="10")
				{
				system("cls");
				exit();
				break;
				}
			cout<<" \n\n Press any key to continue: "<<endl;
			getch();
			system("cls");
			}
		}
		}
		else
		{
		cout<<" You don't have an account please sign up.";
		Sleep(1500);
		}
	}
	else if(option=="2")
	{
	cout <<"\t\t\t\t\t\t ____      ____  _               _   _       "<<endl;  
    cout <<"\t\t\t\t\t\t|___ \\    / ___|(_) __ _ _ __   | | | |_ __  "<<endl;
    cout <<"\t\t\t\t\t\t  __) |   \\___ \\| |/ _` | '_ \\  | | | | '_ \\ "<<endl;
    cout <<"\t\t\t\t\t\t / __/ _   ___) | | (_| | | | | | |_| | |_) |"<<endl;
    cout <<"\t\t\t\t\t\t|_____(_) |____/|_|\\__, |_| |_|  \\___/| .__/ "<<endl;
    cout <<"\t\t\t\t\t\t                   |___/              |_|    "<<endl;
    cout << endl;
		cout<<"\n\n";
	//This if statement will take user to sign up menu.
	signuphead(name,password,role,option,s,i,c);
	}
	else if(option=="3")
	{
	//This if statement will terminate the program.
	system("cls");
	saverecordstofile(name,password,role,balance,loan,complaints,debit,staff,des,s,i,c);
	break;
	}
	}			
}
//This function will store records of my bank in file.

void saverecordstofile(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],string staff[],string des[],int s,int i,int c)
{
	fstream file;
	file.open("bankrecords.txt",ios::out);
	for(int x=0;x<i;x++)
	{
		if(name[x]!=" "){
		file<<name[x];
		file<<',';
		file<<password[x];
		file<<',';
		file<<role[x];
		if ((role[x]=="Manager"||role[x]=="Manager") && x != i-1)
			file << '\n';
		if(role[x]=="Client"||role[x]=="client")
		{
		file<<',';
		file<<balance[x];
		file<<',';
		file<<loan[x];
		file<<',';
		file<<complaints[x];
		file<<',';
		file<<debit[x];
		if (x != i-1)
			file<<'\n';
		}
		}	
	}
	file.close();
}
//This function will load the records stored in file to the arrays of program. 
void loadrecords(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],string staff[],string des[],int &s,int &i,int &c)
{
	i=0;
	string record = "";
	fstream file;
	file.open("bankrecords.txt", ios::in);
	if (file.fail())
	{
		return;
	}
	while ((!file.eof()))
	{
	getline(file, record);
	name[i] = getField(record, 1);
	password[i] = stoi(getField(record, 2));
	cout << password[i];
	role[i]=getField(record, 3);
	if(role[i]=="Client"||role[i]=="client")
	{
	balance[i]=stoi(getField(record,4));	
	loan[i]=stoi(getField(record,5));
	complaints[i]=getField(record,6);
	debit[i]=getField(record,7);
	}
	i=i+1;
	}	
	file.close();
	
}
//This function will sense the comma by which data is separated in file and helps loadrecords() function to load data in arrays.
string getField(string record, int field)
{
	int comma=1;
	string result="";
	for (int x = 0; x < record.length(); x++)
	{
	if (record[x]==',')
	{
	comma=comma+1;
	}
	else if(comma==field)
	{
	result=result+record[x];
	}
	}
	return result;
}
//This function will print header.
void header()
{ 	
	system("color 06" );
	/*cout<<R"(
.----------------.  .----------------.  .----------------.  .----------------.  .----------------.  .-----------------.  .----------------.  .----------------.  .-----------------.  .----------------.
| .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. || .--------------. |
| |  ____  ____  | || |  _________   | || |      __      | || | ____   ____  | || |  _________   | || | ____  _____  | || |   ______     | || |      __      | || | ____  _____  | || |  ___  ____   | |
| | |_   ||   _| | || | |_   ___  |  | || |     /  \     | || ||_  _| |_  _| | || | |_   ___  |  | || ||_   \|_   _| | || |  |_   _ \    | || |     /  \     | || ||_   \|_   _| | || | |_  ||_  _|  | |
| |   | |__| |   | || |   | |_  \_|  | || |    / /\ \    | || |  \ \   / /   | || |   | |_  \_|  | || |  |   \ | |   | || |    | |_) |   | || |    / /\ \    | || |  |   \ | |   | || |   | |_/ /    | |
| |   |  __  |   | || |   |  _|  _   | || |   / ____ \   | || |   \ \ / /    | || |   |  _|  _   | || |  | |\ \| |   | || |    |  __'.   | || |   / ____ \   | || |  | |\ \| |   | || |   |  __'.    | |
| |  _| |  | |_  | || |  _| |___/ |  | || | _/ /    \ \_ | || |    \ ' /     | || |  _| |___/ |  | || | _| |_\   |_  | || |   _| |__) |  | || | _/ /    \ \_ | || | _| |_\   |_  | || |  _| |  \ \_  | |
| | |____||____| | || | |_________|  | || ||____|  |____|| || |     \_/      | || | |_________|  | || ||_____|\____| | || |  |_______/   | || ||____|  |____|| || ||_____|\____| | || | |____||____| | |
| |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | || |              | |
| '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' || '--------------' |
 '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'  '----------------'

				)";;*/
	cout<<R"(    
 	 			    	 _    _ ______     __      ________ _   _ _  _____   ____          _   _ _  __
				    	| |  | |  ____|   /\ \    / /  ____| \ | ( )/ ____| |  _ \   /\   | \ | | |/ /
 				    	| |__| | |__     /  \ \  / /| |__  |  \| | | (___   | |_) | /  \  |  \| | ' / 
				    	|  __  |  __|   / /\ \ \/ / |  __| | . ` |  \___ \  |  _ < / /\ \ | . ` |  <  
 				    	| |  | | |____ / ____ \  /  | |____| |\  |  ____) | | |_) / ____ \| |\  | . \ 
 				    	|_|  |_|______/_/    \_\/   |______|_| \_| |_____/  |____/_/    \_\_| \_|_|\_\
                                                                               								)";;
}
//This function will take username and password from user and passes it to sign in function.
bool signinhead(string name[],int password[],string role[],string &option,int &s,int &i,int &c)
{
	int signinpassword;
	string signinname;
	string enter;
	while(true){
	cout<<" Enter UserName: ";
	cin.ignore();
    getline(cin, signinname);
	cout<<" Enter Password (Only Numbers): ";
	cin>>enter;
	if(checkvpass(enter))
	{
		signinpassword=stoi(enter);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	system("cls");
	cout <<"\t\t\t\t\t\t  _     _     ___   ____ ___ _   _           "<<endl;
    cout <<"\t\t\t\t\t\t / |   | |   / _ \\ / ___|_ _| \\ | |          "<<endl;
    cout <<"\t\t\t\t\t\t | |   | |  | | | | |  _ | ||  \\| |          "<<endl;
    cout <<"\t\t\t\t\t\t | |_  | |__| |_| | |_| || || |\\  |          "<<endl;
    cout <<"\t\t\t\t\t\t |_(_) |_____\\___/ \\____|___|_| \\_|         "<<endl;
    cout << endl;
}}
	if(signin(name,password,role,s,i,c,signinname,signinpassword)){
	return true;}
	else{
	return false;}
}
//This function will sign in the user.
bool signin(string name[],int password[],string role[],int &s,int &i,int &c,string signinname,int signinpassword)
{

	int x=0;
	for(int n=0;n<10;n++)
	{
	if(name[n]==signinname&&password[n]==signinpassword)
	{
	c=n;
	return true;
	x=1;
	break;
	}
	}
	if(x==0)
	{
	return false;
	}
	}
//This function will take username and password from user and passes it to sign in function.
void signuphead(string name[],int password[],string role[],string &option,int &s,int &i,int &c)
{
	int count=1;
	string na;
	string signupname;
	int signuppassword;
	string enter;
	while(true){
		cout<<"\n\n";
	cout<<" Enter UserName: ";
	cin.ignore();
    getline(cin, na);
	cout<<" Enter Password (Only Numbers)(At least 4 numbers): ";
	cin>>enter;
	if(checkvpass(enter)&&checkvalid(na)&&enter.length()>=4)
	{
		signupname=na;
		signuppassword=stoi(enter);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	system("cls");
	cout <<"\t\t\t\t\t\t ____      ____  _               _   _       "<<endl;  
    cout <<"\t\t\t\t\t\t|___ \\    / ___|(_) __ _ _ __   | | | |_ __  "<<endl;
    cout <<"\t\t\t\t\t\t  __) |   \\___ \\| |/ _` | '_ \\  | | | | '_ \\ "<<endl;
    cout <<"\t\t\t\t\t\t / __/ _   ___) | | (_| | | | | | |_| | |_) |"<<endl;
    cout <<"\t\t\t\t\t\t|_____(_) |____/|_|\\__, |_| |_|  \\___/| .__/ "<<endl;
    cout <<"\t\t\t\t\t\t                   |___/              |_|    "<<endl;
    cout << endl;
}}
	for(int l=0;l<10;l++)
	{
	if(name[l]==signupname)
	{
	cout<<" Sorry this account already exist.";
	cout<<" \n\nPress any key to continue.";
	getch();
	count=0;
	break;
	}
	}
	string rol;
	if(count==1)
	{
	while(true){
	cout<<" Enter your role (Manager/Client): ";
	cin>>rol;
	if(rol!="Manager"&&rol!="Client"){
		cout<<"Invalid Input.";
		cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n\n\n";
	}
	else{
	role[i]=rol;
	break;}
}
	signup(name,password,role,s,i,c,signupname,signuppassword);
	cout<<" Congratulations "<<name[i]<<"! You are sucessfully signed up.";
	cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n";
	i=i+1;
	}
	}
//This function will sign in the user.
void signup(string name[],int password[],string role[],int &s,int &i,int &c,string signupname,int signuppassword)
{
	name[i]=signupname;
	password[i]=signuppassword;
}
//This function will check validation of comma.
bool checkvalid(string na)
{
	for(int i=0;na[i]!='\0';i++)
	{
		if(na[i]==',')
		return false;
	}
	return true;
}
//This function will display tasks that manager can perform,takes input from manager and returns it to main function.
string manager()
{
	string choose;
	while(true){
	cout<<R"(	 			__  __                                          _        __  __                     
				|  \/  |                                        ( )      |  \/  |                    
				| \  / |  __ _  _ __    __ _   __ _   ___  _ __ |/  ___  | \  / |  ___  _ __   _   _ 
				| |\/| | / _` || '_ \  / _` | / _` | / _ \| '__|   / __| | |\/| | / _ \| '_ \ | | | |
				| |  | || (_| || | | || (_| || (_| ||  __/| |      \__ \ | |  | ||  __/| | | || |_| |
				|_|  |_| \__,_||_| |_| \__,_| \__, | \___||_|      |___/ |_|  |_| \___||_| |_| \__,_|
        		                      		      __/  |                                                 
         		                     		     |___ /                                                  
																										)";;
	cout<<"\n\n\n";
	cout<<" Select one of the following Option Number..\n";
	cout<<" Option 1: View Records of Clients"<<endl; 
	cout<<" Option 2: Open Account"<<endl;
	cout<<" Option 3: Delete Account"<<endl;
	cout<<" Option 4: View Total balance"<<endl;
	cout<<" Option 5: View complaints"<<endl;
	cout<<" Option 6: Block Debit Card"<<endl;
	cout<<" Option 7: Hire Staff"<<endl;
	cout<<" Option 8: Expel Staff"<<endl;
	cout<<" Option 9: View Bank Staff"<<endl;
	cout<<" Option 10:Log Out"<<endl;
	cout<<" Enter option number:";
	cin>>choose;
	if(choose!="1"&&choose!="2"&&choose!="3"&&choose!="4"&&choose!="5"&&choose!="6"&&choose!="7"&&choose!="8"&&choose!="9"&&choose!="10")
	{
		cout<<" Invalid Input.";
			cout<<" \n\nPress any key to continue.";
	getch();
	system("cls");
	}
	else
	break;
}
	return choose;
	
}
//This function will display tasks that client can perform,takes input from client and returns it to main function.
string client()
{	
	string choice;
	while(true){
	cout<<R"( 
				  _____  _  _               _    _        __  __                     
				 / ____|| |(_)             | |  ( )      |  \/  |                    
				| |     | | _   ___  _ __  | |_ |/  ___  | \  / |  ___  _ __   _   _ 
				| |     | || | / _ \| '_ \ | __|   / __| | |\/| | / _ \| '_ \ | | | |
				| |____ | || ||  __/| | | || |_    \__ \ | |  | ||  __/| | | || |_| |
				 \_____||_||_| \___||_| |_| \__|   |___/ |_|  |_| \___||_| |_| \__,_|
				 																				)";;	
	cout<<"\n\n\n";
	cout<<" Select one of the following Option Number..\n";
	cout<<" Option 1: View Account Status"<<endl; 
	cout<<" Option 2: Deposit Money"<<endl;
	cout<<" Option 3: Withdraw Money"<<endl;
	cout<<" Option 4: Transfer Donations"<<endl;
	cout<<" Option 5: Get Debit Card"<<endl; 
	cout<<" Option 6: Get Loan"<<endl;
	cout<<" Option 7: Pay Loan"<<endl;
	cout<<" Option 8: Exchange Currency"<<endl;
	cout<<" Option 9: Submit Complaints"<<endl;
	cout<<" Option 10:Log Out"<<endl;
	cout<<" Enter option number:";
	cin>>choice;
	if(choice!="1"&&choice!="2"&&choice!="3"&&choice!="4"&&choice!="5"&&choice!="6"&&choice!="7"&&choice!="8"&&choice!="9"&&choice!="10")
	{
		cout<<" Invalid Input.";
			cout<<" \n\nPress any key to continue.";
	getch();
	system("cls");
	}
	else
	break;
}
	return choice;
}
//This function will check that the user input is valid on not.
bool checkvalidation(string enter)
{
	for(int i=0;enter[i]!='\0';i++)
	{
		if(enter[i]!='1'&&enter[i]!='2'&&enter[i]!='3'&&enter[i]!='4'&&enter[i]!='5'&&enter[i]!='6'&&enter[i]!='7'&&enter[i]!='8'&&enter[i]!='9')
		return false;
		break;
	}
	return true;
}
//This function will check validation of password.
bool checkvpass(string enter)
{
	for(int i=0;enter[i]!='\0';i++)
	{
		if(enter[i]!='0'&&enter[i]!='1'&&enter[i]!='2'&&enter[i]!='3'&&enter[i]!='4'&&enter[i]!='5'&&enter[i]!='6'&&enter[i]!='7'&&enter[i]!='8'&&enter[i]!='9')
		return false;
	}
	return true;
}
//This function will show the accounts details of all clients in bank to manager.
bool viewaccounts(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c)
{
	int count=0;
    for(int x=0;name[x]!="\0";x++)
	{
    if((role[x]=="Client"||role[x]=="client")&&name[x]!=" ")
    count++;
	}
	if(count!=0)
	{
	cout<<" NAME\t\tCurrent Balance\t\tDebit Card\t\tLoan"<<endl;
    for(int i=0;name[i]!="\0";i++)
	{
    if((role[i]=="Client"||role[i]=="client")&&name[i]!=" ")
    cout<<" "<<name[i]<<"\t\t"<<balance[i]<<"\t\t\t"<<debit[i]<<"\t\t\t"<<loan[i]<<endl;
	}
	}
	else
	return true;
}
//This function will show client his account details.
void viewrecord(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c)
{
	cout<<" NAME\t\tCurrent Balance\t\tDebit Card\t\tLoan"<<endl;
	cout<<" "<<name[c]<<"\t\t"<<balance[c]<<"\t\t\t"<<debit[c]<<"\t\t\t"<<loan[c];
}
//Client will use this function to deposit money.
bool depositmoney(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c)
{
	int depositamount;
	string enter;
	while(true){
	cout<<" Enter the amount you want to deposit: ";
	cin>>enter;
	if(checkvalidation(enter))
	{
		depositamount=stoi(enter);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n\n\n";}
}
	if(depositamount>0){
	balance[c]+=depositamount;
	return true;}
	else
	return false;
}
//Client will use this function to withdraw money.
bool withdrawmoney(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c)
	{
	int withdrawamount;
	string enter;
	while(true){
	cout<<" Enter the amount you want to withdraw: ";
	cin>>enter;
	if(checkvalidation(enter))
	{
		withdrawamount=stoi(enter);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n\n\n";
}
}
	if(balance[c]>=withdrawamount)
	{
	balance[c]-=withdrawamount;
	return true;
	}
	else
	return false;
	}
bool transfermoney(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],string &welfare,int &s,int &i,int &c)
	{
	int transferamount;
	string enter;
	while(true){
	cout<<" Enter the amount of donations you want to transfer: ";
	cin>>enter;
	if(checkvalidation(enter))
	{
		transferamount=stoi(enter);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n\n\n";
	}
}
	cout<<" Enter the welfare to which yo want to transfer donations: ";
	cin>>welfare;
	if(balance[c]>=transferamount)
	{
	balance[c]-=transferamount;
	return true;
	}
	else
	return false;
}
//This function will issue Debit Card to client.
bool debitcard(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c)
{
	string de;
	string debitcard;
	int salary;
	string enter;
	cout<<" Which Debit Card you want to get(Visa , Master): ";
	cin>>debitcard;
	while(true){ 
	cout<<" Enter your monthly salary: ";
	cin>>enter;
	if(checkvalidation(enter)&&checkvalid(de))
	{
		debitcard=de;
		salary=stoi(enter);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n\n\n";
}
}
	if(salary>=100000)
	{
	debit[c]=debitcard;
	return true;
	}
	else
	{
	return false;
	}
}
//This function will issue Loan to client.
bool getloan(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c)
{
	int salary,loan1;
	string enter,sl;
	while(true){
	cout<<" How much loan you you want to get: ";
	cin>>enter;
	cout<<" Enter your salary: ";
	cin>>sl;
	if(checkvalidation(enter)&&checkvalidation(sl))
	{
		loan1=stoi(enter);
		salary=stoi(sl);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n\n\n";
}
}
	if(salary>=100000)
	{
	loan[c]=loan1;
	return true;
	}
	else
	{
	return false;
	}
}
//This function will deduct loan from client.
void payloan(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c)	
{
	int pay;
	int loanpay;
	string enter;
	while(true){
	cout<<" Enter the amount of loan you want to pay: ";
	cin>>enter;
	if(checkvalidation(enter))
	{
		loanpay=stoi(enter);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n\n\n";
}
}
	if(balance[c]>=loanpay||balance[c]>=loan[c])
	{
	if(loan[c]==0)
	cout<<" You have no loan.";
	else if(loan[c]>loanpay)
	{
	balance[c]=balance[c]-loanpay;
	loan[c]=loan[c]-loanpay;
	cout<<" Your loan is successfully paid.";
	}
	else
	{
	balance[c]=balance[c]-loan[c];
	cout<<"Your loan of "<<loan[c]<<" is successfully paid.";
	loan[c]=0;
	}
	}
	else
	cout<<" Sorry! Your balance is insufficient. ";
}
//This function will submit complaints of client.
bool submitcomplaint(string name[],int password[],string role[],int balance[],int loan[],string complaints[],string debit[],int &s,int &i,int &c)
{
	string complain;
	while(true){
	cout<<" Please write your Complaint: ";
	cin.ignore();
    getline(cin, complain);
	if(checkvalid(complain))
	{
		complaints[c]=complain;
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n\n\n";
	}
}

	return true;
}
//This function will take amount,currency want to exchange and currency want to get from from and give desired currency.
void exchangecurrency()
{
	int amount;
	float exchange;
	string a,b;
	string enter;
	while(true){
	cout<<" Enter the amount you want to exchange: ";
	cin>>enter;
	cout<<" Enter your currency (Dollar, Pound, Rupee): ";
	cin>>a;
	cout<<" Enter your currency you want to get (Dollar, Pound, Rupee): ";
	cin>>b;
	if(checkvalidation(enter))
	{
		if((a=="Dollar"||a=="Pound"||a=="Rupee")&&(b=="Dollar"||b=="Pound"||b=="Rupee")){
		amount=stoi(enter);
		break;}
	}
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	cout<<"\n\n\n";
	
}
	if(a==b)
	exchange=amount;
	if(a=="Rupee"&&b=="Dollar")
	exchange=amount/250;
	if(a=="Rupee"&&b=="Pound")
	exchange=amount/500;
	if(a=="Dollar"&&b=="Rupee")
	exchange=amount*250;
	if(a=="Dollar"&&b=="Pound")
	exchange=amount/2;
	if(a=="Pound"&&b=="Dollar")
	exchange=amount*2;
	if(a=="Pound"&&b=="Rupee")
	exchange=amount*500;
	cout<<" Recieve your "<<exchange<<" "<<b;
}
//This function will display the total balance of clients and loan taken bt clients to manager.
void viewtotal(string name[],int password[],string role[],int balance[],int loan[],int &s,int &i,int &c)
{
	int totalb=0;
	int totall=0;
	for(int i=0;name[i]!="\0";i++){
	totalb=totalb+balance[i];
	totall=totall+loan[i];}
	cout<<" \nTotal Clients Balance in Bank is: "<<totalb;
	cout<<" \n Total Loan given to Clients is: "<<totall;
}
//This function will display the complaints of clients to manager.
bool viewcomplaints(string name[],int password[],string role[],string complaints[],int &s,int &i,int &c)
{
	int count=0;
	for(int i=0;name[i]!="\0";i++)
	{
	if(role[i]!="Manager"&&complaints[i]!="\0"&&name[i]!=" ")
	{
	cout<<" Complaint of Client "<<name[i]<<": "<<complaints[i]<<endl;
	count++;
	}
	}
	if(count==0)
	return true;
}
//Manager can open account of client with the help of this function.
bool openaccount(string name[],int password[],string role[],int &s,int &i,int &c)
{
	string enter;
	int x=0;
	while(true)
	{
	if(name[x]=="\0")
	{
	c=x;
	break;
	}
	x++;
	}
	while(true){
	cout<<" Enter Client Name: ";
	cin.ignore();
    getline(cin, name[c]);
	cout<<" Enter Client Password (only Numbers): ";
	cin>>enter;
	if(checkvpass(enter))
	{
		password[c]=stoi(enter);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	system("cls");}}
	role[c]="Client";	
	c++;
	i++;
	return true;	
}
//Manager can delete account of client with the help of this function.
bool deleteaccount(string name[],int password[],string role[],int balance[],int loan[],string debit[],int &s,int &i,int &c)
{
	int p=-1;
	string namen;
	string enter;
	int passwordn;
	while(true){
	cout<<" Enter Client Name: ";
	cin.ignore();
    getline(cin, namen);
	cout<<" Enter Client Password (only Numbers): ";
	cin>>enter;
	if(checkvpass(enter))
	{
		passwordn=stoi(enter);
		break;
	}
	else{
	cout<<" Invalid Input";
		cout<<" \n\nPress any key to continue.";
	getch();
	system("cls");}}
	for(int x=0;name[x]!="\0";x++)
	{
	if(name[x]==namen)
	{
	p=x;
	break;
	}
	}
	if(p!=-1)
	{
	cout<<" Account of Client "<<name[p]<<" is  deleted. ";
	name[p]=" ";
	balance[p]=0;
	loan[p]=0;
	debit[p]="N/A";
	return false;
	}
	else 
	{
	return true;
	}
}
//This function will assist manager in hiring staff.
bool hirestaff(string staff[],string des[],int &s,int &i,int &c)
{
	cout<<" Enter Employee Name: ";
	cin.ignore();
    getline(cin, staff[s]);
	cout<<" Enter Employee Designation: ";
	cin>>des[s];
	s++;
	return true;
}
//This function will assist manager in expelling staff.
bool expelstaff(string staff[],string des[],int &s,int &i,int &c)
{
	string n,d;
	cout<<" Enter Employee Name: ";
	cin.ignore();
    getline(cin, n);
	cout<<" Enter Employee Designation: ";
	cin>>d;
	int x=-1;
	for(int i=0;i<=s;i++)
	{
	if(staff[i]==n&&des[i]==d)
	{
	x=i;
	break;
	}
	}
	if(x!=-1)
	{
	cout<<" Employee "<<staff[x]<<" is  expelled. ";
	staff[x]=" ";
	des[x]==" ";
	return false;
	}
	else
	return true;
}
//This function will display manager all staff of bank.
bool viewstaff(string staff[],string des[],int &s,int &i,int &c)
{
	int count=0;
	for(int i=0;i<=s;i++)
	{
	if(staff[i]!=" "&&staff[i]!="\0")
	{
	count++;
	}
	}
	if(count==0)
	return true;
	else{
		cout<<" Empoyee Name\t\tDesignation \n";
	for(int i=0;i<=s;i++)
	{
	if(staff[i]!=" ")
	cout<<" "<<staff[i]<<"\t\t\t"<<des[i]<<endl;
	}
	}
	
}
//This function will assist manager to block the debit card of client.
bool blockdebit(string name[],int password[],string role[],string debit[],int &s,int &i,int &c)
{
	int count=0;
	int p=-1;
	string namev;
	cout<<" Enter Client name: ";
	cin>>namev;
	for(int x=0;name[x]!="\0";x++)
	{
	if(name[x]==namev)
	count++;
	}
	if(count==0){
	return true;}
	else{
	for(int y=0;name[y]!="\0";y++)
	{
	if(name[y]==namev&&debit[y]!="N/A")
	p=y;
	}
	if(p!=-1)
	{
	debit[p]="N/A";
	cout<<" The debit card of Client "<<name[p]<<" is blocked.";
	}
	else{
	cout<<" Sorry! The Client has no debit card.";}
	return false;
	}	
}
//This function will exit manager and client from their menus and place them in sign in or sign up options.
bool exit()
{
	system("cls");
	return true;
}

