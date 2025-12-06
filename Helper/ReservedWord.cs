namespace Nano_Runtime.Helper
{
    internal class ReservedWord
    {
        public static bool IsAccumulatorRegisterWord(string word)
        {
            return word == "_Acc";
        }
    }
}
