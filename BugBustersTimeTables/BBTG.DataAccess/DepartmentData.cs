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
    public class DepartmentData
    {
        public List<DepartmentEntity> LoadData()
        {
            using (IDbConnection con = new SQLiteConnection(AppData.ConnectionString))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("SELECT");
                    sb.AppendLine("*");
                    sb.AppendLine("FROM");
                    sb.AppendLine("Department");

                    return con.Query<DepartmentEntity>(sb.ToString(), new DynamicParameters()).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return new List<DepartmentEntity>();
                }
            }

        }
    }
}
