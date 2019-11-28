using MVVM_FIRST.Model;
using System.Collections.Generic;

namespace SDK.Model
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetEmployeesIncludeEnterprise();
    }
}