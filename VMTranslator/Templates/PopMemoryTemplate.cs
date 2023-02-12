﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator.Templates
{
    public static class PopMemoryTemplate
    {

        private static string PopTemplate(string addressPrefix, string baseAddress, int memorySegmentAddress)
        {
            return $@"
@{memorySegmentAddress} //value=2
D=A
@{baseAddress}
D=D+M
@{addressPrefix}_ADDR
M=D
@SP
M=M-1
@SP
A=M 
D=M
@{addressPrefix}_ADDR
A=M
M=D";
        }

        public static string ToLocalAssembly(int memorySegmentAddress)
        {
            return PopTemplate("LOCAL", "LCL", memorySegmentAddress);
        }

        public static string ToArgumentAssembly(int memorySegmentAddress)
        {
            return PopTemplate("ARG", "ARG", memorySegmentAddress);
        }

        public static string ToThisAssembly(int memorySegmentAddress)
        {
            return PopTemplate("THIS", "THIS", memorySegmentAddress);
        }

        public static string ToThatAssembly(int memorySegmentAddress)
        {
            return PopTemplate("THAT", "THAT", memorySegmentAddress);
        }

        public static string ToTempAssembly(int memorySegmentAddress)
        {
            return $@"
@{memorySegmentAddress}
D=A
@5
D=D+A
@R13
M=D
@SP
M=M-1
A=M 
D=M
@R13
A=M
M=D";
        }

        public static string ToStaticAssembly(string staticPrefix, int memorySegmentAddress)
        {
            return $@"
@SP
M=M-1
@SP
A=M 
D=M
@{staticPrefix}.{memorySegmentAddress}
M=D
";
        }

        public static string ToPointerAssembly(int thisOrThat)
        {
            if (thisOrThat != 0 && thisOrThat != 1)
                throw new ArgumentException("Pointer memory segment can only accept 0/1" +
                                            "integer values");

            var address = thisOrThat == 0 ? "THIS" : "THAT";
            return $@"
@SP
M=M-1
A=M
D=M
@{address}
M=D
";
        }
    }
}
