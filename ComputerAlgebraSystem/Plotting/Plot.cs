using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Plotting
{
    /// <summary>
    /// Has a int[][] of points;
    /// </summary>
    public class Plot
    {
        private double[][] _points;
        public double[][] Points => _points;

        /// <summary>
        /// Constructor for the <see cref="Plot"/> class.
        /// </summary>
        /// <param name="points">The Points contained within the <see cref="Plot"/>.</param>
        public Plot(double[][] points)
        {
            _points = points;
        }

        /// <summary>
        /// Uses interpolation to get an Approximate value at a point
        /// </summary>
        /// <param name="x">The X point</param>
        /// <returns>The closest stored value</returns>
        public double[] XApproximateValueAtPoint(double x) // binary search
        {
            int lower = 0;
            int upper = _points.Length - 1;
            const double significanceLevel = 0.000000000005d;

            if (x > _points[upper][0])
            {
                throw new ArgumentException();
            }

            int index = -1;

            bool found = false;

            while (found==false)
            {
                int midpoint = (int)((upper+lower) / 2d);
                //Console.WriteLine($"Midpoint {midpoint}, Upper {upper}, Lower {lower}");

                if (upper == lower+1) // Interpolation
                {
                    double m = (_points[upper][1] - _points[lower][1]) / (_points[upper][0] - _points[lower][0]);
                    double y = m * (x - _points[upper][0]) + _points[upper][1];
                    found = true;
                    return new double[2] { x, y };
                }
                else if (x < _points[midpoint][0])
                {
                    //lower = lower; 
                    upper = midpoint;
                }
                else if (x > _points[midpoint][0])
                {
                    lower = midpoint;
                    //upper = upper;
                }
                else if (Math.Abs(x - _points[midpoint][0]) < significanceLevel) // iteration
                {
                    index = midpoint;
                    found = true;
                }
            }

            return _points[index];
        }


        public double[][] DerivativeApproximation()
        {
            double[][] change = new double[_points.Length - 1][];
            for(int i = 0 ; i < _points.GetLength(0)-1; i++)
            {
                double[] coords = new double[2];
                coords[0] = _points[i][0];
                coords[1] = ((_points[i + 1][1] - _points[i][1]) / (_points[i + 1][0] - _points[i][0]));
                change[i] = coords;
            }

            return change;
        }
        /// <summary>
        /// Uses interpolation to get an Approximate value at a point
        /// </summary>
        /// <returns>The closest stored value</returns>
        public double[] YApproximateValueAtPoint(double y)
        {
            throw new NotImplementedException();
        }

        public string GetStringPlot()
        {
            string toReturn = "";

            throw new NotImplementedException() { };
        }
    }
}
