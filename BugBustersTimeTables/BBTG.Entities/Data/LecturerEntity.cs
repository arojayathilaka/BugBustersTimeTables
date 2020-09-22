using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BBTG.Entities.Data
{
    public class LecturerEntity : IDataErrorInfo
    {
        public int EmployeeId { get; set; } 
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Center { get; set; }
        public string Building { get; set; }
        public int Level { get; set; }
        public double Rank { get; set; }
        string IDataErrorInfo.Error
        {
            get { return null; }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                if (columnName == "Name")
                {
                    // Validate property and return a string if there is an error
                    if (string.IsNullOrEmpty(Name))
                        return "Name is Required";
                }

                // If there's no error, null gets returned
                return null;
            }
        }
    }
}
