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
            string[] splitLine = line.Split(' ');

            BaseVMCommand? logicCommand = TryParseToLogicCommand(splitLine, uniqueId);
            if (logicCommand != null) { return logicCommand; }

            BaseVMCommand? memoryCommand = TryParseMemoryAccessCommand(splitLine, prefix);
            if (memoryCommand != null) { return memoryCommand; }

            BaseVMCommand? branchingCommand = TryParseBranchingCommand(splitLine);
            if (branchingCommand != null) { return branchingCommand; }

            BaseVMCommand? functionCommand = TryParseFunctionCommand(splitLine, uniqueId);
            if (functionCommand != null) { return functionCommand; }


            //if (TryParseToLogicCMD(lineSplit, uniqueId, out BaseVMCommand? parsedCommand)) { }
            //if (parsedCommand != null) { return parsedCommand; }

            //if (TryParseMemoryAccessCMD(lineSplit, prefix, out BaseVMCommand? memoryAccessCommand)) { }
            //if (memoryAccessCommand != null) { return memoryAccessCommand; }

            //if (TryParseBranchingCMD(lineSplit, out var branchingCommand)) { }
            //if (branchingCommand != null) return branchingCommand;

            //if (TryParseFunctionCMD(lineSplit, uniqueId, out var functionCommand)) { }
            //if (functionCommand != null) return functionCommand;

            throw new ArgumentException($"{line} is not a supported vm instruction.");
        }





        private static BaseVMCommand? TryParseToLogicCommand(string[] splitLine, int uniqueId)
        {
            string command = splitLine[0].ToUpper();
            if (Enum.TryParse(command, out BasicCommandsType logicalCommandType))
            {
                {
                    return new BasicLogicalCommands(logicalCommandType);
                }
            }
            else if (Enum.TryParse(command, out ConditionalCommandType conditionalLogicCommandType))
            {
                return new ConditionalLogicCommand(uniqueId, conditionalLogicCommandType);
            } else
            {
                return null;
            }
        }

        private static BaseVMCommand? TryParseMemoryAccessCommand(string[] splitLine, string prefix)
        {
            string memoryAccessCommandString = splitLine[0].ToUpper();
            if (Enum.TryParse(memoryAccessCommandString, out MemoryAccessCommandType memoryAccessCommandsTypes))
            {
                var memorySegment = Enum.Parse<MemorySegment>(splitLine[1].ToUpper());
                var value = int.Parse(splitLine[2]);
                {
                    return new MemoryAccessCommand(value, prefix, memoryAccessCommandsTypes, memorySegment);
                }
            }

            return null;
        }

        private static BaseVMCommand? TryParseBranchingCommand(string[] lineSplit)
        {
            if (Enum.TryParse(lineSplit[0].ToUpper().Replace("-", "_"),
                    out BranchingCommandType branchingCommandType))
            {
                return new BranchingCommand(lineSplit[1], branchingCommandType);
            }
            return null;
        }

        private static BaseVMCommand? TryParseFunctionCommand(string[] lineSplit, int uniqueCommandIndentifer)
        {
            if (Enum.TryParse(lineSplit[0].ToUpper().Replace("-", "_"),
                    out FunctionCommandTypes functionCommandTypes))
            {
                switch (functionCommandTypes)
                {
                    case FunctionCommandTypes.CALL:
                        return new CallFunctionCommand(lineSplit[1], uint.Parse(lineSplit[2]), (uint)uniqueCommandIndentifer);
                    case FunctionCommandTypes.FUNCTION:
                        return new FunctionFunctionCommand(lineSplit[1], uint.Parse(lineSplit[2]), (uint)uniqueCommandIndentifer);
                    case FunctionCommandTypes.RETURN:
                        return new ReturnFunctionCommand();
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            return null;
        }

        //private static bool TryParseToLogicCMD(string[] splitLine, int uniqueId, out BaseVMCommand? parsedCommand)
        //{
        //    string command = splitLine[0].ToUpper();
        //    if (Enum.TryParse(command, out BasicCommandsType logicalCommandType))
        //    {
        //        {
        //            parsedCommand = new BasicLogicalCommands(logicalCommandType);
        //            return true;
        //        }
        //    }

        //    if (Enum.TryParse(command, out ConditionalCommandType conditionalLogicCommandType))
        //    {
        //        {
        //            parsedCommand = new ConditionalLogicCommand(uniqueId, conditionalLogicCommandType);
        //            return true;
        //        }
        //    }

        //    parsedCommand = null;
        //    return false;
        //}

        //private static bool TryParseMemoryAccessCMD(string[] splitLine, string prefix, out BaseVMCommand? memoryAccessCommand)
        //{
        //    string memoryAccessCommandString = splitLine[0].ToUpper();
        //    if (Enum.TryParse(memoryAccessCommandString, out MemoryAccessCommandType memoryAccessCommandsTypes))
        //    {
        //        var memorySegment = Enum.Parse<MemorySegment>(splitLine[1].ToUpper());
        //        var value = int.Parse(splitLine[2]);
        //        {
        //            memoryAccessCommand = new MemoryAccessCommand(value, prefix, memoryAccessCommandsTypes, memorySegment);
        //            return true;
        //        }
        //    }

        //    memoryAccessCommand = null;
        //    return false;
        //}


        //private static bool TryParseBranchingCMD(string[] lineSplit, out BaseVMCommand? branchingCommand)
        //{
        //    if (Enum.TryParse(lineSplit[0].ToUpper().Replace("-", "_"),
        //            out BranchingCommandType branchingCommandType))
        //    {
        //        branchingCommand = new BranchingCommand(lineSplit[1], branchingCommandType);
        //        return true;
        //    }
        //    branchingCommand = null;
        //    return false;
        //}

        //private static bool TryParseFunctionCMD(string[] lineSplit, int uniqueCommandIndentifer,
        //out BaseVMCommand? functionCommand)
        //{
        //    if (Enum.TryParse(lineSplit[0].ToUpper().Replace("-", "_"),
        //            out FunctionCommandTypes functionCommandTypes))
        //    {
        //        switch (functionCommandTypes)
        //        {
        //            case FunctionCommandTypes.CALL:
        //                functionCommand = new CallFunctionCommand(lineSplit[1], uint.Parse(lineSplit[2]), (uint)uniqueCommandIndentifer);
        //                break;
        //            case FunctionCommandTypes.FUNCTION:
        //                functionCommand = new FunctionFunctionCommand(lineSplit[1], uint.Parse(lineSplit[2]), (uint)uniqueCommandIndentifer);
        //                break;
        //            case FunctionCommandTypes.RETURN:
        //                functionCommand = new ReturnFunctionCommand();
        //                break;
        //            default:
        //                throw new ArgumentOutOfRangeException();
        //        }
        //        return true;
        //    }
        //    functionCommand = null;
        //    return false;
        //}
    }
}
