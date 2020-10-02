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
    public class PrefferedRoomForGroupData
    {

         public List<PrefferedRoomForGroupEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("PrefferedRoomForGroup");

                    return con.Query<PrefferedRoomForGroupEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<PrefferedRoomForGroupEntity>();
                }
            }
        }



        public void SaveData(PrefferedRoomForGroupEntity prefferedRoomForGroup)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO PrefferedRoomForGroup (id,GroupNumber,SubGroupNumber,RoomName) values (@id,@GroupNumber,@SubGroupNumber, @RoomName)", prefferedRoomForGroup);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


    }
}
