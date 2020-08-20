using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    class StudentStatisticsViewModel
    {


        StudentStatisticsData _studentStatisticsData;
        public StudentStatisticsViewModel()
        {
            _studentStatisticsData = new StudentStatisticsData();
        }

        public int LoadStudentCount()
        {
            return _studentStatisticsData.LoadStudentCount();
        }

        public int LoadProgrammeWiseStudentCount()
        {
            return _studentStatisticsData.LoadProgrammeWiseStudentCount();
        }

    }
}
