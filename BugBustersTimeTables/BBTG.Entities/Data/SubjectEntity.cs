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

        public SubjectEntity()
        {

        }

        public SubjectEntity(
            int SubjectId, 
            string SubjectCode, 
            string SubjectName, 
            int Year, 
            int Semester, 
            int NoOfLecHrs, 
            int NoOfTuteHrs, 
            int NoOfLabHrs, 
            int NoOfEvalHrs)
        {
            this.SubjectId = SubjectId;
            this.SubjectCode = SubjectCode;
            this.SubjectName = SubjectName;
            this.Year = Year;
            this.Semester = Semester;
            this.NoOfLecHrs = NoOfLecHrs;
            this.NoOfTuteHrs = NoOfTuteHrs;
            this.NoOfLabHrs = NoOfLabHrs;
            this.NoOfEvalHrs = NoOfEvalHrs;
        }
    }
}
