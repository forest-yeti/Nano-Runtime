namespace Nano_Runtime.Runtime.Structure
{
    internal class OpCode(
        string type, 
        string? leftArg = null, 
        string? rightArg = null
    )
    {
        public string Type
        {
            get => _type;
        }

        public string? LeftArg
        {
            get => _leftArg;
        }

        public string? RightArg
        {
            get => _righttArg;
        }

        private readonly string _type = type;
        private readonly string? _leftArg = leftArg;
        private readonly string? _righttArg = rightArg;
    }
}
