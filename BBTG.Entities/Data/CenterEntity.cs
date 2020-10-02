using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class CenterEntity
    {
        public int CenterId { get; set; }
        public string CenterName { get; set; }

        public CenterEntity()
        {

        }

        public CenterEntity(int CenterId, string CenterName)
        {
            this.CenterId = CenterId;
            this.CenterName = CenterName;
        }
    }
}
