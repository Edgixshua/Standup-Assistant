using System;
using System.Collections.Generic;
using System.IO;
using LibGit2Sharp;
using Validation;

namespace Standup_Assistant.Functionality
{
    public static class FileFunctionality
    {
        public static void CreateNotesFile(string notesFile, IEnumerable<string> contents)
        {
            Requires.NotNull(notesFile, nameof(notesFile));
            Requires.NotNull(contents, nameof(contents));

            File.WriteAllLines(notesFile, contents);
        }

        public static IEnumerable<string> CreateNotesContent(Repository repo, IEnumerable<Commit> commits)
        {
            var contents = new List<string>();

            contents.Add("Commits retrieved from " + repo.Info.Path + Environment.NewLine);

            foreach (var commit in commits)
            {
                contents.Add(commit.Message + Environment.NewLine);
            }

            return contents;
        }
    }
}
