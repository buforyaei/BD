using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using WorkShop.Models;

namespace WorkShop.ViewModel
{
    public class RegisterProblemViewModel : ViewModelBase
    {
        private ProblemModel problem1 { get; set; }

        public void Load()
        {
          //  BizLayer.ProblemQuery.AddProblem(DateTime.Today, DateTime.Today, "mamy problem z baza", "");
            var a = BizLayer.ProblemQuery.GetProblems().ToArray();
            BizLayer.ProblemQuery.GetProblem(8);

        }
    }
}
