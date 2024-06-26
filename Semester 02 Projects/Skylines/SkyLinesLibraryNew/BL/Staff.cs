using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLinesLibrary
{
    public class Staff
    {
        
        private string StaffName; 
        private string StaffID; 
        private string StaffDesignation;
        private double StaffSalary; 

      
        public Staff(string name, string ID, string designation, double salary)
        {
            this.StaffName = name; 
            this.StaffID = ID; 
            this.StaffDesignation = designation; 
            this.StaffSalary = salary;  
        }

        // Method to view staff details.
        public string ViewStaff()
        {
            return ($" {StaffID}\t\t\t \t{StaffName}\t\t\t\t {StaffDesignation}\t\t\t\t{StaffSalary}");
        }

        // Method to get the staff name.
        public string GetStaffName()
        {
            return StaffName; 
        }

        // Method to set the staff name.
        public void SetStaffName(string name)
        {
            this.StaffName = name; 
        }

        // Method to get the staff ID.
        public string GetStaffID()
        {
            return StaffID; 
        }

        // Method to set the staff ID.
        public void SetStaffID(string ID)
        {
            this.StaffID = ID;
        }

        // Method to get the staff designation.
        public string GetStaffDesignation()
        {
            return StaffDesignation; 
        }

        // Method to set the staff designation.
        public void SetStaffDesignation(string designation)
        {
            this.StaffDesignation = designation; 
        }

        // Method to get the staff salary.
        public double GetStaffSalary()
        {
            return StaffSalary; 
        }

        // Method to set the staff salary.
        public void SetStaffSalary(double salary)
        {
            this.StaffSalary = salary; 
        }
    }
}
