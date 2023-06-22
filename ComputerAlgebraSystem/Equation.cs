using ComputerAlgebraSystem.Plotting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem
{
    public class Equation
    {
        private protected Expression[]? _expressions;
        private bool solvingSolution; // for: 'public Equation(Expression expressionOne, Expression expressionTwo)'


        /// <summary>
        /// For solving, or plotting, f(x)=g(x)
        /// </summary>
        /// <param name="expressionOne">f(x)</param>
        /// <param name="expressionTwo">g(x)</param>
        public Equation(Expression expressionOne, Expression expressionTwo)
        {
            //throw new NotImplementedException();
            _expressions = new Expression[2];

            // y = f(x)
            Expression y = new Expression();
            y.AddTerm(new Term(1, 'y', 1));

            _expressions[0] = y;
            _expressions[1] = expressionTwo-expressionOne; // f(x)-g(x)



            //Implementation Ideas:
            //f(x)=g(x)
            //f(x)-g(x)=0
            //R(x)=f(x)-g(x)
            //R(x) solutions could be calculated as [r0, r1, r2,...rn];
            //Then assume that y=f(x) and for f(rn)
            //Solutions for R(x) = [(r0, f(r0),(r1, f(r1),...,(rn, f(rn))]
        }



        /// <summary>
        /// For solving, or plotting, y=f(x)
        /// </summary>
        /// <param name="expression">f(x)</param>
        /// <exception cref="Exception">If the expression is null.</exception>
        public Equation(Expression expression)
        {
            _expressions = new Expression[2];
            if (expression == null)
            {
                throw new Exception();
            }

            // y = g(x)
            Expression y = new Expression();
            y.AddTerm(new Term(1, 'y', 1));


            _expressions[0] = y;
            _expressions[1] = expression;
        }


        public string GetStringForm()
        {
            return $"{_expressions[0].GetStringForm()}={_expressions[1].GetStringForm()}";
        }

        /// <summary>
        /// Calculates a jagged array of cartesian points; only for f(x).
        /// </summary>
        /// <param name="plotView"></param>
        /// <returns>Cartesian Coordinates in an array</returns>
        /// <remarks>An array is a more efficient data-structure than a object.</remarks>
        public double[][] PlotValues(PlotView plotView) // It will be more efficient to plot values from array than from. 
        {
            //Maybe custom decimal type in future; [hatred of floating point numbers...]
            double[][] CartesianCoordinates = new double[plotView.X_Detail+1][];

            // Better than recalculating each time in loop.
            double incrementCounter = plotView.XStartValue;
            double increment = plotView.X_GetIncrement();

            

            for (int i = 0; i < CartesianCoordinates.Length; i++) 
            {
                // Calculations
                double[] coords = new double[2]; // [(x0, y0),(x1, y1),....,(xn, yn)]
                coords[0] = incrementCounter;
                coords[1] = _expressions[1].Substitute(incrementCounter); // can't be null;
                // Value Set
                CartesianCoordinates[i] = coords;
                //Increment
                incrementCounter += increment;
            }

            CartesianCoordinates = PlotTrim(plotView, CartesianCoordinates);

            return CartesianCoordinates;
        }

        /// <summary>
        /// Trims values in a select plot from y values
        /// </summary>
        private double[][] PlotTrim(PlotView plotView, double[][] plot) // Easier than inverse functions to implement
        {
            for (int rootPair =0;  rootPair < 2; rootPair++) { }
            
            double[][] rootsU = FindRoots(_expressions[1], plotView.YStartValue, plotView);
            plot = ValueTrim(rootsU, plot);
            double[][] rootsL = FindRoots(_expressions[1], plotView.YEndValue, plotView);
            plot = ValueTrim(rootsL, plot);
            return plot;
        }


        private double[][] ValueTrim(double[][] roots, double[][] plot)
        {
            for (int i = 0; i < roots.Length; i++)
            {
                bool removedExcess = false;
                int lower = 0;
                int upper = plot.Length - 1;
                int accuracyCount = 0;


                while (!removedExcess) //Binary Search
                {
                    int midpoint = (int)((lower + upper) / 2d);

                    if (Math.Abs(plot[midpoint][0] - roots[i][0]) < 0.00005 + 0.00001 * accuracyCount) // Desired
                    {
                        List<double[]> tempStore = plot.ToList();
                        if (roots[i][1] > 0)
                        {
                            tempStore.RemoveRange(roots[i][0] < 0 ? 0 : midpoint, roots[i][0] >= 0 ? tempStore.Count - midpoint : midpoint);
                        }
                        else if (roots[i][1] > 0)
                        {
                            tempStore.RemoveRange(roots[i][0] < 0 ? midpoint : 0, roots[i][0] >= 0 ? 0 : tempStore.Count - midpoint);
                        }

                        plot = tempStore.ToArray();
                        removedExcess = true;
                    }
                    else if (plot[midpoint][0] < roots[i][0])
                    {
                        lower = midpoint;
                    }
                    else if (plot[midpoint][0] > roots[i][0])
                    {
                        upper = midpoint;
                    }
                    accuracyCount++;
                }
            }
            return plot;
        }

        /// <summary>
        /// f(x)=k
        /// </summary>
        /// <param name="a">f(x)</param>
        /// <param name="b">k</param>
        /// <returns>h(x)=f(x)-k values</returns>
        /// <remarks>If <see langword="null"/> there are no roots or not compatible yet.</remarks>
        public static double[][]? FindRoots(Expression a, double b, PlotView plotView) // Lots of different optimised methods; try logical later
        {
            Expression rooting = a - (new Expression(new Term(plotView.YEndValue, 'x', 0)));
            double[]? Xroots = QuadraticFormula(a);

            if (Xroots != null)
            {
                double[][] roots = new double[2][];
                roots[0] = new double[2] { Xroots[0], a.Substitute(Xroots[0]) };
                roots[1] = new double[2] { Xroots[1], a.Substitute(Xroots[1]) };
                return roots;
            }
            else if (a.GetDegree() ==1)
            {
                double root = a.FindPowerTermCoefficient(0) / a.FindPowerTermCoefficient(1);
                double[] roots = new double[2] { root, a.Substitute(root) };
                return new double[1][] { roots };
            }
            else
            {
                return null;
            }
        }

        public static double Discriminant(double a, double b, double c) //ax^2+bx+c
        {
            return (Math.Pow(b,2)-4*a*c);
        }

        public static double[]? QuadraticFormula(Expression expression)
        {
            if (expression.GetDegree() == 2)
            {
                // They can't be null here!
                double a = expression.FindPowerTermCoefficient(2);
                double b = expression.FindPowerTermCoefficient(1);
                double c = expression.FindPowerTermCoefficient(0);

                double descriminant = Discriminant(a, b, c);

                if (descriminant >= 0)
                {
                    double[]? doubles = new double[2] { (-Math.Pow(b, 2) - Math.Sqrt(descriminant)) / (2 * a) , (-Math.Pow(b, 2) + Math.Sqrt(descriminant)) / (2 * a) };
                    return doubles;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
