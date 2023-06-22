using ComputerAlgebraSystem.PrimaryTypes.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Services
{
    public static class OperatorService
    {
        public readonly static Dictionary<string, OperateBase>? Operators = new Dictionary<string, OperateBase>()
        {
            {"+", new OperateBase("Plus", "+") },
            {"-", new OperateBase("Minus", "-") },
        };
    }
}
