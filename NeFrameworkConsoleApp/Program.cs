using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using SharedProject1;

namespace NeFrameworkConsoleApp
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
            var result = DocumentDatabasesStore.GetDatabases(DocumentDatabasesStore.DefaultServiceUrl, authKey);
            result.Wait();
            Console.WriteLine(string.Join(", ", result.Result.Select(o => o.Id)));
        }
    }
}
