using BBTG.Common.Config;
using BBTG.DataAccess;
using BBTG.Entities;
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
        List<SessionEntity> CurrentSessionDataList;
        List<LecturerEntity> CurrentlecturersList;


        //Support ViewModel
        LecturerViewModel _lecturerViewModel;
        

        public SessionViewModel()
        {
            _sessionData = new SessionData();
            _lecturerViewModel = new LecturerViewModel();
        }

        public List<SessionEntity> LoadSessionData()
        {
            CurrentlecturersList = _lecturerViewModel.LoadLecturerData();
            CurrentSessionDataList = _sessionData.LoadData();
            CurrentSessionDataList = SetLecturers(CurrentSessionDataList);
            __Test();
            return CurrentSessionDataList;
        }

        public List<SessionEntity> SetLecturers(List<SessionEntity> sessions)
        {
            return sessions.Select(e => { e.SessionLectures = LecturerEntities(e.LecturerIdsArr); return e; }).ToList();
        }

        /*
         CONDITIONS : - 
                1. Load Data According to the Score
         
         */

        public void __Test() 
        {
            // loop through and get the lowest ranked lecturer and order sessions by him
            CurrentSessionDataList.OrderBy(e => e.SessionLectures.Select(ee => ee.Rank).Min()).ToList();
            // load timeslots
            var x = AppData._timeSlotEntities;

            //assign sessions to each time slot
            x.Select(e => { e.SessionEntity = SessionEntities(x); return e; }).ToList();
        }

        public List<Session> GetSessionList(List<SessionEntity> sessions)
        {
            List<Session> sessionList = new List<Session>();
            sessions = SetLecturers(sessions);
            foreach (SessionEntity s in sessions)
            {
                List<string> lecNames = new List<string>();
                foreach (LecturerEntity l in s.SessionLectures)
                {
                    lecNames.Add(l.Name);
                }
                string[] slctdLecsNames = lecNames.ToArray();
                
                sessionList.Add(new Session
                {
                    Lecturers = string.Join(",", slctdLecsNames),
                    SubjectName = s.SubjectName,
                    SubjectCode = s.SubjectCode,
                    Tag = s.Tag,
                    GroupId = s.GroupId,
                    Count = s.Count,
                    Duration = s.Duration
                });
            }
            return sessionList;
        }

        private List<LecturerEntity> LecturerEntities(int[] vs) 
        {
            List<LecturerEntity> d = new List<LecturerEntity>();
            for (int i = 0; i < vs.Length; i++)
                d.Add(CurrentlecturersList.Find(e => e.EmployeeId == vs[i]));
            
            return d;
        }



        private List<SessionEntity> SessionEntities(List<TimeSlotEntity> currentList)
        {


            //foreach (var item in currentList)
            //{
            //    if (item.SessionEntity.Any(e => CurrentSessionDataList.Any(eee => eee.SessionId == e.SessionId)))
            //        return null;
            //    else
            //        return CurrentSessionDataList;
            //}
            //return null;

            try
            {
                // check if any sessions that are alraedy assigned to timeslots
                if (!currentList.Any(e => e.SessionEntity.Any(ee => CurrentSessionDataList.Any(eee => eee.SessionId == ee.SessionId))))
                    return CurrentSessionDataList;
                else
                    return new List<SessionEntity>();
            }
            catch (Exception ex)
            {
                return CurrentSessionDataList;
            }
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
