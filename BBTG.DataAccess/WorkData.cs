using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using BBTG.Entities.Data;
using System.Data;
using System.Data.SQLite;
using System.Configuration;
using Dapper;
using BBTG.Common.Config;
using System.Windows;

namespace BBTG.DataAccess
{
    public class WorkData
    {
        public void saveWorkingData(WorkEntity work)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                con.Execute("INSERT INTO WorkTable (ID, BatchType, NoOfWorkingDays, WorkingDays, NoOfWorkingHours, TimeSlotStartTime, TimeSlotEndTime) values (@ID, @batchType, @noOfWorkingDays, @workingDays, @noOfWorkingHours, @timeSlotStartTime, @timeSlotEndTime)", work);
            }
        }
        public List<WorkEntity> LoadWorkData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                return con.Query<WorkEntity>("SELECT * FROM WorkTable", new DynamicParameters()).ToList();
            }
        }

        public List<WorkEntity> LoadWorkingDays(int ID)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                return con.Query<WorkEntity>("SELECT * FROM WorkTable WHERE ID =" + ID, new DynamicParameters()).ToList();
            }
        }

        public void AddTimeSlots(TimeSlotEntity timeSlots)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                con.Execute("INSERT INTO TimeSlotTable (ID, Days, TimeSlots, SessionId) values (@ID, @Days, @TimeSlots, @SessionId)", timeSlots);
            }
        }

        public void DeleteTimeSlotData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM TimeSlotTable ");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public List<TimeSlotEntity> LoadTimeSlotData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                return con.Query<TimeSlotEntity>("SELECT * FROM TimeSlotTable", new DynamicParameters()).ToList();
            }
        }

        public void DeleteData(int ID)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("DELETE FROM WorkTable WHERE ID=" + ID);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public void UpdateData(WorkEntity work)
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    con.Execute("UPDATE WorkTable SET BatchType=@batchType, NoOfWorkingDays=@noOfWorkingDays, WorkingDays=@workingDays, NoOfWorkingHours=@noOfWorkingHours, TimeSlotStartTime=@timeSlotStartTime, TimeSlotEndTime=@timeSlotEndTime WHERE ID=@ID", work);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
