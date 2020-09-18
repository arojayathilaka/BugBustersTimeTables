using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class SessionEntity
    {
        public int SessionId { get; set; }
        public string LecturerIds { get; set; }
        public int[] LecturerIdsArr { get { return Array.ConvertAll(LecturerIds.Split(','), e => int.Parse(e)); } private set { } }
        public List<LecturerEntity> SessionLectures { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string Tag { get; set; }
        public string GroupId { get; set; }
        public StudentEntity SessionGrp { get; set; }
        public int Count { get; set; }
        public int Duration { get; set; }

    }
}
