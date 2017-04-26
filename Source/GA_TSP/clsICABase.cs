using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TSP
{
    class distPos
    {
        public int Position;
        public double Distance;
        public distPos(int pos, double dist)
        {
            this.Distance = dist;
            this.Position = pos;
        }
    }
    class clsICABase
    {
        private int SwapParameter = 4;
        public int swapParameter
        {
            get { return SwapParameter; }
            set { SwapParameter = value; }
        }
        private double PRev = 0.05;
        protected int population = 120;

        public clsSOMTSP BestSol;
        public double BestGlobalValue = double.MaxValue;

        protected int NumberOfImpearialist = 3;
        protected double[,] weight_array = new double[0, 0];

        PointF[] CitiesPosition;
        private double[] fitness;
        private Dictionary<int, clsSOMTSP> ICA_Sols;
        private Dictionary<int, clsSOMTSP> Imperialists;

        private Random rnd = new Random(Environment.TickCount);

        public clsICABase(double[,] weights, int popSize, int numImp, PointF[] Cities, int MaxIteration)
        {
            int impID = 0;

            weight_array = weights;
            population = popSize;
            NumberOfImpearialist = numImp;
            CitiesPosition = Cities;
            fitness = new double[Cities.Length];

            ICA_Sols = new Dictionary<int, clsSOMTSP>();
            Imperialists = new Dictionary<int, clsSOMTSP>();

            for (int i = 0; i < popSize; i++)
            {
                ICA_Sols.Add(i, new clsSOMTSP(4 * Cities.Length, Cities, 100));
                for (int k = 0; k < CitiesPosition.Length; k++)
                    ICA_Sols[i].Learn(MaxIteration, k);
                ICA_Sols[i].CurrentValue = ICA_Sols[i].FindCurrentValue(weight_array);
            }

            List<KeyValuePair<int, clsSOMTSP>> SortedArray = ICA_Sols.OrderBy(p => p.Value.CurrentValue).ToList();
            for (int i = 0; i < numImp; i++)
            {
                if (Imperialists.Count == 0)
                {
                    Imperialists.Add(impID, SortedArray[0].Value.Clone());
                    Imperialists[impID].averageOfClonyfitness = 0;
                    Imperialists[impID].attachedEmpire = impID;
                    for (int k = Cities.Length; k < MaxIteration; k++)
                        for (int l = 0; l < Cities.Length; l++)
                            Imperialists[impID].Learn(MaxIteration, k);
                    impID++;
                }
                else
                {
                    for (int j = 0; j < SortedArray.Count; j++)
                    {
                        if (SortedArray[j].Value.CurrentValue > Imperialists[impID - 1].CurrentValue)
                        {
                            Imperialists.Add(impID, SortedArray[j].Value.Clone());
                            Imperialists[impID].averageOfClonyfitness = 0;
                            Imperialists[impID].attachedEmpire = impID;
                            for (int k = Cities.Length; k < MaxIteration; k++)
                                for (int l = 0; l < Cities.Length; l++)
                                    Imperialists[impID].Learn(MaxIteration, k);
                            impID++;
                            break;
                        }
                    }
                }
            }
            SelectColony();
        }

        private void SelectColony()
        {
            double SumHn = 0;
            double[] Hn = new double[Imperialists.Count];
            double[] En = new double[Imperialists.Count];
            int[] NumberOfClony = new int[Imperialists.Count];
            double WorstSolution = double.MinValue;

            // Determine colony number of each Imperialist
            for (int i = 0; i < ICA_Sols.Count; i++)
            {
                if (ICA_Sols[i].CurrentValue > WorstSolution)
                {
                    WorstSolution = ICA_Sols[i].CurrentValue;
                }
            }
            for (int i = 0; i < Imperialists.Count; i++)
            {
                Hn[i] = WorstSolution - Imperialists[i].CurrentValue;
                SumHn += Hn[i];
            }
            for (int i = 0; i < Imperialists.Count; i++)
            {
                En[i] = Hn[i] / SumHn;
                NumberOfClony[i] = (int)Math.Round(En[i] * population);  //NumberOfClony[i] = (int)Math.Round(En[i] * (population - Imperialists.Count));
            }

            // Select Random Solution and attach to each Empire
            for (int k = 0; k < Imperialists.Count; k++)
            {
                int num = 0;
                for (int i = 0; i < ICA_Sols.Count; i++)
                {
                    if (ICA_Sols[i].attachedEmpire == -1)
                    {
                        ICA_Sols[i].attachedEmpire = k;
                        num++;
                    }
                    if (num >= NumberOfClony[k])
                        break;
                }
            }
            for (int k = ICA_Sols.Count - 1; k > 0; k--)
            {
                if (ICA_Sols[k].attachedEmpire == -1)
                    ICA_Sols[k].attachedEmpire = Imperialists.Count - 1;
                else
                    break;

            }
        }
        
        public double[] RunEpoch(int MaxEpoch,int currentEpoch)
        {
            long st = Environment.TickCount;

            #region "Reveloution"
            for (int k = 0; k < ICA_Sols.Count; k++)
            {
                if (rnd.NextDouble() < PRev)
                {
                    for (int i = 0; i < CitiesPosition.Length; i++)
                        ICA_Sols[k].Learn(MaxEpoch, MaxEpoch / 4);
                    //ICA_Sols[k].CurrentValue = ICA_Sols[k].FindCurrentValue(weight_array);
                }
            }
            #endregion           
            long rev = Environment.TickCount;

            #region "Move Clonies"
            foreach (int k in Imperialists.Keys)
            {
                for (int i = 0; i < ICA_Sols.Count; i++)
                {
                    if (ICA_Sols[i].attachedEmpire == Imperialists[k].attachedEmpire)
                        MoveClonies(Imperialists[k], ICA_Sols[i]);
                }
            }
            #endregion
            long move = Environment.TickCount;

            #region "Upgrade each colony"
            foreach (var item in ICA_Sols)
            {
                item.Value.Learn(MaxEpoch, CitiesPosition.Length + currentEpoch);
                item.Value.CurrentValue = item.Value.FindCurrentValue(weight_array);
            }
            #endregion
            long upgrade = Environment.TickCount;

            #region "Swap Clony with Imperialists"
            for (int k = 0; k < NumberOfImpearialist; k++)
            {
                if (Imperialists.ContainsKey(k))
                {
                    for (int i = 0; i < ICA_Sols.Count; i++)
                    {
                        if (ICA_Sols[i].attachedEmpire == Imperialists[k].attachedEmpire)
                        {
                            if (ICA_Sols[i].CurrentValue < Imperialists[k].CurrentValue)
                            {
                                clsSOMTSP tmpSol = Imperialists[k].Clone();
                                Imperialists[k] = ICA_Sols[i].Clone();
                                ICA_Sols[i] = tmpSol;
                            }
                        }
                    }
                }
            }
            #endregion           
            long swap = Environment.TickCount;

            #region "Find nurtalized colony"
            for (int i = 0; i < ICA_Sols.Count; i++)
            {
                if (ICA_Sols[i].CurrentValue == Imperialists[ICA_Sols[i].attachedEmpire].CurrentValue)
                {
                    int selaRandomImp = (int)rnd.Next(Imperialists.Keys.Min(), Imperialists.Keys.Max());
                    int NoiseRedius = (int)Math.Round(Math.Sqrt((ICA_Sols[i].firstHeight * ICA_Sols[i].firstHeight) + (ICA_Sols[i].firstWidth * ICA_Sols[i].firstWidth))) / 20;
                    int start = rnd.Next(0, ICA_Sols[i].Weights.Length / 2);
                    int end = rnd.Next(ICA_Sols[i].Weights.Length / 2 + 1, ICA_Sols[i].Weights.Length);
                    if (Imperialists.ContainsKey(selaRandomImp))
                    {
                        for (int j = start; j < end; j++)
                        {
                            ICA_Sols[i].Weights[j] = new PointF(Imperialists[selaRandomImp].Weights[j].X + rnd.Next(-NoiseRedius, NoiseRedius), Imperialists[selaRandomImp].Weights[j].Y + rnd.Next(-NoiseRedius, NoiseRedius));
                            ICA_Sols[i].Wins[j] = Imperialists[selaRandomImp].Wins[j];
                        }
                        ICA_Sols[i].CurrentValue = ICA_Sols[i].FindCurrentValue(weight_array);
                    }
                    else
                    {
                        for (int j = start; j < end; j++)
                        {
                            ICA_Sols[i].Weights[j] = new PointF(ICA_Sols[i].Weights[j].X + rnd.Next(-NoiseRedius / 20, NoiseRedius / 20), ICA_Sols[i].Weights[j].Y + rnd.Next(-NoiseRedius / 20, NoiseRedius / 20));
                        }
                        ICA_Sols[i].CurrentValue = ICA_Sols[i].FindCurrentValue(weight_array);
                    }
                }
            }
            #endregion

            #region "Imperialist Challenges"
            double WorstVal = double.MinValue;
            int minIndex = -1;
            int weakestImperialist = -1;
            Dictionary<int,clsSOMTSP>.KeyCollection ImpKeys = Imperialists.Keys;
            double[] SumOfFitnesses = new double[NumberOfImpearialist];
            for (int i = 0; i < ICA_Sols.Count; i++)
            {
                SumOfFitnesses[ICA_Sols[i].attachedEmpire] += ICA_Sols[i].CurrentValue;
            }
            foreach (int k in ImpKeys)
            {
                Imperialists[k].ColonyNumber = ICA_Sols.Count(p => p.Value.attachedEmpire == k);
                Imperialists[k].averageOfClonyfitness = SumOfFitnesses[k] / (Imperialists[k].ColonyNumber == 0 ? 1 : Imperialists[k].ColonyNumber);
            }

            if (Imperialists.Count > 1)
            {
                foreach (int i in ImpKeys)
                {
                    if (Imperialists[i].CurrentValue > WorstVal)
                    {
                        WorstVal = Imperialists[i].CurrentValue;
                        weakestImperialist = i;
                    }
                }

                WorstVal = double.MinValue;
                for (int i = 0; i < ICA_Sols.Count; i++)
                {
                    if (ICA_Sols[i].attachedEmpire == Imperialists[weakestImperialist].attachedEmpire)
                    {
                        if (ICA_Sols[i].CurrentValue > WorstVal)
                        {
                            WorstVal = ICA_Sols[i].CurrentValue;
                            minIndex = i;
                        }
                    }
                }
                if (minIndex != -1)
                {
                    double MaxTH = double.MinValue;
                    double SumofNTH = 0;
                    double[] TH = new double[NumberOfImpearialist];
                    double[] NTH = new double[NumberOfImpearialist];
                    double[] Z = new double[NumberOfImpearialist];
                    double maxZ = double.MinValue;
                    int ZIndex = 0;
                    foreach (int k in ImpKeys)
                    {
                        TH[k] = Imperialists[k].CurrentValue + 0.5 * Imperialists[k].averageOfClonyfitness;
                        if (TH[k] > MaxTH)
                            MaxTH = TH[k];
                    }
                    foreach (int k in ImpKeys)
                    {
                        NTH[k] = MaxTH - TH[k];
                        SumofNTH += NTH[k];
                    }
                    foreach (int k in ImpKeys)
                    {
                        Z[k] = Math.Abs(NTH[k] / SumofNTH) - rnd.NextDouble();
                        if (Z[k] > maxZ && k != ICA_Sols[minIndex].attachedEmpire)
                        {
                            maxZ = Z[k];
                            ZIndex = k;
                        }
                    }
                    ICA_Sols[minIndex].attachedEmpire = Imperialists[ZIndex].attachedEmpire;
                }
            }
            #endregion
            long challenge = Environment.TickCount;

            #region "Imperialist elimination"
            if (Imperialists.Count > 1)
            {
                bool[] delete = new bool[NumberOfImpearialist];
                foreach (int k in ImpKeys)
                {
                    delete[k] = false;
                    if (Imperialists[k].ColonyNumber == 0)
                    {
                        delete[k] = true;
                    }
                }

                for (int k = delete.Length - 1; k >= 0; k--)
                {
                    if (delete[k] == true)
                        Imperialists.Remove(k);
                }
            }
            #endregion
            long elimination = Environment.TickCount;

            #region "Save Best Results"
            //////////////////////////////////////////////////////////////
            double BestValue = double.MaxValue;
            double AverageValue = 0;
            foreach (int i in Imperialists.Keys)
            {
                if (Imperialists[i].CurrentValue < BestValue)
                {
                    BestValue = Imperialists[i].CurrentValue;
                    if (BestValue < BestGlobalValue)
                    {
                        BestGlobalValue = BestValue;
                        BestSol = Imperialists[i].Clone();
                    }
                }
            }
            for (int i = 0; i < ICA_Sols.Count; i++)
            {
                AverageValue += ICA_Sols[i].CurrentValue;
                if (ICA_Sols[i].CurrentValue < BestValue)
                {
                    BestValue = ICA_Sols[i].CurrentValue;
                    if (BestValue < BestGlobalValue)
                    {
                        BestGlobalValue = BestValue;
                        BestSol = ICA_Sols[i].Clone();
                    }
                }
            }
            AverageValue /= ICA_Sols.Count;
            #endregion
            long saveBest = Environment.TickCount;

            double perRev = (double)(rev - st) / (saveBest - st);
            double perMov = (double)(move - rev) / (saveBest - st);
            double perUpg = (double)(upgrade - move) / (saveBest - st);
            double perSwp = (double)(swap - upgrade) / (saveBest - st);
            double perCha = (double)(challenge - swap) / (saveBest - st);
            double perDel = (double)(elimination - challenge) / (saveBest - st);
            double perSav = (double)(saveBest - elimination) / (saveBest - st);

            return new double[3] { BestValue, AverageValue, Imperialists.Count };
        }

        private void MoveClonies(clsSOMTSP Imperialist, clsSOMTSP Colony)
        {
            List<distPos> distancesfromrandomCity1 = new List<distPos>(Imperialist.Weights.Length);
            List<distPos> distancesfromrandomCity2 = new List<distPos>(Colony.Weights.Length);
            int randomCity = rnd.Next(CitiesPosition.Length);

            for (int i = 0; i < Imperialist.Weights.Length; i++)
                distancesfromrandomCity1.Add(new distPos(i, distance(Imperialist.Weights[i], CitiesPosition[randomCity])));
            for (int i = 0; i < Colony.Weights.Length; i++)
                distancesfromrandomCity2.Add(new distPos(i, distance(Colony.Weights[i], CitiesPosition[randomCity])));

            distPos[] NearCities1 = distancesfromrandomCity1.OrderBy(o => o.Distance).Take(1).ToArray();
            distPos[] NearCities2 = distancesfromrandomCity2.OrderBy(o => o.Distance).Take(1).ToArray();

            int startImpIndex = (NearCities1[0].Position - SwapParameter / 2 < 0 ? Colony.Weights.Length + (NearCities1[0].Position - SwapParameter / 2) : NearCities1[0].Position - SwapParameter / 2);
            int startColIndex = (NearCities2[0].Position - SwapParameter / 2 < 0 ? Imperialist.Weights.Length + (NearCities2[0].Position - SwapParameter / 2) : NearCities2[0].Position - SwapParameter / 2);
            
            for (int i = 0; i < SwapParameter; i++)
            {
                if ((startColIndex + i < Colony.Weights.Length) && (startImpIndex + i < Imperialist.Weights.Length))
                {
                    Colony.Weights[startColIndex + i] = Imperialist.Weights[startImpIndex + i];
                    Colony.Wins[startColIndex + i] = Imperialist.Wins[startImpIndex + i];
                }
                else
                {
                    if (startColIndex + i >= Colony.Weights.Length)
                        startColIndex = -i;
                    if (startImpIndex + i >= Imperialist.Weights.Length)
                        startImpIndex = -i;
                    Colony.Weights[startColIndex + i] = Imperialist.Weights[startImpIndex + i];
                    Colony.Wins[startColIndex + i] = Imperialist.Wins[startImpIndex + i];
                }
            }
        }

        private double distance(PointF Pos1, PointF Pos2)
        {
            return ((Pos1.X - Pos2.X) * (Pos1.X - Pos2.X) + (Pos1.Y - Pos2.Y) * (Pos1.Y - Pos2.Y));
        }

    }
}
