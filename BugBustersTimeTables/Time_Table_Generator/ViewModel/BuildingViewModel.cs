using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    public class BuildingViewModel
    {
        BuildingData _buildingData;
        public BuildingViewModel()
        {
            _buildingData = new BuildingData();
        }

        public List<BuildingEntity> LoadBuildingData()
        {
            return _buildingData.LoadData();
        }
    }
}
