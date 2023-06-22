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
        private ObservableCollection<LabelTextBoxViewModel> _viewControls;

        public ObservableCollection<LineViewModel> CurveLines => _curveLines;
        // public ObservableCollection<LineViewModel> LabelledPoints => throw new NotImplementedException(); 

        public GraphSystem GraphSystem => _graphSystem;
        /// <summary>
        /// The size of the layout
        /// </summary>
        public ObservableCollection<LabelTextBoxViewModel> ViewControls => _viewControls;

        public void UpdateRenderer()
        {
            for (int i = 0; i < _graphSystem.Graphs.Count; i++)
            {
                _curveLines.Add(new LineViewModel(_graphSystem.Graphs[i].GraphPlot.Graph.GetPlotPoints(),
                    _graphSystem.PlotView.GetXRange(),
                    _graphSystem.PlotView.GetYRange()));
            }
        }


        public GraphCanvasViewModel(GraphSystem graphSystem, NavigationService navigation)
        {
            _graphSystem = graphSystem;
            _curveLines = new ObservableCollection<LineViewModel>();
            _viewControls = new ObservableCollection<LabelTextBoxViewModel>
            {
                // This is os bad
                new LabelTextBoxViewModel("X0", graphSystem.UpdatePlotViewX0, UpdateRenderer),
                new LabelTextBoxViewModel("X1", graphSystem.UpdatePlotViewX1, UpdateRenderer),
                new LabelTextBoxViewModel("Y0", graphSystem.UpdatePlotViewY0, UpdateRenderer),
                new LabelTextBoxViewModel("Y1", graphSystem.UpdatePlotViewY1, UpdateRenderer)
            };
            
            for (int i = 0; i < graphSystem.Graphs.Count; i++)
            {
                _curveLines.Add(new LineViewModel(graphSystem.Graphs[0].GraphPlot.Graph.GetPlotPoints()));
            }

            //_curveLines.Add(new LineViewModel(graphSystem.Graphs[0].GraphPlot.Graph.GetDerivativeApproximation(), _graphPlotView.GetXRange(),  _graphPlotView.GetYRange()));
            
        }
    }
}
