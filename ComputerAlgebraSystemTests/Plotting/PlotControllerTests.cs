using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerAlgebraSystem.Plotting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerAlgebraSystem.Services;

namespace ComputerAlgebraSystem.Plotting.Tests
{
    [TestClass()]
    public class PlotControllerTests
    {
        [TestMethod()]
        public void PlotControllerTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void UpdatePlotTest()
        {
            //Assert.Fail();
        }

        [TestMethod()]
        public void SetNewPlotTest()
        {
           // Assert.Fail();
        }

        [TestMethod()]
        public void XApproximateValueTest()
        {
            Random random = new Random();
            double subVal = random.NextDouble()*20;

            Expression one = CreationService.CreateSimpleQuadratic();
            Equation equation = new Equation(one);
            PlotController plotter = new PlotController(0, 20, 0, 5, equation);

            double[] coords = plotter.XApproximateValue(subVal);
            double sub = one.Substitute(subVal);

            //Console.WriteLine(one.GetStringForm());
            Console.WriteLine($"{subVal}: Approximate {coords[1]}, Substitution {sub}");

            Assert.IsTrue(Math.Abs(coords[1]-sub)<0.0005);
        }
    }
}