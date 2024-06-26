using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
namespace SkyLinesLibrary
{
    public class FlightDL_FH : IFlightDL
    {
        public static List<Flight> Flights = new List<Flight>();
     
        private static string filepath;
        private static FlightDL_FH FlightDL_FHInstance;

        private FlightDL_FH(string FilePath)
        {
            filepath = FilePath;
            LoadFlights();
        }

        public static FlightDL_FH GetFlightDL_FHInstance(string FilePath)
        {
            if (FlightDL_FHInstance == null)
            {
                FlightDL_FHInstance = new FlightDL_FH(FilePath); 
            }
            return FlightDL_FHInstance; 
        }

        // Method to add a flight
        public void AddFlight(Flight f)
        {
            Flights.Add(f); 
            StoreFlights(f); 
        }

        // Method to edit flight details
        public void EditFlight(string name, string flightID, string source, string destination, string date, string takeoff, double price, double seats)
        {
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].GetFlightID() == flightID)
                {
                    Flights[i].SetSource(source);
                    Flights[i].SetDestination(destination);
                    Flights[i].SetTravelDate(date);
                    Flights[i].SetTakeoffTime(takeoff);
                    Flights[i].SetPrice(price);
                    Flights[i].SetSeats(seats);
                    break;
                }
            }
            UpdateFlight(flightID, source, destination, date, takeoff, price, seats); 
        }

        // Method to check if a flight ID is valid
        public bool CheckValidFlightID(string ID)
        {
            
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].GetFlightID() == ID)
                {
                    return false; 
                }
            }
            return true; 
        }

        // Method to check if a flight exists
        public bool IsFlightExist(string ID)
        {
           
            for (int i = 0; i < Flights.Count; i++)
            {
                if (Flights[i].GetFlightID() == ID)
                {
                    return true; 
                }
            }
            return false;
        }

        // Method to load flights from the file
        public void LoadFlights()
        {
            string name, ID, source, destination, date, takeoff, record;
            double price, seats, discount;
            if (File.Exists(filepath))
            {
                StreamReader flightfile = new StreamReader(filepath);
                while ((record = flightfile.ReadLine()) != null)
                {
                    string[] data = record.Split(';');
                    ID = data[0];
                    name = data[1];
                    source = data[2];
                    destination = data[3];
                    date = data[4];
                    takeoff = data[5];
                    price = double.Parse(data[6]);
                    seats = double.Parse(data[7]);
                    discount = double.Parse(data[8]);
                    Flight f = new Flight(ID, name, source, destination, date, takeoff, price, seats);
                    f.SetDiscount(discount);
                    Flights.Add(f);
                }
                flightfile.Close();
            }
            else { return; }
        }

        // Method to store flights in the file
        public void StoreFlights(Flight fl)
        {
            StreamWriter Flightfile = new StreamWriter(filepath, true);
            Flightfile.WriteLine($"{fl.GetFlightID()}; {fl.GetFlightName()};{fl.GetSource()};{fl.GetDestination()}; {fl.GetTravelDate()}; {fl.GetTakeoffTime()}; {fl.GetPrice()}; {fl.GetSeats()};{fl.GetDiscount()}");
            Flightfile.Flush();
            Flightfile.Close();
        }

        // Method to update flight details in the file
        public void UpdateFlight(string originalID, string source, string destination, string date, string takeoff, double price, double seats)
        {
            File.WriteAllText(filepath, string.Empty); 
            foreach (Flight fl in Flights)
            {
                StoreFlights(fl); 
            }
        }

        // Method to update flight discount and price in the file
        public void UpdateDiscount(string FlightID, double Discount, double Price)
        {
            File.WriteAllText(filepath, string.Empty); 
            foreach (Flight fl in Flights)
            {
                StoreFlights(fl); 
            }
        }

        // Method to get all flights
        public List<Flight> GetAllFlights()
        {
            return Flights; 
        }

        // Method to get flight by ID
        public Flight GetFlightByID(string FlightID)
        {
            foreach (Flight f in Flights)
            {
                if (f.GetFlightID() == FlightID)
                {
                    return f; 
                }
            }
            return null; 
        }
    }
}
