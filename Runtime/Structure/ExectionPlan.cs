using Nano_Runtime.Fallback;
using Nano_Runtime.Runtime.Panic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nano_Runtime.Runtime.Structure
{
    internal class ExectionPlan
    {
        public Dictionary<string, Function> Function
        {
            get => _functions;
        }

        private readonly Dictionary<string, Function> _functions = new();
        private readonly Dictionary<string, int> _functionVirtualTable = new();

        public ExectionPlan AddFunction(Function function)
        {
            if (_functions.ContainsKey(function.Name))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.FunctionAlreadyExist, 
                    $"Function with name {function.Name} already exist"
                );
            }

            _functions[function.Name] = function;
            _functionVirtualTable[function.Name] = function.VirtualName;

            return this;
        }

        public int GetEntryPointVirtual()
        {
            if (!_functionVirtualTable.ContainsKey(NanoRuntime.ENTRY_POINT))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.EntryPointNotDefined,
                    $"Entry point 'Main' not defined"
                );
            }

            return _functionVirtualTable[NanoRuntime.ENTRY_POINT];
        }

        public Function GetFunction(string name)
        {
            if (!_functions.ContainsKey(name))
            {
                throw new FailedExectionPlan(
                    (int)FallbackCode.FunctionNotDefined,
                    $"Function with name {name} not defined"
                );
            }

            return _functions[name];
        }
    }
}
