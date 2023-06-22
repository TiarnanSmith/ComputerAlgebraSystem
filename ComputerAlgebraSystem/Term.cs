using ComputerAlgebraSystem.PrimaryTypes;
using ComputerAlgebraSystem.PrimaryTypes.Operators;
using ComputerAlgebraSystem.PrimaryTypes.RealNumber;
using ComputerAlgebraSystem.Services;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    /// <summary>
    /// A Term is a product of its: <see cref="Constant"/>s, <see cref="Variable"/>s, <see cref="Unknown"/>s.
    /// </summary>
    public class Term
    {
        /// <summary>
        /// Coefficients
        /// </summary>
        private protected RealValue _coefficient;
        private protected Variable _variable;
        private protected OperateBase? _operator;
        private protected Unknown? _unknown;

        

        public Term(double coefficient, char variable, double exponent)
        { 
            if (coefficient < 0)
            {
                _operator = OperatorService.Operators["-"];
            }
            else if (coefficient > 0)
            {
                _operator = OperatorService.Operators["+"];
            }
            else
            {
                _operator = null;
            }

            _coefficient = new RealValue(coefficient);
            _variable = new Variable(variable, exponent);
        }


        public double GetCoefficient()
        {
            return _coefficient.Value;
        }

        public string GetStringForm()
        {
            double coefficient = Math.Abs(_coefficient.Value); // Separate declaration for check
            string op =  _operator == null ? "" : _operator.Symbol;

            return _variable.Exponent!=0?  $"{op}{coefficient}{_unknown}{_variable.GetStringForm()}" : $"{op}{coefficient}{_unknown}";
        }

        /// <returns>The exponent of the variable</returns>
        public double GetExponent()
        {
            return _variable.Exponent;
        }

        public double Substitute(double value)
        {
            return Math.Pow(value, _variable.Exponent)*_coefficient.Value;
        }


        /// <summary>
        /// Multiplication and division
        /// </summary>
        public static bool AreSimilarTerms(Term a, Term b)
        {
            if (b._unknown == a._unknown)
            {
                if (b._variable.Letter == a._variable.Letter)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Arithmetic
        /// </summary>
        public static bool ArithmeticSimilarTerms(Term a, Term b)
        {
            if (b._unknown == a._unknown)
            {
                if (b._variable.Letter == a._variable.Letter && b._variable.Exponent == a._variable.Exponent)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// Scalar Multiplier
        /// </summary>
        /// <param name="a">Term to be mutiplied</param>
        /// <param name="b">The Factor to multiply by</param>
        /// <returns>The Product of the factor and the <see cref="Term"/>.</returns>
        public static Term operator *(Term a, double b)
        {
            return new Term(a._coefficient.Value * b,
                a._variable.Letter,
                (a._variable).Exponent);
        }


        // All operations assume that the variables are able to be operated on.
        public static Term operator *(Term a, Term b)
        {
            if (!AreSimilarTerms(a, b)) // In case of failure to properly implement OperatorService
            {
                throw new Exception();
            }

            return new Term(a._coefficient.Value * b._coefficient.Value,
                a._variable.Letter,
                (a._variable * b._variable).Exponent);
        }

        public static Term operator /(Term a, Term b)
        {
            if (!AreSimilarTerms(a, b)) // In case of failure to properly implement OperatorService
            {
                throw new Exception();
            }

            return new Term(a._coefficient.Value / b._coefficient.Value,
                a._variable.Letter,
                (a._variable / b._variable).Exponent);
        }

        public static Term operator +(Term a, Term b)
        {
            if (!ArithmeticSimilarTerms(a, b)) // In case of failure to properly implement OperatorService
            {
                throw new Exception();
            }

            return new Term((a._coefficient+ b._coefficient).Value, a._variable.Letter, a._variable.Exponent);
        }

        public static Term operator -(Term a, Term b)
        {
            if (!ArithmeticSimilarTerms(a, b)) // In case of failure to properly implement OperatorService
            {
                throw new Exception();
            }

            return new Term((a._coefficient - b._coefficient).Value, a._variable.Letter, a._variable.Exponent);
        }
    }
}
