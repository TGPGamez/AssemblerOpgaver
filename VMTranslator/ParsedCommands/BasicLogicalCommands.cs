using VMTranslator.Templates;

namespace VMTranslator.ParsedCommands
{
    public class BasicLogicalCommands : BaseVMCommand
    {
        private BasicCommandsTypes logicalCommandType;

        public BasicLogicalCommands(BasicCommandsTypes logicalCommandType)
        {
            this.logicalCommandType = logicalCommandType;
        }

        public override string ToAssembly()
        {
            switch (logicalCommandType)
            {
                case BasicCommandsTypes.ADD:
                    return LogicalTemplates.Add();
                case BasicCommandsTypes.SUB:
                    return LogicalTemplates.Sub();
                case BasicCommandsTypes.NEG:
                    return LogicalTemplates.Neg();
                case BasicCommandsTypes.AND:
                    return LogicalTemplates.And();
                case BasicCommandsTypes.OR:
                    return LogicalTemplates.Or();
                case BasicCommandsTypes.NOT:
                    return LogicalTemplates.Not();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}