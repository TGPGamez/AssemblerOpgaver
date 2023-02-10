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
                    break;
                case BasicCommandsTypes.SUB:
                    break;
                case BasicCommandsTypes.NEG:
                    break;
                case BasicCommandsTypes.AND:
                    break;
                case BasicCommandsTypes.OR:
                    break;
                case BasicCommandsTypes.NOT:
                    break;
                default:
                    break;
            }
        }
    }
}