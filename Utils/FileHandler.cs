using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class FileHandler
    {
        public static bool FileExistsAndIsCorrectExtension(string path, string extension)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.Exists && fileInfo.Extension.Equals("." + extension);
        }

        public static void PrintFile(string path, List<string> lines) 
        {
            File.WriteAllLines(path, lines);
        }

        public static List<string> GetLinesInFile(string path)
        {
            return File.ReadAllLines(path).ToList();
        }
    }
}
