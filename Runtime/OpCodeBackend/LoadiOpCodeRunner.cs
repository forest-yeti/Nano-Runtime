using Nano_Runtime.Fallback;
using Nano_Runtime.Helper;
using Nano_Runtime.Memory;
using Nano_Runtime.Runtime.Panic;
using Nano_Runtime.Runtime.Structure;
using System.Globalization;

namespace Nano_Runtime.Runtime.OpCodeBackend
{
    internal class LoadiOpCodeRunner : IOpCodeRunner
    {
        public string SupportedType()
        {
            return OpCodeTable.Loadi;
        }

        public void Run(OpCode opCode)
        {
            string? variableName = opCode.LeftArg;
            if (variableName == null)
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.OpCodeWrongStructure,
                    $"LOADI op code need to define left arg as variable name"
                );
            }

            string? value = opCode.RightArg;
            if (value == null)
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.OpCodeWrongStructure,
                    $"LOADI op code need to define right arg as variable value"
                );
            }

            float numberValue = 0;
            if (!float.TryParse(value, NumberStyles.Float, CultureInfo.InvariantCulture, out numberValue))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.OpCodeWrongStructure,
                    $"LOADI op code need to define right arg as number value"
                );
            }

            if (ReservedWord.IsAccumulatorRegisterWord(variableName))
            {
                GlobalRegister.Accumulator = numberValue;
                return;
            }

            if (!CallStack.GetScope(GlobalRegister.RunningFunction).HasNumberVariable(variableName))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.FunctionScopeVariableNotDefined,
                    $"LOADI op code failed, variable with name {variableName} not defined"
                );
            }

            CallStack
                .GetScope(GlobalRegister.RunningFunction)
                .LoadNumberVariable(variableName, numberValue);
        }
    }
}
