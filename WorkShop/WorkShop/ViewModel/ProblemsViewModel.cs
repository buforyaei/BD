using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Serialization;
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
        public ICommand ShowOnlyOpenProblemsCmd { get; set; }
        public ICommand FilterByNameCmd { get; set; }

        private string _filterString;

        public string FilterString
        {
            get { return _filterString; }
            set { Set(ref _filterString, value); } 
        }
        public ProblemsViewModel()
        {
            InitializeCommands();
        }
        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            RefreshCmd = new RelayCommand(Refresh);
            ShowOnlyOpenProblemsCmd = new RelayCommand(ShowOnlyOpenProblems);
            FilterByNameCmd = new RelayCommand(FilterByname);
        }

        private void FilterByname()
        {
            if (string.IsNullOrEmpty(FilterString))
                Load();
            else
            {
                Load();
                ObservableCollection<ProblemListItem> problems = new ObservableCollection<ProblemListItem>();

                foreach (var p in ProblemsList)
                {
                    if (p.Obj.name.Contains(FilterString) || p.Obj.model.Contains(FilterString))
                        problems.Add(p);
                }
                ProblemsList = null;
                ProblemsList = problems;
            }
        }
        private void ShowOnlyOpenProblems()
        {
            var problemsList = new ObservableCollection<ProblemListItem>();
            var problems = ProblemQuery.GetProblems().ToArray();
            foreach (var problem in problems)
            {
                if(problem.endDate.Value.Year == DateTime.MaxValue.Year)
                problemsList.Add(new ProblemListItem(problem));
            }
            ProblemsList = null;
            ProblemsList = problemsList;
        }
        private void Refresh()
        {
            Load();
        }
        public void Load()
        {
            ProblemsList = null;
            var problemsList = new ObservableCollection<ProblemListItem>();
            var problems = ProblemQuery.GetProblems().ToArray();
            foreach (var problem in problems)
            {
               problemsList.Add(new ProblemListItem(problem));
            }
            ProblemsList = problemsList;
        }
    }
}
