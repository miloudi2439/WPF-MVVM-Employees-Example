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

        public List<Employee> GetEmployeesIncludeEnterprise(int currentPage , int pageSize )
        {
            return _db.Employees.Include(x => x.Enterprise).OrderBy(x => x.Id).Skip(currentPage*pageSize).Take(pageSize).ToList();
            //return _db.Employees.ToList();
        }

        public List<Employee> SearchEmployee(string searchText, List<string> filters , int currentPage, int pageSize)
        {
            bool firstName =filters.Contains("FirstNameFilter");
            bool lastName = filters.Contains("LastNameFilter");

            if(lastName && firstName)
                return _db.Employees.Where(x => x.FirstName.ToLower().Contains(searchText.ToLower())
                || x.LastName.ToLower().Contains(searchText.ToLower())).Include(x => x.Enterprise).
                OrderBy(x => x.Id).Skip(currentPage * pageSize).Take(pageSize).ToList();

            else if (lastName)
                return _db.Employees.Where(x => x.LastName.ToLower().Contains(searchText.ToLower())).Include(x => x.Enterprise).
                       OrderBy(x => x.Id).Skip(currentPage * pageSize).Take(pageSize).ToList();

            return _db.Employees.Where(x=> x.FirstName.ToLower().Contains(searchText.ToLower())).Include(x => x.Enterprise).
            OrderBy(x => x.Id).Skip(currentPage * pageSize).Take(pageSize).ToList();
        }

        public int NumberofSearchEmployee(string searchText, List<string> filters, int currentPage, int pageSize)
        {
            bool firstName = filters.Contains("FirstNameFilter");
            bool lastName = filters.Contains("LastNameFilter");

            if (lastName && firstName)
                return _db.Employees.Where(x => x.FirstName.ToLower().Contains(searchText.ToLower())
                || x.LastName.ToLower().Contains(searchText.ToLower())).Include(x => x.Enterprise).
                OrderBy(x => x.Id).ToList().Count;

            else if (lastName)
                return _db.Employees.Where(x => x.LastName.ToLower().Contains(searchText.ToLower())).Include(x => x.Enterprise).
                       OrderBy(x => x.Id).ToList().Count;

            return _db.Employees.Where(x => x.FirstName.ToLower().Contains(searchText.ToLower())).Include(x => x.Enterprise).
            OrderBy(x => x.Id).ToList().Count;
        }
    }
}
