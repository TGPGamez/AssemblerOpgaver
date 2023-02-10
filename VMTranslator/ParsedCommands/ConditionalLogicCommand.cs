namespace VMTranslator.ParsedCommands
{
    public class ConditionalLogicCommand : BaseVMCommand
    {
        private object uniqueId;
        private ConditionalCommandTypes conditionalLogicCommandType;

        public ConditionalLogicCommand(int uniqueId, ConditionalCommandTypes conditionalLogicCommandType)
        {
            this.uniqueId = uniqueId;
            this.conditionalLogicCommandType = conditionalLogicCommandType;
        }

        public override string ToAssembly()
        {
            throw new NotImplementedException();
        }
    }
}