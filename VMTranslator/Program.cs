using System.Diagnostics;
using System.IO;
using Utils;



namespace VMTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InputMenu();
        }



        private static void InputMenu()
        {
            string path = "";
            do
            {
                Console.Clear();
                Console.Write("Path: ");
                path = Console.ReadLine().Replace("/", "\\");
            } while (string.IsNullOrEmpty(path) ||string.IsNullOrWhiteSpace(path));
            string outputFile = TransformToOutputFile(path);
            Run(path, outputFile);

            //Console.WriteLine("Input path: ");
            //Console.WriteLine(" - " + path);

            //Console.WriteLine();
            //Console.WriteLine("Output path:");
            //Console.WriteLine(" - " + outputFile);
        }

        private static void Run(string inputPath, string outputPath)
        {
            try
            {
                FilesRunner runner = new FilesRunner(inputPath, outputPath);
                string output = runner.Run();
                Console.WriteLine($"Assembly successful, output file path: {output}");
                Console.WriteLine("Click ESCAPE TO EXIT");
                Console.WriteLine();
                Process.Start("explorer.exe", Path.GetDirectoryName(outputPath));
                if (Console.ReadKey().Key != ConsoleKey.Escape) { InputMenu(); }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occured...{e}");
            }
        }

        private static string TransformToOutputFile(string path)
        {
            string fileName = Path.GetFileNameWithoutExtension(path) + ".asm";
            string directory = Path.GetDirectoryName(path);
            
            if (directory != null)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                if (fileName != ".asm")
                {
                    return directoryInfo.FullName + "\\" + fileName;
                }
                else
                {
                    return directoryInfo.FullName + "\\" + directoryInfo.Name + ".asm";
                }
            }
            return fileName == null ? "UnknownFileName.asm" : fileName;
        }

        //private static void Menu()
        //{
        //    Console.Clear();
        //    Console.Write("Path: ");
        //    string path = Console.ReadLine();
        //    string outputDirectory = Path.GetDirectoryName(path);
        //    if (outputDirectory == null)
        //    {
        //        Console.WriteLine("The input path must contain a directory");
        //    }
        //    string outputFilePath = Path.Combine(outputDirectory!,
        //        $"{Path.GetFileNameWithoutExtension(path)}.asm");

        //    try
        //    {
        //        TranslatorRunner runner = new TranslatorRunner(path, outputFilePath);
        //        string outputPath = runner.Run();
        //        Console.WriteLine($"Assembly successful, output file path: {outputPath}");
        //        Console.WriteLine("Click ESCAPE TO EXIT");
        //        Console.WriteLine();
        //        if (Console.ReadKey().Key != ConsoleKey.Escape) { Menu(); }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"An unexpected error occured...{e}");
        //    }

        //    FileInfo fileInfo = new FileInfo(startPath + path);

        //    string outputFilePath = fileInfo.DirectoryName + "/" + fileInfo.Name.Replace(fileInfo.Extension, "-out.asm");

        //    try
        //    {
        //        Runner runner = new Runner(startPath + path, outputFilePath);
        //        string outputPath = runner.Run();
        //        Console.WriteLine($"Assembly successful, output file path: {outputPath}");
        //        Console.WriteLine("Click ESCAPE TO EXIT");
        //        Console.WriteLine();
        //        if (Console.ReadKey().Key != ConsoleKey.Escape) { Menu(); }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine($"An unexpected error occured...{e}");
        //    }
        //}
    }
}