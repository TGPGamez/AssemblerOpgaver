using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using VMTranslator.ParsedCommands;

namespace VMTranslator
{
    public class Translator
    {
        private readonly string prefix;
        public Translator(string prefix) 
        { 
            this.prefix = prefix;
        }

        public void ConvertToAssembly(StreamReader streamReader, StreamWriter streamWriter)
        {
            string? line;
            int index = 0;
            while (!streamReader.EndOfStream)
            {
                line = CodeManipulator.RemoveComments(streamReader.ReadLine());
                if (string.IsNullOrWhiteSpace(line)) continue;

                BaseVMCommand parsedCmd = line.ToParsedCommand(index, prefix);

                index++;
            }
        }
    }
}
