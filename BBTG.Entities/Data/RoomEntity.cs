using System;
using System.Collections.Generic;
using System.Text;
namespace BBTG.Entities.Data
{
    public class RoomEntity
    {

        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public string Building { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }
       

        public RoomEntity()
        {

        }

        public RoomEntity(int RoomId, string RoomName, string Building, string RoomType, int Capacity)
        {
            this.RoomId = RoomId;
            this.RoomName = RoomName;
            this.Building = Building;
            this.RoomType = RoomType;
            this.Capacity = Capacity;
            }
    }
}

