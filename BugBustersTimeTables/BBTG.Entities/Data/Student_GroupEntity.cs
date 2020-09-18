using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class Student_GroupEntity
    {
        public int StudentId { get; set; }

        public string AcademicYrSem { get; set; }

        public string Programme { get; set; }

        public int GroupNumber { get; set; }

        public string GroupId { get; set; }

        public Student_GroupEntity()
        {

        }

        public Student_GroupEntity(int StudentId, string AcademicYrSem, string Programme, int GroupNumber, string GroupId)
        {
            this.StudentId = StudentId;
            this.AcademicYrSem = AcademicYrSem;
            this.Programme = Programme;
            this.GroupNumber = GroupNumber;
            this.GroupId = GroupId;
        }

    }
}
