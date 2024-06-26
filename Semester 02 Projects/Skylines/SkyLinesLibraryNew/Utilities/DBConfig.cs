using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;

namespace SkyLinesLibrary
{
    // A  class to manage database connection
    public class DbConfig
    {

        private static string connectionString = "server=AMIR-HASHMI;database=SKYLINES;Trusted_Connection=True;";



        private SqlConnection con;

       
        private static DbConfig instance;

        
        private DbConfig()
        {
            con = new SqlConnection(connectionString);
        }

        
        public static DbConfig GetInstance()
        {
            if (instance == null)
            {
                instance = new DbConfig();
            }
            return instance;
        }

       
        public void OpenConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        
        public SqlConnection GetConnection()
        {
            OpenConnection(); 
            return con;
        }
    }
}
