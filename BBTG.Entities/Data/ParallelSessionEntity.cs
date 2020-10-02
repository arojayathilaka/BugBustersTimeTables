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

        public string Ses1 { get; set; }

        public string Ses2 { get; set; }

        public string Day { get; set; }

        public string STime { get; set; }

        public string ETime { get; set; }

        public ParallelSessionEntity()
        {

        }

        public ParallelSessionEntity(int ParallelSessionId, string Ses1, string Ses2, string Day, string STime, string ETime)
        {
            this.ParallelSessionId = ParallelSessionId;
            this.Ses1 = Ses1;
            this.Ses2 = Ses2;
            this.Day = Day;
            this.STime = STime;
            this.ETime = ETime;
        }
    }
}
