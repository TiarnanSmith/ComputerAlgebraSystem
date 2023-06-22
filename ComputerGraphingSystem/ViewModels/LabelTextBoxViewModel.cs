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
        private string _description;
        private string _tBContents;
        public string Description => _description;
        
        public string TBContents
        {
            get { return _tBContents.ToString(); }
            set 
            {
                _tBContents = value;
                OnPropertyChanged(nameof(TBContents));
                ChangedSize();
            }
        }

        //ICommand ChangeSize { get; }
        private Action _updateRenderer;
        private Action<double> _updateController;

        private void ChangedSize()
        {
            double tb = Convert.ToDouble(_tBContents);
            _updateController.Invoke(tb);
            _updateRenderer.Invoke();
        }

        public LabelTextBoxViewModel(string description, Action<double> updateController, Action updateRenderer)
        {
            _tBContents = "";
            _description = description;
            _updateRenderer = updateRenderer;
            _updateController = updateController;
        }
    }
}
