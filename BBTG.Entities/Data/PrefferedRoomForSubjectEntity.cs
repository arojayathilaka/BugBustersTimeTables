using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class PrefferedRoomForSubjectEntity
    {
        public int id { get; set; }
        public string SubjectName { get; set; }
        public string TagName { get; set; }
        public string RoomName { get; set; }


        public PrefferedRoomForSubjectEntity()
        {

        }

        public PrefferedRoomForSubjectEntity(int id,String SubjectName,String TagName, String RoomName)
        {
            this.id=id;
            this.SubjectName = SubjectName;
            this.TagName = TagName;
            this.RoomName = RoomName;
        }
    }
}