using MVVM_FIRST.Model;
using System.Collections.Generic;

namespace SDK.Model
{
    public interface IEmployeesRepository
    {
        List<Employee> GetEmployeesIncludeEnterprise(int currentPage, int pageSize);
    }
}