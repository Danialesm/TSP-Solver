using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TSP
{
    class clsMemeticSOM
    {
        private int popSize = 20;
        private clsSOMTSP[] individuals;
        public clsSOMTSP BestResult;
        public double BestFitness = double.MaxValue;
        private double[] fitnesses;
        private PointF[] Cities;
        private Random rnd = new Random(Environment.TickCount);
        private double[,] WeightArray;

        public clsMemeticSOM(int NumNN, int pop, double[,] weights, PointF[] inpCities, float Width, float Height)
        {
            popSize = pop;
            Cities = inpCities;

            WeightArray = weights;
            individuals = new clsSOMTSP[popSize];
            fitnesses = new double[popSize];

            for (int i = 0; i < popSize; i++)
            {
                int randomcity = rnd.Next(Cities.Length - 1);
                individuals[i] = new clsSOMTSP(NumNN, Cities, Cities[randomcity].X, Cities[randomcity].Y, Width, Height, 1000 * rnd.NextDouble());
            }
            BestResult = new clsSOMTSP(NumNN, Cities, 0, 0, Width, Height, 100);
        }
        public void RunEpoch(int MaxLearnEpoch, int CurrentEpoch)
        {
            int WorstIndex = -1;
            double WorstFitness = 0;
            for (int i = 0; i < popSize; i++)
            {
                //SOM Operator
                for (int j = 0; j < Cities.Length; j++)
                {
                    individuals[i].Learn(MaxLearnEpoch, CurrentEpoch);
                }
                //Maping Operator
                //individuals[i].FineTune();
                ////individuals[i].RemoveUnnecessary();
                //fitnesses[i] = individuals[i].findTourValue(WeightArray);
                fitnesses[i] = individuals[i].FindCurrentValue(WeightArray);
                if (fitnesses[i] < BestFitness)
                {
                    BestFitness = fitnesses[i];
                    for (int j = 0; j < individuals[0].Weights.Length; j++)
                        BestResult.Weights[j] = individuals[i].Weights[j];
                }
                if (fitnesses[i] > WorstFitness)
                {
                    WorstFitness = fitnesses[i];
                    WorstIndex = i;
                }
            }
            //Select Operator
            for (int i = 0; i < individuals[WorstIndex].Weights.Length; i++)
            {
                individuals[WorstIndex].Weights[i] = BestResult.Weights[i];
            }
        }

        public PointF[] GetBestWeights()
        {
            BestResult.FineTune();
            BestResult.RemoveUnnecessary();
            BestFitness = BestResult.EXfindTourValue(WeightArray);
            return BestResult.Weights;
        }


    }
}
