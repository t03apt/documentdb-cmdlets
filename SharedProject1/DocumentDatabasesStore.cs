using System;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace SharedProject1
{
    class DocumentDatabasesStore
    {
        public static Task<FeedResponse<Database>> GetDatabases(string serviceUrl, string authKey)
        {
            DocumentClient client = new DocumentClient(new Uri(serviceUrl), authKey);
            var result = client.ReadDatabaseFeedAsync();
            return result;
        }
    }
}
