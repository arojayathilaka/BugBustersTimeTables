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
    public class BuildingData
    {
        public List<BuildingEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Building");

                    return con.Query<BuildingEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return new List<BuildingEntity>();
                }
            }
            
        }


        public void UpdateData(BuildingEntity building)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("UPDATE Building SET BuildingName=@BuildingName WHERE BuildingId=@BuildingId", building);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void SaveData(BuildingEntity building)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO Building (BuildingId, BuildingName) values (@BuildingId, @BuildingName)", building);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void DeleteData(int buildingId)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM Building WHERE BuildingId=" + buildingId);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
