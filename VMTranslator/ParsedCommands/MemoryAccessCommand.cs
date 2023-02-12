using VMTranslator.Templates;

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
            switch (memoryAccessCommandsTypes)
            {
                case MemoryAccessCommandTypes.POP:
                    return PopCommandToAssembly(prefix, memorySegment, value);
                case MemoryAccessCommandTypes.PUSH:
                    return PushCommandToAssembly(prefix, memorySegment, value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private string PopCommandToAssembly(string prefix, MemorySegments segment, int address)
        {
            switch (segment)
            {
                case MemorySegments.LOCAL:
                    return PopMemoryTemplate.ToLocalAssembly(address);
                case MemorySegments.ARGUMENT:
                    return PopMemoryTemplate.ToArgumentAssembly(address);
                case MemorySegments.THIS:
                    return PopMemoryTemplate.ToThisAssembly(address);
                case MemorySegments.THAT:
                    return PopMemoryTemplate.ToThatAssembly(address);
                case MemorySegments.CONSTANT:
                    throw new InvalidDataException("Cannot perform POP command for constant memory segment");
                case MemorySegments.STATIC:
                    return PopMemoryTemplate.ToStaticAssembly(prefix, address);
                case MemorySegments.POINTER:
                    return PopMemoryTemplate.ToPointerAssembly(address);
                case MemorySegments.TEMP:
                    return PopMemoryTemplate.ToTempAssembly(address);
                default:
                    throw new ArgumentOutOfRangeException(nameof(segment), segment, null);
            }
        }

        private string PushCommandToAssembly(string prefix, MemorySegments segment, int value)
        {
            switch (segment)
            {
                case MemorySegments.LOCAL:
                    return PushMemoryTemplate.ToLocalAssembly(value);
                case MemorySegments.ARGUMENT:
                    return PushMemoryTemplate.ToArgumentAssembly(value);
                case MemorySegments.THIS:
                    return PushMemoryTemplate.ToThisAssembly(value);
                case MemorySegments.THAT:
                    return PushMemoryTemplate.ToThatAssembly(value);
                case MemorySegments.CONSTANT:
                    return PushMemoryTemplate.ToConstantAssembly(value);
                case MemorySegments.STATIC:
                    return PushMemoryTemplate.ToStaticAssembly(prefix, value);
                case MemorySegments.POINTER:
                    return PushMemoryTemplate.ToPointerAssembly(value);
                case MemorySegments.TEMP:
                    return PushMemoryTemplate.ToTempAssembly(value);
                default:
                    throw new ArgumentOutOfRangeException(nameof(segment), segment, null);
            }
        }
    }
}