using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace Time_Table_Generator.ViewModel
{
    internal class StudentViewModel
    {
        StudentData _studentData;
        public StudentViewModel()
        {
            _studentData = new StudentData();
        }

        public List<StudentEntity> LoadStudentData()
        {
            return _studentData.LoadData();
        }

        public void SaveStudentData(StudentEntity student)
        {
            _studentData.SaveData(student);
        }

        public void UpdateStudentData(StudentEntity student)
        {
            _studentData.UpdateData(student);
        }

        public void DeleteStudentData(int studentId)
        {
            _studentData.DeleteData(studentId);
        }
    }
}
