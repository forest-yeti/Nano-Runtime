namespace Nano_Runtime.Runtime.Panic
{
    internal class FailedExectionPlan : Exception
    {
        private readonly int code;

        public FailedExectionPlan(int code, string message) : base(message)
        {
            this.code = code;
        }

        public string GetFormattedMessage()
        {
            return $"[{this.code}] {this.Message}";
        }
    }
}
