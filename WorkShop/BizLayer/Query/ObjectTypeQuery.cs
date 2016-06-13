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
    public class ObjectTypeQuery
    {
        public static IQueryable<DataLayer.Object_type> GetObjectType(int id)
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Object_types
                     where z.code.Equals(id)
                     select z;

            return (zz);
        }
        public static IQueryable<DataLayer.Object_type> GetObjectTypes()
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Object_types
                     select z;

            return (zz);
        }
        public static void AddObjectType(int code, string name)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                Object_type obj = new Object_type();
                obj.code = code;
                obj.name = name;
                dc.Object_types.InsertOnSubmit(obj);
                dc.SubmitChanges();
            }
        }
        public static void UpdateObjectType(int code, string name)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var obj = from o in dc.Object_types
                           where o.code == code
                           select o;
                Object_type obj_ = obj.Single();
                obj_.name = name;
                dc.SubmitChanges();
            }
        }

        public static void DeleteObjectType(int code)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var obj= from o in dc.Object_types
                           where o.code == code
                           select o;
                foreach (var o in obj)
                {
                    dc.Object_types.DeleteOnSubmit(o);
                }
                dc.SubmitChanges();
            }
        }
    }
}
