namespace AssemblerOpgave
{
    internal class Program
    {
        private static string startPath = "C:\\Users\\grang\\OneDrive\\Skrivebord\\Nand2Tetris\\nand2tetris\\projects\\06\\";
        static void Main(string[] args)
        {
            Menu();
        }

        private static void Menu()
        {


            string path = String.Empty;
            bool fileChecks = false;
            do
            {
                Console.Clear();
                Console.Write("Path: ");
                path = Console.ReadLine();
                fileChecks = FileExistsAndIsASM(path);
            } while (fileChecks == false);

            FileInfo fileInfo = new FileInfo(startPath + path);

            string outputFilePath = fileInfo.DirectoryName + "/" + fileInfo.Name.Replace(fileInfo.Extension, "-out.hack");

            try
            {
                Runner runner = new Runner(startPath + path, outputFilePath);
                string outputPath = runner.Run();
                Console.WriteLine($"Assembly successful, output file path: {outputPath}");
                Console.WriteLine("Click ESCAPE TO EXIT");
                Console.WriteLine();
                if (Console.ReadKey().Key != ConsoleKey.Escape) { Menu(); }
            }
            catch (AssemblyException e)
            {
                Console.WriteLine($"An error occurred during assembly: {e} ");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An unexpected error occured...{e}");
            }
        }

        private static bool FileExistsAndIsASM(string? path)
        {
            string fullPath = startPath + path;
            FileInfo fileInfo = new FileInfo(fullPath);
            return fileInfo.Exists && fileInfo.Extension.Equals(".asm");
        }
    }
}