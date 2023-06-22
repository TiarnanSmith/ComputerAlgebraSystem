namespace ComputerAlgebraSystem.PrimaryTypes.Operators
{
    public class OperateBase : IOperate
    {
        private readonly string _name;
        private readonly string _symbol;
        private int _value;

        public string Name => _name;
        public string Symbol => _symbol;
        public int Value => _value;
        public OperateBase(string name, string symbol, int value)
        {
            _name = name;
            _symbol = symbol;
            _value = value;
        }
    }
}