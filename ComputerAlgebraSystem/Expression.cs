using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    // could use hashing in future
    public class Expression
    {
        private protected List<Term> _terms;
        private protected List<Term>? _productTerms => throw new NotImplementedException();

        public Expression()
        {
            _terms = new List<Term>();
        }

        public Expression(List<Term> terms)
        {
            _terms = terms;
        }

        public Expression(Term term)
        {
            _terms = new List<Term>() { term };
        }

        /// <summary>
        /// Substitutes a number into the expression 
        /// </summary>
        /// <param name="value">Variable value to substitute</param>
        /// <returns></returns>
        public double Substitute(double x)
        {
            double sum = 0;
            for (int i = 0; i < _terms.Count; i++)
            {
                sum+=_terms[i].Substitute(x);
            }
            return sum;
        }

        // fix this documentation
        /// <summary>
        /// Substitutes a number into the expression 
        /// </summary>
        /// <param name="x">Variable value to substitute</param>
        /// <param name="k">A Unknown value</param>
        public double Substitute(double x, double k)
        {
            throw new NotImplementedException();
        }




        public void AddTerm(Term term) // O(n^2)
        {
            
            if (_terms != null || _terms.Count != 0)
            {
                // BAD [FIX THIS]
                for (int i = 0; i < _terms.Count; i++)
                {
                    //Console.WriteLine($"{_terms[i].GetStringForm()} and {term.GetStringForm()} are {Term.ArithmeticSimilarTerms(_terms[i], term)}");
                    if (Term.ArithmeticSimilarTerms(_terms[i], term))
                    {
                        _terms[i] = _terms[i] + term;
                        return;
                    }
                }
            }
            
            
            _terms.Add(term);
        }

        /// <summary>
        /// f(x)=a+b
        /// </summary>
        /// <param name="a">A simplified expression.</param>
        /// <param name="b">A expression</param>
        /// <returns>f(x)</returns>
        public static Expression operator +(Expression a, Expression b) // O(n)
        {
            Expression z = a;

            for (int k = 0; k < b._terms.Count; k++)
            {
                z.AddTerm(b._terms[k]);
            }

            return z;
        }

        /// <summary>
        /// f(x)=a-b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>f(x)</returns>
        public static Expression operator -(Expression a, Expression b) // O(n)
        {
            Expression z = a;

            for (int k = 0; k < b._terms.Count; k++)
            {
                z.AddTerm(b._terms[k]*-1d); // Hacky solution.
            }

            return z;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Expression operator *(Expression a, Expression b)
        {
            Expression z = new Expression(); 

            for (int i = 0; i < a._terms.Count; i++)
            {
                for (int k = 0; k < b._terms.Count; k++)
                {
                    z.AddTerm((a._terms[i] * b._terms[k]));
                }
            }

            return z;
        }

        /// <summary>
        /// Scalar Multiplication
        /// </summary>
        /// <param name="a"><see cref="Expression"/> to be mutiplied by.</param>
        /// <param name="b">The factor as which to multiply by.</param>
        /// <returns>The Product of the <see cref="Expression"/> and <see cref="double"/>.</returns>
        public static Expression operator *(Expression a, double b)
        {
            Expression z = new Expression();

            for (int i = 0; i < a._terms.Count; i++)
            {
                z.AddTerm((a._terms[i] * b));
            }

            return z;
        }

        /// <summary>
        /// Polynomial Davison
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static Expression operator /(Expression a, Expression b)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// Gets <see cref="string"/> form of <see cref="Expression"/>.
        /// </summary>
        /// <returns>The expression represented as a <see cref="string"/>.</returns>
        public string GetStringForm()
        {
            string returnStr = "";

            for (int i = 0; i < _terms.Count; i++)
            {
                returnStr = $"{returnStr}{_terms[i].GetStringForm()}";
            }

            return (returnStr.Substring(0,1)== "+") ? returnStr.TrimStart('+'): returnStr  ;
        }

        /// <summary>
        /// Gets the degree of the expression in int form.
        /// </summary>
        /// <returns>The degree of the expression</returns>
        /// <remarks>Returns null when the EQ doesn't have an degree.</remarks>
        public int? GetDegree() // 
        {
            int? degree = 0;

            for (int i = 0; i < _terms.Count; i++)
            {
                double exp = _terms[i].GetExponent();
                if (Math.Floor(exp) != exp)
                {
                    return null;
                }
                else if (_terms[i].GetExponent() > degree)
                {
                    degree = (int)exp;
                }
            }

            return degree;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">Desired Power of the 'x' term of the Coefficient.</param>
        /// <returns>The coefficient.</returns>
        /// <remarks>If <see langword="null"/>, there is no term with the power 'a'.</remarks>
        public double FindPowerTermCoefficient(double a)
        {
            for (int i = 0; i < _terms.Count; ++i)
            {
                if (_terms[i].GetExponent() == a)
                {
                    return _terms[i].GetCoefficient() ;
                }
            }
            return 0;
        }
    }
}
