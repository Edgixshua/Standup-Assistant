using System;
using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace Standup_Assistant.Functionality
{
    public static class GitFunctionality
    {
        public static IEnumerable<Commit> GetFilteredCommitLog(Repository repo, string branch)
        {
            var dateSince = new DateTimeOffset(DateTime.Now.AddDays(-1));
            var dateUntil = new DateTimeOffset(DateTime.Now);

            var filter = new CommitFilter
            {
                SortBy = CommitSortStrategies.Reverse | CommitSortStrategies.Time,
                ExcludeReachableFrom = repo.Branches[branch].Tip,
                IncludeReachableFrom = repo.Head.Tip
            };

            var results = repo.Commits.QueryBy(filter);

            // Filter commit log to only return commits since yesterday.
            var filteredLog = results.Where(commit => commit.Committer.When > dateSince && commit.Committer.When < dateUntil);

            return filteredLog;
        }
    }
}
