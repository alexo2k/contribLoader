using SntsepomexContributionLoader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        Employee GetEmployeeWithContribs(Expression<Func<Employee, bool>> predicate);

        List<Employee> SearchEmployees(Expression<Func<Employee, bool>> predicate);
    }
}
