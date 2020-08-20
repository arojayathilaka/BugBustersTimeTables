using BBTG.Common.Config;
using BBTG.Entities.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BBTG.DataAccess
{
    public class SubjectData
    {
        public List<SubjectEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Subject");

                    return con.Query<SubjectEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<SubjectEntity>();
                }
            }
        }

        public void UpdateData(SubjectEntity Subject)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("UPDATE Subject SET SubjectCode=@SubjectCode, SubjectName=@SubjectName, Year=@Year, Semester=@Semester, NoOfLecHrs=@NoOfLecHrs, NoOfTuteHrs=@NoOfTuteHrs, NoOfLabHrs=@NoOfLabHrs, NoOfEvalHrs=@NoOfEvalHrs WHERE SubjectId=@SubjectId", Subject);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void SaveData(SubjectEntity Subject)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO Subject (SubjectId,SubjectCode,SubjectName,Year,Semester,NoOfLecHrs,NoOfTuteHrs,NoOfLabHrs,NoOfEvalHrs) values (@SubjectId, @SubjectCode,@SubjectName,@Year,@Semester,@NoOfLecHrs,@NoOfTuteHrs,@NoOfLabHrs,@NoOfEvalHrs)", Subject);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void DeleteData(int SubjectId)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM Subject WHERE SubjectId=" + SubjectId);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
