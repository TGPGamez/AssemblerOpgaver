using VMTranslator.Templates;

namespace VMTranslator.ParsedCommands
{
    public class BasicLogicalCommands : BaseVMCommand
    {
        private BasicCommandsType logicalCommandType;

        public BasicLogicalCommands(BasicCommandsType logicalCommandType)
        {
            this.logicalCommandType = logicalCommandType;
        }

        public override string ToAssembly()
        {
            switch (logicalCommandType)
            {
                case BasicCommandsType.ADD:
                    return LogicalTemplates.Add();
                case BasicCommandsType.SUB:
                    return LogicalTemplates.Sub();
                case BasicCommandsType.NEG:
                    return LogicalTemplates.Neg();
                case BasicCommandsType.AND:
                    return LogicalTemplates.And();
                case BasicCommandsType.OR:
                    return LogicalTemplates.Or();
                case BasicCommandsType.NOT:
                    return LogicalTemplates.Not();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}