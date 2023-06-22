using ComputerAlgebraSystem.Plotting;
using ComputerGraphingSystem.Model;
using ComputerGraphingSystem.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphingSystem.ViewModels
{
    public class GraphCanvasViewModel : ViewModelBase
    {
        private ObservableCollection<LineViewModel> _curveLines;
        private GraphSystem _graphSystem;
        

        public ObservableCollection<LineViewModel> CurveLines => _curveLines;
        // public ObservableCollection<LineViewModel> LabelledPoints => throw new NotImplementedException(); 

        public GraphSystem GraphSystem => _graphSystem;



        private ObservableCollection<LabelTextBoxViewModel> _viewControls;
        /// <summary>
        /// The controls for the size of the graph view.
        /// </summary>
        public ObservableCollection<LabelTextBoxViewModel> ViewControls => _viewControls;



        private ObservableCollection<LabelTextBoxViewModel> _equationControls;
        public ObservableCollection<LabelTextBoxViewModel> EquationControls => _equationControls;



        public void UpdateRenderer()
        {
            for (int i = 0; i < _graphSystem.Graphs.Count; i++)
            {
                _curveLines[i] = new LineViewModel(_graphSystem.Graphs[i].GraphPlot.Graph.GetPlotPoints(),
                    _graphSystem.PlotView.GetXRange(),
                    _graphSystem.PlotView.GetYRange());
            }
        }

        public void AddCachedGraphs()
        {
            for (int i = 0; i < _graphSystem.Graphs.Count; i++)
            {
                _curveLines.Add(new LineViewModel(_graphSystem.Graphs[i].GraphPlot.Graph.GetPlotPoints(),
                    _graphSystem.PlotView.GetXRange(),
                    _graphSystem.PlotView.GetYRange(), _graphSystem.Graphs[i].GraphPlot.Name)); ;
            }
            
        }


        public GraphCanvasViewModel(GraphSystem graphSystem, NavigationService navigation)
        {
            _graphSystem = graphSystem;
            _curveLines = new ObservableCollection<LineViewModel>();
            _viewControls = new ObservableCollection<LabelTextBoxViewModel>
            {
                // This is os bad
                new LabelTextBoxViewModel("X0"),
                new LabelTextBoxViewModel("X1"),
                new LabelTextBoxViewModel("Y0"),
                new LabelTextBoxViewModel("Y1")
            };

            AddCachedGraphs();
        }
    }
}
