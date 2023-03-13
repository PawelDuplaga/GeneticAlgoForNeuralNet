using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixAlgebraForDoubles;
using NeuralNetworkManager;

namespace GeneticAlgoForNeuralNet
{
    internal class GenAlgoNNet
    {
        public int populationSize = 100;









        public NeuralNetwork? RouletteSelection(NeuralNetwork[] generation)
        {

            double totafitness = generation.Sum(x => x.fintess);
            double roulettePosition = new Random().NextDouble();
            double cumulativeFitness = 0;

            foreach(var net in generation)
            {
                cumulativeFitness += net.fintess / totafitness;
                if(cumulativeFitness >= roulettePosition) 
                {
                    return net;
                }
            }

            return null;
        }

        


    }
}
