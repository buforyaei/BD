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
    public class TaskQuery
    {
        public static IQueryable<DataLayer.Task> GetTask(int id)
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Tasks
                     where z.taskID.Equals(id)
                     select z;

            return (zz);
        }

        public static IQueryable<DataLayer.Task> GetTasks()
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Tasks
                     select z;

            return (zz);
        }

        public static void AddTask(DateTime beginDate, DateTime endDate, string taskDesc,
                string resultDesc, string status)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                DataLayer.Task task = new DataLayer.Task();
                task.beginDate = beginDate;
                task.endDate = endDate;
                task.taskDesc = taskDesc;
                task.resultDesc = resultDesc;
                task.status = status;

                dc.Tasks.InsertOnSubmit(task);
                dc.SubmitChanges();
            }
        }
        public static void UpdateProblem(int id, DateTime beginDate, DateTime endDate, string taskDesc,
                string resultDesc,string status)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var task = from t in dc.Tasks
                              where t.taskID == id
                              select t;
                DataLayer.Task task_ = task.Single();
                task_.beginDate = beginDate;
                task_.endDate = endDate;
                task_.taskDesc = taskDesc;
                task_.resultDesc = resultDesc;
                task_.status = status;

                dc.SubmitChanges();
            }
        }
        public static void DeleteProblem(int id)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var task = from t in dc.Tasks
                           where t.taskID == id
                           select t;
                foreach (var t in task)
                {
                    dc.Tasks.DeleteOnSubmit(t);
                }
                dc.SubmitChanges();
            }
        }
    }
}
