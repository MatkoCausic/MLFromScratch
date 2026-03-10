using System;
using System.Collections.Generic;
using System.Text;

namespace Machine_Learning.Optimisation_Methods
{
    internal class Genetic_Algorithm
    {
        int populationSize;
        int numberOfGenerations;
        float crossoverProbability;
        float mutationProbability;
        float mutation_deviation;

        public Genetic_Algorithm(int populationSize, int numberOfGenerations, float crossoverProbability, float mutationProbability, float mutation_deviation)
        {
            this.populationSize = populationSize;
            this.numberOfGenerations = numberOfGenerations;
            this.crossoverProbability = crossoverProbability;
            this.mutationProbability = mutationProbability;
            this.mutation_deviation = mutation_deviation;
        }
        
        public void Execute()
        {
            GeneratePopulation();
            FitnessFunction();
            if (!TerminateCondition())
            {
                Selection();
                Crossover();
                Mutation();
            }
        }

        double[][] GeneratePopulation()
        {

        }
        void Selection();
        void Crossover();
        void Mutation();
        float FitnessFunction();
        bool TerminateCondition();
    }
}
