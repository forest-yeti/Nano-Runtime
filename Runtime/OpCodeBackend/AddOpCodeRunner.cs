using Nano_Runtime.Fallback;
using Nano_Runtime.Memory;
using Nano_Runtime.Runtime.Panic;
using Nano_Runtime.Runtime.Structure;

namespace Nano_Runtime.Runtime.OpCodeBackend
{
    internal class AddOpCodeRunner : IOpCodeRunner
    {
        public string SupportedType()
        {
            return OpCodeTable.Add;
        }

        public void Run(OpCode opCode)
        {
            string? variableName = opCode.LeftArg;
            if (variableName == null)
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.OpCodeWrongStructure,
                    $"ADD op code need to define left arg as variable name"
                );
            }

            int value = CallStack
                .GetScope(GlobalRegister.RunnedFunction)
                .GetIntVariable(variableName);

            GlobalRegister.Accumulator += value;
        }
    }
}
