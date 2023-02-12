using VMTranslator.Templates;

namespace VMTranslator.ParsedCommands
{
    public class MemoryAccessCommand : BaseVMCommand
    {
        private int value;
        private string prefix;
        private MemoryAccessCommandType memoryAccessCommandsTypes;
        private MemorySegment memorySegment;

        public MemoryAccessCommand(int value, string prefix, MemoryAccessCommandType memoryAccessCommandsTypes, MemorySegment memorySegment)
        {
            this.value = value;
            this.prefix = prefix;
            this.memoryAccessCommandsTypes = memoryAccessCommandsTypes;
            this.memorySegment = memorySegment;
        }

        public override string ToAssembly()
        {
            switch (memoryAccessCommandsTypes)
            {
                case MemoryAccessCommandType.POP:
                    return PopCommandToAssembly(prefix, memorySegment, value);
                case MemoryAccessCommandType.PUSH:
                    return PushCommandToAssembly(prefix, memorySegment, value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string PopCommandToAssembly(string prefix, MemorySegment segment, int address)
        {
            switch (segment)
            {
                case MemorySegment.LOCAL:
                    return PopMemoryTemplate.ToLocalAssembly(address);
                case MemorySegment.ARGUMENT:
                    return PopMemoryTemplate.ToArgumentAssembly(address);
                case MemorySegment.THIS:
                    return PopMemoryTemplate.ToThisAssembly(address);
                case MemorySegment.THAT:
                    return PopMemoryTemplate.ToThatAssembly(address);
                case MemorySegment.CONSTANT:
                    throw new InvalidDataException("Cannot perform POP command for constant memory segment");
                case MemorySegment.STATIC:
                    return PopMemoryTemplate.ToStaticAssembly(prefix, address);
                case MemorySegment.POINTER:
                    return PopMemoryTemplate.ToPointerAssembly(address);
                case MemorySegment.TEMP:
                    return PopMemoryTemplate.ToTempAssembly(address);
                default:
                    throw new ArgumentOutOfRangeException(nameof(segment), segment, null);
            }
        }

        private string PushCommandToAssembly(string prefix, MemorySegment segment, int value)
        {
            switch (segment)
            {
                case MemorySegment.LOCAL:
                    return PushMemoryTemplate.ToLocalAssembly(value);
                case MemorySegment.ARGUMENT:
                    return PushMemoryTemplate.ToArgumentAssembly(value);
                case MemorySegment.THIS:
                    return PushMemoryTemplate.ToThisAssembly(value);
                case MemorySegment.THAT:
                    return PushMemoryTemplate.ToThatAssembly(value);
                case MemorySegment.CONSTANT:
                    return PushMemoryTemplate.ToConstantAssembly(value);
                case MemorySegment.STATIC:
                    return PushMemoryTemplate.ToStaticAssembly(prefix, value);
                case MemorySegment.POINTER:
                    return PushMemoryTemplate.ToPointerAssembly(value);
                case MemorySegment.TEMP:
                    return PushMemoryTemplate.ToTempAssembly(value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(segment), segment, null);
            }
        }
    }
}