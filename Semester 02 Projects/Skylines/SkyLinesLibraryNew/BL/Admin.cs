using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace SkyLinesLibrary
{
//This 'Admin' Class is a Child Class which is inheriting 'Person' class.
    public class Admin : Person
    {
        public Admin(string name, string password, string role) : base(name, password, role)
        {

        }
	//Method to get admin details.
	public string ViewAdmin()
	{
	return ($"{Name}\t\t\t{Password}\t\t\t{Role}");
	}
    }
}

