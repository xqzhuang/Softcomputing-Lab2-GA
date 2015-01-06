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
        public UserFunction() : base(new Range(0, 255)) { }

        public override double OptimizationFunction(double x)
        {
            //Generate polynomial function f(x) = x + x^2 + 3*x^3
            Polynomial p = new Polynomial(1, 0, 1, 3);      

            Complex c = new Complex();
            c.Re = x;

            //Evaluate with current x
            Complex r = p.Evaluate(c);
            
            //return Math.Cos(x / 23) * Math.Sin(x / 50) + 2;
            return r.Re;
        }
    }
}
