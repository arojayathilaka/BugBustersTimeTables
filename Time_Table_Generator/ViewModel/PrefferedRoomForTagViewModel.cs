using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class PrefferedRoomForTagViewModel
    {
        PrefferedRoomForTagData _prefferedRoomForTagData;
        public PrefferedRoomForTagViewModel()
        {
            _prefferedRoomForTagData = new PrefferedRoomForTagData();
        }

       public void SavePrefferedRoomForTagData(PrefferedRoomForTagEntity prefferedRoomForTag)
        {
            _prefferedRoomForTagData.SaveData(prefferedRoomForTag);
        }

           public List<PrefferedRoomForTagEntity> LoadData()
        {
            return _prefferedRoomForTagData.LoadData();
        }


       
    }
}
