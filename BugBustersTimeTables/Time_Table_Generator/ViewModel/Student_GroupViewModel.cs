using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Time_Table_Generator.ViewModel
{
    internal class Student_GroupViewModel
    {
        Student_GroupData _studentData;
        public Student_GroupViewModel()
        {
            _studentData = new Student_GroupData();
        }

        public List<Student_GroupEntity> LoadStudentData()
        {
            return _studentData.LoadData();
        }

        public void SaveStudentData(Student_GroupEntity student)
        {
            _studentData.SaveData(student);
        }

        public void UpdateStudentData(Student_GroupEntity student)
        {
            _studentData.UpdateData(student);
        }

        public void DeleteStudentData(int studentId)
        {
            _studentData.DeleteData(studentId);
        }
    }
}
