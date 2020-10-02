using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class ParallelSessionEntity
    {

        public int ParallelSessionId { get; set; }

        public string Lecturer { get; set; }

        public string GroupId { get; set; }

        public string SubGroupId { get; set; }

        public string Session { get; set; }

        public ParallelSessionEntity()
        {

        }

        public ParallelSessionEntity(int ParallelSessionId, string Lecturer, string GroupId, string SubGroupId, string Session)
        {
            this.ParallelSessionId = ParallelSessionId;
            this.Lecturer = Lecturer;
            this.GroupId = GroupId;
            this.SubGroupId = SubGroupId;
            this.Session = Session;
        }
    }
}
