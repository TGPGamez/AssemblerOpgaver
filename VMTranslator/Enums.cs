using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public enum BasicCommandsType
    {
        ADD,
        SUB,
        NEG,
        AND,
        OR,
        NOT,
    }

    public enum ConditionalCommandType
    {
        EQ,
        GT,
        LT
    }

    public enum MemoryAccessCommandType
    {
        PUSH,
        POP
    }

    public enum MemorySegment
    {
        LOCAL,
        ARGUMENT,
        THIS,
        THAT,
        CONSTANT,
        STATIC,
        POINTER,
        TEMP
    }

    public enum BranchingCommandType
    {
        GOTO,
        IF_GOTO,
        LABEL
    }

    public enum FunctionCommandTypes
    {
        CALL,
        FUNCTION,
        RETURN
    }
}
