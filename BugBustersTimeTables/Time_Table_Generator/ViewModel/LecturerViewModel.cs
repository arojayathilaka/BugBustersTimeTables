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

        public List<LecturerEntity> LoadData()
        {
            return _lecturerData.LoadLecturerData();
        }

        public void SaveData(LecturerEntity lecturer)
        {
            _lecturerData.SaveLecturerData(lecturer);
        }

        public void UpdateData(LecturerEntity lecturer)
        {
            _lecturerData.UpdateLecturerData(lecturer);
        }

        public void DeleteData(int lecturerId)
        {
            _lecturerData.DeleteLecturerData(lecturerId);
        }
    }
}
