
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyLinesLibrary; // Importing necessary namespaces
using System.Data.SqlClient;

namespace SkyLines_Website
{
    // A class to handle the initialization of data access objects
    internal class ObjectHandler
    {
        // Connection string for the database
        public static string connectionstring = "server=Amir-Hashmi;database=SKYLINES;Trusted_Connection=True;";

        // Data access objects for different entities
        private static IAdminDL AdminDL = AdminDL_DB.GetAdminDL_DBInstance(connectionstring);
        private static IStaffDL StaffDL = StaffDL_DB.GetStaffDL_DBInstance(connectionstring);
        private static IFlightDL FlightDL = FlightDL_DB.GetFlightDL_DBInstance(connectionstring);
        private static IClientDL ClientDL = ClientDL_DB.GetClientDL_DBInstance(connectionstring);

        
        /*private static IAdminDL AdminDL = AdminDL_FH.GetAdminDL_FHInstance("D:\\Semester 02 Projects\\Skylines\\AMSNew1\\SKYLINES(Admins).txt");
        private static IStaffDL StaffDL = StaffDL_FH.GetStaffDL_FHInstance("D:\\Semester 02 Projects\\Skylines\\AMSNew1\\SKYLINES(Staff).txt");
        private static IFlightDL FlightDL = FlightDL_FH.GetFlightDL_FHInstance("D:\\Semester 02 Projects\\Skylines\\AMSNew1\\SKYLINES(Flights).txt");
        private static IClientDL ClientDL = ClientDL_FH.GetClientDL_FHInstance("D:\\Semester 02 Projects\\Skylines\\AMSNew1\\SKYLINES(Clients).txt");*/
        

        // Method to get the data access object for administrators
        public static IAdminDL GetAdminDL()
        {
            return AdminDL;
        }

        // Method to get the data access object for clients
        public static IClientDL GetClientDL()
        {
            return ClientDL;
        }

        // Method to get the data access object for staff
        public static IStaffDL GetStaffDL()
        {
            return StaffDL;
        }

        // Method to get the data access object for flights
        public static IFlightDL GetFlightDL()
        {
            return FlightDL;
        }
        public static int GetSeatsBooked(string FlightID)
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
        public static double GetSeatsBookedPrice(Flight fl)
        {
            int bookedseats = GetSeatsBooked(fl.GetFlightID());
            double price = fl.GetPrice() * bookedseats;
            return price;
            
        }
    }
}



