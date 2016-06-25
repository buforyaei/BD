using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BizLayer.Query;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using WorkShop.Models;
using WorkShop.UserControls;

namespace WorkShop.ViewModel
{
    public class RegisterProblemViewModel : ViewModelBase
    {
        
        public ICommand LoadCmd { get; set; }
        public ICommand RegisterProblemCmd { get; set; }
        public ICommand ClearFieldsCmd { get; set; }
        public ICommand RefreshCmd { get; set; }
        public ICommand LoadWithProblemCmd { get; set; }
        private string _descritpion;
        private string _resultDescritpion;
        private DataLayer.Object _selectedObject;
        private ObservableCollection<DataLayer.Object> _objects; 
        private DateTime _beginDate;
        private DateTime _endDate;
        private string _problemId;

        public ObservableCollection<DataLayer.Object> Objects
        {
            get { return _objects; }
            set { Set(ref _objects, value); }
        }
        public DateTime BeginDate
        {
            get { return _beginDate; }
            set { Set(ref _beginDate, value); }
        }
        public DateTime EndDate
        {
            get { return _endDate; }
            set { Set(ref _endDate, value); }
        }
        public DataLayer.Object SelectedObject
        {
            get { return _selectedObject; }
            set { Set(ref _selectedObject, value); }
        }
        public string ResultDescritpion
        {
            get { return _resultDescritpion; }
            set { Set(ref _resultDescritpion, value); }
        } 
        public string Descritpion
        {
            get { return _descritpion; }
            set { Set(ref _descritpion, value); }
        }
        public string ProblemId
        {
            get { return _problemId; }
            set { Set(ref _problemId, value); }
        }

        public RegisterProblemViewModel()
        {
            InitializeCommands();
        }

        private void InitializeCommands()
        {
            LoadCmd = new RelayCommand(Load);
            RegisterProblemCmd = new RelayCommand(RegisterProblem);
            ClearFieldsCmd = new RelayCommand(ClearFields); 
            RefreshCmd = new RelayCommand(Refresh);
            LoadWithProblemCmd = new RelayCommand<ProblemListItem>(LoadWithProblem);
        }

        private void LoadWithProblem(ProblemListItem problemItem)
        {
            BeginDate = problemItem.Problem.beginDate.Value;
            EndDate = problemItem.Problem.endDate.Value;
            ProblemId = problemItem.Problem.problemID.ToString();
            Descritpion = problemItem.Problem.problemDesc;
            ResultDescritpion = problemItem.Problem.resultDesc;
        }
        private void Refresh()
        {
            Load();
        }
        private void ClearFields()
        {
            BeginDate = DateTime.Today;
            EndDate = DateTime.MaxValue;
            ProblemId = "";
            Descritpion = "";
            ResultDescritpion = "";
        }
        private void RegisterProblem()
        {
            if (SelectedObject!= null && !String.IsNullOrEmpty(Descritpion) && BeginDate != DateTime.MinValue)
            {
                if(ProblemId=="")
                ProblemQuery.AddProblem(BeginDate,EndDate,Descritpion,ResultDescritpion,SelectedObject.objectID);
                else
                    ProblemQuery.UpdateProblem(Int32.Parse(ProblemId), BeginDate, EndDate, Descritpion,
                        ResultDescritpion, SelectedObject.objectID);

                MessageBox.Show("Operation successfull", "OK",
                     MessageBoxButton.OK);
                Load();
            }
            else
            {
                MessageBox.Show("Some unnullable fields where left emppty.", "Ops!",
                    MessageBoxButton.OK);
            }
            
        }
        private  void Load()
        {
            ClearFields();
            var objects = ObjectQuery.GetObjects().ToList();
            var objectsObservable = new ObservableCollection<DataLayer.Object>();
            if(objects.Count>0)
            {
                    foreach (var o in objects)
                    {
                        objectsObservable.Add(o);
                    }
                Objects = objectsObservable;
                SelectedObject = Objects.FirstOrDefault();
            }
        }
    }    
}

