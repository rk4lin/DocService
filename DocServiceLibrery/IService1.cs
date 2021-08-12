using DocServiceLibrery.ServiceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace DocServiceLibrary
{
    [ServiceContract]
    public interface IService1
    {
        /// <summary>
        /// Получить все документы
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json)]
        List<DocMember> GetDocuments();
    }


}
