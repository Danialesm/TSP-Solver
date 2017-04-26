using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TSP
{
    /// <summary>
    /// Programmer : Danial Esmaeili
    /// Version : 1.0.1
    /// Last Revision : 10/27/2010
    /// </summary>
    struct Gens
    {
        public int position;
        public float value;
    }
    struct Chromosome
    {
        public Gens[] Gen;
        public Chromosome(int length)
        {
            Gen = new Gens[length];
        }
    }
    class clsGATSP
    {
        private Dictionary<int, Chromosome> GA_Chrom;
        private Dictionary<int, Chromosome> MatingPool;
        private float[] fitness;
        private Random rnd = new Random(Environment.TickCount);
    
        private int population = 120;
        private int TorSize = 6;
        private float Pc = 0.6f, Pm = 0.04f, Pe = 0.005f;
        private double[,] weight_array = new double[0, 0];
        public Chromosome BestSol;
        public double BestGlobalValue = double.MaxValue;

        public clsGATSP(double[,] weights, int popsize)
        {
            BestGlobalValue = double.MaxValue; 
            population = popsize;
            weight_array = weights;
            BestSol = new Chromosome(weight_array.GetUpperBound(0));
            fitness = new float[population];
            GA_Chrom = new Dictionary<int, Chromosome>(population);
            MatingPool = new Dictionary<int, Chromosome>(population);
            initialize();
        }
        private void initialize()
        {
            for (int k = 0; k < population; k++)
            {
                GA_Chrom.Add(k, new Chromosome(weight_array.GetUpperBound(0)));

                for (int i = 0; i < weight_array.GetUpperBound(0); i++)
                {
                    GA_Chrom[k].Gen[i].value = rnd.Next(0, 5000);
                    GA_Chrom[k].Gen[i].position = i + 1;    
                }
                fitness[k] = find_fitness_vector(GA_Chrom[k]);
            }
        }
        public float[] RunEpoch()
        {
            MatingPool.Clear();

            // Selection of Mating pool by Tournament (size = TorSize)
            for (int k = 0; k < population; k++)
            {
                int minTorIndex = 0;
                double minTorValue = double.MaxValue;
                for (int tor = 1; tor <= TorSize; tor++)
                {
                    int srcpoint = rnd.Next(0, population);
                    if (fitness[srcpoint] < minTorValue)
                    {
                        minTorIndex = srcpoint;
                        minTorValue = fitness[srcpoint];
                    }
                }
                MatingPool.Add(k, GA_Chrom[minTorIndex]);
            }

            // Crossover
            for (int k = 0; k < population; k++)
            {
                double p = rnd.NextDouble();
                if (p < Pc)
                {
                    int srcpoint = rnd.Next(0, population);
                    int dstpoint = rnd.Next(0, population);
                    if (srcpoint != dstpoint)
                    {
                        Chromosome[] ret = crossover(MatingPool[srcpoint], MatingPool[dstpoint]);
                        MatingPool[srcpoint] = ret[0];
                        MatingPool[dstpoint] = ret[1];
                    }
                }
            }

            // Mutation
            for (int k = 0; k < population; k++)
            {
                MatingPool[k] = mutate(MatingPool[k]);
            }

            // Elitist
            if (BestGlobalValue != double.MaxValue)
            {
                for (int k = 0; k < population; k++)
                {
                    double p = rnd.NextDouble();
                    if (p < Pe)
                    {
                        MatingPool[k] = Elitist(MatingPool[k]);
                    }
                }
            }

            // Saving Mating Pool for next epoch
            for (int k = 0; k < population; k++)
            {
                for (int i = 0; i < weight_array.GetUpperBound(0); i++)
                {
                    GA_Chrom[k].Gen[i].position = MatingPool[k].Gen[i].position;
                    GA_Chrom[k].Gen[i].value = MatingPool[k].Gen[i].value;
                }
            }

            // update fitness values
            float[] returned = new float[2];
            float Min_Current = float.MaxValue;
            float Estimated_value = 0;
            fitness = new float[population];
            for (int k = 0; k < population; k++)
            {
                fitness[k] = find_fitness_vector(GA_Chrom[k]);
                Estimated_value += fitness[k];
                if (fitness[k] < Min_Current) //minimization
                {
                    if (fitness[k] < BestGlobalValue)
                    {
                        BestGlobalValue = fitness[k];
                        //SaveBestChromosome(sort_chormosome(GA_Chrom[k]));
                        SaveBestChromosome(GA_Chrom[k]);
                    }
                    Min_Current = fitness[k];
                }
            }
            Estimated_value /= population;
            returned[0] = Min_Current;
            returned[1] = Estimated_value;
            return returned;
        }
        private Chromosome Elitist(Chromosome chromosome)
        {
            Chromosome chrom = new Chromosome(weight_array.GetUpperBound(0));
            for (int i = 0; i < weight_array.GetUpperBound(0); i++)
            {
                chrom.Gen[i].value = BestSol.Gen[i].value;
                chrom.Gen[i].position = BestSol.Gen[i].position;//i + 1;
            }
            return chrom;
        }
        public Chromosome GetBestSolution()
        {
            Chromosome ret = new Chromosome(weight_array.GetUpperBound(0));
            for (int i = 0; i < weight_array.GetUpperBound(0); i++)
            {
                ret.Gen[i].value = BestSol.Gen[i].value;
                ret.Gen[i].position = BestSol.Gen[i].position;
            }
            ret = sort_chormosome(ret);
            return ret;
        }
        private Chromosome mutate(Chromosome chromosome)
        {
            Chromosome chrom = new Chromosome(weight_array.GetUpperBound(0));
            for (int i = 0; i < weight_array.GetUpperBound(0); i++)
                chrom.Gen[i] = chromosome.Gen[i];

            for (int i = 0; i < weight_array.GetUpperBound(0); i++)
            {
                double P = rnd.NextDouble();
                if (P < Pm)
                {
                    chrom.Gen[i].value = rnd.Next(0, 5000);
                }
                chrom.Gen[i].position = i + 1;
            }
            return chrom;
        }
        private Chromosome[] crossover(Chromosome chromosome_1, Chromosome chromosome_2)
        {
            Chromosome[] ret = new Chromosome[2];
            Chromosome tmp_chor1 = new Chromosome(weight_array.GetUpperBound(0));
            Chromosome tmp_chor2 = new Chromosome(weight_array.GetUpperBound(0));
            
            for (int i = 0; i < weight_array.GetUpperBound(0); i++)
                tmp_chor1.Gen[i] = chromosome_1.Gen[i];
            for (int i = 0; i < weight_array.GetUpperBound(0); i++)
                tmp_chor2.Gen[i] = chromosome_2.Gen[i];

            int position = rnd.Next(1, weight_array.GetUpperBound(0) - 1);

            for (int i = 0; i < position; i++)
            {
                tmp_chor1.Gen[i].value = chromosome_2.Gen[i].value;
                tmp_chor2.Gen[i].value = chromosome_1.Gen[i].value;
            }

            for (int i = 0; i < weight_array.GetUpperBound(0); i++)
            {
                tmp_chor1.Gen[i].position = i + 1;
                tmp_chor2.Gen[i].position = i + 1;
            }

            ret[0] = tmp_chor1;
            ret[1] = tmp_chor2;
            return ret;
        }
        private float find_fitness_vector(Chromosome chromosome)
        {
            double return_value = 0;
            Chromosome sorted_chromosome = sort_chormosome(chromosome);
            for (int i = 0; i < sorted_chromosome.Gen.Length - 1; i++)
            {
                return_value += weight_array[sorted_chromosome.Gen[i].position, sorted_chromosome.Gen[i + 1].position];
            }
            return_value += weight_array[sorted_chromosome.Gen[chromosome.Gen.Length - 1].position, sorted_chromosome.Gen[0].position];
            return (float)(return_value);
        }
        private Chromosome sort_chormosome(Chromosome chromosome)
        {
            Chromosome chor = new Chromosome(weight_array.GetUpperBound(0));
            for (int i = 0; i < weight_array.GetUpperBound(0); i++)
                chor.Gen[i] = chromosome.Gen[i];

            for (int i = 0; i < weight_array.GetUpperBound(0) - 1; i++)
            {
                for (int j = i + 1; j < weight_array.GetUpperBound(0); j++)
                {
                    if (chor.Gen[j].value < chor.Gen[i].value)
                    {
                        Gens tmpGen;
                        tmpGen = chor.Gen[i];
                        chor.Gen[i] = chor.Gen[j];
                        chor.Gen[j] = tmpGen;
                    }
                }
            }
            return chor;
        }      
        void SaveBestChromosome(Chromosome ch)
        {
            for (int i = 0; i < ch.Gen.Length; i++)
            {
                BestSol.Gen[i].value = ch.Gen[i].value;
                BestSol.Gen[i].position = ch.Gen[i].position;
            }
        }
    }
}
