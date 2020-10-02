using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class FacultyViewModel
    {
        FacultyData _facultyData;
        public FacultyViewModel()
        {
            _facultyData = new FacultyData();
        }

        public List<FacultyEntity> LoadFacultyData()
        {
            return _facultyData.LoadData();
        }
    }
}
