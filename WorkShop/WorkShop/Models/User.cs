using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Models
{
    public enum Role
    {
        Admin,
        Employy,
        Manager
    }
    class User
    {
      
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
       
        

        public void UserLoggedIn(string name,string password)
        {
            Name = name;
            Password = password;
            
        }

        public bool IsEmployy()
        {
            if (!Name.Contains("employy")) return false;
            return true;
        }
        public bool IsManaager()
        {
            if (!Name.Contains("manager")) return false;
            return true;
        }
        public bool IsAdmin()
        {
            if (!Name.Contains("admin")) return false;
            return true;
        }
    }
}
