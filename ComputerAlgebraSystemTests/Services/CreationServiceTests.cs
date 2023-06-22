using Microsoft.VisualStudio.TestTools.UnitTesting;
using ComputerAlgebraSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerAlgebraSystem.Services.Tests
{
    [TestClass()]
    public class CreationServiceTests
    {
        [TestMethod()]
        public void CreateSimpleQuadraticTest()
        {
            Expression a = CreationService.CreateSimpleQuadratic();

            //Console.WriteLine(a.GetStringForm());
            Assert.IsTrue(a.GetDegree() == 2);
        }
    }
}