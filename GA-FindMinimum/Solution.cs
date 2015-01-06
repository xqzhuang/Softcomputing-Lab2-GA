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

        private UserFunction userFunction = new UserFunction();

        /// <summary>
        /// Initial population
        /// </summary>
        /// <returns>population</returns>
        public Population Init()
        {
            //minimization
            userFunction.Mode = OptimizationFunction1D.Modes.Minimization;

            Population population = new Population(populationSize, new BinaryChromosome(chromosomeLength),
                userFunction, (ISelectionMethod)new RankSelection());


            return population;
        }

        /// <summary>
        /// run genetic algorithm, find solution
        /// </summary>
        /// <param name="population"></param>
        /// <returns></returns>
        public double[] Solve(Population population)
        {
            // iterations
            int i = 1;

            double[] data = new double[2];

            while (true)
            {
                // run one epoch of genetic algorithm, including crossover and mutate?
                population.RunEpoch();            

                data[0] = userFunction.Translate(population.BestChromosome);
                data[1] = userFunction.OptimizationFunction(data[0]);

                // increase current iteration
                i++;

                if ((iterations != 0) && (i > iterations))
                    break;
            }

            return data;
        }

    }
}
