using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class LecturerNAEntity
    {
        public int LecturerId { get; set; }

        public string Lecturer { get; set; }

        public string Day { get; set; }

        public string STime { get; set; }

        public string ETime { get; set; }

        public LecturerNAEntity()
        {

        }

        public LecturerNAEntity(int LecturerId, string Lecturer, string Day, string STime, string ETime)
        {
            this.LecturerId = LecturerId;
            this.Lecturer = Lecturer;
            this.Day = Day;
            this.STime = STime;
            this.ETime = ETime;
        }

    }
}
