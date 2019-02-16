using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace Standup_Assistant
{
    partial class StandupAssistantService : ServiceBase
    {
        public StandupAssistantService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var repo = new Repository(ConfigurationManager.AppSettings["GitRepositoryDirectory"]);
            var branch = ConfigurationManager.AppSettings["Branch"];
        }

        protected override void OnStop()
        {
            // TODO: Add code here to perform any tear-down necessary to stop your service.
        }
    }
}
