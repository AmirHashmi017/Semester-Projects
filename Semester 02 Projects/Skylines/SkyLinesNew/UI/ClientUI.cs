using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SkyLinesLibrary;

namespace SkyLines
{
    internal class ClientUI
    {
//This function will get the input for feedback from user.
        public static string GetFeedBack()
        {
            string feedback;
	while(true)
{
            Console.WriteLine("\t\t\t Submit FeedBack\n\n");
            Console.Write(" Enter Your FeedBack: ");
            feedback = Console.ReadLine();
	if(!(Validations.CheckCommaandColon(feedback)))
{
Console.WriteLine(" Invalid FeedBack.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
}
break;
}
            return feedback;
        }
//This function will print statements after submitting feedback.
        public static void FeedBackResult()
        {
            Console.WriteLine(" Your FeedBack is sucessfully Submitted.");
    
        Console.WriteLine("\n\n Press any key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }
//This function will get input for search flight and display the required flights.     
        public static bool SearchFlight()
        {
            List<Flight> Flights = ObjectHandler.GetFlightDL().GetAllFlights();
            int count = 0;
            Console.WriteLine("\t\t\t Search Flights\n\n");
            Console.Write(" Enter Departure Airport: ");
            string source = Console.ReadLine();
            Console.Write(" Enter Arrival Airport: ");
            string destination = Console.ReadLine();
            Console.WriteLine("Flight ID\t\t\t Flight Name\t\t\t Depature Airport\t\t Arrival Airport\t\t Departure Date\t\t Departure Time \t\t Landing Time\t\t Price\t\t Seats\n");
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].GetSource() == source && Flights[i].GetDestination() == destination && Flights[i].GetSeats() > 0)
                {
                    Console.WriteLine(Flights[i].ViewFlight());
                    count++;
                }
            }
            if (count == 0)
            {
                Console.WriteLine(" No such Flights Available.");
                Console.WriteLine("\n\n Press any key to Continue..");
                Console.ReadKey();
                Console.Clear();
                return false;
            }

            return true;
        }
//This function will get input from user for booking a flight.
        public static void BookingInput(int clientno)
        {
            int count = 0;
            List<Flight> Flights = ObjectHandler.GetFlightDL().GetAllFlights();
            Console.WriteLine("\n\n\n\t\t\t Book Flight\n\n");
            Console.Write(" Enter Flight ID: ");
            string ID = Console.ReadLine();
            Flight fl;
            List<Client> clients = ObjectHandler.GetClientDL().GetAllClients();
            foreach (Flight f in Flights)
            {
                if (f.GetFlightID() == ID&&f.GetSeats()>0)
                {
                   
                     fl=f;
                    count++;
                    if (clients[clientno].BookFlight(fl))
                    {
                        ObjectHandler.GetFlightDL().EditFlight(f.GetFlightName(), f.GetFlightID(), f.GetSource(), f.GetDestination(), f.GetTravelDate(), f.GetTakeoffTime(), f.GetPrice(), f.GetSeats());
                        ObjectHandler.GetClientDL().StoreBookedFlights(ID, clients[clientno].GetName());
                        Console.WriteLine(" \n\nThe Flight is Sucessfully Booked.");
                        Console.WriteLine("\n\n Press any key to Continue..");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                        Console.WriteLine("\n\n The Flight is Already Booked."); 
                }
            }
            if (count == 0)
            {
                Console.WriteLine(" No Such Flight Available.");
                Console.WriteLine("\n\n Press any key to Continue..");
                Console.ReadKey();
                Console.Clear();
            }
        }
//This function will get input from user for cancelling flight.
        public static string CancelFlightInput()
        {
            Console.WriteLine("\n\n\n\t\t\t Cancel Reserved Seat\n\n");
            Console.Write(" Enter Flight ID: ");
            string ID = Console.ReadLine();
            Thread.Sleep(300);
            return ID;
        }
//This function will display all the reserved flights of a specific client.
        public static void dispalyBookedFlights(int clientNo)
        {             List<Client> clients = ObjectHandler.GetClientDL().GetAllClients();
                   Console.WriteLine("\n\n\n\t\t\t View Booked Flights\n\n");
                   Console.WriteLine("Flight ID\t\t\t Flight Name\t\t\t Depature Airport\t\t Arrival Airport\t\t Departure Date\t\t Departure Time \t\t Landing Time\t\t Price\t\t Seats\n");
                   for (int i = 0; i < clients[clientNo].GetBookedFlights().Count; i++)
            {
                Console.WriteLine(clients[clientNo].GetBookedFlights()[i].ViewFlight());
            }
        }
    }
}
