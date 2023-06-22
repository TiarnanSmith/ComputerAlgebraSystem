using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerAlgebraSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using ComputerAlgebraSystem.Plotting;

namespace ComputerAlgebraSystem.Tests
{
    [TestClass()]
    public class EquationTests
    {
        [TestMethod()]
        public void PlotValuesTest() // Uses all the types and references in a non-structural way. 
        {
            PlotView plotView = new PlotView(0, 5, 0, 10);

            Expression expression = new Expression();
            Term t = new Term(0.5, 'x', 2);
            expression.AddTerm(t);

            Equation Equation = new Equation(expression);

            // List<double[]> :(, should of just used objects, for f**ks sake...

            List<double[]> val = new List<double[]>();

            val = (Equation.PlotValues(plotView)).ToList<double[]>();

            string[] r = new string[val.Count];
            for(int i = 0; i < r.Length; i++)
            {
                string j = $"{val[i][0]}, {val[i][1]}";
                r[i] = j;
            }

            //File.WriteAllLines(@"C:\Users\tiarn\Desktop\Programing\ComputerAlgebraSystem\ComputerAlgebraSystemTests\values.csv", r);

            Assert.IsTrue(val.Count == 1281); ; // Manual Check
        }
    }
}