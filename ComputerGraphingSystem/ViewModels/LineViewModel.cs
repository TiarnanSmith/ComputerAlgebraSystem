using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Documents;
using System.Collections;
using System.Collections.Generic;

namespace ComputerGraphingSystem.ViewModels
{
    /// <summary>
    /// A Handler for the <see cref="LineView"/>
    /// </summary>
    /// <remarks>Naming explanation: "A curve is a generalization of a line."</remarks>
    public class LineViewModel : ViewModelBase
    {
        private PointCollection _points;
        private System.Drawing.Color _colour;
        private double _width;

        /// <summary>
        /// Points for the line view
        /// </summary>
        public PointCollection Points => _points;
        public System.Drawing.Color Colour => _colour;
        public double Width => _width;



        public LineViewModel(double[][] points, double xRange = 10, double yRange = 10, string equation = "eq", string colour = "Black", double width = 3d)
        {
            _points = new PointCollection();
            _colour = System.Drawing.Color.FromName(colour);
            _width = width;


            for (int i = 0; i < points.Length; i++) // find better way of doing this
            {
                _points.Add(new Point(points[i][0]*(1280/xRange), points[i][1]*-(720/ yRange)));
            }
        }

        // Thinking: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/user-defined-conversion-operators
    }
}
