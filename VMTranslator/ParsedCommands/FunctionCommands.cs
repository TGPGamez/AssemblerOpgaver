using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMTranslator.Templates;

namespace VMTranslator.ParsedCommands
{
    public class CallFunctionCommand : BaseVMCommand
    {
        private readonly string functionName;
        private readonly uint numberOfArgs;
        private readonly uint index;

        public CallFunctionCommand(string functionName, uint numberOfArgs, uint index)
        {
            this.functionName = functionName;
            this.numberOfArgs = numberOfArgs;
            this.index = index;
        }
        public override string ToAssembly()
        {
            return FunctionTemplates.CallToAssembly(this.functionName, this.numberOfArgs, this.index);
        }
    }

    public class FunctionFunctionCommand : BaseVMCommand
    {
        private readonly string functionName;
        private readonly uint numberOfLocalVars;
        private readonly uint index;

        public FunctionFunctionCommand(string functionName, uint numberOfLocalVars, uint index)
        {
            this.functionName = functionName;
            this.numberOfLocalVars = numberOfLocalVars;
            this.index = index;
        }
        public override string ToAssembly()
        {
            return FunctionTemplates.FunctionToAssembly(this.functionName, this.numberOfLocalVars, this.index);
        }
    }
    public class ReturnFunctionCommand : BaseVMCommand
    {
        public override string ToAssembly()
        {
            return FunctionTemplates.ReturnToAssembly();
        }
    }
}
