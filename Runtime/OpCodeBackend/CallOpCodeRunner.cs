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
            if (functionName == "__I_Output_WriteLine")
            {
                int intValue = GlobalStack.IntStack.Pop();
                Console.WriteLine(intValue);
                return;
            }

            GlobalRegister.CallBreakedPointer = GlobalRegister.InstructionPointer;
            GlobalRegister.InstructionPointer = BakedHelper.BakeString(functionName) - 1;
            GlobalRegister.RunnedFunction = functionName;
            CallStack.AddScope(functionName, new());
        }
    }
}
