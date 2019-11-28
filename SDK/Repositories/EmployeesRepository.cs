using MVVM_FIRST.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace SDK.Model
{
    public class EmployeesRepository<T> : GenericRepository<T>, IEmployeesRepository where T : class
    {
        public EmployeesRepository(WorkDbContext db) : base(db)
        {
        }

        public IEnumerable<Employee> GetEmployeesIncludeEnterprise()
        {
            return _db.Employees.Include(x => x.Enterprise).ToList();
        }

    }
}
