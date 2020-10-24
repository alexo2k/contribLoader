using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SntsepomexContributionLoader.Repositories;

namespace SntsepomexContributionLoader.Persistence
{
    class UnitOfWork : IUnitOfWork
    {

        private readonly ContributionContext _context;

        public UnitOfWork(ContributionContext context) {
            _context = context;
            Employees = new EmployeeRepository(_context);
            Workplaces = new WorkplaceRepository(_context);
            WorkPositions = new WorkPositionRepository(_context);
            Contributions = new ContributionRepository(_context);
            Interests = new InterestRepository(_context);
        }

        public IEmployeeRepository Employees { get; private set; }

        public IWorkplaceRepository Workplaces { get; private set; }

        public IWorkPositionRepository WorkPositions { get; private set; }

        public IContributionRepository Contributions { get; private set; }

        public IInterestRepository Interests { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose() {
            _context.Dispose();
        }
    }
}
