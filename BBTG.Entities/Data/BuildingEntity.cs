using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class BuildingEntity
    {
        public int BuildingId { get; set; }
        public string BuildingName { get; set; }

        public BuildingEntity()
        {

        }

        public BuildingEntity(int BuildingId, string BuildingName)
        {
            this.BuildingId = BuildingId;
            this.BuildingName = BuildingName;
        }
    }
}
