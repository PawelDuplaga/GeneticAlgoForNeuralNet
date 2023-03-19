using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        //temp_data
        private List<double> generations_avg_fitness;
        private List<double> generations_smallest_fitness;
        private List<double> generations_largest_fitness;


        public List<NeuralNetwork> RunAlgo (List<NeuralNetwork> startGeneration, )
        {
            
        }


        public List<NeuralNetwork> SelectNewGeneration(List<NeuralNetwork> pastGeneration)
        {
            List<NeuralNetwork> newGeneration = new List<NeuralNetwork>();

            while(newGeneration.Count < this.populationSize * this.newCandidatesInPopulationRatio)
            {
                List<NeuralNetwork> candidates = Selectors.RouletteSelection(pastGeneration,2);

                double temp_mutatationProbabilty = new Random().NextDouble();
                double temp_crossoverProbabilty = new Random().NextDouble();

                NeuralNetwork new_candidate = candidates[0];

                if (temp_crossoverProbabilty <= this.crossoverProbabilty)
                {
                    new_candidate = Crossover(candidates[0], candidates[1]);
                }
                if (temp_mutatationProbabilty <= this.crossoverProbabilty)
                {
                    new_candidate = Mutate(new_candidate);
                }

                newGeneration.Add(new_candidate);

            }

            while(newGeneration.Count < populationSize)
            {
                newGeneration.Add(pastGeneration[0].RadomizeWeights_XavierInitialization());
            }

            return newGeneration;
        }

        public setGenerationFitnesses(double[] fitnesses, List<NeuralNetwork> currGeneration)
        {
            for
        }


        //I need it more generic - need Change later
        public NeuralNetwork Mutate(NeuralNetwork net)
        {
            Random rand = new Random();

            for (int j = 0; j< net.WEIGHTS.Count;j++) 
            {
                for(int i = 0; i < net.WEIGHTS[j].rows;i++)
                {
                    for(int k=0; k < net.WEIGHTS[j].columns; k++)
                    {
                        double random_mutationGeneRatio = rand.NextDouble();
                        if(random_mutationGeneRatio < this.mutationGeneRatio)
                        {
                            double current_value = net.WEIGHTS[j][i, k];
                            int number_of_inputs = net.LAYERS[j].columns;
                            net.WEIGHTS[j][i, k] = MutateValueForXavierReLU(current_value, number_of_inputs);
                        }
                    }
                }
            }
            return net;
        }



        //public static double MutateValue(double value, double)
        //{
        //    Random rand = new Random();
        //    double noise = rand.NextDouble() * sigma;
        //    double sign = rand.NextDouble() < 0.5 ? -1.0 : 1.0;
        //    double mutatedValue = value + sign * noise;
        //    return mutatedValue;
        //}

        public static Func<double, int, double> MutateValueForXavierReLU => (value, n_in) =>
        {
            Random rand = new Random();
            double noise = rand.NextDouble() * Math.Sqrt(2 / n_in);
            double sign = rand.NextDouble() < 0.5 ? -1.0 : 1.0;
            double mutatedValue = value + sign * noise;
            return mutatedValue;
        };





        public NeuralNetwork Crossover(NeuralNetwork n1, NeuralNetwork n2)
        {
            return n1;
        }



        private class Selectors
        {

            public static List<NeuralNetwork> RouletteSelection(List<NeuralNetwork> generation, int numberOfDifferentCandidates)
            {

                double totafitness = generation.Sum(x => x.fintess);
                //generation.Sort((x,y) => y.fintess.CompareTo(x.fintess));
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
