using Nano_Runtime.Fallback;
using Nano_Runtime.Helper;
using Nano_Runtime.Memory;
using Nano_Runtime.Runtime.Panic;
using Nano_Runtime.Runtime.Structure;

namespace Nano_Runtime.Runtime.OpCodeBackend
{
    internal class PutiOpCodeRunner : IOpCodeRunner
    {
        public string SupportedType()
        {
            return OpCodeTable.Puti;
        }

        public void Run(OpCode opCode)
        {
            string? variableName = opCode.LeftArg;
            if (variableName == null)
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.OpCodeWrongStructure,
                    $"PUTI op code need to define left arg as variable name"
                );
            }

            if (ReservedWord.IsAccumulatorRegisterWord(variableName))
            {
                GlobalStack.NumberStack.Push(GlobalRegister.Accumulator);
                return;
            }

            float value = CallStack
                .GetScope(GlobalRegister.RunningFunction)
                .GetNumberVariable(variableName);

            GlobalStack.NumberStack.Push(value);
        }
    }
}
