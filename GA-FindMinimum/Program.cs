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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nBegin Evolutionary Optimization\n");

            Solution s = new Solution();

            Population p = s.Init();
            //p.CrossoverRate = 

            double[] result = s.Solve(p);


            Console.WriteLine("\nWhen x = {0} get Result = {1} \n",result[0], result[1]);

            Console.ReadLine();
        }
    }
}
