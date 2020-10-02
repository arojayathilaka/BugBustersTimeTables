using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class SubjectEntity
    {
        public int SubjectId { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
        public int NoOfLecHrs { get; set; }
        public int NoOfTuteHrs { get; set; }
        public int NoOfLabHrs { get; set; }
        public int NoOfEvalHrs { get; set; }
    }
}
