using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities
{
    public class Session
    {
        public string Lecturers { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string Tag { get; set; }
        public string GroupId { get; set; }
        public int Count { get; set; }
        public int Duration { get; set; }
    }
}
