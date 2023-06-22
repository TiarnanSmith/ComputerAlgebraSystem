using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphingSystem.Commands
{
    public class ChangedViewSizeCommand : CommandBase
    {
        private Action<double> _action;
        private Action _update;
        private string _tag;
        public ChangedViewSizeCommand(Action<double> action, Action update, ref string tag)
        {
            _action=action;
            _update=update;
            _tag = tag;
        }

        public override void Execute(object? parameter)
        {
            double con = Convert.ToDouble(_tag);
            _action(con);
            _update();

        }
    }
}
