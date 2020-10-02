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
    public class PrefferedRoomForLecturerData
    {

         public List<PrefferedRoomForLecturerEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("PrefferedRoomForLecturer");

                    return con.Query<PrefferedRoomForLecturerEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<PrefferedRoomForLecturerEntity>();
                }
            }
        }


        public void SaveData(PrefferedRoomForLecturerEntity prefferedRoomForLecturer)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO PrefferedRoomForLecturer (id,Name,RoomName) values (@id,@Name,@RoomName)", prefferedRoomForLecturer);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


    }
}
