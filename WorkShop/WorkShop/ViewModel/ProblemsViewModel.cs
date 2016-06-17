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
        
        public ProblemsViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
          
        }
        public void Load()
        {
           var problemsList = new ObservableCollection<ProblemListItem>();
            var problems = ProblemQuery.GetProblems().ToArray();
            foreach (var problem in problems)
            {
               // var obj = BizLayer.ObjectQuery.GetObject(problem.Object.objectID);
                var tasks = BizLayer.Query.TaskQuery.GetTasks();

                problemsList.Add(new ProblemListItem("Kowalski Jan",problem.problemID.ToString(),"2342342",problem.problemDesc,problem.resultDesc,"SPS2345","6",problem.endDate.Value.Date, "Rynek 1A Rybnik"));
            }
            ProblemsList = problemsList;
        }
    }
}
