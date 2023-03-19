using NeuralNetworkManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoForNeuralNet
{
    public interface IMutator
    {
        public NeuralNetwork Mutate(NeuralNetwork neuralNet);

    }
}
