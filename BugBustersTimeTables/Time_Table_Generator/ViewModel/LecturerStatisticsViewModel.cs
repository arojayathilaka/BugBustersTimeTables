using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    class LecturerStatisticsViewModel
    {


        LecturerStatisticsData _lecturerStatisticsData;
            public LecturerStatisticsViewModel()
            {
            _lecturerStatisticsData = new LecturerStatisticsData();
            }

            public int LoadLecturerCount()
            {
                return _lecturerStatisticsData.LoadLecturerCount();
            }

        public int LoadDepartmentWiseLecturerCount()
        {
            return _lecturerStatisticsData.LoadDepartmentWiseLecturerCount();
        }

        public int LoadFacultyWiseLecturerCount()
        {
            return _lecturerStatisticsData.LoadFacultyWiseLecturerCount();
        }

        public int LoadCenterWiseLecturerCount()
        {
            return _lecturerStatisticsData.LoadCenterWiseLecturerCount();
        }


        public int LoadLevelWiseLecturerCount()
        {
            return _lecturerStatisticsData.LoadLevelWiseLecturerCount();

        }

    }
    }






