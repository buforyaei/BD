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
    public class ObjectQuery
    {
        public static IQueryable<DataLayer.Object> GetObject(int id)
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Objects
                     where z.objectID.Equals(id)
                     select z;

            return (zz);
        }

        public static IQueryable<DataLayer.Object> GetObjects()
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Objects
                     select z;

            return (zz);
        }
        public static void AddObject(int clientID)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                DataLayer.Object obj = new DataLayer.Object();
                obj.clientID = clientID;
                dc.Objects.InsertOnSubmit(obj);
                dc.SubmitChanges();
            }
        }
        public static void UpdateObject(int id, int clientID)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var obj = from o in dc.Objects
                              where o.objectID == id
                              select o;
                DataLayer.Object obj_ = obj.Single();
                obj_.clientID = clientID;
                dc.SubmitChanges();
            }
        }

        public static void DeleteObject(int id)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var obj = from o in dc.Objects
                          where o.objectID == id
                          select o;
                var problem = from p in dc.Problems
                              where p.objectID == id
                              select p;
                foreach(var p in problem)
                {
                    p.objectID = null;
                }
                foreach(var o in obj)
                {
                    dc.Objects.DeleteOnSubmit(o);
                }
                dc.SubmitChanges();
            }
        }
    }
}
