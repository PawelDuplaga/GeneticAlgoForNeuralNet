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
                NeuralNetwork n1 = RouletteSelection(pastGeneration);
                NeuralNetwork n2 = RouletteSelection(pastGeneration);

                double temp_mutatationProbabilty = new Random().NextDouble();
                double temp_crossoverProbabilty = new Random().NextDouble();

                if (temp_mutatationProbabilty <= crossoverProbabilty)
                {
                    n1 = Mutate(n1);
                }
            }


        }


        public NeuralNetwork Mutate(NeuralNetwork net)
        {
            return net;
        }

        public (NeuralNetwork n1, NeuralNetwork n2) Crossover(NeuralNetwork n1, NeuralNetwork n2)
        {
            return (n1, n2);
        }



        public NeuralNetwork? RouletteSelection(List<NeuralNetwork> generation, Func<double,double> transformFunction)
        {

            double totafitness = generation.Sum(x => transformFunction(x.fintess));
            double roulettePosition = new Random().NextDouble();
            double cumulativeFitness = 0;

            foreach(var net in generation)
            {
                cumulativeFitness += transformFunction(net.fintess / totafitness);
                if(cumulativeFitness >= roulettePosition) 
                {
                    return net;
                }
            }

            return null;
        }

        


    }
}
