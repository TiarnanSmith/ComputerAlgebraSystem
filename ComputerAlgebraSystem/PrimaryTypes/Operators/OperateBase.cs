namespace ComputerAlgebraSystem.PrimaryTypes.Operators
{
    public class OperateBase : IOperate
    {
        private readonly string _name;
        private readonly string _symbol;

        public string Name => _name;
        public string Symbol => _symbol;

        public OperateBase(string name, string symbol)
        {
            _name = name;
            _symbol = symbol;
        }
    }
}