using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnitTestTutorial.Helpers;
using UnitTestTutorial.Helpers.Interfaces;

namespace UnitTestTutorial.Test.Helpers
{
    [TestFixture]
    public class FileHelperTests
    {
        private IFileHelper _sut;

        private string _path;

        private string _sourceFolder;

        private string _destinationFolder;

        private string _testFolder;

        [SetUp]
        public void SetUp()
        {
            _sut = new FileHelper();
            _path = AppDomain.CurrentDomain.BaseDirectory;
            _testFolder = "test";
            _sourceFolder = "source";
            _destinationFolder = "destination";

            Directory.CreateDirectory(Path.Combine(_path,_testFolder));
            Directory.CreateDirectory(Path.Combine(_path,_testFolder,_sourceFolder));
            Directory.CreateDirectory(Path.Combine(_path,_testFolder,_destinationFolder));
        }

        [Test]
        public void CopyFiles_Should_Copy_Files_Between_Two_Directories()
        {
            using(FileStream stream = File.Create(Path.Combine(_path,_testFolder,_sourceFolder,"file.txt"))){};

            _sut.CopyFiles(Path.Combine(_path,_testFolder,_sourceFolder),Path.Combine(_path,_testFolder,_destinationFolder));

            Assert.IsTrue(Directory.GetFiles(Path.Combine(_path,_testFolder,_destinationFolder)).Any());
        }

        [TearDown]
        public void TearDown()
        {
            Directory.Delete(Path.Combine(_path,_testFolder),true);
        }
    }
}