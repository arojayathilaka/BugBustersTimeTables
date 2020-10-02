using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class PrefferedRoomForGroupEntity
    {
         public int id { get; set; }
        public int GroupNumber { get; set; }
        public int SubGroupNumber { get; set; }
        public string RoomName { get; set; }


        public PrefferedRoomForGroupEntity()
        {

        }

        public PrefferedRoomForGroupEntity(int id,int GroupNumber, int SubGroupNumber, String RoomName)
        {
            this.id = id;
            this.GroupNumber = GroupNumber;
            this.SubGroupNumber = SubGroupNumber;
            this.RoomName = RoomName;
        }
    }
}