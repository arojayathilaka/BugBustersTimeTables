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
    public class SubjectStatisticsData
    {
        public int LoadSubjectCount()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(*)");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Subject");

                    return con.Query(sb.ToString(), new DynamicParameters());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //return new List<LecturerEntity>();
                }



            }
        }




        public int LoadOfferedYearWiseSubjectCount()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(*)");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Subject");
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



        public int LoadOfferedSemesterWiseSubjectCount()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT");
                    sb.AppendLine("COUNT(*)");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Subject");
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