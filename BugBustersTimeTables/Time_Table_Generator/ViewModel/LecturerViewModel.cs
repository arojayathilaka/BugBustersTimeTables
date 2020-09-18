using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Table_Generator.ViewModel
{
    internal class LecturerViewModel
    {
        LecturerData _lecturerData;
        public LecturerViewModel()
        {
            _lecturerData = new LecturerData();
        }

        public List<LecturerEntity> LoadLecturerData()
        {
            return _lecturerData.LoadData();
        }

        public List<LecturerEntity> LoadLecturerDataById(int id)
        {
            return _lecturerData.LoadData().FindAll((e) => e.EmployeeId == id);
        }

        public void SaveLecturerData(LecturerEntity lecturer)
        {
            _lecturerData.SaveData(lecturer);
        }

        public void UpdateLecturerData(LecturerEntity lecturer)
        {
            _lecturerData.UpdateData(lecturer);
        }

        public void DeleteLecturerData(int lecturerId)
        {
            _lecturerData.DeleteData(lecturerId);
        }
    }
}
