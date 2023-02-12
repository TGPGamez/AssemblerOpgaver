using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VMTranslator.Templates
{
    public static class BranchingTemplates
    {
        public static string LabelToAssembly(string labelName)
        {
            return $@"
({labelName})
";
        }

        public static string GoToToAssembly(string labelName)
        {
            return $@"
@{labelName}
0;JMP
";
        }

        public static string IfGoToToAssembly(string labelName)
        {
            return $@"
@SP
M=M-1
A=M
D=M
@{labelName}
D;JNE
";
        }
    }
}
