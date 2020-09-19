using System;
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

        public void DeleteWorkData(int ID)
        {
            _workData.DeleteData(ID);
        }

        public void UpdateWorkData(WorkEntity work)
        {
            _workData.UpdateData(work);
        }
    }
}
