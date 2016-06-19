using System.Windows.Navigation;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace WorkShop.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<AddUserViewModel>();
            SimpleIoc.Default.Register<EditTasksViewModel>();
            SimpleIoc.Default.Register<EditUserViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<MyTasksViewModel>();
            SimpleIoc.Default.Register<ObjectViewModel>();
            SimpleIoc.Default.Register<ObjectListViewModel>();
            SimpleIoc.Default.Register<ProblemsViewModel>();
            SimpleIoc.Default.Register<ProblemsTaskListViewModel>();
            SimpleIoc.Default.Register<RaportViewModel>();
            SimpleIoc.Default.Register<RegisterProblemViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
            SimpleIoc.Default.Register<TaskSimpleViewModel>();
        
        }

        public LoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginViewModel>();
            }
        }
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }
   
        public MyTasksViewModel MyTasks
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MyTasksViewModel>();
            }
        }
        public ProblemsViewModel Problems
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProblemsViewModel>();
            }
        }
        public SearchViewModel Search
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }
        public AddUserViewModel AddUser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AddUserViewModel>();
            }
        }
        public EditUserViewModel EditUser
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditUserViewModel>();
            }
        }
        public RaportViewModel Raport
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RaportViewModel>();
            }
        }
        public EditTasksViewModel EditTasks
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditTasksViewModel>();
            }
        }
        public RegisterProblemViewModel RegisterProblem
        {
            get
            {
                return ServiceLocator.Current.GetInstance<RegisterProblemViewModel>();
            }
        }
        public TaskSimpleViewModel TaskSimple
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TaskSimpleViewModel>();
            }
        }
        public ProblemsTaskListViewModel ProblemTaskList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ProblemsTaskListViewModel>();
            }
        }
        public ObjectViewModel Object
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ObjectViewModel>();
            }
        }
        public ObjectListViewModel ObjectList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ObjectListViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}