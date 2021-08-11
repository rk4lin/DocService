using DocServiceLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace DocClient
{
    class DocPresenter
    {
        public static List<DocMember> Request()
        {

            var serviceAddress = "http://localhost:8000/DocServiceLibrary";
            var serviceName = "DocService";

            Uri conUri = new Uri($"{serviceAddress}/{serviceName}");

            EndpointAddress address = new EndpointAddress(conUri);

            WSHttpBinding clientBindingHttp = new WSHttpBinding();

            ChannelFactory<IService1> factory = new ChannelFactory<IService1>(clientBindingHttp, address);

            var service = factory.CreateChannel();

            var res = service.GetDocuments();

            return res;
            
        }
        
    }
}
