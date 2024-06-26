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
// A class to manage staff data.
    public class StaffDL_FH : IStaffDL
    {
// A list to store data of all Staff members.
        private static List<Staff> AirlineStaff = new List<Staff>();
       
        private static string filepath;
        private static StaffDL_FH StaffDL_FHInstance;
        private StaffDL_FH(string FilePath)
        {
            filepath = FilePath;
            LoadStaff();
        }
        public static StaffDL_FH GetStaffDL_FHInstance(string FilePath)
        {
            if (StaffDL_FHInstance == null)
            {
                StaffDL_FHInstance = new StaffDL_FH(FilePath);
            }
            return StaffDL_FHInstance;
        }
//This method adds staff into list.
        public void AddStaff(Staff s)
        {
            AirlineStaff.Add(s);
            StoreStaff(s);
        }
//This method removes staff from list.
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
//This method update staff's record from list.
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
//This method checks that the staff ID is valid or not by checking that it already exist or not.
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
//This method checks whether the staff exists or not.
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
//This method load staff data from file.
        public void LoadStaff()
        {
            string Name, ID, Designation;
            double Salary;
            string record;
            if (File.Exists(filepath))
            {
                StreamReader stafffile = new StreamReader(filepath);
                while ((record = stafffile.ReadLine()) != null)
                {
                    string[] data = record.Split(',');
                    ID = data[0];
                    Name = data[1];
                    Designation = data[2];
                    Salary = double.Parse(data[3]);
                    Staff s = new Staff(Name, ID, Designation, Salary);
                    AirlineStaff.Add(s);
                }
                stafffile.Close();
            }
            else { return; }
        }
//This method stores staff data in file.
        public void StoreStaff(Staff st)
        {
            StreamWriter stafffile = new StreamWriter(filepath, true);
            stafffile.WriteLine($"{st.GetStaffID()},{st.GetStaffName()},{st.GetStaffDesignation()},{st.GetStaffSalary()}");
            stafffile.Flush();
            stafffile.Close();
        }
//This method update staff data in file.
        public void UpdateStaff(string originalID, string name, string designation, double salary)
        {
            File.WriteAllText(filepath, string.Empty);
            foreach (Staff st in AirlineStaff)
            {
                StoreStaff(st);
            }
        }
//This method delete staff data from file.
        public void DeleteStaff(string staffID)
        {
            File.WriteAllText(filepath, string.Empty);
            foreach (Staff st in AirlineStaff)
            {
                StoreStaff(st);
            }
        }
//This method returns the list of all staffs.
        public List<Staff> GetAllStaff()
        {
            return AirlineStaff;
        }
    }
}


