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
    public class SessionData
    {
        public List<SessionEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Session");

                    var x = con.Query<SessionEntity>(sb.ToString(), new DynamicParameters()).ToList();
                    return x;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<SessionEntity>();
                }
            }
        }

        public void SaveData(SessionEntity session)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO Session (SessionId, LecturerIds, SubjectName, SubjectCode, Tag, GroupId, Count, Duration) values (@SessionId, @LecturerIds, @SubjectName, @SubjectCode, @Tag, @GroupId, @Count, @Duration)", session);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void DeleteData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM Session");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
