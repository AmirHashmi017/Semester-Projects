using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyLinesLibrary; 

namespace SkyLines
{
   
    internal class ObjectHandler
    {
        
        public static string connectionstring = "server=localhost\\SQLEXPRESS;database=SKYLINES;Trusted_Connection=True;";

       
        private static IAdminDL AdminDL = AdminDL_DB.GetAdminDL_DBInstance(connectionstring);
        private static IStaffDL StaffDL = StaffDL_DB.GetStaffDL_DBInstance(connectionstring);
        private static IFlightDL FlightDL = FlightDL_DB.GetFlightDL_DBInstance(connectionstring);
        private static IClientDL ClientDL = ClientDL_DB.GetClientDL_DBInstance(connectionstring);

         
       /* private static IAdminDL AdminDL = AdminDL_FH.GetAdminDL_FHInstance("G:\\AMSNew\\SKYLINES(Admins).txt");
        private static IStaffDL StaffDL = StaffDL_FH.GetStaffDL_FHInstance("G:\\AMSNew\\SKYLINES(Staff).txt");
        private static IFlightDL FlightDL = FlightDL_FH.GetFlightDL_FHInstance("G:\\AMSNew\\SKYLINES(Flights).txt");
        private static IClientDL ClientDL = ClientDL_FH.GetClientDL_FHInstance("G:\\AMSNew\\SKYLINES(Clients).txt");*/
        

        
        public static IAdminDL GetAdminDL()
        {
            return AdminDL;
        }

       
        public static IClientDL GetClientDL()
        {
            return ClientDL;
        }

        
        public static IStaffDL GetStaffDL()
        {
            return StaffDL;
        }

        
        public static IFlightDL GetFlightDL()
        {
            return FlightDL;
        }
    }
}


