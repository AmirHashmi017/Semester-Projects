using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkyLinesLibrary; // Importing necessary namespaces
namespace SkyLines
{
    internal class StaffUI
    {
        //This function will take input for hiring new staff.
        public static void HireStaff()
        {
            string name; string ID; string designation; double salary;
            while (true)
            {
                Console.WriteLine("\t\t\t Hire Staff\n\n");
                Console.Write(" Enter Staff ID: ");
                ID = Console.ReadLine();
                if (!(Validations.CheckCommaandColon(ID)))
                {
                    Console.WriteLine(" Invalid Staff ID.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                if (!(ObjectHandler.GetStaffDL().CheckValidStaffID(ID)))
                {
                    Console.WriteLine(" This StaffID Already Exist.Kindly Enter any other ID.");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.Write(" Enter Staff Name: ");
                name = Console.ReadLine();
                if (!(Validations.CheckCommaandColon(name)))
                {
                    Console.WriteLine(" Invalid Staff Name.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.Write(" Enter Staff Designation: ");
                designation = Console.ReadLine();
                if (!(Validations.CheckCommaandColon(designation)))
                {
                    Console.WriteLine(" Invalid Staff Designation.Comma and colon is not Allowed!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                Console.Write(" Enter Staff Salary: ");
                string checksalary = Console.ReadLine();
                if (!(Validations.CheckNumber(checksalary)))
                {
                    Console.WriteLine(" Invalid Salary!!!");
                    Console.WriteLine(" Press any key to continue!!!");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                salary = double.Parse(checksalary);
                Staff s = new Staff(name, ID, designation, salary);
                ObjectHandler.GetStaffDL().AddStaff(s);
                break;
            }
            Console.WriteLine(" \nThe Desired Staff is Sucessfully Hired.");
            Console.WriteLine(" \n\nPress any key to continue!!!");
            Console.ReadKey();
        }
        //This function will take input for expelling existing staff.
        public static void ExpellStaff()
        {
            Console.WriteLine("\t\t\t Expel Staff\n\n");
            Console.Write(" Enter Staff Name: ");
            string name = Console.ReadLine();
            Console.Write(" Enter Staff ID: ");
            string ID = Console.ReadLine();
            ObjectHandler.GetStaffDL().RemoveStaff(name, ID);
            Console.WriteLine(" \nThe Desired Staff is Expelled.");

            Console.WriteLine(" Press any key to continue!!!");
            Console.ReadKey();
        }
        //This function will take input for updating staff.
        public static void UpdateStaff()
        {
            string newname, newdesignation, checksalary;
            double newsalary;
            Console.Write(" Enter Staff Name: ");
            string name = Console.ReadLine();
            Console.Write(" Enter Staff ID: ");
            string ID = Console.ReadLine();
            if (ObjectHandler.GetStaffDL().IsStaffExist(ID))
            {
                while (true)
                {
                    Console.WriteLine("\t\t\t Update Staff Information\n\n");
                    Console.Write(" Enter Edited Staff Name: ");
                    newname = Console.ReadLine();
                    if (!(Validations.CheckCommaandColon(name)))
                    {
                        Console.WriteLine(" Invalid Staff Name.Comma and colon is not Allowed!!!");
                        Console.WriteLine(" Press any key to continue!!!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    Console.Write(" Enter Edited Staff Designation: ");
                    newdesignation = Console.ReadLine();
                    if (!(Validations.CheckCommaandColon(newdesignation)))
                    {
                        Console.WriteLine(" Invalid Staff Designation.Comma and colon is not Allowed!!!");
                        Console.WriteLine(" Press any key to continue!!!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    Console.Write(" Enter Edited Staff Salary: ");
                    checksalary = Console.ReadLine();
                    if (!(Validations.CheckNumber(checksalary)))
                    {
                        Console.WriteLine(" Invalid Salary!!!");
                        Console.WriteLine(" Press any key to continue!!!");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                    break;
                }
                newsalary = double.Parse(checksalary);
                ObjectHandler.GetStaffDL().EditStaff(ID, newname, newdesignation, newsalary);
                Console.WriteLine(" \nThe Desired Staff's Information is sucessfully updated.");
            }
            else
            {
                Console.WriteLine(" \nNo Such Staff Found.");
            }
            Console.WriteLine(" \n\nPress any key to continue!!!");
            Console.ReadKey();
        }
        //This function will print all the staff.
        public static void ViewAllStaff()
        {
            List<Staff> AirlineStaff = ObjectHandler.GetStaffDL().GetAllStaff();
            Console.WriteLine("\t\t\t View AirLine Staff\n\n");
            Console.WriteLine("Staff ID\t\t\t Staff Name\t\t\t Designation\t\t\t Salary\n");
            for (int i = 0; i < AirlineStaff.Count; i++)
            {
                Console.WriteLine(AirlineStaff[i].ViewStaff());
            }
            Console.WriteLine("\n\n Press any key to Continue..");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
