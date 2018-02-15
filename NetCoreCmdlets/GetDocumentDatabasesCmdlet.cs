using System;
using System.Management.Automation;
using Microsoft.Azure.Documents.Client;

namespace SendGreeting
{
    [Cmdlet(VerbsCommon.Get, "DocumentDatabases")]
    public class GetDocumentDatabasesCmdlet : Cmdlet
    {
        [Parameter(Mandatory = true)]
        public string ServiceUrl { get; set; }

        [Parameter(Mandatory = true)]
        public string AuthKey { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                DocumentClient client = new DocumentClient(new Uri(ServiceUrl), AuthKey);
                var result = client.ReadDatabaseFeedAsync();

                WriteObject(result);
            }
            catch (Exception ex)
            {
                WriteObject(ex);
            }
        }
    }
}