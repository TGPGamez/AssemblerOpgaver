using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblerOpgave
{
    public class Runner
    {
        private readonly string _assemblyFilePath;
        private readonly string _outPath;
        public Runner(string assemblyFilePath, string outputFilePath)
        {
            _assemblyFilePath = assemblyFilePath;
            _outPath = outputFilePath;
        }

        public string Run()
        {
            using FileStream reader = File.OpenRead(_assemblyFilePath);
            using StreamWriter writer = new StreamWriter(_outPath, false);
            Assembler assembler = new Assembler();
            assembler.ConvertToMachineCode(new StreamReader(reader), writer);
            return _outPath;
        }
    }
}
