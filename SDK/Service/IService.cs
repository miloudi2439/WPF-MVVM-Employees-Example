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
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
    [ServiceKnownType(typeof(Employee))]
    [ServiceKnownType(typeof(Enterprise))]
    public interface IService
    {


        [OperationContract]
        List<User> GetUsers();
        [OperationContract]
        List<Enterprise> GetEnterprises();
        [OperationContract]
        List<Employee> GetEmployeesIncludeEnterprise(int currentPage, int pageSize);
        [OperationContract]
        void AddEmployee(Employee obj);
        [OperationContract]
        void RemoveEmployee(Employee obj);
        [OperationContract]
        void UpdateEmployee(Employee obj, int Id);
        void AddEnterprise(Enterprise obj);
        [OperationContract]
        void RemoveEnterprise(Enterprise obj);
        [OperationContract]
        void UpdateEnterprise(Enterprise obj, int Id);
        void AddUser(User obj);
        [OperationContract]
        void RemoveUser(User obj);
        [OperationContract]
        void UpdateUser(User obj, int Id);
        [OperationContract]
        int NumberOfEmployees();
        [OperationContract]
        int NumberOfEnterprises();
        [OperationContract]
        int NumberOfUsers();


    }
}
