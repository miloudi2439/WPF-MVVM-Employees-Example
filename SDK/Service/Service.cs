using MVVM_FIRST.Model;
using SDK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service : IService
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();


        //private static readonly Lazy<Service> lazy =new Lazy<Service> (() => new Service());

        //public static Service Instance { get { return lazy.Value; } }

       /* public Service()
        {
            var entreprise = _UnitOfWork.EnterprisesRepository.GetByID(1);
            for (int i = 0; i < 70000; i++)
            {
                var emp = new Employee
                {
                    FirstName = $"Employee FN {i}",
                    LastName = $"Employee LN {i}",
                    City = $"City  {i%100}",
                    Salary ="20000DA" , 
                    Age = 25 ,
                    EnterpriseId = entreprise.Id
                };
                _UnitOfWork.EmployeesRepository.Add(emp);
                Console.WriteLine($"items count {i}");
                if (i % 100 == 0)
                {
                    _UnitOfWork.Save();
                }

            }
            _UnitOfWork.Save();
        }
        */

        public void AddEmployee(Employee obj)
        {
            _UnitOfWork.EmployeesRepository.Add(obj);
            _UnitOfWork.Save();
        }

        public void AddEnterprise(Enterprise obj)
        {
            _UnitOfWork.EnterprisesRepository.Add(obj);
            _UnitOfWork.Save();
        }

        public void AddUser(User obj)
        {
            _UnitOfWork.UsersRepository.Add(obj);
            _UnitOfWork.Save();
        }

        public List<Employee> GetEmployeesIncludeEnterprise(int currentPage, int pageSize)
        {

            var r = _UnitOfWork.EmployeesRepository.GetEmployeesIncludeEnterprise(currentPage, pageSize);
            return r;

        }

        public List<Enterprise> GetEnterprises()
        {
            return _UnitOfWork.EnterprisesRepository.GetAll();

        }

        public List<User> GetUsers()
        {
            return _UnitOfWork.UsersRepository.GetAll();
        }

        public int NumberOfEmployees()
        {
            return _UnitOfWork.EmployeesRepository.NumberOfRows();
        }

        public int NumberOfEnterprises()
        {
            return _UnitOfWork.EnterprisesRepository.NumberOfRows();
        }

        public int NumberofSearchEmployee(string searchText, List<string> filters, int currentPage, int pageSize)
        {
            return _UnitOfWork.EmployeesRepository.NumberofSearchEmployee(searchText, filters, currentPage, pageSize);
        }

        public int NumberOfUsers()
        {
            return _UnitOfWork.UsersRepository.NumberOfRows();
        }

        public void RemoveEmployee(Employee obj)
        {
            _UnitOfWork.EmployeesRepository.Remove(obj);
            _UnitOfWork.Save();
        }

        public void RemoveEnterprise(Enterprise obj)
        {
            _UnitOfWork.EnterprisesRepository.Remove(obj);
            _UnitOfWork.Save();
        }

        public void RemoveUser(User obj)
        {
            _UnitOfWork.UsersRepository.Remove(obj);
            _UnitOfWork.Save();
        }

        public List<Employee> SearchEmployee(string searchText, List<string> filters, int currentPage, int pageSize)
        {
            return _UnitOfWork.EmployeesRepository.SearchEmployee(searchText, filters, currentPage, pageSize);
        }

        public void UpdateEmployee(Employee obj, int Id)
        {
            _UnitOfWork.EmployeesRepository.Update(obj, Id);
            _UnitOfWork.Save();
        }

        public void UpdateEnterprise(Enterprise obj, int Id)
        {
            _UnitOfWork.EnterprisesRepository.Update(obj, Id);
            _UnitOfWork.Save();
        }

        public void UpdateUser(User obj, int Id)
        {
            _UnitOfWork.UsersRepository.Update(obj, Id);
            _UnitOfWork.Save();
        }
    }
}
