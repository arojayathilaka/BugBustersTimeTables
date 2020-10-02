using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class PrefferedRoomForSubjectViewModel
    {
        PrefferedRoomForSubjectData _prefferedRoomForSubjectData;
        public PrefferedRoomForSubjectViewModel()
        {
            _prefferedRoomForSubjectData = new PrefferedRoomForSubjectData();
        }

        public void SavePrefferedRoomForSubjectData(PrefferedRoomForSubjectEntity prefferedRoomForSubject)
        {
            _prefferedRoomForSubjectData.SaveData(prefferedRoomForSubject);
        }
            public List<PrefferedRoomForSubjectEntity> LoadData()
        {
            return _prefferedRoomForSubjectData.LoadData();
        }


    }
}