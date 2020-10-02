using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Entities.Data
{
    public class DepartmentEntity
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public DepartmentEntity()
        {

        }

        public DepartmentEntity(int DepartmentId, string DepartmentName)
        {
            this.DepartmentId = DepartmentId;
            this.DepartmentName = DepartmentName;
        }
    }
}
