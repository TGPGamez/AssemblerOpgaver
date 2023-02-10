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
        POP,
        PUSH
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
}
