using BBTG.Common.Config;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Time_Table_Generator
{
    internal class StartUp
    {
        public StartUp()
        {
            SetAppData();
        }

        private void SetAppData()
        {
            //db Environment.CurrentDirectory + "\\BBTG.db";
            //AppData.ConnectionString = $@"Data Source = BBTG.db; Version = 3; providerName=System.Data.SqlClient";
            AppData.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            new AppData();


            //(from pa in patients
            // where pa.Age > 20
            //orderby pa.PatientName, pa.Gender, pa.Age
            // select pa).Count();

            //var scoreQuery = x.FindAll(e => e.SessionEntity.FindAll); 
           


        }


    }
}
