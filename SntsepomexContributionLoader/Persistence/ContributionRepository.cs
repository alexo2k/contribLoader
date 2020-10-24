using SntsepomexContributionLoader.Models;
using SntsepomexContributionLoader.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SntsepomexContributionLoader.Persistence
{
    public class ContributionRepository : Repository<Contribution>, IContributionRepository
    {
        public ContributionRepository(ContributionContext context) : base(context) {

        }

        public ContributionContext ContributionContext {
            get { return Context as ContributionContext; }
        }

        public double GetBigTotal(int empId)
        {
            return ContributionContext.Contributions.Where(con => con.EmployeeId == empId).Sum(con => con.ContributionAccumulated);
        }

        public Contribution GetLastContribution(Expression<Func<Contribution, bool>> predicate)
        {
            return ContributionContext.Contributions.Where(predicate).OrderByDescending(con => con.ContributionId).FirstOrDefault();
        }

        public Contribution GetPrevious(string year)
        {
            string auxPrevYear = (Int32.Parse(year) - 1).ToString();
            return ContributionContext.Contributions.Where(con => con.Year == auxPrevYear).OrderByDescending(con => con.FortnightNumber).FirstOrDefault();
        }

        public double GetTotal(int empId, int contribType)
        {
            return ContributionContext.Contributions.Where(con => con.EmployeeId == empId && con.ContribType == contribType).Sum(con => (double?) con.ContributionBalance) ?? 0;
        }

        public double TotalOfPeriods(int empId)
        {
            return ContributionContext.Contributions.Count(con => con.EmployeeId == empId);
        }

        public IEnumerable<ContributionExcelModel> GetExcelReport(string pYear, int pFornight) {

            IEnumerable<ContributionExcelModel> listaEmpleados;

            listaEmpleados = ContributionContext.Contributions.Join(
                ContributionContext.Employees, 
                con=> con.EmployeeId, 
                emp=> emp.EmployeeId, 
                (con, emp) => new ContributionExcelModel {
                    EmployeeId = emp.EmployeeId,
                    LastName = emp.LastName,
                    MaidenName = emp.MaidenName,
                    Name = emp.Name,
                    RFC = emp.RFC,
                    CURP = emp.CURP,
                    EmployeeCode = emp.EmployeeCode,
                    ContribBalance = con.ContributionBalance,
                    ContribAccumulated = con.ContributionAccumulated,
                    ContribDate = con.ContributionDate,
                    Year = con.Year,
                    FornightNumber = con.FortnightNumber ?? default(int),
                    ContribType = con.ContribType
                }).Where(conEmp => conEmp.Year == pYear && conEmp.FornightNumber == pFornight);

            return listaEmpleados;
        }
    }
}
