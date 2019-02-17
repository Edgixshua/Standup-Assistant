using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Standup_Assistant.Functionality;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Standup_AssistantTests
{
    [TestClass]
    public class FileFunctionalityTests
    {
        [TestMethod]
        public void CreatingNotesFile_WithNullNotesFile_ThrowsArgumentNullException()
        {
            // Arrange
            string notesFile = null;
            var contents = new Mock<IEnumerable<string>>();

            // Act
            void CreateNotesFile() => FileFunctionality.CreateNotesFile(notesFile, contents.Object);

            // Assert
            Assert.ThrowsException<ArgumentNullException>((Action)CreateNotesFile);
        }

        [TestMethod]
        public void CreatingNotesFile_WithNullContents_ThrowsArgumentNullException()
        {
            // Arrange
            IEnumerable<string> contents = null;
            string notesFile = "test";

            // Act
            void CreateNotesFile() => FileFunctionality.CreateNotesFile(notesFile, contents);

            // Assert
            Assert.ThrowsException<ArgumentNullException>((Action)CreateNotesFile);
        }
    }
}
