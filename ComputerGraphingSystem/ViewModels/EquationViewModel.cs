using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphingSystem.ViewModels
{
    public class EquationViewModel : LabelTextBoxViewModel
    {
        public new string Description { get => this._description; }
        public new string TBContents 
        {
            get { return _tBContents.ToString(); }
            set
            {
                _tBContents = value;
                OnPropertyChanged(nameof(TBContents));
            }
        }

        

        public EquationViewModel(string description) : base(description)
        {
            this._description = description;
        }

        
    }
}
