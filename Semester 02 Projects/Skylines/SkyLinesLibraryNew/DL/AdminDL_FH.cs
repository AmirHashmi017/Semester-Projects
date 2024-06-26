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
    public  class AdminDL_FH : IAdminDL
    {
        
        private static List<Admin> Admins = new List<Admin>();
       
        
        private static string filepath;

        
        private static AdminDL_FH AdminDL_FHInstance;

        
        private AdminDL_FH(string FilePath)
        {
            filepath=FilePath; 
            LoadAdmins(); 
        }

        // Method to get an instance of AdminDL_FH
        public static AdminDL_FH GetAdminDL_FHInstance(string FilePath)
        {
            if(AdminDL_FHInstance == null)
            {
                AdminDL_FHInstance = new AdminDL_FH(FilePath); 
            }
            return AdminDL_FHInstance; 
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

        // Method to load admins from the file
        public void LoadAdmins()
        {
            string name, password, role;
            string record;
            if (File.Exists(filepath))
            {
                StreamReader adminfile = new StreamReader(filepath);
                while ((record = adminfile.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    name = data[0];
                    password = data[1];
                    role = data[2];
                    Admin a = new Admin(name, password, role);
                    Admins.Add(a); 
                }
                adminfile.Close();
            }
            else { return; } 
        }

        // Method to store admin in the file
        public void StoreAdmins(Admin ad)
        {
            StreamWriter adminfile = new StreamWriter(filepath, true);
            adminfile.WriteLine($"{ad.GetName()},{ad.GetPassword()},{ad.GetRole()}");
            adminfile.Flush();
            adminfile.Close();
        }

        // Method to get all admins
        public List<Admin> GetAllAdmins()
        {
            return Admins; 
        }
    }
}
