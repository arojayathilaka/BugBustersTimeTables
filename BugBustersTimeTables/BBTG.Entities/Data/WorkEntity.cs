using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class WorkEntity
    {
        public int ID { get; set; }
        public String batchType { get; set; }
        public int noOfWorkingDays { get; set; }
        public String workingDays { get; set; }
        public int noOfWorkingHours { get; set; }
        public String timeSlotStartTime { get; set; }
        public String timeSlotEndTime { get; set; }

        public WorkEntity(int workId, String batch, int noOfWorkingDays, String workingDays, int noOfWorkingHours, String timeSlotStartTime, String timeSlotEndTime)
        {
            this.ID = workId;
            this.batchType = batch;
            this.noOfWorkingDays = noOfWorkingDays;
            this.workingDays = workingDays;
            this.noOfWorkingHours = noOfWorkingHours;
            this.timeSlotStartTime = timeSlotStartTime;
            this.timeSlotEndTime = timeSlotEndTime;
        }
        public WorkEntity()
        {

        }



    }

    public class TimeSlotEntity 
    {
        public int ID { get; set; }
        public string Date { get; set; }
        public string TImeSlot { get; set; }
        public List<SessionEntity>  SessionEntity  { get; set; }
    }
        


}
