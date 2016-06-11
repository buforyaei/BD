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
    public class EmployeesQuery
    {
        public static IQueryable<DataLayer.Employee> GetEmployee(int id)
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Employees
                     where z.employID.Equals(id)
                     select z;

            return (zz);
        }
        public static IQueryable<DataLayer.Employee> GetEmployees()//int id
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Employees
                     select z;

            return (zz);
        }

        public static void AddEmployee(string username, string password, string role, int personID) //,int personID
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                Employee employee = new Employee();
                employee.username = username;
                employee.password = password;
                employee.role = role;
               // employee.personID = personID;
                dc.Employees.InsertOnSubmit(employee);
                dc.SubmitChanges();
            }
        }
        public static void UpdateEmployee(int id, string username, string password, string role, int personID)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var emp = from e in dc.Employees
                              where e.employID == id
                              select e;
                Employee emp_ = emp.Single();
                emp_.username = username;
                emp_.password = password;
                emp_.role = role;
                emp_.personID = personID;
                dc.SubmitChanges();
            }
        }
        public static void DeleteEmployee(int id)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var emp = from e in dc.Employees
                          where e.employID == id
                          select e;
                foreach (var e in emp)
                {
                    dc.Employees.DeleteOnSubmit(e);
                }
                dc.SubmitChanges();
                
            }
        }
    }
}
