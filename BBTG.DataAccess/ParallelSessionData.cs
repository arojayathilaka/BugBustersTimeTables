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
    public class ParallelSessionData
    {

        public List<ParallelSessionEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("ParallelSession");

                    return con.Query<ParallelSessionEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<ParallelSessionEntity>();
                }
            }
        }
        public void UpdateData(ParallelSessionEntity parallelSession)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("UPDATE ParallelSession SET Ses1=@Ses1, Ses2=@Ses2, Day=@Day, STime=@STime, ETime=@ETime WHERE ParallelSessionId=@ParallelSessionId", parallelSession);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void SaveData(ParallelSessionEntity parallelSession)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO ParallelSession (ParallelSessionId, Ses1, Ses2, Day, STime, ETime) values (@ParallelSessionId, @Ses1, @Ses2, @Day, @STime, @ETime)", parallelSession);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void DeleteData(int ParallelSessionId)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM ParallelSession WHERE ParallelSessionId=" + ParallelSessionId);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

    }
}
