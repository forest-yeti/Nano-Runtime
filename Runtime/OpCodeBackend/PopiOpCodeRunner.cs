using Nano_Runtime.Fallback;
using Nano_Runtime.Memory;
using Nano_Runtime.Runtime.Panic;
using Nano_Runtime.Runtime.Structure;

namespace Nano_Runtime.Runtime.OpCodeBackend
{
    internal class PopiOpCodeRunner : IOpCodeRunner
    {
        public string SupportedType()
        {
            return OpCodeTable.Popi;
        }

        public void Run(OpCode opCode)
        {
            string? variableName = opCode.LeftArg;
            if (variableName == null)
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.OpCodeWrongStructure,
                    $"POPI op code need to define left arg as variable name"
                );
            }

            if (GlobalStack.IntStack.Count == 0)
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.EmptyGlobalStack,
                    "Empty global stack"
                );
            }

            int intValue = GlobalStack.IntStack.Pop();

            CallStack
                .GetScope(GlobalRegister.RunningFunction)
                .LoadIntVariable(variableName, intValue);
        }
    }
}
