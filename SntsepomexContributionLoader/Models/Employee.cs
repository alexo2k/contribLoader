using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [MaxLength(8)]
        public string EmployeeCode { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(40)]
        public string MaidenName { get; set; }
        [MaxLength(60)]
        public string Name { get; set; }
        [MaxLength(15)]
        public string RFC { get; set; }
        [MaxLength(22)]
        public string CURP { get; set; }
        public DateTime GovernmentEntry { get; set; }
        public DateTime DependencyEntry { get; set; }
        [ForeignKey("WorkPlace")]
        public int WorkplaceId { get; set; }
        [ForeignKey("WorkPosition")]
        public int WorkPositionId { get; set; }
        public Workplace WorkPlace { get; set; }
        public WorkPosition WorkPosition { get; set; }
        public virtual ICollection<Contribution> Contributions { get; set; }
    }
}
