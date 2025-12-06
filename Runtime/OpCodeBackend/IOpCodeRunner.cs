using Nano_Runtime.Runtime.Structure;

namespace Nano_Runtime.Runtime.OpCodeBackend
{
    internal interface IOpCodeRunner
    {
        public string SupportedType();
        public void Run(OpCode opCode);
    }
}
