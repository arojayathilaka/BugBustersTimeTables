using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class PrefferedRoomForLecturerViewModel
    {
        PrefferedRoomForLecturerData _prefferedRoomForLecturerData;
        public PrefferedRoomForLecturerViewModel()
        {
            _prefferedRoomForLecturerData = new PrefferedRoomForLecturerData();
        }

        public void SavePrefferedRoomForLecturerData(PrefferedRoomForLecturerEntity prefferedRoomForLecturer)
        {
            _prefferedRoomForLecturerData.SaveData(prefferedRoomForLecturer);
        }

             public List<PrefferedRoomForLecturerEntity> LoadData()
        {
            return _prefferedRoomForLecturerData.LoadData();
        }


    }
}