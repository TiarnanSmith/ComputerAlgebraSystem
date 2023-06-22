using ComputerAlgebraSystem.Plotting;
using ComputerGraphingSystem.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ComputerGraphingSystem.ViewModels
{
    public class LabelTextBoxViewModel : ViewModelBase
    {
        private protected string _description;
        private protected string _tBContents;
        public string Description => _description;
        
        public string TBContents
        {
            get { return _tBContents.ToString(); }
            set 
            {
                _tBContents = value;
                OnPropertyChanged(nameof(TBContents));
            }
        }

        //ICommand ChangeSize { get; }
        public LabelTextBoxViewModel(string description)
        {
            _tBContents = "";
            _description = description;
        }
    }
}
