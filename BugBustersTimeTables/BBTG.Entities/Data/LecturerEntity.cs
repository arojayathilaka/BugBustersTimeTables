using System;
using System.Collections.Generic;
using System.Text;

namespace BBTG.Entities.Data
{
    public class LecturerEntity
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Center { get; set; }
        public string Building { get; set; }
        public int Level { get; set; }
        public double Rank { get; set; }

        public LecturerEntity()
        {

        }

        public LecturerEntity(int EmployeeId, string Name, string Faculty, string Department, string Center, string Building, int Level, double Rank)
        {
            this.EmployeeId = EmployeeId;
            this.Name = Name;
            this.Faculty = Faculty;
            this.Department = Department;
            this.Center = Center;
            this.Building = Building;
            this.Level = Level;
            this.Rank = Rank;
        }      
    }
}
