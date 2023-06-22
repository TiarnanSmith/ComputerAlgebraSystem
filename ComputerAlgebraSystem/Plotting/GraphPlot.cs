using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Plotting
{
    // Links a Graph and a Equation
    public class GraphPlot
    {
        private Graph _graph;
        private Equation _equation;
        private string _name;

        public Graph Graph => _graph;
        public string Name => _equation.GetStringForm();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="equation"></param>
        /// <param name="name"></param>
        public GraphPlot(Equation equation, string name = "Graph")
        {
            _equation = equation;
            _graph = new Graph();
        }

        public void CalculatePlot(PlotView plotView)
        {
            Plot points = new Plot(_equation.PlotValues(plotView));
            _graph.AddPlot(points);
        }

        public double[] XApproximateValue(double a)
        {
            return _graph.XApproximateValue(a);
        }

    }
}
