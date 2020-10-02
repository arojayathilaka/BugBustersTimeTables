using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Table_Generator.ViewModel
{
    internal class SessionNAViewModel
    {
        SessionNAData _sessionNAData;
        public SessionNAViewModel()
        {
            _sessionNAData = new SessionNAData();
        }

        public List<SessionNAEntity> LoadSessionNAData()
        {
            return _sessionNAData.LoadData();
        }

        public void SaveSessionNAData(SessionNAEntity sessionNa)
        {
            _sessionNAData.SaveData(sessionNa);
        }

        public void UpdateSessionNAData(SessionNAEntity sessionNa)
        {
            _sessionNAData.UpdateData(sessionNa);
        }

        public void DeleteSessionNaData(int sessionId)
        {
            _sessionNAData.DeleteData(sessionId);
        }
    }
}
