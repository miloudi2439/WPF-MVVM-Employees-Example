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
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            // Code added to write output to the console window.
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public List<Enterprise> GetEnterprises()
        {
            return  _UnitOfWork.EnterprisesRepository.GetAll().ToList();
             
        }
    }
}
