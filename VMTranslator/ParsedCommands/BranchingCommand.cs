using VMTranslator.Templates;

namespace VMTranslator.ParsedCommands
{
    internal class BranchingCommand : BaseVMCommand
    {
        private string value;
        private BranchingCommandTypes branchingCommandType;

        public BranchingCommand(string value, BranchingCommandTypes branchingCommandType)
        {
            this.value = value;
            this.branchingCommandType = branchingCommandType;
        }

        public override string ToAssembly()
        {
            switch (branchingCommandType)
            {
                case BranchingCommandTypes.GOTO:
                    return BranchingTemplates.GoToToAssembly(value);
                case BranchingCommandTypes.IF_GOTO:
                    return BranchingTemplates.IfGoToToAssembly(value);
                case BranchingCommandTypes.LABEL:
                    return BranchingTemplates.LabelToAssembly(value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}