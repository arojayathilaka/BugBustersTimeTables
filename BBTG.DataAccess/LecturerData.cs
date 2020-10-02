using BBTG.Common.Config;
using BBTG.Entities.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Windows;

namespace BBTG.DataAccess
{
    public class LecturerData
    {
        public List<LecturerEntity> LoadData()
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
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return new List<LecturerEntity>();
                }
            }
        }

        public void UpdateData(LecturerEntity lecturer)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("UPDATE Lecturer SET Name=@Name, Faculty=@Faculty, Department=@Department, Center=@Center, Building=@Building, Level=@Level, Rank=@Rank WHERE EmployeeId=@EmployeeId", lecturer);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void SaveData(LecturerEntity lecturer)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try{
                    con.Execute("INSERT INTO Lecturer (EmployeeId, Name, Faculty, Department, Center, Building, Level, Rank) values (@EmployeeId, @Name, @Faculty, @Department, @Center, @Building, @Level, @Rank)", lecturer);
                } catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void DeleteData(int lecturerId)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM Lecturer WHERE EmployeeId="+lecturerId);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
