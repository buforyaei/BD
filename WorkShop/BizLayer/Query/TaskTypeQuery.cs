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
    public class TaskTypeQuery
    {
        public static IQueryable<DataLayer.Task_type> GetTaskType(int id)
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Task_types
                     where z.code.Equals(id)
                     select z;

            return (zz);
        }
        public static IQueryable<DataLayer.Task_type> GetTaskTypes()
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Task_types
                     select z;

            return (zz);
        }
        public static void AddTaskType(int code, string name)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                Task_type task = new Task_type();
                task.code = code;
                task.name = name;
                dc.Task_types.InsertOnSubmit(task);
                dc.SubmitChanges();
            }
        }
        public static void UpdateTaskType(int code, string name)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var task = from t in dc.Task_types
                           where t.code == code
                           select t;
                Task_type task_ = task.Single();
                task_.name = name;
                dc.SubmitChanges();
            }
        }

        public static void DeleteTaskType(int code)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var task = from t in dc.Task_types
                           where t.code == code
                           select t;
                foreach (var t in task)
                {
                    dc.Task_types.DeleteOnSubmit(t);
                }
                dc.SubmitChanges();
            }
        }
    }
}
