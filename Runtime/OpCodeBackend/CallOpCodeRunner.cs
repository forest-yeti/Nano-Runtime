using Nano_Runtime.Fallback;
using Nano_Runtime.Helper;
using Nano_Runtime.Memory;
using Nano_Runtime.Runtime.Panic;
using Nano_Runtime.Runtime.Structure;

namespace Nano_Runtime.Runtime.OpCodeBackend
{
    internal class CallOpCodeRunner : IOpCodeRunner
    {
        public string SupportedType()
        {
            return OpCodeTable.Call;
        }

        public void Run(OpCode opCode)
        {
            string? functionName = opCode.LeftArg;
            if (functionName == null)
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.OpCodeWrongStructure,
                    $"CALL op code need to define left arg as function name"
                );
            }

            // @TODO: Временное решение, для самой ранней версии
            if (functionName == "__N_Output_WriteLine")
            {
                float intValue = GlobalStack.NumberStack.Pop();
                Console.WriteLine(intValue);
                return;
            }

            CallStack.CallFrameStack.Push(new CallFrame(functionName, GlobalRegister.InstructionPointer));
            GlobalRegister.InstructionPointer = BakedHelper.BakeString(functionName) - 1;
            GlobalRegister.RunningFunction = functionName;
            CallStack.AddScope(functionName, new());
        }
    }
}
