using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Table_Generator.ViewModel
{
    internal class LecturerNAViewModel
    {
        LecturerNAData _lecturerNAData;
        public LecturerNAViewModel()
        {
            _lecturerNAData = new LecturerNAData();
        }

        public List<LecturerNAEntity> LoadLecturerNAData()
        {
            return _lecturerNAData.LoadData();
        }

        public void SaveLecturerNAData(LecturerNAEntity lecturerNa)
        {
            _lecturerNAData.SaveData(lecturerNa);
        }

        public void UpdateLecturerNAData(LecturerNAEntity lecturerNa)
        {
            _lecturerNAData.UpdateData(lecturerNa);
        }

        public void DeleteLecturerNaData(int lecturerId)
        {
            _lecturerNAData.DeleteData(lecturerId);
        }
    }
}
