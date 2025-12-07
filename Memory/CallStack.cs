namespace Nano_Runtime.Memory
{
    internal class CallStack
    {
        public static Stack<CallFrame> CallFrameStack = new();

        private static Dictionary<string, FunctionScope> _functionScopes = new();

        public static void AddScope(string name, FunctionScope scope)
        {
            _functionScopes[name] = scope;
        }

        public static void RemoveScope(string name)
        {
            _functionScopes.Remove(name);
        }

        public static FunctionScope GetScope(string name)
        {
            return _functionScopes[name];
        }
    }
}
