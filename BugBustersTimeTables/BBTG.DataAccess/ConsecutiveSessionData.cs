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
    public class ConsecutiveSessionData
    {
        public List<ConsecutiveSessionEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("ConsecutiveSession");

                    return con.Query<ConsecutiveSessionEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<ConsecutiveSessionEntity>();
                }
            }
        }

        public void UpdateData(ConsecutiveSessionEntity ConsecutiveSession)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("UPDATE ConsecutiveSession SET Ses1=@Ses1, Ses2=@Ses2 WHERE ConsId=@ConsId", ConsecutiveSession);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void SaveData(ConsecutiveSessionEntity ConsecutiveSession)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO ConsecutiveSession (ConsId, Ses1, Ses2) values (@ConsId, @Ses1, @Ses2)", ConsecutiveSession);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
