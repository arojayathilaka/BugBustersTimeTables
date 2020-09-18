using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class SessionViewModel
    {
        SessionData _sessionData;

        public SessionViewModel()
        {
            _sessionData = new SessionData();
        }

        public List<SessionEntity> LoadSessionData()
        {
            return _sessionData.LoadData();
        }

        public void SaveSessionData(SessionEntity Session)
        {
            _sessionData.SaveData(Session);
        }
    }
}
