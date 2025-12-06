namespace Nano_Runtime.Memory
{
    internal class CallStack
    {
        private static Dictionary<string, FunctionScope> _functionScopes = new();
        public static Stack<string> Stack = new();

        public static void AddScope(string name, FunctionScope scope)
        {
            _functionScopes[name] = scope;
            Stack.Push(name);
        }

        public static void RemoveScope(string name)
        {
            _functionScopes.Remove(name);
            Stack.Pop();
        }

        public static FunctionScope GetScope(string name)
        {
            return _functionScopes[name];
        }
    }
}
