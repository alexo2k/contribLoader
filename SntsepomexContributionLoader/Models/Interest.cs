using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Models
{
    public class Interest
    {
        public int InterestId { get; set; }
        [MaxLength(4)]
        public string Year { get; set; }
        public double Percentage { get; set; }
    }
}
