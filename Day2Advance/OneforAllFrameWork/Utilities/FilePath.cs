using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoreFramework.Utilities
{
    internal class FilePath
    {
        public static void CreateFolder(string path) { Directory.CreateDirectory(path); }
        public static void DeleteFolder(string path) { Directory.Delete(path); }
        public static void CreateFile(string path) { File.Create(path); }
        public static void DeleteFile(string path) { File.Delete(path); }
        public static string GetCurrentDirectodyPath()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\..\\..\\..";
            TestContext.Progress.WriteLine(path);
            return path;
        }
        public static void CreateIfNotExists(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

    }
}
