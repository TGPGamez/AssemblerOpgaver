using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblerOpgave
{
    public static class SymbolTableExtension
    {
        public static void GetLabelSymbols(this SymbolTable table, StreamReader streamReader, string commentString)
        {
            int memoryAddress = 0;
            string? line;
            while (!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine()?.Trim().Split(commentString)[0];
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith(commentString))
                {
                    continue;
                }

                if (line.StartsWith("(") && line.EndsWith(")"))
                {
                    // this is a label symbol, so the this isn't an instruction, so there is no memory address increment.
                    var symbolName = line.TrimStart('(').TrimEnd(')').Trim();
                    table.AddIfItDoesNotExist(symbolName, memoryAddress);
                }
                else
                {
                    memoryAddress++;
                }
            }
            streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
        }
    }
}
