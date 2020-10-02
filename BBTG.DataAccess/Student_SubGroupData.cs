using BBTG.Common.Config;
using BBTG.Entities.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows;

namespace BBTG.DataAccess
{
    public class Student_SubGroupData
    {
        public List<Student_SubGroupEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Student");

                    return con.Query<Student_SubGroupEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<Student_SubGroupEntity>();
                }
            }
        }
        public void UpdateData(Student_SubGroupEntity student)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("UPDATE Student SET AcademicYrSem=@AcademicYrSem, Programme=@Programme, GroupNumber=@GroupNumber, GroupId=@GroupId, SubGroupNumber=@SubGroupNumber, SubGroupId=@SubGroupId WHERE StudentId=@StudentId", student);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void SaveData(Student_SubGroupEntity student)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO Student (StudentId, AcademicYrSem, Programme, GroupNumber, GroupId, SubGroupNumber, SubGroupId) values (@StudentId, @AcademicYrSem, @Programme, @GroupNumber, @GroupId, @SubGroupNumber, @SubGroupId)", student);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void DeleteData(int studentId)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM Student WHERE StudentId=" + studentId);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
