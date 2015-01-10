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

        private int populationSize = 40;

        public int PopulationSize
        {
            get { return populationSize; }
            set { populationSize = value; }
        }

        private int chromosomeLength = 32;

        public int ChromosomeLength
        {
            get { return chromosomeLength; }
            set { chromosomeLength = value; }
        }

        private int iterations = 100;

        public int Iterations
        {
            get { return iterations; }
            set { iterations = value; }
        }

        private UserFunction userFunction;

        /// <summary>
        /// Initial population
        /// </summary>
        /// <returns>population</returns>
        public Population Init(int min, int max)
        {
            userFunction = new UserFunction(min, max);

            //we do minimization
            userFunction.Mode = OptimizationFunction1D.Modes.Minimization;

            Population population = new Population(populationSize, new BinaryChromosome(chromosomeLength),
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
            for (int i = 1; i <= iterations; i++)
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
