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
            var c = ProblemQuery.GetProblems().ToArray();
            var problemsArray = new Models.ProblemModel[c.Length];
            for (int i=0;i<c.Length;i++)
            {
                problemsArray[i]= new Models.ProblemModel(c[i].problemID, c[i].problemDesc, c[i].resultDesc, null, null, null);
            }
            var problemsObservable = new ObservableCollection<ProblemListItem>();
            for (int i = 0; i < c.Length; i++)
            {
               
                problemsObservable.Add(new ProblemListItem(problemsArray[i].problemDesc, problemsArray[i].problemID.ToString(),
                    problemsArray[i].endDate.ToString(), problemsArray[i].problemDesc));
            }
            ProblemsList = problemsObservable;
           
        }
    }
}
