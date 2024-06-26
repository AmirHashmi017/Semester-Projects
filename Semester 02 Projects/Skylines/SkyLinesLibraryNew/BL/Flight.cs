using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLinesLibrary
{
    public class Flight
    {
        private string FlightID; 
        private string FlightName; 
        private string Source; 
        private string Destination; 
        private double Price; 
        private double Discount; 
        private string TravelDate; 
        private string TakeoffTime; 
        private double Seats; 

        public Flight(string FlightID, string FlightName, string Source, string Destination, string TravelDate, string TakeoffTime, double Price, double Seats)
        {
            this.FlightID = FlightID; 
            this.FlightName = FlightName; 
            this.Source = Source;
            this.Destination = Destination; 
            this.TravelDate = TravelDate;
            this.TakeoffTime = TakeoffTime;
            this.Price = Price;
            this.Seats = Seats; 
            this.Discount = 0; 
        }

        // Method to view flight details
        public string ViewFlight()
        {
            return ($" {FlightID}\t\t\t\t {FlightName}\t\t\t {Source}\t\t\t\t {Destination}\t\t\t\t {TravelDate}\t\t\t {TakeoffTime}\t\t\t {Price}\t\t{Seats}");
        }

        // Method to get the flight name
        public string GetFlightName()
        {
            return FlightName;
        }

        // Method to set the flight name
        public void SetFlightname(string name)
        {
            this.FlightName = name;
        }

        // Method to get the flight ID
        public string GetFlightID()
        {
            return FlightID;
        }

        // Method to set the flight ID
        public void SetFlightID(string ID)
        {
            this.FlightID = ID;
        }

        // Method to get the source of the flight
        public string GetSource()
        {
            return Source;
        }

        // Method to set the source of the flight
        public void SetSource(string source)
        {
            this.Source = source;
        }

        // Method to get the destination of the flight
        public string GetDestination()
        {
            return Destination;
        }

        // Method to set the destination of the flight
        public void SetDestination(string destination)
        {
            this.Destination = destination;
        }

        // Method to get the travel date of the flight
        public string GetTravelDate()
        {
            return TravelDate;
        }

        // Method to set the travel date of the flight
        public void SetTravelDate(string TravelDate)
        {
            this.TravelDate = TravelDate;
        }

        // Method to get the takeoff time of the flight
        public string GetTakeoffTime()
        {
            return TakeoffTime;
        }

        // Method to set the takeoff time of the flight
        public void SetTakeoffTime(string time)
        {
            this.TakeoffTime = time;
        }

        // Method to get the discount applied to the flight
        public double GetDiscount()
        {
            return Discount;
        }

        // Method to set the discount applied to the flight
        public void SetDiscount(double Discount)
        {
            this.Discount = Discount;
        }

        // Method to get the price of the flight
        public double GetPrice()
        {
            return Price;
        }

        // Method to set the price of the flight
        public void SetPrice(double price)
        {
            this.Price = price;
        }

        // Method to get the number of seats in the flight
        public double GetSeats()
        {
            return Seats;
        }

        // Method to set the number of seats in the flight
        public void SetSeats(double seats)
        {
            this.Seats = seats;
        }

        // Method to issue discount on the flight
        public void IssueDiscount(string FlightID, double Discount)
        {
            this.Discount = Discount;
            Price -= Price * (Discount / 100);
        }
        
        // Method to calculate revenue for the flight based on booked seats
        public double GetRevenue(int bookedseats)
        {
            double revenue = bookedseats * Price;
            return revenue;
        }
    }
}
