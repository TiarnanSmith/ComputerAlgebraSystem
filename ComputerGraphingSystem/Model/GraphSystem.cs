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
    }
}
