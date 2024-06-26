using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SkyLinesLibrary
{
    public class AdminDL_DB : IAdminDL
    {
        
        public static List<Admin> Admins = new List<Admin>();

       
        private DbConfig db = DbConfig.GetInstance();

        
        private static AdminDL_DB AdminDL_DBInstance;

        
        private AdminDL_DB(string connectionstring)
        {
            LoadAdmins(); 
        }

        
        public static AdminDL_DB GetAdminDL_DBInstance(string connectionstring)
        {
            if (AdminDL_DBInstance == null)
            {
                AdminDL_DBInstance = new AdminDL_DB(connectionstring);
            }
            return AdminDL_DBInstance;
        }

        // Method to add an admin
        public void AddAdmin(Admin admin)
        {
            Admins.Add(admin); 
            StoreAdmins(admin);
        }

        // Method to check if an admin exists
        public bool IsAdminExist(string name, string password)
        {
          
            for (int i = 0; i < Admins.Count; i++)
            {
                if (Admins[i].GetName() == name && Admins[i].GetPassword() == password)
                {
                    return true; 
                }
            }
            return false; 
        }

        // Method to find the index of an admin
        public int FindAdmin(string name, string password)
        {
            int AdminNo = 1000; 
            
            for (int i = 0; i < Admins.Count; i++)
            {
                if (Admins[i].GetName() == name && Admins[i].GetPassword() == password)
                {
                    AdminNo = i; 
                    return AdminNo; 
                }
            }
            return AdminNo; 
        }

        // Method to check if admin name is valid
        public bool CheckValidAdminName(string name)
        {
            
            for (int i = 0; i < Admins.Count; i++)
            {
                if (Admins[i].GetName() == name)
                {
                    return false; 
                }
            }
            return true; 
        }

        // Method to load admins from the database
        public void LoadAdmins()
        {
            
            string name, password, role;
            string searchquery = "Select * From Admins";
            SqlCommand command = new SqlCommand(searchquery, db.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                name = reader.GetString(0);
                password = reader.GetString(1);
                role = reader.GetString(2);
                Admin a = new Admin(name, password, role);
                Admins.Add(a); 
            }
            reader.Close();
        }

        // Method to store admin in the database
        public void StoreAdmins(Admin ad)
        {
            
            string query = string.Format("INSERT INTO Admins(AdminName,AdminPassword,Role)" + "Values ('{0}','{1}','{2}')", ad.GetName(), ad.GetPassword(), ad.GetRole());

            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }

        // Method to get all admins
        public List<Admin> GetAllAdmins()
        {
            return Admins; 
        }
    }
}
