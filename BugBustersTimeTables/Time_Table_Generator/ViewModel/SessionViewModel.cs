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

        public List<SessionEntity> LoadSessionDataBySubject(string subjectCode)
        {
            return _sessionData.LoadData().FindAll(s => s.SubjectCode == subjectCode);
        }

        public List<SessionEntity> LoadSessionDataByGroup(string group)
        {
            return _sessionData.LoadData().FindAll(s => s.GroupId == group);
        }

        public List<SessionEntity> LoadSessionDataBySubGroup(string subGroup)
        {
            return _sessionData.LoadData().FindAll(s => s.GroupId == subGroup);
        }

        public List<SessionEntity> LoadSessionDataByTag(string tag)
        {
            return _sessionData.LoadData().FindAll(s => s.Tag == tag);
        }

        public List<SessionEntity> LoadSessionDataByLecturer(int lecturerId)
        {
            return _sessionData.LoadData().FindAll(s =>
            {
                for (int i = 0; i < s.LecturerIdsArr.Length; i++)
                {
                    if (s.LecturerIdsArr[i] == lecturerId)
                    {
                        return true;
                    }
                }
                return false;
            });
        }

        public void SaveSessionData(SessionEntity session)
        {
            _sessionData.SaveData(session);
        }
    }
}
