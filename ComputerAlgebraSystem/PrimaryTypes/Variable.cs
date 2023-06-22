using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.PrimaryTypes
{
    public class Variable
    {
        private char _letter;
        /// <summary>
        /// Letter to which a <see cref="Variable"/> is represented by.
        /// </summary>
        public char Letter => _letter;

        private double _exponent;
        public double Exponent => _exponent;

        /// <summary>
        /// Range of the variable
        /// </summary>
        private Range? range;

        public Variable(char letter, double exponent)
        {
            _letter = letter;
            _exponent = exponent;

        }

        public string GetStringForm()
        {
            return $"{_letter}^({_exponent})";
        }

        public static Variable operator *(Variable a, Variable b)
        {
            if (a.Letter == b.Letter)
            {
                return new Variable(a.Letter, b.Exponent+a.Exponent);
            }
            else
            {
                return null;
            }
        }

        public static Variable operator /(Variable a, Variable b)
        {
            if (a.Letter == b.Letter)
            {
                return new Variable(a.Letter, b.Exponent + a.Exponent);
            }
            else
            {
                return null;
            }
        }
    }
}
