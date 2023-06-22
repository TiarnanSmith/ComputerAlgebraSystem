namespace ComputerAlgebraSystem.PrimaryTypes.RealNumber
{
    /// <summary>
    /// Make more use in future
    /// </summary>
    public class RealValue
    {
        private double _value;
        public double Value => _value;

        public RealValue(double value)
        {
            _value = value;
        }

        public static RealValue operator +(RealValue a, RealValue b)
        {
            return new RealValue(a._value + b._value);
        }

        public static RealValue operator -(RealValue a, RealValue b)
        {
            return new RealValue(a._value - b._value);
        }
    }
}