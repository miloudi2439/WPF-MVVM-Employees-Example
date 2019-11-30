using MVVM_FIRST.Model;
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
    public interface IService
    {
        [OperationContract]
        double Add(double n1, double n2);

        [OperationContract]
        List<Enterprise> GetEnterprises();

    }
}
