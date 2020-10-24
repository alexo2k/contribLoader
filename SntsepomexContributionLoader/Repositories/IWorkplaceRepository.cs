using SntsepomexContributionLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Repositories
{
    public interface IWorkplaceRepository : IRepository<Workplace>
    {
        IEnumerable<Workplace> GetWorkplacesByOrder();
    }
}
