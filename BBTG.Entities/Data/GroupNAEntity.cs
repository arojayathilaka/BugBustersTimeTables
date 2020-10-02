using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class GroupNAEntity
    {
        public int GroupId { get; set; }

        public string GroupNumber { get; set; }

        public string Day { get; set; }

        public string STime { get; set; }

        public string ETime { get; set; }

        public GroupNAEntity()
        {

        }

        public GroupNAEntity(int GroupId, string GroupNumber, string Day, string STime, string ETime)
        {
            this.GroupId = GroupId;
            this.GroupNumber = GroupNumber;
            this.Day = Day;
            this.STime = STime;
            this.ETime = ETime;
        }

    }
}
