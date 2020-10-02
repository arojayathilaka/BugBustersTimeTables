using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class PrefferedRoomForSessionEntity
    {
        public int id { get; set; }
        public int SessionId { get; set; }
        public string RoomName { get; set; }


        public PrefferedRoomForSessionEntity()
        {

        }

        public PrefferedRoomForSessionEntity(int id,int SessionId, String RoomName)
        {
            this.id = id;
            this.SessionId = SessionId;
            this.RoomName = RoomName;
        }
    }
}
