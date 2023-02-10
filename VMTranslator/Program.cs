using Utils;

namespace VMTranslator
{
    internal class Program
    {
        private static string startPath = "C:\\Users\\grang\\OneDrive\\Skrivebord\\Nand2Tetris\\nand2tetris\\projects\\07\\MemoryAccess\\BasicTest\\";
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
                Console.Write("Path: " + startPath);
                path = Console.ReadLine();
                fileChecks = FileHandler.FileExistsAndIsCorrectExtension(startPath + path, "vm");
            } while (fileChecks == false);

            List<string> lines = FileHandler.GetLinesInFile(startPath + path);
            List<string> cleanLines = lines.Select(CodeManipulator.RemoveComments)
                .Where(line => line.Length != 0).ToList();



            Console.ReadKey();
        }
        //https://github.com/CallumHoughton18/nand2tetris-in-dotnet/tree/377dbafd58823d07f59794fb2e46bbd15ea3e2e2/HackVMTranslator.Core
    }
}