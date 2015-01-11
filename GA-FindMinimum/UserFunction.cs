using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PolyLib;
using AForge;
using AForge.Genetic;
using AForge.Controls;

namespace GA_FindMinimum
{
    class UserFunction : OptimizationFunction1D
    {
        public UserFunction(int min, int max) : base(new Range(min, max)) { }

        public override double OptimizationFunction(double x)
        {
            // Generate polynomial which is an integral of (x+20)*(x+14)*(x+3)*(x-15)*(x-24)

            // P(x) = (1/6)*x^6 - (2/5)*x^5 - (701/4)*x^4 - 246*x^3 + 52380*x^2 + 302400*x

            // local minima: {x = -20, x = -3, x = 24}

            Polynomial p = new Polynomial(0, 302400, 52380, -246, -701d/4d, -2d/5d, 1d/6d);

            Complex c = new Complex();
            c.Re = x;

            //Evaluate with current x
            Complex r = p.Evaluate(c);
            
            return r.Re;
        }
    }
}
