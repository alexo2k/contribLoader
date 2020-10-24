using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Models
{
    public class ContributionExcelModel
    {
        public int EmployeeId { get; set; }
        public string LastName { get; set; }
        public string MaidenName { get; set; }
        public string Name { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string EmployeeCode { get; set; }
        public double ContribBalance { get; set; }
        public double ContribAccumulated { get; set; }
        public DateTime ContribDate { get; set; }
        public string Year { get; set; }
        public int FornightNumber { get; set; }
        public int ContribType { get; set; }
    }
}
