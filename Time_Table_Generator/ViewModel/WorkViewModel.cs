﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBTG.DataAccess;
using BBTG.Entities.Data;

namespace Time_Table_Generator.ViewModel
{
    internal class WorkViewModel
    {
        WorkData _workData;

        public WorkViewModel()
        {
            _workData = new WorkData();
        }

        public void SaveData(WorkEntity work)
        {
            _workData.saveWorkingData(work);
        }
        public List<WorkEntity> LoadData()
        {
            return _workData.LoadWorkData();
        }

        public List<WorkEntity> LoadWorkingDaysData(int ID)
        {
            return _workData.LoadWorkingDays(ID);
        }

        public void DeleteWorkData(int ID)
        {
            _workData.DeleteData(ID);
        }

        public void UpdateWorkData(WorkEntity work)
        {
            _workData.UpdateData(work);
        }
    }

    public class TimeSlotViewModel
    {
        WorkData _workData;

        public TimeSlotViewModel()
        {
            _workData = new WorkData();
        }

        public void SaveTimeSlotsData(TimeSlotEntity timeSlotEntity)
        {
            _workData.AddTimeSlots(timeSlotEntity);
        }

        public List<TimeSlotEntity> LoadTimeSlotData()
        {
            //var x = AppData._timeSlotEntities;
            return _workData.LoadTimeSlotData();
        }

        public void DeleteTimeData()
        {
            _workData.DeleteTimeSlotData();
        }

    }
}
