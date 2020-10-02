using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Table_Generator.ViewModel
{
    internal class GroupNAViewModel
    {
        GroupNAData _groupNAData;
        public GroupNAViewModel()
        {
            _groupNAData = new GroupNAData();
        }

        public List<GroupNAEntity> LoadGroupNAData()
        {
            return _groupNAData.LoadData();
        }

        public void SaveGroupNAData(GroupNAEntity groupNa)
        {
            _groupNAData.SaveData(groupNa);
        }

        public void UpdateGroupNAData(GroupNAEntity groupNa)
        {
            _groupNAData.UpdateData(groupNa);
        }

        public void DeleteGroupNaData(int groupId)
        {
            _groupNAData.DeleteData(groupId);
        }
    }
}
