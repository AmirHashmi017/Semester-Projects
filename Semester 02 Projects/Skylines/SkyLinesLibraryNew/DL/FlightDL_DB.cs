using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SkyLinesLibrary
{
    public class FlightDL_DB : IFlightDL
    {
        
        public static List<Flight> Flights = new List<Flight>();

        
        private static DbConfig db = DbConfig.GetInstance();

       
        private static FlightDL_DB FlightDL_DBInstance;

        
        private FlightDL_DB(string connectionstring)
        {
            LoadFlights(); 
        }

        
        public static FlightDL_DB GetFlightDL_DBInstance(string connectionstring)
        {
            if (FlightDL_DBInstance == null)
            {
                FlightDL_DBInstance = new FlightDL_DB(connectionstring); 
            }
            return FlightDL_DBInstance; 
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

        // Method to load flights from the database
        public void LoadFlights()
        {
            string name, ID, source, destination, date, takeoff;
            double price, seats, discount;
            string searchquery = "Select * From Flights"; 
            SqlCommand command = new SqlCommand(searchquery, db.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                ID = reader.GetString(0);
                name = reader.GetString(1);
                source = reader.GetString(2);
                destination = reader.GetString(3);
                date = reader.GetString(4);
                takeoff = reader.GetString(5);
                price = reader.GetDouble(6);
                seats = reader.GetDouble(7);
                discount = reader.GetDouble(8);
                
                
                Flight f = new Flight(ID, name, source, destination, date, takeoff, price, seats);
                f.SetDiscount(discount); 
                Flights.Add(f); 
            }
            reader.Close();
        }

        // Method to store flights in the database
        public void StoreFlights(Flight fl)
        {
            
            string query = string.Format("INSERT INTO Flights(FlightID,FlightName,Source,Destination,TravelDate,TakeoffTime,Price,Seats,Discount)" + "Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                                         fl.GetFlightID(), fl.GetFlightName(), fl.GetSource(), fl.GetDestination(), fl.GetTravelDate(), fl.GetTakeoffTime(), fl.GetPrice(), fl.GetSeats(), fl.GetDiscount());
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }

        // Method to update flight details in the database
        public void UpdateFlight(string originalID, string source, string destination, string date, string takeoff, double price, double seats)
        {
            
            string query = string.Format("UPDATE Flights SET Source='{0}',Destination='{1}',TravelDate='{2}',TakeoffTime='{3}',Price='{4}',Seats='{5}'WHERE FlightID='{6}'",
                                         source, destination, date, takeoff, price, seats, originalID);
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }

        // Method to update flight discount and price in the database
        public void UpdateDiscount(string FlightID, double Discount, double Price)
        {
            
            string query = string.Format("UPDATE Flights SET Discount='{0}',Price='{1}' WHERE FlightID='{2}'", Discount, Price, FlightID);
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
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
