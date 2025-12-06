using Nano_Runtime.Fallback;
using Nano_Runtime.Runtime.Panic;

namespace Nano_Runtime.Memory
{
    internal class FunctionScope
    {
        private readonly Dictionary<string, Variable<int>> _intVariables = new();

        public void AddIntVariable(string name, int value)
        {
            if (HasIntVariable(name))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.FunctionScopeVariableAlreadyDefined,
                    $"Function scope variable already defined with name {name}"
                );
            }

            _intVariables[name] = new Variable<int>(name, value);
        }

        public void LoadIntVariable(string name, int value)
        {
            if (!HasIntVariable(name))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.FunctionScopeVariableNotDefined,
                    $"Function scope variable not defined with name {name}"
                );
            }

            _intVariables[name].Value = value;
        }

        public int GetIntVariable(string name)
        {
            if (!HasIntVariable(name))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.FunctionScopeVariableNotDefined,
                    $"Function scope variable not defined with name {name}"
                );
            }

            return _intVariables[name].Value;
        }

        public bool HasIntVariable(string name)
        {
            return _intVariables.ContainsKey(name);
        }
    }
}
