using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using MatrixAlgebraForDoubles;
using NeuralNetworkManager;

namespace GeneticAlgoForNeuralNet
{
    internal class GenAlgoNNet
    {
        public int populationSize = 100;
        public double newCandidatesInPopulationRatio = 0.2;
        public double crossoverProbabilty = 0.01;
        public double crossoverGeneRatio = 0.05;
        public double mutatationProbabilty = 0.01;
        public double mutationGeneRatio = 0.05;


        public void SelectNewGeneration(List<NeuralNetwork> pastGeneration)
        {
            List<NeuralNetwork> newGeneration = new List<NeuralNetwork>();

            while(newGeneration.Count < populationSize*newCandidatesInPopulationRatio)
            {
                List<NeuralNetwork> candidates = Selectors.RouletteSelection(pastGeneration,2);

                double temp_mutatationProbabilty = new Random().NextDouble();
                double temp_crossoverProbabilty = new Random().NextDouble();

                NeuralNetwork new_candidate = candidates[0];

                if (temp_crossoverProbabilty <= crossoverProbabilty)
                {
                    new_candidate = Crossover(candidates[0], candidates[1]);
                }
                if (temp_mutatationProbabilty <= crossoverProbabilty)
                {
                    new_candidate = Mutate(new_candidate);
                }

                newGeneration.Add(new_candidate);

            }


        }


        public NeuralNetwork Mutate(NeuralNetwork net)
        {
            return net;
        }

        public NeuralNetwork Crossover(NeuralNetwork n1, NeuralNetwork n2)
        {
            return n1;
        }



        private class Selectors
        {

            public static List<NeuralNetwork> RouletteSelection(List<NeuralNetwork> generation, int numberOfDifferentCandidates)
            {

                double totafitness = generation.Sum(x => x.fintess);
                List<NeuralNetwork> results = new List<NeuralNetwork>();


                while (results.Count() < numberOfDifferentCandidates)
                {
                    double cumulativeFitness = 0;
                    double roulettePosition = new Random().NextDouble();

                    for (int i = 0; i < generation.Count; i++)
                    {
                        cumulativeFitness += generation[i].fintess / totafitness;
                        if (cumulativeFitness >= roulettePosition)
                        {
                            if (results.Contains(generation[i])) break;
                            else results.Add(generation[i]);
                        }
                    }

                }

                return results;
            }

            public static List<NeuralNetwork> RouletteSelection(List<NeuralNetwork> generation, int numberOfDifferentCandidates, Func<double, double> RouletteAddingRatioFunc)
            {

                double totafitness = generation.Sum(x => RouletteAddingRatioFunc(x.fintess));
                List<NeuralNetwork> results = new List<NeuralNetwork>();
                

                while (results.Count() < numberOfDifferentCandidates) 
                {
                    double cumulativeFitness = 0;
                    double roulettePosition = new Random().NextDouble();

                    for (int i = 0; i < generation.Count; i++)
                    {
                        cumulativeFitness += RouletteAddingRatioFunc(generation[i].fintess) / totafitness;
                        if (cumulativeFitness >= roulettePosition)
                        {
                            if (results.Contains(generation[i])) break;
                            else results.Add(generation[i]);
                        }
                    }

                }

                return results;
            }

        }

    }
}
