using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace Time_Table_Generator.ViewModel
{
    internal class RoomViewModel
    {
        RoomData _roomData;
        public RoomViewModel()
        {
            _roomData = new RoomData();
        }

        public List<RoomEntity> LoadRoomData()
        {
            return _roomData.LoadData();
        }

        public void SaveRoomData(RoomEntity room)
        {
            _roomData.SaveData(room);
        }

        public void UpdateRoomData(RoomEntity room)
        {
            _roomData.UpdateData(room);
        }

        public void DeleteRoomData(int roomId)
        {
            _roomData.DeleteData(roomId);
        }
    }
}
