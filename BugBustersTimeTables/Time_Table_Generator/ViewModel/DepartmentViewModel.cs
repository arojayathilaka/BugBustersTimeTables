using BBTG.DataAccess;
using BBTG.Entities.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Time_Table_Generator.ViewModel
{
    internal class DepartmentViewModel
    {
        DepartmentData _departmentData;
        public DepartmentViewModel()
        {
            _departmentData = new DepartmentData();
        }

        public List<DepartmentEntity> LoadDepartmentData()
        {
            return _departmentData.LoadData();
        }
    }
}
