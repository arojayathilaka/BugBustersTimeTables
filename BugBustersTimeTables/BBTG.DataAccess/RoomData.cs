using BBTG.Common.Config;
using BBTG.Entities.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Data;
using System.Windows;

namespace BBTG.DataAccess
{
    public class RoomData
    {

        public List<RoomEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Room");

                    return con.Query<RoomEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<RoomEntity>();
                }
            }
        }

        public void UpdateData(RoomEntity room)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("UPDATE Room SET RoomName=@RoomName, Building=@Building, RoomType=@RoomType, Capacity=@Capacity WHERE RoomId=@RoomId", room);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void SaveData(RoomEntity room)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO Room (RoomId, RoomName, Building, RoomType, Capacity) values (@RoomId, @RoomName, @Building, @RoomType, @Capacity)", room);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void DeleteData(int roomId)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM Room WHERE RoomId=" + roomId);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
