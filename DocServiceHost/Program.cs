using DocServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace DocServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8000/DocServiceLibrary");
            string address = "http://localhost:8000/DocServiceLibrary/DocService";

            ServiceHost selfHost = new ServiceHost(typeof(Service1), baseAddress);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IService1), new WSHttpBinding(), address);

                ServiceMetadataBehavior mb = new ServiceMetadataBehavior();

                mb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(mb);

                selfHost.Open();
                Console.WriteLine("The service is redy");

                Console.WriteLine("Press <Enter> to terminate the service.");
                Console.ReadLine(); 
                selfHost.Close();

            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
