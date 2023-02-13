using Utils;
using VMTranslator;
using VMTranslator.Templates;

namespace VMTranslator
{
    public class FilesRunner
    {
        private string inputFilePath;
        private string outputFilePath;

        public FilesRunner(string inputFilePath, string outputFilePath)
        {
            this.inputFilePath = inputFilePath;
            this.outputFilePath = outputFilePath;
        }

        public string Run()
        {
            List<string> vmFilePaths = FileHandler.GetFilesForConversion(inputFilePath, outputFilePath, "vm");

            ChecksBeforeRunning(vmFilePaths);

            foreach (string vmFile in vmFilePaths)
            {
                Runner runner = new Runner(vmFile, outputFilePath);
                runner.Run();
            }

            return outputFilePath;
        }

        private void ChecksBeforeRunning(List<string> vmFilePaths)
        {
            bool isMultiFile = vmFilePaths.Count > 1;
            bool hasNeededMainAndSysFiles = vmFilePaths.Any(x =>
            {
                string fileName = Path.GetFileName(x);
                return fileName == "Sys.vm";
            });

            if (isMultiFile && !hasNeededMainAndSysFiles)
            {
                throw new ApplicationException("Cannot convert multiple .vm files without Sys.vm and Main.vm files");
            }

            if (isMultiFile)
            {
                WriteBootstrapCode(outputFilePath);
            }
        }

        /// <summary>
        /// Writes asm that calls Sys.init function and initializes the stack pointer
        /// </summary>
        /// <param name="outPath"></param>
        private void WriteBootstrapCode(string outPath)
        {
            using StreamWriter writer = new StreamWriter(outPath);
            string sysInitCall = FunctionTemplates.CallToAssembly("Sys.init", 0, 8853348);
            writer.Write($@"
@256
D=A
@0
M=D
{sysInitCall}
");
        }
    }
}