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
            
            
            //Temp
            Expression eq = new Expression();
            eq.AddTerm(new Term(1d, 'x', 2d));
            PlotController controller = new PlotController(_plotView, new Equation(eq));

            Expression eq2 = new Expression();
            eq2.AddTerm(new Term(1d, 'x', 1d));
            PlotController controller2 = new PlotController(_plotView, new Equation(eq2));

            Expression express3 = new Expression();
            express3.AddTerm(new Term(0.5d, 'x', 2d));
            express3.AddTerm(new Term(-3d, 'x', 0d));
            PlotController equation3 = new PlotController(_plotView, new Equation(express3));

            _graphs.Add(controller);
            _graphs.Add(controller2);
            _graphs.Add(equation3);
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
