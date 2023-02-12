using VMTranslator.Templates;

namespace VMTranslator.ParsedCommands
{
    public class ConditionalLogicCommand : BaseVMCommand
    {
        private int uniqueId;
        private ConditionalCommandTypes conditionalLogicCommandType;

        public ConditionalLogicCommand(int uniqueId, ConditionalCommandTypes conditionalLogicCommandType)
        {
            this.uniqueId = uniqueId;
            this.conditionalLogicCommandType = conditionalLogicCommandType;
        }

        public override string ToAssembly()
        {
            switch (conditionalLogicCommandType)
            {
                case ConditionalCommandTypes.EQ:
                    return LogicalTemplates.EqualCommand(uniqueId);
                case ConditionalCommandTypes.GT:
                    return LogicalTemplates.GreaterThanCommand(uniqueId);
                case ConditionalCommandTypes.LT:
                    return LogicalTemplates.LessThanCommand(uniqueId);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}