using MVVM_FIRST.Model;
using SDK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDK.Service
{
    public class Service : IService
    {
        private UnitOfWork _UnitOfWork = new UnitOfWork();



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
