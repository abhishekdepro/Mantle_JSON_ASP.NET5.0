using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.Storage;
using IronPython.Hosting;
using IronPython.Runtime;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using System.IO;

namespace WorkerRoleFetch
{
    public class WorkerRole : RoleEntryPoint
    {
        private ScriptEngine pyEngine = null;
        private ScriptRuntime pyRuntime = null;
        private ScriptScope pyScope = null;
        private SimpleLogger _logger = new SimpleLogger();
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.TraceInformation("WorkerRoleFetch entry point called", "Information");

            
            while (true)
            {
                //Thread.Sleep(10000);

                pyEngine = Python.CreateEngine();
                    string dir = Path.GetDirectoryName(@"C:\Users\Abhishek De\Documents\GitHub\AzureWorkerRole\AzureTableStore.py");
                ICollection<string> paths = pyEngine.GetSearchPaths();

                if (!String.IsNullOrWhiteSpace(dir))
                {
                    paths.Add(dir);
                }
                else
                {
                    paths.Add(Environment.CurrentDirectory);
                }
                pyEngine.SetSearchPaths(paths);
        
                ScriptSource source = pyEngine.CreateScriptSourceFromFile(@"C:\Users\Abhishek De\Documents\GitHub\AzureWorkerRole\AzureTableStore.py");
                CompiledCode compile = source.Compile();
                compile.Execute();
                Trace.TraceInformation("Working", "Information");
            }
        }

        
        

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = 12;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }
    }
}
