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
    //Class to manage Staff Data.
    public class StaffDL_DB : IStaffDL
    {
  //List to store all staffs.
        public static List<Staff> AirlineStaff = new List<Staff>();

        private static DbConfig db = DbConfig.GetInstance();

        
        private static StaffDL_DB StaffDL_DBInstance;

        private StaffDL_DB(string connectionstring)
        {
            LoadStaff(); 
        }

        public static StaffDL_DB GetStaffDL_DBInstance(string connectionstring)
        {
            if (StaffDL_DBInstance == null)
            {
                StaffDL_DBInstance = new StaffDL_DB(connectionstring);
            }
            return StaffDL_DBInstance;
        }

        // Method to add a new staff member
        public void AddStaff(Staff s)
        {
            AirlineStaff.Add(s); 
            StoreStaff(s); 
        }

        // Method to remove a staff member
        public void RemoveStaff(string name, string staffID)
        {
            for (int i = 0; i < AirlineStaff.Count; i++)
            {
                if (AirlineStaff[i].GetStaffID() == staffID)
                {
                    AirlineStaff.RemoveAt(i);
                    break;
                }
            }
            DeleteStaff(staffID); 
        }

        // Method to edit staff details
        public void EditStaff(string staffID, string newname, string newdesignation, double newsalary)
        {
            for (int i = 0; i < AirlineStaff.Count; i++)
            {
                if (AirlineStaff[i].GetStaffID() == staffID)
                {
                    AirlineStaff[i].SetStaffName(newname);
                    AirlineStaff[i].SetStaffDesignation(newdesignation);
                    AirlineStaff[i].SetStaffSalary(newsalary);
                    break;
                }
            }
            UpdateStaff(staffID, newname, newdesignation, newsalary); 
        }

        // Method to check if a staff ID is valid
        public bool CheckValidStaffID(string ID)
        {
            for (int i = 0; i < AirlineStaff.Count; i++)
            {
                if (AirlineStaff[i].GetStaffID() == ID)
                {
                    return false;
                }
            }
            return true;
        }

        // Method to check if a staff member exists
        public bool IsStaffExist(string ID)
        {
            for (int i = 0; i < AirlineStaff.Count; i++)
            {
                if (AirlineStaff[i].GetStaffID() == ID)
                {
                    return true;
                }
            }
            return false;
        }

        // Method to load staff data from the database
        public void LoadStaff()
        {
            string name, ID, designation;
            double salary;
            string searchquery = "Select * From Staff";
            SqlCommand command = new SqlCommand(searchquery, db.GetConnection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                name = reader.GetString(0);
                ID = reader.GetString(1);
                designation = reader.GetString(2);
                salary = reader.GetDouble(3);
                Staff s = new Staff(name, ID, designation, salary);
                AirlineStaff.Add(s);
            }
            reader.Close();
        }
// Method to store staff data in the database
        public void StoreStaff(Staff st)
        {
            string query = string.Format("INSERT INTO Staff(StaffName,StaffID,StaffDesignation,StaffSalary)" + "Values ('{0}','{1}','{2}','{3}')", st.GetStaffName(), st.GetStaffID(), st.GetStaffDesignation(), st.GetStaffSalary());
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }
// Method to load update staff data from the database
        public void UpdateStaff(string originalID, string name, string designation, double salary)
        {
            string query = string.Format("UPDATE Staff SET StaffName='{0}',StaffDesignation='{1}',StaffSalary='{2}' WHERE StaffID='{3}'", name, designation, salary, originalID);
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }
// Method to load delete staff data from the database
        public void DeleteStaff(string staffID)
        {
            string query = string.Format("DELETE FROM Staff WHERE StaffID='{0}'", staffID);
            SqlCommand cmd = new SqlCommand(query, db.GetConnection());
            cmd.ExecuteNonQuery();
        }
//Method to return the List of all staff Members.
        public List<Staff> GetAllStaff()
        {
            return AirlineStaff;
        }
    }
}

