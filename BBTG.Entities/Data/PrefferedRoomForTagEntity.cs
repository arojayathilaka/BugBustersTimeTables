using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class PrefferedRoomForTagEntity
    {
        public int id { get; set; }
        public string TagName { get; set; }
        public string RoomName { get; set; }


        public PrefferedRoomForTagEntity()
        {

        }

        public PrefferedRoomForTagEntity(int id,String TagName,String RoomName)
        {
            this.id = id;
            this.TagName = TagName;
            this.RoomName = RoomName;
        }
    }
}
