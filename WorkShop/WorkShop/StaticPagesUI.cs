using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Models;
using WorkShop.Pages;

namespace WorkShop
{
    static class StaticPagesUi
    {
        public static AddUserPage AddUserPage = new AddUserPage();
        public static ClientsPage ClientsPage = new ClientsPage();
        public static EditTasksPage EditTasksPage = new EditTasksPage();
        public static EditUserPage EditUserPage = new EditUserPage();
        public static LoginPage LoginPage = new LoginPage();
        public static MenuAdminPage MenuAdminPage = new MenuAdminPage();
        public static MenuEmployyPage MenuEmployyPage = new MenuEmployyPage();
        public static MenuManagerPage MenuManagerPage = new MenuManagerPage();
        public static MyTasksPage MyTasksPage = new MyTasksPage();
        public static ObjectListPage ObjectListPage = new ObjectListPage();
        public static ProblemsPage ProblemsPage = new ProblemsPage();
        public static RaportPage RaportPage = new RaportPage();
        public static RegisterProblemPage RegisterProblemPage = new RegisterProblemPage();
        public static SearchPage SearchPage = new SearchPage();
        public static TaskSimplePage TaskSimplePage = new TaskSimplePage();


        public static User User = new User();
    }
}
