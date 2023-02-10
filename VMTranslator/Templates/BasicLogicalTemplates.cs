using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator.Templates
{
    public static class BasicLogicalTemplates
    {
        public static string Add()
        {
            return "+";
        }

        public static string Sub()
        {
            return "-";
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
            return "";
        }

        public static string Not()
        {
            return "";
        }
    }
}
