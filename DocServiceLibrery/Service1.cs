using DocServiceLibrery.DAL;
using DocServiceLibrery.ServiceModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DocServiceLibrary
{

    public class Service1 : IService1
    {
        private List<DocMember> documents = new List<DocMember>();

        public List<DocMember> GetDocuments()
        {
            //   using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-KLV0IMD\\SQLEXPRESS;Initial Catalog=documents;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")) 
           // using (var con = new SqlConnection(connection_string))

            {
                var con = DBConnect.Connecting();

                SqlCommand command = new SqlCommand("select number_document, date_document, last_update_document from documents", con);

                using (var result = command.ExecuteReader())
                {
                    var number = result.GetOrdinal("number_document");
                    var dateDocument = result.GetOrdinal("date_document");
                    var lastUpdateDocument = result.GetOrdinal("last_update_document");

                    while (result.Read())
                    {
                        var document = new DocMember();
                        document.docNumber = result.GetInt32(number);
                        document.dateCreateDocument = result.GetDateTime(dateDocument);
                        document.lastUpdateDate = result.GetDateTime(lastUpdateDocument);

                        documents.Add(document);

                    }

                }
                return documents;
            }
        }
        
    }
 }

