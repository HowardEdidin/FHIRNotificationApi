using System;
using System.Configuration;
using Microsoft.Azure.Documents.Client;

namespace FhirNotificationApi
{
    /// <summary>
    ///
    /// </summary>
    public class DocumentDbContext
    {
        private DocumentClient _client;

        /// <summary>
        ///  EndPoint
        /// </summary>
        public static string EndPoint = ConfigurationManager.AppSettings["EndPoint"];

        /// <summary>
        /// AuthKey
        /// </summary>
        public static string AuthKey = ConfigurationManager.AppSettings["AuthKey"];






        /// <summary>
        /// Create the connection
        /// </summary>
        public DocumentClient Client
        {
            get
            {
                if (_client != null) return _client;
                var endpointUri = new Uri(EndPoint);
                _client = new DocumentClient(endpointUri, AuthKey, new ConnectionPolicy
                {
                    ConnectionMode = ConnectionMode.Direct,
                    ConnectionProtocol = Protocol.Tcp

                });

                return _client;
            }
        }


    }
}