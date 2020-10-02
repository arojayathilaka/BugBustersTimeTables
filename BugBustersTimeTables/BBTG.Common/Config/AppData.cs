using BBTG.Entities.Data;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BBTG.Common.Config
{
    public class AppData
    {
        public static string ConnectionString { get; set; }

        public static List<TimeSlotEntity> _timeSlotEntities { get; private set; }


        public AppData()
        {
            TimeSlotEntity x = new TimeSlotEntity();


            string[] days = new string[] { "Mon", "Tue", "Wed", "Thu", "Fri" };
            //For day : - 9 ? 
            // # of days : - 5 ? 
            // TOT = 9*5 = 45
            _timeSlotEntities = new List<TimeSlotEntity>();
            int startTime = 8;
            int currentDate = 0;
            int endTime = 17;
            for (int i = 1; i < 46; i++)
            {
                if (startTime == endTime) 
                {
                    startTime = 8;
                    currentDate++;
                }
 
                _timeSlotEntities.Add(
                    new TimeSlotEntity { ID = i, TImeSlot = $"{startTime}-{++startTime}",Date=days[currentDate]}
                    ); 
            }

       
         }

        
            
    }
}
