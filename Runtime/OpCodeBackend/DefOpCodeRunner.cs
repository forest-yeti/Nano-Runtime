using Nano_Runtime.Fallback;
using Nano_Runtime.Helper;
using Nano_Runtime.Memory;
using Nano_Runtime.Runtime.Panic;
using Nano_Runtime.Runtime.Structure;

namespace Nano_Runtime.Runtime.OpCodeBackend
{
    internal class DefOpCodeRunner : IOpCodeRunner
    {
        private static string INT_TYPE = "INT";

        private List<string> _supportedVariableTypes = new()
        {
            INT_TYPE,
        };

        public string SupportedType()
        {
            return OpCodeTable.Def;
        }

        public void Run(OpCode opCode)
        {
            string? targetType = opCode.LeftArg;
            if (targetType == null || !_supportedVariableTypes.Contains(targetType))
            {
                string supportedTypes = string.Join(", ", _supportedVariableTypes);
                throw new FailedExectionPlan(
                    (int)FallbackCode.OpCodeWrongStructure,
                    $"DEF op code need to define left arg like - {supportedTypes}"
                );
            }

            string? variableName = opCode.RightArg;
            if (variableName == null)
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.OpCodeWrongStructure,
                    $"DEF op code need to define right arg like variable name"
                );
            }

            if (ReservedWord.IsAccumulatorRegisterWord(variableName))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.ReservedWordUsing,
                    $"DEF op code - Reserved word '_Acc' using"
                );
            }

            if (targetType == INT_TYPE)
            {
                CallStack
                    .GetScope(GlobalRegister.RunningFunction)
                    .AddIntVariable(variableName, 0);
            }
        }
    }
}
