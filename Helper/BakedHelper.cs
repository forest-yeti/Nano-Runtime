namespace Nano_Runtime.Helper
{
    static class BakedHelper
    {
        public static int BakeString(string value)
        {
            const ulong offset = 1469598103934665603;
            const ulong prime = 1099511628211;

            ulong hash = offset;
            foreach (char c in value)
            {
                hash ^= c;
                hash *= prime;
            }

            int result = (int)(hash & 0xFFFFFFFF);
            return Math.Abs(result);
        }
    }
}
