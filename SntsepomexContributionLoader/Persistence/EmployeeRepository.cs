using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SntsepomexContributionLoader.Models;
using SntsepomexContributionLoader.Repositories;

namespace SntsepomexContributionLoader.Persistence
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ContributionContext context) : base(context) {

        }

        public ContributionContext ContributionContext {
            get { return Context as ContributionContext; }
        }
  
        public Employee GetEmployeeWithContribs(Expression<Func<Employee, bool>> predicate)
        {
            return ContributionContext.Employees.Where(predicate).Include(emp => emp.Contributions).Include(emp => emp.WorkPlace).FirstOrDefault();
        }
        public List<Employee> SearchEmployees(Expression<Func<Employee, bool>> predicate)
        {
            return ContributionContext.Employees.Where(predicate).ToList();
        }
    }
}
