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
            //Generate polynomial function f(x) = x^5 + 3*x^4 - 2*x^3 - 4*x + 5
            Polynomial p = new Polynomial(5, -4, 0, -2, 3, 1);

            Complex c = new Complex();
            c.Re = x;

            //Evaluate with current x
            Complex r = p.Evaluate(c);
            
            return r.Re;
        }
    }
}
