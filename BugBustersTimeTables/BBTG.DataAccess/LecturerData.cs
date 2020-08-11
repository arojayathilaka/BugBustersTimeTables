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
                con.Execute("INSERT INTO Lecturer (employeeId, name, faculty, department, center, building, level, rank) values (@EmployeeId, @Name, @Faculty, @Department, @Center, @Building, @Level, @Rank)", lecturer);
            }
        }
    }
}
