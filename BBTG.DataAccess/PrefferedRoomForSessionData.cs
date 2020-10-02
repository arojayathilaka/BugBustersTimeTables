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
    public class PrefferedRoomForSessionData
    {
        public List<PrefferedRoomForSessionEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("PrefferedRoomForSession");

                    return con.Query<PrefferedRoomForSessionEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<PrefferedRoomForSessionEntity>();
                }
            }
        }



        public void SaveData(PrefferedRoomForSessionEntity prefferedRoomForSession)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO PrefferedRoomForSession (id,SessionId, RoomName) values (@id,@SessionId, @RoomName)", prefferedRoomForSession);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


    }
}
