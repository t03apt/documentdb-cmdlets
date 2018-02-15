using System.Management.Automation;  // PowerShell namespace.

namespace SendGreeting
{
    // Declare the class as a cmdlet and specify and
    // appropriate verb and noun for the cmdlet name.
    [Cmdlet(VerbsCommunications.Send, "Greeting")]
    public class SendGreetingCommand : Cmdlet
    {
        // Declare the parameters for the cmdlet.
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        // Overide the ProcessRecord method to process
        // the supplied user name and write out a
        // greeting to the user by calling the WriteObject
        // method.
        protected override void ProcessRecord()
        {
            WriteObject("Hello " + Name + "!");
        }
    }
}