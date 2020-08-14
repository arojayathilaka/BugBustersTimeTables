using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBTG.Common
{
    public class Class1
    {
        

        public Class1(int employeeId, string name)
        {
            this.employeeId = employeeId;
            this.name = name;
        }

        public int employeeId { get; set; }
        public string name { get; set; }
    }
}
