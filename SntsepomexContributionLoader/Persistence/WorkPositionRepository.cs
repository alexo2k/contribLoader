using SntsepomexContributionLoader.Models;
using SntsepomexContributionLoader.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Persistence
{
    public class WorkPositionRepository : Repository<WorkPosition>, IWorkPositionRepository
    {
        public WorkPositionRepository(ContributionContext context) : base(context) {

        }

        public ContributionContext ContributionContext {
            get { return Context as ContributionContext; }
        }

        public IEnumerable<WorkPosition> GetPositionOrdered()
        {
            return ContributionContext.WorkPositions.OrderBy(w => w.WorkPositionDescription).ToList();
        }
    }
}
