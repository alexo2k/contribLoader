using SntsepomexContributionLoader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader
{
    public class ContributionContext : DbContext
    {
        public ContributionContext() : base("name=ContributionContext") {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Interest> Interests { get; set; }
        public DbSet<Workplace> Workplaces { get; set; }
        public DbSet<WorkPosition> WorkPositions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Contribution> Contributions { get; set; }
    }
}
