using System;
using System.Collections.Generic;
using System.Management.Automation;
using System.Reflection;
using Newtonsoft.Json;

namespace SharedProject1
{
    [Cmdlet(VerbsCommon.Get, "DocumentDatabases")]
    public class GetDocumentDatabasesCmdlet : Cmdlet
    {
        static GetDocumentDatabasesCmdlet()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }

        [Parameter(Mandatory = true)]
        public string ServiceUrl { get; set; }

        [Parameter(Mandatory = true)]
        public string AuthKey { get; set; }

        protected override void ProcessRecord()
        {
            try
            {
                var result = DocumentDatabasesStore.GetDatabases(ServiceUrl, AuthKey);

                WriteObject(result);
            }
            catch (Exception ex)
            {
                WriteObject(ex);
            }
        }

        private static readonly IDictionary<string, Assembly> AssemblyBindingRedirects = new Dictionary<string, Assembly>
        {
            { "Newtonsoft.Json, Version=6.0.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed", typeof(JsonConvert).Assembly }
        };

        private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return AssemblyBindingRedirects.TryGetValue(args.Name, out var assembly) ? assembly : null;
        }
    }
}