using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BizLayer.Query;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.UserControls;

namespace WorkShop.ViewModel
{
    public class ProblemsViewModel : ViewModelBase
    {
       
        public ObservableCollection<ProblemListItem> ProblemsList
        {
            get { return _problemsList; }
            set { Set(ref _problemsList, value); }
        }

        private ObservableCollection<ProblemListItem> _problemsList;
        public ICommand LoadCmd { get; set; }
        public ICommand RefreshCmd { get; set; }
        public ProblemsViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            RefreshCmd = new RelayCommand(Refresh);
          
        }

        private void Refresh()
        {
            Load();
        }
        public void Load()
        {
           var problemsList = new ObservableCollection<ProblemListItem>();
            var problems = ProblemQuery.GetProblems().ToArray();
            foreach (var problem in problems)
            {
               // var obj = BizLayer.ObjectQuery.GetObject(problem.Object.objectID);
                var tasks = BizLayer.Query.TaskQuery.GetTasks();

                problemsList.Add(new ProblemListItem(problem));
            }
            ProblemsList = problemsList;
        }
    }
}
