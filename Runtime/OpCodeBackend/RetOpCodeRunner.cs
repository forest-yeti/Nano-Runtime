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
            CallStack.RemoveScope(GlobalRegister.RunnedFunction);

            if (CallStack.Stack.Count == 0)
            {
                throw new ExitProgramSignal();
            }

            string targetFunction = CallStack.Stack.Peek();
            GlobalRegister.InstructionPointer = GlobalRegister.CallBreakedPointer;
            GlobalRegister.RunnedFunction = targetFunction;
        }
    }
}
