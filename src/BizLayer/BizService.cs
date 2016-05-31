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
    public static class BizService
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        public static IQueryable<Problem> GetProblem(int txt)
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Problems
                     where z.problemID.Equals(txt)
                     select z;

            return (zz);
        }
    }
}
