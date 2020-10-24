using SntsepomexContributionLoader.Models;
using SntsepomexContributionLoader.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Persistence
{
    public class InterestRepository : Repository<Interest>, IInterestRepository
    {
        public InterestRepository(ContributionContext context) : base(context) {

        }

        public ContributionContext ContributionContext {
            get {return Context as ContributionContext; }
        }
    }
}
