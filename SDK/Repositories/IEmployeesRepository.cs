using MVVM_FIRST.Model;
using System.Collections.Generic;

namespace SDK.Model
{
    public interface IEmployeesRepository
    {
        List<Employee> GetEmployeesIncludeEnterprise(int currentPage, int pageSize);
        List<Employee> SearchEmployee(string searchText, List<string> filters, int currentPage, int pageSize);
        int NumberofSearchEmployee(string searchText, List<string> filters, int currentPage, int pageSize);
    }
}