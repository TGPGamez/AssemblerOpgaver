using VMTranslator.Templates;

namespace VMTranslator.ParsedCommands
{
    internal class BranchingCommand : BaseVMCommand
    {
        private string value;
        private BranchingCommandType branchingCommandType;

        public BranchingCommand(string value, BranchingCommandType branchingCommandType)
        {
            this.value = value;
            this.branchingCommandType = branchingCommandType;
        }

        public override string ToAssembly()
        {
            switch (branchingCommandType)
            {
                case BranchingCommandType.GOTO:
                    return BranchingTemplates.GoToToAssembly(value);
                case BranchingCommandType.IF_GOTO:
                    return BranchingTemplates.IfGoToToAssembly(value);
                case BranchingCommandType.LABEL:
                    return BranchingTemplates.LabelToAssembly(value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}