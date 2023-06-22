using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.PrimaryTypes
{
    public class Range
    {
        private readonly double? _upper;
        private readonly double? _lower;

        /// <summary>
        /// Lower bound for variable. Infinity is represented by <see langword="null"/>.
        /// </summary>
        public double? Lower => _lower;
        /// <summary>
        /// Upper bound for variable. Infinity is represented by <see langword="null"/>.
        /// </summary>
        public double? Upper => _upper;


        public Range(double? lower, double? upper)
        {
            _lower = lower;
            _upper = upper;
        }

        public override string? ToString()
        {
            string rVal = $"{Lower} < # < {Upper}";
            return rVal;
        }
    }
}
