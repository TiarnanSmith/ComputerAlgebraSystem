using ComputerGraphingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphingSystem.Stores
{
    public class Pages
    {
        public static Dictionary<string, Func<ViewModelBase>> viewModelFunctions = new Dictionary<string, Func<ViewModelBase>>();
    }
}
