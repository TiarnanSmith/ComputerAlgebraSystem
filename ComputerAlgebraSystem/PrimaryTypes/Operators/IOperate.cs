using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.PrimaryTypes.Operators
{
    /// <summary>
    /// Interface for all operators [Used for MainOperator]
    /// </summary>
    internal interface IOperate
    {
        public string Name { get; }
        public string Symbol { get; }
    }
}
