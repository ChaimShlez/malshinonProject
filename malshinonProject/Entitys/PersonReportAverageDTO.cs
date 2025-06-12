using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace malshinonProject.Entitys
{
    internal class PersonReportAverageDTO
    {
        

        public string FullName { get; set; }
        public string CodeName { get; set; }
        public double Average { get; set; }

        public PersonReportAverageDTO(string fullName, string codeName, double average)
        {
            FullName = fullName;
            CodeName = codeName;
            Average = average;
        }

        public PersonReportAverageDTO()
        {
        }
    }
}
