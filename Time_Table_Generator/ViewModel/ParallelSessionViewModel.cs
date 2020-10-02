using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Table_Generator.ViewModel
{
    internal class ParallelSessionViewModel
    {
        ParallelSessionData _parallelSessionData;
        public ParallelSessionViewModel()
        {
            _parallelSessionData = new ParallelSessionData();
        }

        public List<ParallelSessionEntity> LoadParallelSessionData()
        {
            return _parallelSessionData.LoadData();
        }

        public void SaveParallelSessionData(ParallelSessionEntity parallelSession)
        {
            _parallelSessionData.SaveData(parallelSession);
        }

        public void UpdateParallelSessionData(ParallelSessionEntity parallelSession)
        {
            _parallelSessionData.UpdateData(parallelSession);
        }

        public void DeleteParallelSessionData(int parallelSessionId)
        {
            _parallelSessionData.DeleteData(parallelSessionId);
        }
    }
}
