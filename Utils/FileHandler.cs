using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public class FileHandler
    {
        public static bool FileExists(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo.Exists;
        }

        public static void PrintFile(string path, List<string> lines) 
        {
            File.WriteAllLines(path, lines);
        }

        public static List<string> GetLinesInFile(string path)
        {
            return File.ReadAllLines(path).ToList();
        }

        /// <summary>
        /// Gets all files with a certain "type" (extension) from a directory
        /// Also deletes the output path file if it exists
        /// </summary>
        /// <param name="inputFilePath">Input path</param>
        /// <param name="outputFilePath">Output path</param>
        /// <param name="type">Type of file (extension)</param>
        /// <returns></returns>
        public static List<string> GetFilesForConversion(string inputFilePath, string outputFilePath, string type)
        {
            List<string> vmFilePaths = new List<string>();
            if (File.Exists(outputFilePath)) File.Delete(outputFilePath);

            if (Directory.Exists(inputFilePath))
            {
                vmFilePaths = Directory.GetFiles(inputFilePath, $"*.{type}").ToList();
            }
            else if (File.Exists(inputFilePath))
            {
                vmFilePaths.Add(inputFilePath);
            }

            return vmFilePaths;
        }
    }
}
