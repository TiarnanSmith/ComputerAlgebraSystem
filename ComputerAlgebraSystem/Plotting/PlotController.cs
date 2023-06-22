using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Plotting
{
    /// <summary>
    /// Pass-Through class for linking a plotview and a graphplot.
    /// </summary>
    public class PlotController
    {
        private PlotView _plotView;
        private GraphPlot _graphPlot;

        public GraphPlot GraphPlot => _graphPlot;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x0">Lower Bound x</param>
        /// <param name="x1">Upper Bound x</param>
        /// <param name="y0">Lower Bound y</param>
        /// <param name="y1">Upper Bound y</param>
        public PlotController(int x0, int x1, int y0, int y1, Equation equation)
        {
            _plotView = new PlotView(x0, x1, y0, y1);
            _graphPlot = new GraphPlot(equation);
            _graphPlot.CalculatePlot(_plotView);
        }

        /// <summary>
        /// Direct <see cref="PlotView"/>
        /// </summary>
        public PlotController(PlotView plotv, Equation equation)
        {
            _plotView = plotv;
            _graphPlot = new GraphPlot(equation);
            _graphPlot.CalculatePlot(_plotView);
        }

        /// <summary>
        /// Updates the plot.
        /// </summary>
        /// <param name="x0">Lower Bound x</param>
        /// <param name="x1">Upper Bound x</param>
        /// <param name="y0">Lower Bound y</param>
        /// <param name="y1">Upper Bound y</param>
        public void UpdatePlot(int x0, int x1, int y0, int y1)
        {
            _plotView = new PlotView(x0, x1, y0, y1);
            setNewPlot();
        }
        public void UpdatePlot(PlotView plotView)
        {
            _plotView = plotView;
            setNewPlot();
        }


        /// <summary>
        /// Calculates a fresh plot
        /// </summary>
        private void setNewPlot()
        {
            _graphPlot.CalculatePlot(_plotView);
        }

        public double[] XApproximateValue(double a)
        {
            a = a > _plotView.XEndValue ? throw new NotImplementedException() : a;

            return _graphPlot.XApproximateValue(a);
        }
    }
}
