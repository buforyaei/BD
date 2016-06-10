using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Runtime;
using DataLayer;

namespace BizLayer
{
    public class ProblemQuery
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static IQueryable<DataLayer.Problem> GetProblem(int id)
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Problems
                     where z.problemID.Equals(id)
                     select z;

            return (zz);
        }
        public static IQueryable<DataLayer.Problem> GetProblems()
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Problems
                     select z;

            return (zz);
        }
        public static void AddProblem(DateTime beginDate, DateTime endDate, string problemDesc,
                string resultDesc)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                Problem problem = new Problem();
                problem.beginDate = beginDate;
                problem.endDate = endDate;
                problem.problemDesc = problemDesc;
                problem.resultDesc = resultDesc;

                dc.Problems.InsertOnSubmit(problem);
                dc.SubmitChanges();
            }
        }
        public static void UpdateProblem(int id, DateTime beginDate, DateTime endDate, string problemDesc,
                string resultDesc)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var problem = from p in dc.Problems
                              where p.problemID == id
                              select p;
                Problem problem_ = problem.Single();
                problem_.beginDate = beginDate;
                problem_.endDate = endDate;
                problem_.problemDesc = problemDesc;
                problem_.resultDesc = resultDesc;

                dc.SubmitChanges();
            }
        }
        public static void DeleteProblem(int id)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var problem = from p in dc.Problems
                              where p.problemID == id
                              select p;
                foreach (var p in problem)
                {
                    dc.Problems.DeleteOnSubmit(p);
                }
                dc.SubmitChanges();
                //try
                //{

                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine(e);
                //    // Provide for exceptions.
                //}
            }
        }

    }
}
