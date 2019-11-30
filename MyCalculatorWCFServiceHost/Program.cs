using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
namespace MyCalculatorWCFServiceHost
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Create a URI to serve as the base address
            Uri httpUrl = new Uri("http://localhost:8090/SDK/Service/Service");

            //Create ServiceHost
            ServiceHost host = new ServiceHost(typeof(SDK.Service.Service), httpUrl);

            //Add a service endpoint
            host.AddServiceEndpoint(typeof(SDK.Service.IService), new WSHttpBinding(), "");

            //Enable metadata exchange
            ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smb);

            //Start the Service
            host.Open();
            Console.WriteLine("Service is host at " + DateTime.Now.ToString());
            Console.WriteLine("Host is running... Press  key to stop");
            Console.ReadLine();
        }
    }
}
