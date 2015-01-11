using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AForge;
using AForge.Genetic;
using AForge.Controls;
namespace GA_FindMinimum
{
    class Solution
    {

        public int PopulationSize { get; set; }
        public int ChromosomeLength { get; set; }
        public int Iterations { get; set; }

        private UserFunction userFunction;

        public Solution()
        {
            PopulationSize = 40;
            ChromosomeLength = 32;
            Iterations = 100;
        }

        /// <summary>
        /// Initial population
        /// </summary>
        /// <returns>population</returns>
        public Population Init(int min, int max)
        {
            userFunction = new UserFunction(min, max);

            //we do minimization
            userFunction.Mode = OptimizationFunction1D.Modes.Minimization;

            Population population = new Population(PopulationSize, new BinaryChromosome(ChromosomeLength),
                userFunction, (ISelectionMethod)new RouletteWheelSelection());

            return population;
        }

        /// <summary>
        /// run genetic algorithm, find solution
        /// </summary>
        /// <param name="population"></param>
        /// <returns></returns>
        public double[] Solve(Population population)
        {
            double[] data = new double[2];

            // iterations
            for (int i = 1; i <= Iterations; i++)
            {
                // run one epoch of genetic algorithm, including crossover and mutate
                population.RunEpoch();

                data[0] = userFunction.Translate(population.BestChromosome);
                data[1] = userFunction.OptimizationFunction(data[0]);
            }

            return data;
        }

    }
}
