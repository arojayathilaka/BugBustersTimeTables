using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Table_Generator.ViewModel
{
    internal class SubGroupNAViewModel
    {
        SubGroupNAData _subgroupNAData;
        public SubGroupNAViewModel()
        {
            _subgroupNAData = new SubGroupNAData();
        }

        public List<SubGroupNAEntity> LoadSubGroupNAData()
        {
            return _subgroupNAData.LoadData();
        }

        public void SaveSubGroupNAData(SubGroupNAEntity subgroupNa)
        {
            _subgroupNAData.SaveData(subgroupNa);
        }

        public void UpdateSubGroupNAData(SubGroupNAEntity subgroupNa)
        {
            _subgroupNAData.UpdateData(subgroupNa);
        }

        public void DeleteSubGroupNaData(int subgroupId)
        {
            _subgroupNAData.DeleteData(subgroupId);
        }
    }
}
