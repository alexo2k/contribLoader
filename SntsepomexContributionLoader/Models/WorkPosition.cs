using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Models
{
    public class WorkPosition
    {
        public int WorkPositionId { get; set; }
        [MaxLength(7)]
        public string WorkPositionCode { get; set; }
        [MaxLength(3)]
        public string WorkPositionLevel { get; set; }
        public string WorkPositionDescription { get; set; }
        public string WorkPositionType { get; set; }
    }
}
