using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Table_Generator.ViewModel
{
    internal class ConsecutiveSessionViewModel
    {
        ConsecutiveSessionData _consecutiveSessionData;
        public ConsecutiveSessionViewModel()
        {
            _consecutiveSessionData = new ConsecutiveSessionData();
        }

        public List<ConsecutiveSessionEntity> LoadConsecutiveSessionData()
        {
            return _consecutiveSessionData.LoadData();
        }

        public void SaveConsecutiveSessionData(ConsecutiveSessionEntity consecutiveSession)
        {
            _consecutiveSessionData.SaveData(consecutiveSession);
        }

        public void UpdateConsecutiveSessionData(ConsecutiveSessionEntity consecutiveSession)
        {
            _consecutiveSessionData.UpdateData(consecutiveSession);
        }
    }
}
