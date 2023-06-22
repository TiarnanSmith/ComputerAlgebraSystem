using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Plotting
{
    /// <summary>
    /// 
    /// </summary>
    public class Graph
    {
        private Plot[] _plotPoints; // stack is incremented through until 'undoSteps'
        private const int undoSteps = 5;
        private int undoIncrement = 0;

        
        /// <summary>
        /// Discouraged method of adding <see cref="Plot"/> points!
        /// </summary>
        public Graph(Plot[] plotPoints)
        {

            plotPoints = plotPoints.Length > undoSteps ? throw new Exception() : plotPoints; // Error checking

            _plotPoints = plotPoints;
        }

        /// <summary>
        /// 
        /// </summary>
        public Graph()
        {
            _plotPoints = new Plot[undoSteps - 1];
        }

        public double[][] GetDerivativeApproximation()
        {
            return _plotPoints[undoIncrement - 1].DerivativeApproximation();
        }

        /// <summary>
        /// Adds a <see cref="Plot"/> to the <see cref="Graph"/>
        /// </summary>
        public void AddPlot(Plot plot) // Basically a stack
        {
            if (undoIncrement < 5)
            {
                _plotPoints[undoIncrement] = plot;
                undoIncrement++;
            }
            if (undoIncrement > undoSteps)
            {
                undoIncrement = 0;
                _plotPoints[undoIncrement] = plot;
                undoIncrement++;
            }
        }

        public double[][] GetPlotPoints()
        {
            return _plotPoints[undoIncrement - 1].Points;
        }

        /// <summary>
        /// Removes last <see cref="Plot"/> from the <see cref="Graph"/>
        /// </summary>
        /// <remarks>There is no redo feature; once a <see cref="Plot"/> is removed from the <see cref="Graph"/>, its gone.</remarks>
        public void RemovePlot() { throw new NotImplementedException(); }

        public double[] XApproximateValue(double d)
        {
            return _plotPoints[undoIncrement-1].XApproximateValueAtPoint(d);
        }
    }
}
