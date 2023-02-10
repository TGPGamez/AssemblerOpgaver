using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VMTranslator.ParsedCommands
{
    public static class Parser
    {
        public static BaseVMCommand ToParsedCommand(this string line, int uniqueId, string prefix)
        {
            string[] split = line.Split(' ');

            if (TryParseToLogicCMD(split, uniqueId, out BaseVMCommand? parsedCommand)) { }
            if (parsedCommand != null) { return parsedCommand; }

            if (TryParseMemoryAccessCMD(split, prefix, out BaseVMCommand? memoryAccessCommand)) { }
            if (memoryAccessCommand != null) { return memoryAccessCommand; }

            throw new ArgumentException("Unsupported vm instruction.");
        }




        private static bool TryParseToLogicCMD(string[] splitLine, int uniqueId, out BaseVMCommand? parsedCommand)
        {
            string command = splitLine[0].ToUpper();
            if (Enum.TryParse(command, out BasicCommandsTypes logicalCommandType))
            {
                {
                    parsedCommand = new BasicLogicalCommands(logicalCommandType);
                    return true;
                }
            }

            if (Enum.TryParse(command, out ConditionalCommandTypes conditionalLogicCommandType))
            {
                {
                    parsedCommand = new ConditionalLogicCommand(uniqueId, conditionalLogicCommandType);
                    return true;
                }
            }

            parsedCommand = null;
            return false;
        }

        private static bool TryParseMemoryAccessCMD(string[] splitLine, string prefix, out BaseVMCommand? memoryAccessCommand)
        {
            string memoryAccessCommandString = splitLine[0].ToUpper();
            if (Enum.TryParse(memoryAccessCommandString, out MemoryAccessCommandTypes memoryAccessCommandsTypes))
            {
                var memorySegment = Enum.Parse<MemorySegments>(splitLine[1].ToUpper());
                var value = int.Parse(splitLine[2]);
                {
                    memoryAccessCommand = new MemoryAccessCommand(value, prefix, memoryAccessCommandsTypes, memorySegment);
                    return true;
                }
            }

            memoryAccessCommand = null;
            return false;
        }

        
    }
}
