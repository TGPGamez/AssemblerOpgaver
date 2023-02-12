using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator
{
    public enum BasicCommandsTypes
    {
        ADD,
        SUB,
        NEG,
        AND,
        OR,
        NOT,
    }

    public enum ConditionalCommandTypes
    {
        EQ,
        GT,
        LT
    }

    public enum MemoryAccessCommandTypes
    {
        PUSH,
        POP
    }

    public enum MemorySegments
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

    public enum BranchingCommandTypes
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
