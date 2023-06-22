using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Plotting
{
    /// <summary>
    /// A class for storing the 'frame' of the plot.
    /// </summary>
    public class PlotView
    {
        // Primary driver of calculations.
        private double _xStartValue;
        private double _xEndValue;

        // In future detail required could be calculated from the Y start and end values.
        private double _yStartValue;
        private double _yEndValue;

        // The _yDetail Probably isn't needed with the current implementation of the PlotView.
        private int _yDetail;
        private int _xDetail;
        


        /// <summary>
        /// The First X Value
        /// </summary>
        public double XStartValue => _xStartValue;
        /// <summary>
        /// The First Y Value
        /// </summary>
        public double YStartValue => _yStartValue;
        /// <summary>
        /// The Last X Value
        /// </summary>
        public double XEndValue => _xEndValue;
        /// <summary>
        /// The Last Y Value
        /// </summary>
        public double YEndValue => _yEndValue;

        /// <summary>
        /// Default value is 1280
        /// </summary>
        public int X_Detail => _xDetail;

        /// <summary>
        /// Default value is 720
        /// </summary>
        public int Y_Detail => _yDetail;

        public PlotView(double xStartValue, double xEndValue, double yStartValue, double yEndValue)
        {
            _xStartValue = xStartValue;
            _xEndValue = xEndValue;
            _yStartValue = yStartValue;
            _yEndValue = yEndValue;

            _xDetail = 1280;
            _yDetail = 720;
        }

        public double GetXRange()
        {
            return _xEndValue-_xStartValue;
        }

        public double GetYRange()
        {
            return _yEndValue - _yStartValue;
        }

        /// <summary>
        /// Sets the X_Detail using a factor.
        /// </summary>
        /// <param name="detailFactor">The factor at which 1280 is mutiplied by.</param>
        /// <remarks>Intended for 'sub-pixel' detail on a plot.</remarks>
        public void X_SetDetail(int detailFactor)
        {
            _xDetail = _xDetail * detailFactor;
        }



        /// <returns>The value at which to increment X by.</returns>
        public double X_GetIncrement() // Recalculated every time; maybe store a value?
        {
            return (XEndValue - XStartValue) / _xDetail; // (a-b)/n where a>b
        }
    }
}
