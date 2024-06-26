using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyLinesLibrary;
namespace SkyLines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            ObjectHandler.GetAdminDL();
            ObjectHandler.GetStaffDL();
            ObjectHandler.GetFlightDL();
            ObjectHandler.GetClientDL();
            string LoginCheck; int clientnumber;
            int loginoption, option;
            while (true)
            {
                
 Console.WriteLine("\t\t\t\t\t   ____   __ ____  __   __    ____   _  __   ____   ____");
Console.WriteLine("\t\t\t\t\t  / __/  / //_/\\ \\/ /  / /   /  _/  / |/ /  / __/  / __/");
Console.WriteLine("\t\t\t\t\t _\\ \\   / ,<    \\  /  / /__ _/ /   /    /  / _/   _\\ \\  ");
Console.WriteLine("\t\t\t\t\t/___/  /_/|_|   /_/  /____//___/  /_/|_/  /___/  /___/  ");
Console.Write("\n\n\n");
                                                        
//This will print the start menu.
                loginoption = UtilityUI.FrontScreen();
                if (loginoption == 1)
                {
//This will display login input fields.
                    LoginCheck = UtilityUI.Login();
                    if (LoginCheck == " ")
                    {
                        continue;
                    }
//This will check whether the loged in person is admin or user and dispaly the respective menu to him.
                    else if (LoginCheck.ToLower() != "admin")
                    {
                        clientnumber = int.Parse(LoginCheck);
                        while (true)
                        {
                            Console.Clear();
                            option = UtilityUI.ClientMenu();
                            if (option == 1)
                            {
                                ClientUI.SearchFlight();
                                Console.WriteLine("\n\n Press any key to Continue..");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (option == 2)
                            {
                                ClientUI.BookingInput(clientnumber);
                            }
                            else if (option == 3)
                            {
                                List<Client>clients=ObjectHandler.GetClientDL().GetAllClients();
                                string ID=ClientUI.CancelFlightInput();
                                Flight f = clients[clientnumber].CancelFlight(ID);
                                if (f != null)
                                {
                                    ObjectHandler.GetFlightDL().EditFlight(f.GetFlightName(), f.GetFlightID(), f.GetSource(), f.GetDestination(), f.GetTravelDate(), f.GetTakeoffTime(), f.GetPrice(), f.GetSeats());
                                    ObjectHandler.GetClientDL().DeleteBookedFlights(ID, clients[clientnumber].GetName());

                                    Console.WriteLine("The Reserve Seat is Cancelled.");
                                }
                                else
                                    Console.WriteLine(" No such Flight Found");
                                Console.WriteLine("\n\n Press any key to Continue..");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (option == 4)
                            {
                                ClientUI.dispalyBookedFlights(clientnumber);
                                Console.WriteLine("\n\n Press any key to Continue..");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (option == 5)
                            {
                                List<Client> clients = ObjectHandler.GetClientDL().GetAllClients();
                               string feedback= ClientUI.GetFeedBack();
                                List<Client> Clients = ObjectHandler.GetClientDL().GetAllClients();
                                Clients[clientnumber].SetFeedBack(feedback);
                                ObjectHandler.GetClientDL().UpdateFeedBack(clients[clientnumber].GetName(), feedback);
                                ClientUI.FeedBackResult();
                            }
                            else if (option == 6)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else if (LoginCheck.ToLower() == "admin")
                    {
                        while (true)
                        {
                            Console.Clear();
                            option = UtilityUI.AdminMenu();
                            if (option == 1)
                            {
                                FlightUI.AddNewFlight();
                            }
	          if (option == 2)
                            {
                                FlightUI.ViewFlightsRevenue();
                                Console.WriteLine("\n\n Press any key to Continue..");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else if (option == 3)
                            {
                                FlightUI.UpdateFlight();
                            }
                            else if (option == 4)
                            {
                                FlightUI.ViewAllFlights();
                            }
                            else if (option == 5)
                            {
                                StaffUI.HireStaff();
                            }
                            else if (option == 6)
                            {
                                StaffUI.ExpellStaff();
                            }
                            else if (option == 7)
                            {
                                StaffUI.UpdateStaff();
                            }
                            else if (option == 8)
                            {
                                StaffUI.ViewAllStaff();
                            }
                            else if (option == 9)
                            {
                                FlightUI.ViewAllFeedBack();
                            }
                            else if (option == 10)
                            {
                                Console.Clear();
                                break;
                            }
                        }
                    }
                }
                else if (loginoption == 2)
                {
                    UtilityUI.SignUp();
                }
                else if (loginoption == 3)
                {
                    Console.Clear();
                    break;
                }
            }

        }
    }
}
