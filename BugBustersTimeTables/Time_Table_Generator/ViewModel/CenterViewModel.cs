using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class CenterViewModel
    {
        CenterData _centerData;
        public CenterViewModel()
        {
            _centerData = new CenterData();
        }

        public List<CenterEntity> LoadCenterData()
        {
            return _centerData.LoadData();
        }
    }
}
