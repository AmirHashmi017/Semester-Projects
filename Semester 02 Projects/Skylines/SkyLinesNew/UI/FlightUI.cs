using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyLinesLibrary;
namespace SkyLines
{
    internal class FlightUI
    {
//This function will print feedback of all clients.
        public static void ViewAllFeedBack()
        {
            List<Client> Clients = ObjectHandler.GetClientDL().GetAllClients();
            Console.WriteLine("\t\t\t View FeedBack\n\n");
            for (int i = 0; i < Clients.Count; i++)
            {
                if (Clients[i].GetFeedBack() != null)
                {
                    Console.WriteLine(Clients[i].ViewFeedBack());
                }
            }
            Console.WriteLine("\n\n Press any key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }
//Thhis function will take input from user for adding new flight.
        public static void AddNewFlight()
        {
            
            string name; string ID; string source; string destination; string date; string takeoff; double price; double seats;
            string checkprice, checkseats;
            while (true)
            {
Console.WriteLine("\t\t\t Add Flight\n\n");
                Console.Write(" Enter Flight ID: ");
                ID = Console.ReadLine();
	if(!(Validations.CheckCommaandColon(ID)))
	{
	Console.WriteLine(" Invalid Flight ID.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
	}
	 if (!(ObjectHandler.GetFlightDL().CheckValidFlightID(ID)))
                {
                    Console.WriteLine(" This FlightID Already Exist.Kindly Enter any other ID.");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.Write(" Enter Flight Name: ");
                name = Console.ReadLine();
	if(!(Validations.CheckCommaandColon(name)))
	{
	Console.WriteLine(" Invalid Flight Name.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
	}
                Console.Write(" Enter Departure Airport: ");
                source = Console.ReadLine();
	if(!(Validations.CheckCommaandColon(source)))
	{
	Console.WriteLine(" Invalid Departure Airport.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
	}
                Console.Write(" Enter Arrival Airport: ");
                destination = Console.ReadLine();
	if(!(Validations.CheckCommaandColon(destination)))
	{
	Console.WriteLine(" Invalid Arrival Airport.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
	}
                Console.Write(" Enter Departure Date (DD-MM-YYYY): ");
                date = Console.ReadLine();
                if (!(Validations.CheckValidDate(date)))
                {
                    Console.WriteLine(" Invalid Date!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.Write(" Enter Departure Time i.e (12:00 AM,05:30 PM): ");
                takeoff = Console.ReadLine();
                if (!(Validations.CheckValidTime(takeoff)))
                {
                    Console.WriteLine(" Invalid Departure Time!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
               
                Console.Write(" Enter Ticket Price: ");
                checkprice = Console.ReadLine();
                if (!(Validations.CheckNumber(checkprice)))
                {
                    Console.WriteLine(" Invalid Price!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                price = double.Parse(checkprice);
                Console.Write(" Enter Number of Seats: ");
                checkseats = Console.ReadLine();
                if (!(Validations.CheckNumber(checkseats)))
                {
                    Console.WriteLine(" Invalid Input!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                seats = double.Parse(checkseats);
                Flight f = new Flight(ID,name, source, destination, date, takeoff, price, seats);
                ObjectHandler.GetFlightDL().AddFlight(f);
                break;
            }
            Console.WriteLine(" \nThe Desired Flight is Sucessfully Added.");
            Console.WriteLine(" \n\nPress any key to continue!!!");
            Console.ReadKey();
        }
//This function will take input from user for updating Flight.
        public static void UpdateFlight()
        {
            
            string name; string ID; string source; string destination; string date; string takeoff;  double price; double seats;
            string checkprice, checkseats;
            Console.Write(" Enter Flight Name: ");
            name = Console.ReadLine();
            Console.Write(" Enter Flight ID: ");
            ID = Console.ReadLine();
            if (ObjectHandler.GetFlightDL().IsFlightExist(ID))
            {
                while (true)
                {
	Console.WriteLine("\t\t\t Edit Flight Schedule\n\n");
                    Console.Write(" Enter Departure Airport: ");
                    source = Console.ReadLine();
	if(!(Validations.CheckCommaandColon(source)))
	{
	Console.WriteLine(" Invalid Departure Airport.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
	}
                    Console.Write(" Enter Arrival Airport: ");
                    destination = Console.ReadLine();
	if(!(Validations.CheckCommaandColon(destination)))
	{
	Console.WriteLine(" Invalid Arrival Airport.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
	}
                    Console.Write(" Enter Departure Date (DD-MM-YYYY): ");
                    date = Console.ReadLine();
                    if (!(Validations.CheckValidDate(date)))
                    {
                        Console.WriteLine(" Invalid Date!!!");
                        Console.WriteLine(" Press any key to continue!!!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    Console.Write(" Enter Departure Time i.e (12:00 AM,05:30 PM): ");
                    takeoff = Console.ReadLine();
                    if (!(Validations.CheckValidTime(takeoff)))
                    {
                        Console.WriteLine(" Invalid Departure Time!!!");
                        Console.WriteLine(" Press any key to continue!!!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                   
                    Console.Write(" Enter Ticket Price: ");
                    checkprice = Console.ReadLine();
                    if (!(Validations.CheckNumber(checkprice)))
                    {
                        Console.WriteLine(" Invalid Price!!!");
                        Console.WriteLine(" Press any key to continue!!!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    price = double.Parse(checkprice);
                    Console.Write(" Enter Number of Seats: ");
                    checkseats = Console.ReadLine();
                    if (!(Validations.CheckNumber(checkseats)))
                    {
                        Console.WriteLine(" Invalid Input!!!");
                        Console.WriteLine(" Press any key to continue!!!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    seats = double.Parse(checkseats);
                    break;
                }
                ObjectHandler.GetFlightDL().EditFlight(name, ID, source, destination, date, takeoff, price, seats);
                Console.WriteLine(" \nThe Desired Flight's schedule is sucessfully updated.");
            }
            else
            {
                Console.WriteLine(" \nNo Such Flight Found.");
            }
            Console.WriteLine(" \n\nPress any key to continue!!!");
            Console.ReadKey();
        }
//Thos function will print all the flights.
        public static void ViewAllFlights()
        {
            List<Flight> Flights = ObjectHandler.GetFlightDL().GetAllFlights();
            Console.WriteLine("\t\t\t View Flights\n\n");
            Console.WriteLine("Flight ID\t\t\t Flight Name\t\t\t Depature Airport\t\t Arrival Airport\t\t Departure Date\t\t Departure Time \t\t Landing Time\t\t Price\t\t Seats\n");
            for (int i = 0; i < Flights.Count; i++)
            {
                Console.WriteLine(Flights[i].ViewFlight());
            }
            Console.WriteLine("\n\n\n Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

//This function will print all flights and revenue generated by them.
public static void ViewFlightsRevenue()
{

List<Flight> flight = ObjectHandler.GetFlightDL().GetAllFlights();

            if (flight != null && flight.Count > 0)
            {
Console.WriteLine("FlightID\t\tFlightName\t\tPrice\t\tSeatsBooked\t\tRevenueGenerated");
                foreach (Flight fl in flight)
                {
                    Console.WriteLine($"{fl.GetFlightID()}\t\t {fl.GetFlightName()}\t\t{fl.GetPrice()}\t\t{GetSeatsBooked(fl.GetFlightID())}\t\t\t{fl.GetRevenue(GetSeatsBooked(fl.GetFlightID()))}");
                }
            }
}
//This function will calculate seats booked for every flight.
public  static int GetSeatsBooked(string FlightID)
        {
            int bookedseats = 0;
            List<Client> clients = ObjectHandler.GetClientDL().GetAllClients();
            foreach (Client C in clients)
            {
                foreach (Flight F in C.GetBookedFlights())
                {
                    if (FlightID == F.GetFlightID())
                        bookedseats++;
                }
            }
            return bookedseats;
        }

    }
}
