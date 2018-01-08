using System.IO;
using UnitTestTutorial.Helpers.Interfaces;

namespace UnitTestTutorial.Helpers
{
    public class FileHelper : IFileHelper
    {
        public void CopyFiles(string source, string destination)
        {
            var files = Directory.GetFiles(source);
            foreach (var file in files)
            {
                File.Copy(Path.Combine(source,Path.GetFileName(file)),destination);
            }
        }
    }
}