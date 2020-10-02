using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class PrefferedRoomForSessionViewModel
    {
        PrefferedRoomForSessionData _prefferedRoomForSessionData;
        public PrefferedRoomForSessionViewModel()
        {
            _prefferedRoomForSessionData = new PrefferedRoomForSessionData();
        }

        public void SavePrefferedRoomForSessionData(PrefferedRoomForSessionEntity prefferedRoomForSession)
        {
            _prefferedRoomForSessionData.SaveData(prefferedRoomForSession);
        }

        public List<PrefferedRoomForSessionEntity> LoadData()
        {
            return _prefferedRoomForSessionData.LoadData();
        }

    }
}
