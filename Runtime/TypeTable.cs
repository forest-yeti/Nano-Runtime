namespace Nano_Runtime.Runtime
{
    static class TypeTable
    {
        public static string INT_TYPE = "INT";
        public static string FLOAT_TYPE = "FLOAT";

        public static bool IsNumberType(string type)
        {
            return type == INT_TYPE || type == FLOAT_TYPE;
        }

        public static bool IsInteger(float value)
        {
            return Math.Abs(value - MathF.Round(value)) < 1e-6f;
        }
    }
}
