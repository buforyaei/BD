using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace BD_WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        bool _isWorking;
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        public MainViewModel(IDialogService dialogService)
        {
          //  _dialogService = dialogService;
            InitializeCommands();
        }

        public bool IsWorking
        {
            get { return _isWorking; }
            set { Set(ref _isWorking, value); }
        }

        public ICommand LoadCmd { get; set; }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
           
        }

        private void Load()
        {
            int a = 5;
        }

    }
}