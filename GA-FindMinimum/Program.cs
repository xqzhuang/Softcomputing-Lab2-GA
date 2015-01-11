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
            Console.WriteLine("Begin Evolutionary Optimization");

            Solution s = new Solution();

            int[][] ranges = {
                                new int[] {-25, -11},
                                new int[] {-11, 7},
                                new int[] {7, 27}
                                };

            foreach (int[] range in ranges)
            {
                Population p = s.Init(range[0], range[1]);

                double[] result = s.Solve(p);

                Console.WriteLine("\n================================================");
                Console.WriteLine("Range: x >= {0} && x <= {1} ", range[0], range[1]);
                Console.WriteLine("Local minimum: x = {0}, y = {1}", result[0], result[1]);
            }

            Console.WriteLine("\nEND");
            Console.ReadLine();

            //for (int i = -3; i <= 4; i++)
            //{
            //    Population p = s.Init(i, i+1);

            //    double[] result = s.Solve(p);

            //    Console.WriteLine("\n================================================");
            //    Console.WriteLine("Range: x >= {0} && x <= {1} ", i, i+1);
            //    Console.WriteLine("When x = {0}  get local minimun = {1}", result[0], result[1]);
            //}

            //Console.WriteLine("\nEND");
            //Console.ReadLine();
        }
    }
}
