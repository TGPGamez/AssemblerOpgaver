using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator.Templates
{
    public static class LogicalTemplates
    {
        public static string Add()
        {
            return ArithmeticTemplate("+");
        }

        public static string Sub()
        {
            return ArithmeticTemplate("-");
        }

        public static string Neg()
        {
            return @"
@SP
A=M-1
M=-M";
        }

        public static string And()
        {
            return @"
@SP
M=M-1
A=M
D=M
@SP
A=M-1
M=D&M";
        }

        public static string Or()
        {
            return @"
@SP
M=M-1
A=M
D=M
@SP
A=M-1
M=D|M";
        }

        public static string Not()
        {
            return @"
@SP
A=M-1
M=!M";
        }



        public static string EqualCommand(int index)
        {
            return ConditionalTemplate("JEQ", "EQ", index);
        }

        public static string GreaterThanCommand(int index)
        {
            return ConditionalTemplate("JGT", "GT", index);
        }

        public static string LessThanCommand(int index)
        {
            return ConditionalTemplate("JLT", "LT", index);
        }

        public static string AddCommand()
        {
            return ArithmeticTemplate("+");
        }

        public static string SubCommand()
        {
            return ArithmeticTemplate("-");
        }




        private static string ArithmeticTemplate(string ariOperator)
        {
            return $@"
@SP
M=M-1
A=M
D=M
@SP
A=M-1
M=M{ariOperator}D";
        }


        private static string ConditionalTemplate(string jump, string prefix, int index)
        {
            return $@"
@SP
M=M-1
A=M
D=M

@SP
A=M-1
D=M-D

@{prefix}_TRUE_{index}
D;{jump}

@SP
A=M-1
M=0
@{prefix}_FALSE_{index}
0;JMP
({prefix}_TRUE_{index})
@SP
A=M-1
M=-1
({prefix}_FALSE_{index})
";
        }
    }
}
