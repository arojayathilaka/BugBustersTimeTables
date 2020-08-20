using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    class SubjectStatisticsViewModel
    {


        SubjectStatisticsData _subjectStatisticsData;
        public SubjectStatisticsViewModel()
        {
            _subjectStatisticsData = new SubjectStatisticsData();
        }

        public int LoadSubjectCount()
        {
            return _subjectStatisticsData.LoadSubjectCount();
        }

        public int LoadOfferedYearWiseSubjectCount()
        {
            return _subjectStatisticsData.LoadOfferedYearWiseSubjectCount();
        }

        public int LoadOfferedSemesterWiseSubjectCount()
        {
            return _subjectStatisticsData.LoadOfferedSemesterWiseSubjectCount();
        }

    }
}
