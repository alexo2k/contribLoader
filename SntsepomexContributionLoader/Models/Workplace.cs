using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Models
{
    public class Workplace
    {
        public int WorkplaceId { get; set; }
        [MaxLength(11)]
        public string WorkplaceCode { get; set; }
        public string WorkplaceDescription { get; set; }
        [MaxLength(3)]
        public string WorkplaceCity { get; set; }
        [MaxLength(3)]
        public string WorkplaceZone { get; set; }

    }
}
