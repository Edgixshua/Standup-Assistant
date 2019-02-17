using System;
using LibGit2Sharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Standup_Assistant.Functionality;

namespace Standup_AssistantTests
{
    [TestClass]
    public class GitFunctionalityTests
    {
        [TestMethod]
        public void GettingFilteredCommitLog_WithNullBranch_ThrowsArgumentNullException()
        {
            // Arrange 
            string branch = null;
            var repo = new Repository();

            // Act
            void GetCommitLog() => GitFunctionality.GetFilteredCommitLog(repo, branch);

            // Assert
            Assert.ThrowsException<ArgumentNullException>((Action)GetCommitLog);
        }
    }
}
