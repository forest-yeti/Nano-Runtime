using Nano_Runtime.Helper;
using Nano_Runtime.Memory;
using Nano_Runtime.Runtime.Signal;
using Nano_Runtime.Runtime.Structure;

namespace Nano_Runtime.Runtime.OpCodeBackend
{
    internal class RetOpCodeRunner : IOpCodeRunner
    {
        public string SupportedType()
        {
            return OpCodeTable.Ret;
        }

        public void Run(OpCode opCode)
        {
            CallStack.RemoveScope(GlobalRegister.RunningFunction);

            CallFrame breakedCallFrame = CallStack.CallFrameStack.Pop();
            if (CallStack.CallFrameStack.Count == 0)
            {
                throw new ExitProgramSignal();
            }

            CallFrame returnCallFrame = CallStack.CallFrameStack.Peek();

            GlobalRegister.InstructionPointer = breakedCallFrame.ReturnAddress;
            GlobalRegister.RunningFunction = returnCallFrame.FunctionName;
        }
    }
}
