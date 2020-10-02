using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class SessionNAEntity
    {
        public int SessionId { get; set; }

        public string Session { get; set; }

        public string Day { get; set; }

        public string STime { get; set; }

        public string ETime { get; set; }

        public SessionNAEntity()
        {

        }

        public SessionNAEntity(int SessionId, string Session, string Day, string STime, string ETime)
        {
            this.SessionId = SessionId;
            this.Session = Session;
            this.Day = Day;
            this.STime = STime;
            this.ETime = ETime;
        }

    }
}
