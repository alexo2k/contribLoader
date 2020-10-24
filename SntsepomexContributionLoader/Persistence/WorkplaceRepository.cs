using SntsepomexContributionLoader.Models;
using SntsepomexContributionLoader.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Persistence
{
    public class WorkplaceRepository : Repository<Workplace>, IWorkplaceRepository
    {
        public WorkplaceRepository(ContributionContext context) : base(context) {

        }

        public ContributionContext ContributionContext {
            get { return Context as ContributionContext; }
        }

        public IEnumerable<Workplace> GetWorkplacesByOrder()
        {
            return ContributionContext.Workplaces.OrderBy(w => w.WorkplaceDescription).ToList();
        }

    }
}
