using Utils;



namespace VMTranslator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {
            Console.Clear();
            Console.Write("Path: ");
            string path = Console.ReadLine();
            string outputDirectory = Path.GetDirectoryName(path);
            if (outputDirectory == null)
            {
                Console.WriteLine("The input path must contain a directory");
            }
            string outputFilePath = Path.Combine(outputDirectory!,
                $"{Path.GetFileNameWithoutExtension(path)}.asm");

            try
            {
                HackVmTranslatorRunner runner = new HackVmTranslatorRunner(path, outputFilePath);
                string outputPath = runner.Run();
                Console.WriteLine($"Assembly successful, output file path: {outputPath}");
                Console.WriteLine("Click ESCAPE TO EXIT");
                Console.WriteLine();
                if (Console.ReadKey().Key != ConsoleKey.Escape) { Menu(); }
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occured...{e}");
            }

            //FileInfo fileInfo = new FileInfo(startPath + path);

            //string outputFilePath = fileInfo.DirectoryName + "/" + fileInfo.Name.Replace(fileInfo.Extension, "-out.asm");

            //try
            //{
            //    Runner runner = new Runner(startPath + path, outputFilePath);
            //    string outputPath = runner.Run();
            //    Console.WriteLine($"Assembly successful, output file path: {outputPath}");
            //    Console.WriteLine("Click ESCAPE TO EXIT");
            //    Console.WriteLine();
            //    if (Console.ReadKey().Key != ConsoleKey.Escape) { Menu(); }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine($"An unexpected error occured...{e}");
            //}
        }
    }
}