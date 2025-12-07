namespace Nano_Runtime.Memory
{
    internal class CallFrame(string functionName, int returnAddress)
    {
        public string FunctionName
        {
            get => _functionName;
        }

        public int ReturnAddress
        {
            get => _returnAddress;
        }

        private readonly string _functionName = functionName;
        private readonly int _returnAddress = returnAddress;
    }
}
