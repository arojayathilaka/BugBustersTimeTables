using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class SessionEntity
    {
        public LecturerEntity Lecturer { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string Tag { get; set; }
    }
}
