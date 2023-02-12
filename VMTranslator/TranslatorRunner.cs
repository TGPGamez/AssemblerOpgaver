using VMTranslator;
using VMTranslator.Templates;

internal class TranslatorRunner
{
    private string inputFilePath;
    private string outputFilePath;

    public TranslatorRunner(string inputFilePath, string outputFilePath)
    {
        this.inputFilePath = inputFilePath;
        this.outputFilePath = outputFilePath;
    }

    public string Run()
    {
        List<string> vmFilePaths = GetVmFilesForConversion();
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

        foreach (string vmFile in vmFilePaths)
        {
            Runner runner = new Runner(vmFile, outputFilePath);
            runner.Run();
        }

        return outputFilePath;
    }

    private List<string> GetVmFilesForConversion()
    {
        List<string> vmFilePaths = new List<string>();
        if (File.Exists(outputFilePath)) File.Delete(outputFilePath);

        if (Directory.Exists(inputFilePath))
        {
            vmFilePaths = Directory.GetFiles(inputFilePath, "*.vm").ToList();
        }
        else if (File.Exists(inputFilePath))
        {
            vmFilePaths.Add(inputFilePath);
        }

        return vmFilePaths;
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