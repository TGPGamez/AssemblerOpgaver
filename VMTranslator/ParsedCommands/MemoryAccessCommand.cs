namespace VMTranslator.ParsedCommands
{
    public class MemoryAccessCommand : BaseVMCommand
    {
        private int value;
        private string prefix;
        private MemoryAccessCommandTypes memoryAccessCommandsTypes;
        private MemorySegments memorySegment;

        public MemoryAccessCommand(int value, string prefix, MemoryAccessCommandTypes memoryAccessCommandsTypes, MemorySegments memorySegment)
        {
            this.value = value;
            this.prefix = prefix;
            this.memoryAccessCommandsTypes = memoryAccessCommandsTypes;
            this.memorySegment = memorySegment;
        }

        public override string ToAssembly()
        {
            throw new NotImplementedException();
        }
    }
}