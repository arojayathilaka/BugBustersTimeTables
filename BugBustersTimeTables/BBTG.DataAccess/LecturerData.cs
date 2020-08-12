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
            using (IDbConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                return con.Query<LecturerEntity>("SELECT * FROM Lecturer", new DynamicParameters()).ToList();
            }
        }

        public void SaveLecturerData(LecturerEntity lecturer)
        {
            using (IDbConnection con = new SQLiteConnection(ConfigurationManager.ConnectionStrings["Default"].ConnectionString))
            {
                try{
                    con.Execute("INSERT INTO Lecturer (EmployeeId, Name, Faculty, Department, Center, Building, Level, Rank) values (@EmployeeId, @Name, @Faculty, @Department, @Center, @Building, @Level, @Rank)", lecturer);
                } catch(SQLiteException e)
                {
                    MessageBox.Show("Failed to add lecturer!");
                }
            }
        }
    }
}
