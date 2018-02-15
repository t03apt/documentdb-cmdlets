using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using SharedProject1;

namespace NetCoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddUserSecrets<Program>()
                .Build();

            var authKey = config["AuthKey"];
            var result = DocumentDatabasesStore.GetDatabases("https://tpapp-cosmodb.documents.azure.com:443/", authKey);
            result.Wait();
            Console.WriteLine();
        }
    }
}
