using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class SubGroupNAEntity
    {
        public int SubGroupId { get; set; }

        public string SubGroupNumber { get; set; }

        public string Day { get; set; }

        public string STime { get; set; }

        public string ETime { get; set; }

        public SubGroupNAEntity()
        {

        }

        public SubGroupNAEntity(int SubGroupId, string SubGroupNumber, string Day, string STime, string ETime)
        {
            this.SubGroupId = SubGroupId;
            this.SubGroupNumber = SubGroupNumber;
            this.Day = Day;
            this.STime = STime;
            this.ETime = ETime;
        }

    }
}
