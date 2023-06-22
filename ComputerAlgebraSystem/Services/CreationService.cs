using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ComputerAlgebraSystem.Services
{
    /// <summary>
    /// Handles the creation of Terms and Product Terms
    /// </summary>
    public static class CreationService
    {


        /// <returns>A quadratic with integer roots between (plus/minus) 1 and 8</returns>
        public static Expression CreateSimpleQuadratic() // Mainly a testing function using expansion service
        {
            Random rand = new Random();

            Expression roots = new Expression();
            roots.AddTerm(new Term(rand.Next(1, 8), 'x', 1));
            roots.AddTerm(new Term(rand.Next(1, 8), 'x', 2));
            roots.AddTerm(new Term(rand.Next(-8, 8), 'x', 0));

            return roots;
        }

    }
}
