using BBTG.Common.Config;
using BBTG.Entities.Data;
using Dapper;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows;

namespace BBTG.DataAccess
{
    public class LecturerData
    {
        public List<LecturerEntity> LoadLecturerData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Lecturer");

                    return con.Query<LecturerEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return new List<LecturerEntity>();
                }
            }
        }

        public void SaveLecturerData(LecturerEntity lecturer)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try{
                    con.Execute("INSERT INTO Lecturer (EmployeeId, Name, Faculty, Department, Center, Building, Level, Rank) values (@EmployeeId, @Name, @Faculty, @Department, @Center, @Building, @Level, @Rank)", lecturer);
                } catch(SQLiteException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
