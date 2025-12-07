using Nano_Runtime.Fallback;
using Nano_Runtime.Runtime;
using Nano_Runtime.Runtime.Panic;
using System.Reflection.Metadata;

namespace Nano_Runtime.Memory
{
    internal class FunctionScope
    {
        private readonly Dictionary<string, Variable<float>> _numberVariables = new();
        private readonly Dictionary<string, string> _numberTypeMapping = new();

        public void AddNumberVariable(string name, string type)
        {
            if (HasNumberVariable(name))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.FunctionScopeVariableAlreadyDefined,
                    $"Function scope variable already defined with name {name}"
                );
            }

            _numberVariables[name] = new Variable<float>(name, 0f);
            _numberTypeMapping[name] = type;
        }

        public void LoadNumberVariable(string name, float value)
        {
            if (!HasNumberVariable(name))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.FunctionScopeVariableNotDefined,
                    $"Function scope number variable not defined with name {name}"
                );
            }

            if (_numberTypeMapping[name] == TypeTable.INT_TYPE && !TypeTable.IsInteger(value))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.LoadFloatToInt,
                    $"Variable with name {name} supported only integer value"
                );
            }

            _numberVariables[name].Value = value;
        }

        public float GetNumberVariable(string name)
        {
            if (!HasNumberVariable(name))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.FunctionScopeVariableNotDefined,
                    $"Function scope variable not defined with name {name}"
                );
            }

            return _numberVariables[name].Value;
        }

        public bool HasNumberVariable(string name)
        {
            return _numberVariables.ContainsKey(name);
        }
    }
}
