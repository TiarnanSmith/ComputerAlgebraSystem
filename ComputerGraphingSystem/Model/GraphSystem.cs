using ComputerAlgebraSystem;
using ComputerAlgebraSystem.Plotting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphingSystem.Model
{
    public class GraphSystem
    {
        private List<PlotController> _graphs;
        private PlotView _plotView;


        public List<PlotController> Graphs => _graphs;
        public PlotView PlotView => _plotView;

        public GraphSystem(PlotView plot)
        {
            _plotView = plot;
            _graphs = new List<PlotController>();

            Expression eq = new Expression();
            eq.AddTerm(new Term(1d, 'x', 2d));
            PlotController controller = new PlotController(_plotView, new Equation(eq));

            Expression eq2 = new Expression();
            eq.AddTerm(new Term(1d, 'x', 1d));
            PlotController controller2 = new PlotController(_plotView, new Equation(eq));

            _graphs.Add(controller);
            _graphs.Add(controller2);
        }

        public void RecalculateAll()
        {
            for (int i = 0; i  < _graphs.Count; i++ )
            {
                _graphs[i].UpdatePlot(_plotView);
            }
        }

        // Lazy
        public void UpdatePlotViewX0(double x0)
        {
            _plotView = new PlotView(x0, _plotView.XEndValue, _plotView.YStartValue, _plotView.YEndValue);
            RecalculateAll();
        }
        public void UpdatePlotViewX1(double x1)
        {
            _plotView = new PlotView(_plotView.XStartValue, x1, _plotView.YStartValue, _plotView.YEndValue);
            RecalculateAll();
        }
        public void UpdatePlotViewY0(double y0)
        {
            _plotView = new PlotView(_plotView.XStartValue, _plotView.XEndValue, y0, _plotView.YEndValue);
            RecalculateAll();
        }
        public void UpdatePlotViewY1(double y1)
        {
            _plotView = new PlotView(_plotView.XStartValue, _plotView.XEndValue, _plotView.YStartValue, y1);
            RecalculateAll();
        }
    }
}
