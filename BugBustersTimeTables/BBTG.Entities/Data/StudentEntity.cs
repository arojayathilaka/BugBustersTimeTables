using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class StudentEntity
    {
        public int StudentId { get; set; }

        public string AcademicYrSem { get; set; }

        public string Programme { get; set; }

        public int GroupNumber { get; set; }

        public string GroupId { get; set; }

        public int SubGroupNumber { get; set; }

        public string SubGroupId { get; set; }

        public StudentEntity()
        {

        }

        public StudentEntity(int StudentId, string AcademicYrSem, string Programme, int GroupNumber, string GroupId, int SubGroupNumber, string SubGroupId)
        {
            this.StudentId = StudentId;
            this.AcademicYrSem = AcademicYrSem;
            this.Programme = Programme;
            this.GroupNumber = GroupNumber;
            this.GroupId = GroupId;
            this.SubGroupNumber = SubGroupNumber;
            this.SubGroupId = SubGroupId;
        }
    }
}
