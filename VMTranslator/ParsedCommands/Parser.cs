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

            if (TryParseBranchingCMD(split, out var branchingCommand)) { }
            if (branchingCommand != null) return branchingCommand;

            if (TryParseFunctionCMD(split, uniqueId, out var functionCommand)) { }
            if (functionCommand != null) return functionCommand;

            throw new ArgumentException($"{line} is not a supported vm instruction.");
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


        private static bool TryParseBranchingCMD(string[] lineSplit, out BaseVMCommand? branchingCommand)
        {
            if (Enum.TryParse(lineSplit[0].ToUpper().Replace("-", "_"),
                    out BranchingCommandTypes branchingCommandType))
            {
                branchingCommand = new BranchingCommand(lineSplit[1], branchingCommandType);
                return true;
            }
            branchingCommand = null;
            return false;
        }

        private static bool TryParseFunctionCMD(string[] lineSplit, int uniqueCommandIndentifer,
        out BaseVMCommand? functionCommand)
        {
            if (Enum.TryParse(lineSplit[0].ToUpper().Replace("-", "_"),
                    out FunctionCommandTypes functionCommandTypes))
            {
                switch (functionCommandTypes)
                {
                    case FunctionCommandTypes.CALL:
                        functionCommand = new CallFunctionCommand(lineSplit[1], uint.Parse(lineSplit[2]), (uint)uniqueCommandIndentifer);
                        break;
                    case FunctionCommandTypes.FUNCTION:
                        functionCommand = new FunctionFunctionCommand(lineSplit[1], uint.Parse(lineSplit[2]), (uint)uniqueCommandIndentifer);
                        break;
                    case FunctionCommandTypes.RETURN:
                        functionCommand = new ReturnFunctionCommand();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                return true;
            }
            functionCommand = null;
            return false;
        }
    }
}
