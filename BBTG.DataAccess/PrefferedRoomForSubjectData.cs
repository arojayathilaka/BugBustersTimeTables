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
    public class PrefferedRoomForSubjectData
    {

          public List<PrefferedRoomForSubjectEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("id");
                    sb.AppendLine("FROM");
                    sb.AppendLine("PrefferedRoomForSubject");

                    return con.Query<PrefferedRoomForSubjectEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<PrefferedRoomForSubjectEntity>();
                }
            }
        }



        public void SaveData(PrefferedRoomForSubjectEntity prefferedRoomForSubject)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("INSERT INTO PrefferedRoomForSubject (id,SubjectName,TagName,RoomName) values (@id,@SubjectName,@TagName, @RoomName)", prefferedRoomForSubject);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }


    }
}
