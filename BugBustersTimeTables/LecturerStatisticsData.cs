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
    public class LecturerStatisticsData
    {
        public int LoadLecturerCount()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(*)");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Lecturer");

                    return con.Query(sb.ToString(), new DynamicParameters());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //return new List<LecturerEntity>();
                }


               
            }
        }




        public int LoadFacultyWiseLecturerCount()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(*)");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Lecturer");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("");

                    return con.Query(sb.ToString(), new DynamicParameters());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //return new List<LecturerEntity>();
                }



            }
        }



        public int LoadDepartmentWiseLecturerCount()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(*)");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Lecturer");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("");

                    return con.Query(sb.ToString(), new DynamicParameters());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //return new List<LecturerEntity>();
                }



            }
        }



        public int LoadCenterWiseLecturerCount()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(*)");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Lecturer");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("");

                    return con.Query(sb.ToString(), new DynamicParameters());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //return new List<LecturerEntity>();
                }



            }
        }


        public int LoadLevelWiseLecturerCount()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(*)");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Lecturer");
                    sb.AppendLine("WHERE");
                    sb.AppendLine("");

                    return con.Query(sb.ToString(), new DynamicParameters());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //return new List<LecturerEntity>();
                }



            }
        }



    }
}
