using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Text;


namespace Time_Table_Generator.ViewModel
{
    internal class Student_SubGroupViewModel
    {
        Student_SubGroupData _studentData;
        public Student_SubGroupViewModel()
        {
            _studentData = new Student_SubGroupData();
        }

        public List<Student_SubGroupEntity> LoadStudentData()
        {
            return _studentData.LoadData();
        }

        public void SaveStudentData(Student_SubGroupEntity student)
        {
            _studentData.SaveData(student);
        }

        public void UpdateStudentData(Student_SubGroupEntity student)
        {
            _studentData.UpdateData(student);
        }

        public void DeleteStudentData(int studentId)
        {
            _studentData.DeleteData(studentId);
        }
    }
}
