using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SntsepomexContributionLoader.Repositories;

namespace SntsepomexContributionLoader
{
    public interface IUnitOfWork : IDisposable
    {
        IEmployeeRepository Employees { get; }
        IWorkplaceRepository Workplaces { get; }
        IWorkPositionRepository WorkPositions { get; }
        IContributionRepository Contributions { get; }
        IInterestRepository Interests { get; }
        int Complete();
    }
}
