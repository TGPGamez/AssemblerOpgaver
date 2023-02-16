using System.Diagnostics;

namespace JackToHack
{
    internal class Progra
    {
        static string filePath = @"C:/Users/grang/OneDrive/Skrivebord/Nand2Tetris/nand2tetris/projects/09/Average/Main.jack";
        static string compilerPath = @"C:/Users/grang/OneDrive/Skrivebord/Nand2Tetris/nand2tetris/tools/JackCompiler.bat";

        static void Main(string[] args)
        {
            ProcessStartInfo psi = new ProcessStartInfo
            {
                WorkingDirectory = @"C:\Windows\System32",
                FileName = "cmd.exe",
                Arguments = "/C " + compilerPath + " " + filePath,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardInput = true,
            };
            Process process = Process.Start(psi);
            process.Close();
        }

        // .jack -> .vm -> .asm
    }
}