using ComputerGraphingSystem.Stores;
using ComputerGraphingSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphingSystem.Services
{
    public class NavigationService
    {
        private NavigationStore _navigationStore;
        private Func<ViewModelBase> _createViewModel;
        

        public NavigationService(NavigationStore navigationStore, string createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = Pages.viewModelFunctions[createViewModel];
        }
        /// <summary>
        /// Changes current view model 
        /// </summary>
        /// <param name="t">The desired 'page code'</param>
        public void Navigate(string t)
        {
            // Very Intresting
            _createViewModel = Pages.viewModelFunctions[t];
            _navigationStore.CurrentViewModel = _createViewModel();
        }

        public void SubmitNavigate(string response)
        {
            _createViewModel = Pages.viewModelFunctions["graph"];
            _navigationStore.CurrentViewModel = _createViewModel();
        }
    }
}
