using System.Linq;
using DataLayer;

namespace BizLayer.Query
{
    public class ClientQuery
    {
        public static IQueryable<DataLayer.Client> GetClient(int id)
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Clients
                     where z.clientID.Equals(id)
                     select z;

            return (zz);
        }
        public static IQueryable<DataLayer.Client> GetClients() //int id
        {
            TasksDataContext dc = new TasksDataContext();
            //dc.Log = Console.Out;
            var zz = from z in dc.Clients
                     select z;

            return (zz);
        }
        public static void AddClient(int clientID)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                DataLayer.Client client = new DataLayer.Client();
                client.clientID = clientID;
                dc.Clients.InsertOnSubmit(client);
                dc.SubmitChanges();
            }
        }
        public static void UpdateClient(int id, int personID)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var client = from c in dc.Clients
                          where c.clientID == id
                          select c;
                DataLayer.Client client_ = client.Single();
                client_.personID = personID;
                dc.SubmitChanges();
            }
        }

        public static void DeleteClient(int id)
        {
            using (TasksDataContext dc = new TasksDataContext())
            {
                var client = from c in dc.Clients
                          where c.clientID == id
                          select c;
                foreach (var c in client)
                {
                    dc.Clients.DeleteOnSubmit(c);
                }
                dc.SubmitChanges();
            }
        }
    }
}
