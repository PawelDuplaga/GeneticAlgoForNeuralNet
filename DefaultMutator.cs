using NeuralNetworkManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoForNeuralNet
{
    public class DefaultMutator : IMutator
    {
        public NeuralNetwork Mutate(NeuralNetwork nnet)
        {
            return nnet;
        }
    }
}
