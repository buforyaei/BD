using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    partial class Person
    {
        public override string ToString()
        {
            return this.name;
        }
    }
    partial class Object
    {
        public override string ToString()
        {
            return "Name: " + this.name + " Model: " + this.model + " Id: " + this.objectID;
        }
    }
    partial class Client
    {
        public override string ToString()
        {
            return "Name: " + this.Person.name;
        }
    }
  
}
