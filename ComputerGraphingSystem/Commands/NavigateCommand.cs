using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerGraphingSystem.Services;
using ComputerGraphingSystem.ViewModels;

namespace ComputerGraphingSystem.Commands
{
    class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;
        private readonly string _t;

        public NavigateCommand(NavigationService navigationService, string tag)
        {
            _navigationService = navigationService;
            _t= tag;
        }

        public override void Execute(object? parameter)
        {
            _navigationService.Navigate(_t);
        }
    }
}
