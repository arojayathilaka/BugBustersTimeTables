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
    public class PrefferedRoomForTagData
    {
        
        public List<PrefferedRoomForTagEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("PrefferedRoomForTag");

                    return con.Query<PrefferedRoomForTagEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<PrefferedRoomForTagEntity>();
                }
            }
        }


        public void SaveData(PrefferedRoomForTagEntity prefferedRoomForTag)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO PrefferedRoomForTag (id,TagName, RoomName) values (@id,@TagName, @RoomName)", prefferedRoomForTag);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

      
    }
}
