using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Models
{
    public class Contribution
    {
        public Int64 ContributionId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int? FortnightNumber { get; set; }
        [MaxLength(4)]
        public string Year { get; set; }
        public DateTime ContributionDate { get; set; }
        public double ContributionBalance { get; set; }
        public double ContributionAccumulated { get; set; }
        //public double GeneratedInterest { get; set; }
        //public bool CalculateInterest { get; set; }
        public int ContribType { get; set; }

    }
}
