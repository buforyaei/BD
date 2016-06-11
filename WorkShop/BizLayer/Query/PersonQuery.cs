using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Runtime;
using DataLayer;

namespace BizLayer.Query
{
    public class PersonQuery
    {
        public static IQueryable<DataLayer.Person> GetPerson(int id)
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Persons
                     where z.personID.Equals(id)
                     select z;

            return (zz);
        }
        public static IQueryable<DataLayer.Person> GetPersons() //int id
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Persons
                     select z;

            return (zz);
        }

        public static void AddPerson(string name, string surname, string address, int phone)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                Person person = new Person();
                person.name = name;
                person.surname = surname;
                person.address = address;
                person.phone = phone;
                dc.Persons.InsertOnSubmit(person);
                dc.SubmitChanges();
            }
        }
        public static void UpdateEmployee(int id, string name, string surname, string address, int phone)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var person = from p in dc.Persons
                          where p.personID == id
                          select p;
                Person person_ = person.Single();
                person_.name = name;
                person_.surname = surname;
                person_.address = address;
                person_.phone = phone;
                dc.SubmitChanges();
            }
        }
        public static void DeleteEmployee(int id)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var person = from p in dc.Persons
                          where p.personID == id
                          select p;
                foreach (var p in person)
                {
                    dc.Persons.DeleteOnSubmit(p);
                }
                dc.SubmitChanges();

            }
        }
    }
}
