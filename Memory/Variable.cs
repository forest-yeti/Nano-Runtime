namespace Nano_Runtime.Memory
{
    internal class Variable<T>(string name, T value)
    {
        public string Name
        {
            get => _name;
        }

        public T Value
        {
            get => _value;
            set => _value = value;
        }

        private readonly string _name = name;
        private T _value = value;
    }
}
