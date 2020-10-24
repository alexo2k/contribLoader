using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SntsepomexContributionLoader.Models;

namespace SntsepomexContributionLoader.Repositories
{
    public interface IContributionRepository : IRepository<Contribution>
    {
        Contribution GetPrevious(string year);

        Contribution GetLastContribution(Expression<Func<Contribution, bool>> predicate);

        double GetBigTotal(int empId);

        double GetTotal(int empId, int contribType);

        double TotalOfPeriods(int empId);

        IEnumerable<ContributionExcelModel> GetExcelReport(string pYear, int pFornight);
    }
}
