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
            ObservableCollection<ProblemListItem> problemsList = new ObservableCollection<ProblemListItem>();
            problemsList.Add(_w0);
            problemsList.Add(_w1);
            problemsList.Add(_w2);
            problemsList.Add(_w3);
            problemsList.Add(_w4);
            ProblemsList = problemsList;
        }
    }
}
