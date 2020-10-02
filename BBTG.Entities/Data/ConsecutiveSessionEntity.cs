using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class ConsecutiveSessionEntity
    {

        public int ConsId { get; set; }

        public string Ses1 { get; set; }
        
        public string Ses2 { get; set; }

        public ConsecutiveSessionEntity()
        {

        }

        public ConsecutiveSessionEntity(int ConsId, string Ses1, string Ses2)
        {
            this.ConsId = ConsId;
            this.Ses1 = Ses1;
            this.Ses2 = Ses2;
        }
    }
}
