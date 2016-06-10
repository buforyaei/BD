using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.UserControls;

namespace WorkShop.ViewModel
{
    public class ProblemsViewModel : ViewModelBase
    {
        ProblemListItem _w0 = new ProblemListItem("Test", "7855","78789789789", "testdescritpion");
        ProblemListItem _w1 = new ProblemListItem("Kowalski", "6515","0700880880", "testdescritpiontestdescritpiontestdescritpion");
        ProblemListItem _w2 = new ProblemListItem("Momot", "427","7577587587", "testdescritpiontestdescritpiontestdescritpiontestdescritpiontestdescritpiontestdescritpion");
        ProblemListItem _w3 = new ProblemListItem("Cab", "125525","7857271471", "testdescritpion");
        ProblemListItem _w4 = new ProblemListItem("Cab", "125525","7857271471", "testdescritpion");




        public ObservableCollection<ProblemListItem> ProblemsList
        {
            get { return _problemsList; }
            set { Set(ref _problemsList, value); }
        }

        private ObservableCollection<ProblemListItem> _problemsList;
        public ICommand LoadCmd { get; set; }

        public ObservableCollection<WorkShop.Models.ProblemModel> ProblemsDataGrid
        {
            get { return _problemsDataGrid; }
            set { Set(ref _problemsDataGrid, value); }
        }

        private ObservableCollection<WorkShop.Models.ProblemModel> _problemsDataGrid;

        
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
            var a = BizLayer.ProblemQuery.GetProblems();
            var b = a.ToList();
            var c = b.ToArray();
            var problemsArray = new WorkShop.Models.ProblemModel[c.Length];
            for (int i=0;i<c.Length;i++)
            {
                //int problemID, string problemDesc, string resultDesc, DateTime beginDate, DateTime endDate, int objectId)
                problemsArray[i]=new WorkShop.Models.ProblemModel(c[i].problemID, c[i].problemDesc, c[i].resultDesc, null, null, null);
            }
            var problemsObservable = new ObservableCollection<ProblemListItem>();
            for (int i = 0; i < c.Length; i++)
            {
                ///(string name, string id, string phone, string description)
                problemsObservable.Add(new ProblemListItem(problemsArray[i].problemDesc, problemsArray[i].problemID.ToString(),
                    problemsArray[i].endDate.ToString(), problemsArray[i].problemDesc));
            }
            ProblemsList = problemsObservable;
            // ObservableCollection<ProblemListItem> problemsList = new ObservableCollection<ProblemListItem>();
            //
            // ObservableCollection<ProblemListItem> problemsList = new ObservableCollection<ProblemListItem>();
            //problemsList.Add(_w0);
            //problemsList.Add(_w1);
            //problemsList.Add(_w2);
            //problemsList.Add(_w3);
            //problemsList.Add(_w4);
            //ProblemsList = problemsList;
            //var p = new ObservableCollection<WorkShop.Models.ProblemModel>();
            //for (int i = 0; i < ProblemsList.Count; i++)
            //{
            //    ///(string name, string id, string phone, string description)
            //    p.Add(problemsArray[i]);
            //}
            //ProblemsDataGrid = p;
        }
        public ObservableCollection<T> ToObservableCollection<T>(IEnumerable<T> enumeration)
        {
            return new ObservableCollection<T>(enumeration);
        }
    }
}
