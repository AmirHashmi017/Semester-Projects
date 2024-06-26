using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyLinesLibrary;
namespace SkyLines
{
    internal class UtilityUI
    {
//This function will display Login Menu.
        public static int FrontScreen()
        {
            string enter;
            int option;
            while (true)
            {
                Console.WriteLine("\t\t\t\t  _     _     ___   ____ ___ _   _           ");
    Console.WriteLine("\t\t\t\t / |   | |   / _ \\ / ___|_ _| \\ | |          ");
    Console.WriteLine("\t\t\t\t | |   | |  | | | | |  _ | ||  \\| |          ");
    Console.WriteLine("\t\t\t\t | |_  | |__| |_| | |_| || || |\\  |          ");
    Console.WriteLine("\t\t\t\t |_(_) |_____\\___/ \\____|___|_| \\_|         ");
    Console.Write("\n");
    Console.WriteLine("\t\t\t\t ____      ____  _               _   _       ");  
    Console.WriteLine("\t\t\t\t|___ \\    / ___|(_) __ _ _ __   | | | |_ __  ");
                Console.WriteLine("\t\t\t\t  __) |   \\___ \\| |/ _` | '_ \\  | | | | '_ \\ ");
    Console.WriteLine("\t\t\t\t / __/ _   ___) | | (_| | | | | | |_| | |_) |");
    Console.WriteLine("\t\t\t\t|_____(_) |____/|_|\\__, |_| |_|  \\___/| .__/ ");
    Console.WriteLine("\t\t\t\t                   |___/              |_|    ");
    Console.Write("\n");
    Console.WriteLine("\t\t\t\t _____    _____      _ _                   ");
    Console.WriteLine("\t\t\t\t|___ /   | ____|_  _(_) |_                   ");
    Console.WriteLine("\t\t\t\t  |_ \\   |  _| \\ \\/ / | __|                  ");
    Console.WriteLine("\t\t\t\t ___) |  | |___ >  <| | |_                   ");
    Console.WriteLine("\t\t\t\t|____(_) |_____/_/\\_\\_|\\__|                  ");
    Console.WriteLine("\t\t\t\t                                             ");
    Console.Write("\n\n");
                Console.Write("\t\t\t\t Enter Option Number: ");
                enter = Console.ReadLine();
                if (enter != "1" && enter != "2" && enter != "3")
                {
                    Console.WriteLine(" \n\nInvalid Input..");
                    Console.WriteLine(" Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                option = int.Parse(enter);
                Console.Clear();
                return option;
            }
        }
//This function will display admin menu.
        public static int AdminMenu()
        {
            string enter;
            int option;
            while (true)
            {
                
Console.WriteLine(" \t\t  	       _             _          _____                       _ ");
Console.WriteLine(" \t\t    /\\        | |           (_)        |  __ \\                     | |");
Console.WriteLine(" \t\t   /  \\     __| | _ __ ___   _  _ __   | |__) |  __ _  _ __    ___ | |");
Console.WriteLine(" \t\t  / /\\ \\   / _` || '_ ` _ \\ | || '_ \\  |  ___/  / _` || '_ \\  / _ \\| |");
Console.WriteLine(" \t\t / ____ \\ | (_| || | | | | || || | | | | |     | (_| || | | ||  __/| |");
Console.WriteLine(" \t\t/_/    \\_\\ \\__,_||_| |_| |_||_||_| |_| |_|      \\__,_||_| |_| \\___||_|");
Console.Write("\n\n\n\n");
                                                                      
                Console.WriteLine(" \t1. Add Flight");
                Console.WriteLine(" \t2. Calculate Flight's Revenue");
                Console.WriteLine(" \t3. Edit Flight Schedule");
                Console.WriteLine(" \t4. View Flights");
                Console.WriteLine(" \t5. Hire Staff");
                Console.WriteLine(" \t6. Expel Staff");
                Console.WriteLine(" \t7. Update Staff's Information");
                Console.WriteLine(" \t8. View AirLine Staff");
                Console.WriteLine(" \t9. View FeedBack");
	                                
                Console.WriteLine(" \t10. Log Out");
                Console.Write(" \tEnter Option Number: ");
                enter = Console.ReadLine();
                if (enter != "1" && enter != "2" && enter != "3" && enter != "4" && enter != "5" && enter != "6" && enter != "7" && enter != "8" && enter != "9"&&enter!="10")
                {
                    Console.WriteLine(" \n\nInvalid Input..");
                    Console.WriteLine(" Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                option = int.Parse(enter);
                Console.Clear();
                return option;
            }
        }
//This function will display client menu.
        public static int ClientMenu()
        {
            string enter;
            int option;
            while (true)
            {
Console.WriteLine(" \t\t _    _                    _____                       _ ");
Console.WriteLine(" \t\t| |  | |                  |  __ \\                     | |");
Console.WriteLine(" \t\t| |  | | ___   ___  _ __  | |__) |  __ _  _ __    ___ | |");
Console.WriteLine(" \t\t| |  | |/ __| / _ \\| '__| |  ___/  / _` || '_ \\  / _ \\| |");
Console.WriteLine(" \t\t| |__| |\\__ \\|  __/| |    | |     | (_| || | | ||  __/| |");
Console.WriteLine(" \t\t \\____/ |___/ \\___||_|    |_|      \\__,_||_| |_| \\___||_|");
Console.Write("\n\n\n\n");
                                                         
                Console.WriteLine(" \t1. Search Flights");
                Console.WriteLine(" \t2. Book Flight");
                Console.WriteLine(" \t3. Cancel Reserve Seat");
                Console.WriteLine(" \t4. View Reserved Flights");
                Console.WriteLine(" \t5. Submit FeedBack");
                Console.WriteLine(" \t6. Log Out");
                Console.Write(" \tEnter Option Number: ");
                enter = Console.ReadLine();
                if (enter != "1" && enter != "2" && enter != "3" && enter != "4" && enter != "5" && enter != "6")
                {
                    Console.WriteLine(" \n\nInvalid Input..");
                    Console.WriteLine(" Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                option = int.Parse(enter);
                Console.Clear();
                return option;
            }
        }
//This function will take input from user for sign up.
        public static void SignUp()
        {
            
            string name, password, role;
            while (true)
            {
Console.WriteLine("\t\t\t Sign Up\n\n");
                Console.Write(" Enter UserName: ");
                name = Console.ReadLine();
if(!(Validations.CheckCommaandColon(name)))
	{
	Console.WriteLine(" Invalid Name.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
	}
                if (!(ObjectHandler.GetClientDL().CheckValidClientName(name) && ObjectHandler.GetAdminDL().CheckValidAdminName(name)))
                {
                    Console.WriteLine(" \n\nSorry! This UserName is Already Taken..");
                    Console.WriteLine(" Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.Write(" Enter Password: ");
                password = Console.ReadLine();
if(!(Validations.CheckCommaandColon(password)))
	{
	Console.WriteLine(" Invalid Password.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
	}
                Console.Write(" Enter Role (Admin/Client): ");
                role = Console.ReadLine();
                if (role.ToLower() != "client" &&role.ToLower() !="admin")
                {
                    Console.WriteLine(" Invalid Input..Please Enter Valid Role!!");
                    Console.WriteLine(" Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                break;
            }
            if (role.ToLower() == "client")
            {
                Client c = new Client(name, password, role);
                ObjectHandler.GetClientDL().AddClient(c);
            }
            else if (role.ToLower() == "admin")
            {
                Admin a = new Admin(name, password, role);
                ObjectHandler.GetAdminDL().AddAdmin(a);
            }
            Console.WriteLine($"\n\n {name}! You are sucessfully Signed Up as a {role}");
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
//This function will take input from user for login.
        public static string Login()
        {
            int number;
            string result = " ";
            Console.WriteLine("\t\t\t Login\n\n");
            string name, password;
            Console.Write(" Enter UserName: ");
            name = Console.ReadLine();
            Console.Write(" Enter Password: ");
            password = Console.ReadLine();
            if (ObjectHandler.GetClientDL().IsClientExist(name, password))
            {
                number = ObjectHandler.GetClientDL().FindClient(name, password);
                result = number.ToString();
            }
            else if (ObjectHandler.GetAdminDL().IsAdminExist(name, password))
            {
                result = "Admin";
            }
            if (result != " ")
            {
                Console.WriteLine($"\n\n {name}! You are sucessfully Signed in.");
            }
            else
            {
                Console.WriteLine(" \n\n No such Person Exist!!");
            }
            Console.WriteLine(" Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            return result;
        }
    }
}
