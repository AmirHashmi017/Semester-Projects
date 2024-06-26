using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkyLinesLibrary
{
    // This 'Person' Class is a Parent Class which is inherited by two child classes 'Admin' and 'Client.'
    public class Person
    {
        protected string Name; 
        protected string Password;
        protected string Role; 

        
        public Person(string name, string password, string role)
        {
            this.Name = name; 
            this.Password = password; 
            this.Role = role; 
        }

        // Method to get the name of the person
        public string GetName()
        {
            return Name; 
        }

        // Method to set the name of the person
        public void SetName(string name)
        {
            this.Name = name; 
        }

        // Method to get the password of the person
        public string GetPassword()
        {
            return Password; 
        }

        // Method to set the password of the person
        public void SetPassword(string password)
        {
            this.Password = password; 
        }

        // Method to get the role of the person
        public string GetRole()
        {
            return Role; 
        }

        // Method to set the role of the person
        public void SetRole(string role)
        {
            this.Role = role; 
        }
    }
}
