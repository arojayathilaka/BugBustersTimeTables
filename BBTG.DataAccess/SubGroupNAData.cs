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
    public class SubGroupNAData
    {
        public List<SubGroupNAEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("SubGroupNA");

                    return con.Query<SubGroupNAEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<SubGroupNAEntity>();
                }
            }
        }

        public void UpdateData(SubGroupNAEntity SubGroupNA)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("UPDATE SubGroupNA SET SubGroupNumber=@SubGroupNumber, Day=@Day, STime=@STime, ETime=@ETime WHERE SubGroupId=@SubGroupId", SubGroupNA);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void SaveData(SubGroupNAEntity SubGroupNA)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO SubGroupNA (SubGroupId, SubGroupNumber, Day, STime, ETime) values (@SubGroupId, @SubGroupNumber, @Day, @STime, @ETime)", SubGroupNA);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void DeleteData(int SubGroupId)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM SubGroupNA WHERE SubGroupId=" + SubGroupId);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
