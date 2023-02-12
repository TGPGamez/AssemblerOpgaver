using VMTranslator.Templates;

namespace VMTranslator.ParsedCommands
{
    public class ConditionalLogicCommand : BaseVMCommand
    {
        private int uniqueId;
        private ConditionalCommandType conditionalLogicCommandType;

        public ConditionalLogicCommand(int uniqueId, ConditionalCommandType conditionalLogicCommandType)
        {
            this.uniqueId = uniqueId;
            this.conditionalLogicCommandType = conditionalLogicCommandType;
        }

        public override string ToAssembly()
        {
            switch (conditionalLogicCommandType)
            {
                case ConditionalCommandType.EQ:
                    return LogicalTemplates.EqualCommand(uniqueId);
                case ConditionalCommandType.GT:
                    return LogicalTemplates.GreaterThanCommand(uniqueId);
                case ConditionalCommandType.LT:
                    return LogicalTemplates.LessThanCommand(uniqueId);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}