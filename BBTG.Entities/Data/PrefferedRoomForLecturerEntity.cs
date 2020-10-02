using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class PrefferedRoomForLecturerEntity
    {
          public int id { get; set; }
        public string Name { get; set; }
        public string RoomName { get; set; }


        public PrefferedRoomForLecturerEntity()
        {

        }

        public PrefferedRoomForLecturerEntity(int id,String Name, String RoomName)
        {
            this.id = id;
            this.Name = Name;
            this.RoomName = RoomName;
        }
    }
}