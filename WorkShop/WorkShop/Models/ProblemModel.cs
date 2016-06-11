using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkShop.Models
{
    public class ProblemModel
    {
        public int problemID { get; set; }
        public string problemDesc { get; set; }
        public string resultDesc { get; set; }
        public DateTime? beginDate { get; set; }
        public DateTime? endDate { get; set; }
        public int? objectId { get; set; }

        public ProblemModel(int problemID, string problemDesc, string resultDesc, DateTime? beginDate, DateTime? endDate, int? objectId)
        {
            this.problemID = problemID;
            this.problemDesc = problemDesc;
            this.resultDesc = resultDesc;
            if(beginDate != null) this.beginDate = beginDate;
            this.endDate = endDate;
            this.objectId = objectId;
        }
    }
}
