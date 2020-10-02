using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class PrefferedRoomForGroupViewModel
    {
        PrefferedRoomForGroupData _prefferedRoomForGroupData;
        public PrefferedRoomForGroupViewModel()
        {
            _prefferedRoomForGroupData = new PrefferedRoomForGroupData();
        }

        public void SavePrefferedRoomForGroupData(PrefferedRoomForGroupEntity prefferedRoomForGroup)
        {
            _prefferedRoomForGroupData.SaveData(prefferedRoomForGroup);
        }

           public List<PrefferedRoomForGroupEntity> LoadData()
        {
            return _prefferedRoomForGroupData.LoadData();
        }

    }
}