using LibGit2Sharp;
using Standup_Assistant.Functionality;
using System.Configuration;
using System.IO;
using System.ServiceProcess;

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
            var branch = ConfigurationManager.AppSettings["Branch"];
            var file = ConfigurationManager.AppSettings["StandupNotesFile"];
            var repo = new Repository(ConfigurationManager.AppSettings["GitRepositoryDirectory"]);

            // Delete yesterday's notes.
            File.Delete(file);

            var commits = GitFunctionality.GetFilteredCommitLog(repo, branch);

            FileFunctionality.CreateNotesFile(file, FileFunctionality.CreateNotesContent(repo, commits));
        }

        protected override void OnStop()
        {
        }
    }
}
