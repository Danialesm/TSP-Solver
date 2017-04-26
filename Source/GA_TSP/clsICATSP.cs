using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TSP
{
    struct Location
    {
        public int position;
        public double value;
    }

    class Solution
    {
        public int ColonyNumber = 0;
        public double averageOfClonyfitness = -1;
        public int attachedEmpire = -1;
        public Location[] loc;
        public double fitnessVal;
        public Solution(int length)
        {
            loc = new Location[length];
            fitnessVal = double.MaxValue;
            attachedEmpire = -1;
            averageOfClonyfitness = -1;
            fitnessVal = double.MaxValue;
        }
        public Solution Clone()
        {
            Solution tmpsol = new Solution(loc.Length);
            for (int i = 0; i < tmpsol.loc.Length; i++)
            {
                tmpsol.loc[i] = this.loc[i];
            }
            tmpsol.averageOfClonyfitness = this.averageOfClonyfitness;
            tmpsol.attachedEmpire = this.attachedEmpire;
            tmpsol.fitnessVal = this.fitnessVal;
            return tmpsol;
        }
    }
    
    class clsICATSP
    {
        protected Dictionary<int, Solution> ICA_Sols;
        protected Dictionary<int, Solution> Imperialists;
        private float[] fitness;
        private Random rnd = new Random(Environment.TickCount);
    
        protected int population = 120;
        protected int NumberOfImpearialist = 3;
        protected double Beta = 2;
        protected double Gamma = 1.5;
        //protected double landa = 1.03;//1.5;
        protected double Prev = 0.01;
        protected double[,] weight_array = new double[0, 0];
        public Solution BestSol;
        public double BestGlobalValue = double.MaxValue;
        private bool useNewOperator = true;

        public bool UseNewOperator
        {
            get { return useNewOperator; }
            set { useNewOperator = value; }
        }

        public clsICATSP(){}
        public clsICATSP(double[,] weights, int popsize,int numImp)
        {
            NumberOfImpearialist = numImp;
            BestGlobalValue = double.MaxValue;

            population = popsize;
            weight_array = weights;

            BestSol = new Solution(weight_array.GetUpperBound(0));
            fitness = new float[population];

            ICA_Sols = new Dictionary<int, Solution>(population);
            Imperialists = new Dictionary<int, Solution>(NumberOfImpearialist);

        }
        public void init()
        {
            // Create Random Solutions
            initialize();

            //Sort Solutions and Select Imperalists
            SelectImperialists();

            //find numer of clony for each imperalist
            SelectClony(Imperialists, population);
        }
        private void SelectClony(Dictionary<int, Solution> Imperalists, int popsize)
        {
            double[] Hn = new double[Imperalists.Count];
            double SumHn = 0;
            double[] En = new double[Imperalists.Count];
            int[] NumberOfClony = new int[Imperalists.Count];
            double WorstSolution = double.MinValue;

            for (int i = 0; i< ICA_Sols.Count; i++)
            {
                if (ICA_Sols[i].fitnessVal > WorstSolution)
                {
                    WorstSolution = ICA_Sols[i].fitnessVal;
                }
            }

            for (int i = 0; i < Imperalists.Count; i++)
            {
                Hn[i] = WorstSolution - Imperalists[i].fitnessVal;
                SumHn += Hn[i];
            }
            for (int i = 0; i < Imperalists.Count; i++)
            {
                En[i] = Hn[i] / SumHn;
                NumberOfClony[i] = (int)Math.Round(En[i] * (popsize - Imperalists.Count));
            }

            // Select Random Solution and attach to each Empire
            for (int k = 0; k < Imperalists.Count; k++)
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

        }
        protected virtual void SelectImperialists()
        {
            double[] sorted_fitness = new double[ICA_Sols.Count];
            int[] sorted_index = new int[ICA_Sols.Count];
            int endoflope;

            if (NumberOfImpearialist < fitness.Length - 1)
                endoflope = NumberOfImpearialist;
            else
                endoflope = fitness.Length - 1;


            for (int i = 0; i < endoflope; i++)
            {
                sorted_fitness[i] = ICA_Sols[i].fitnessVal;
                for (int j = i + 1; j < fitness.Length; j++)
                {
                    if (ICA_Sols[j].attachedEmpire != -3)
                    {
                        if (ICA_Sols[j].fitnessVal < sorted_fitness[i])
                        {
                            sorted_fitness[i] = ICA_Sols[j].fitnessVal;
                            sorted_index[i] = j;
                        }
                    }
                }
                ICA_Sols[sorted_index[i]].attachedEmpire = -3;
            }
            for (int i = 0; i < NumberOfImpearialist; i++)
            {
                ICA_Sols[sorted_index[i]].attachedEmpire = i;
                Imperialists.Add(i, ICA_Sols[sorted_index[i]].Clone());
            }
        }
        protected virtual void initialize()
        {
            for (int k = 0; k < population; k++)
            {
                ICA_Sols.Add(k, new Solution(weight_array.GetUpperBound(0)));

                for (int i = 0; i < weight_array.GetUpperBound(0); i++)
                {
                    ICA_Sols[k].loc[i].value = rnd.Next(0, 5000);
                    ICA_Sols[k].loc[i].position = i + 1;    
                }
                ICA_Sols[k].attachedEmpire = -1;
                ICA_Sols[k].fitnessVal = find_fitness_vector(ICA_Sols[k]);
            }
        }
        protected virtual double find_fitness_vector(Solution sol)
        {
            double return_value = 0;
            Solution sorted_sol = MakeUp_Solution(sol);
            for (int i = 0; i < sorted_sol.loc.Length - 1; i++)
            {
                return_value += weight_array[sorted_sol.loc[i].position, sorted_sol.loc[i + 1].position];
            }
            return_value += weight_array[sorted_sol.loc[sorted_sol.loc.Length - 1].position, sorted_sol.loc[0].position];
            return return_value;
        }
        public Solution MakeUp_Solution(Solution sol)
        {
            Solution solution = new Solution(weight_array.GetUpperBound(0));
            for (int i = 0; i < weight_array.GetUpperBound(0); i++)
                solution.loc[i] = sol.loc[i];

            for (int i = 0; i < weight_array.GetUpperBound(0) - 1; i++)
            {
                for (int j = i + 1; j < weight_array.GetUpperBound(0); j++)
                {
                    if (solution.loc[j].value < solution.loc[i].value)
                    {
                        Location tmploc;
                        tmploc = solution.loc[i];
                        solution.loc[i] = solution.loc[j];
                        solution.loc[j] = tmploc;
                    }
                }
            }
            solution.attachedEmpire = sol.attachedEmpire;
            solution.averageOfClonyfitness = sol.averageOfClonyfitness;
            solution.ColonyNumber = sol.ColonyNumber;
            solution.fitnessVal = sol.fitnessVal;
            return solution;
        }
        private Solution Reveloution(Solution solution)
        {
            Solution tmpSol = new Solution(weight_array.GetUpperBound(0));
            tmpSol = solution.Clone();

            for (int i = 0; i < tmpSol.loc.Length; i++)
            {
                double P = rnd.NextDouble();
                if (P < Prev)
                {
                    tmpSol.loc[i].value = rnd.Next(0, 5000);
                }
                tmpSol.loc[i].position = i + 1;
            }
            tmpSol.fitnessVal = find_fitness_vector(tmpSol);
            return tmpSol;
        }
        protected virtual Solution MoveClonies(Solution Imperialist, Solution Colony)
        {
            Solution tmpSol = new Solution(Colony.loc.Length);
            tmpSol = Colony.Clone();
            double[] RandomX = new double[Colony.loc.Length];
            double[] Distance = new double[Colony.loc.Length];
            double[] X = new double[Colony.loc.Length];
            for (int i = 0; i < RandomX.Length; i++)
            {
                RandomX[i] = rnd.NextDouble();
                Distance[i] = Imperialist.loc[i].value - Colony.loc[i].value;
                X[i] = Beta * Distance[i] * RandomX[i] + Math.Pow(-1, rnd.Next(1, 2)) * Prev * Distance[i];
                tmpSol.loc[i].value += X[i];
                if (tmpSol.loc[i].value < 0) Colony.loc[i].value = 0;
                if (tmpSol.loc[i].value > 5000) Colony.loc[i].value = 5000;
            }
            tmpSol.fitnessVal = find_fitness_vector(tmpSol);
            return tmpSol;
        }
        private Solution ReArrange(Solution newImp)
        {
            Solution ret = newImp.Clone();
            for (int i = 0; i < ret.loc.Length; i++)
            {
                for (int j = 0; j < newImp.loc.Length; j++)
                {
                    if (newImp.loc[j].position == i + 1)
                    {
                        ret.loc[i] = newImp.loc[j];
                        break;
                    }
                }
            }
            return ret;
        }

        private Solution MoveImperialist(Solution Imperialist1, Solution Imperialist2)
        {
            Solution tmpSol = new Solution(Imperialist1.loc.Length);
            
            double[] RandomX = new double[Imperialist1.loc.Length];
            double[] Distance = new double[Imperialist1.loc.Length];
            double[] X = new double[Imperialist1.loc.Length];

            tmpSol = Imperialist1.Clone();

            for (int i = 0; i < Imperialist2.loc.Length; i++)
            {
                RandomX[i] = rnd.NextDouble();
                Distance[i] = Imperialist2.loc[i].value - tmpSol.loc[i].value;
                X[i] = RandomX[i] * Distance[i];
                tmpSol.loc[i].value += X[i];
                if (tmpSol.loc[i].value < 0) tmpSol.loc[i].value = 0;
                if (tmpSol.loc[i].value > 5000) tmpSol.loc[i].value = 5000;
            }
            tmpSol.fitnessVal = find_fitness_vector(tmpSol);
            return tmpSol;
        }
        private Solution CrossOverImperialists(Solution Imperialist1, Solution Imperialist2)
        {
            Solution tmpSol = new Solution(Imperialist1.loc.Length);

            double[] RandomX = new double[Imperialist1.loc.Length];
            double[] Distance = new double[Imperialist1.loc.Length];
            double[] X = new double[Imperialist1.loc.Length];

            tmpSol = Imperialist1.Clone();
            int Start = rnd.Next(Imperialist1.loc.Length);
            for (int i = Start; i < RandomX.Length; i++)
                tmpSol.loc[i].value = Imperialist2.loc[i].value;
            tmpSol.fitnessVal = find_fitness_vector(tmpSol);
            return tmpSol;
        }

        public double[] RunEpoch()
        {            
            #region "Reveloution"
            for (int k = 0; k < ICA_Sols.Count; k++)
            {
                ICA_Sols[k] = Reveloution(ICA_Sols[k]);
            }
            #endregion           
            
            #region "Move Clonies"
            //Move Clony toward related Empire and Update Fitness values
            foreach (int k in Imperialists.Keys)
            {
                for (int i = 0; i < ICA_Sols.Count; i++)
                {
                    if (ICA_Sols[i].attachedEmpire == Imperialists[k].attachedEmpire)
                    {
                        ICA_Sols[i] = MoveClonies(Imperialists[k], ICA_Sols[i]);
                    }
                }
            }
            #endregion

            #region "My Operator - Upgrade Imperialists"

            if (useNewOperator == true)
            {
                #region "commented"
                //for (int k1 = 0; k1 < ICA_Sols.Count; k1++)
                //{
                //    if (ICA_Sols[k1].fitnessVal < (landa * BestGlobalValue))
                //    {
                //        for (int k2 = 0; k2 < ICA_Sols.Count; k2++)
                //        {
                //            if (ICA_Sols[k2].fitnessVal < (landa * BestGlobalValue))
                //            {
                //                Solution ret = new Solution(ICA_Sols[k1].loc.Length);
                //                //ret = CrossOverImperialists(ICA_Sols[k1], ICA_Sols[k2]);
                //                ret = MoveImperialist(ICA_Sols[k1], ICA_Sols[k2]);
                //                if (ret.fitnessVal < ICA_Sols[k1].fitnessVal && ret.fitnessVal < ICA_Sols[k2].fitnessVal)
                //                {
                //                    ICA_Sols[k1] = ret.Clone();
                //                    //break;
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion
                for (int k1 = 0; k1 < Imperialists.Count; k1++)
                {
                    #region "imperialist upgrade"

                    //for (int k2 = k1; k2 < Imperialists.Count; k2++)
                    //{
                    //    Solution ret = new Solution(Imperialists[k1].loc.Length);
                    //    if (Imperialists[k1].fitnessVal != Imperialists[k2].fitnessVal)
                    //    {
                    //        ret = CrossOverImperialists(Imperialists[k1], Imperialists[k2]);
                    //        if (ret.fitnessVal < Imperialists[k1].fitnessVal && ret.fitnessVal < Imperialists[k2].fitnessVal)
                    //        {
                    //            Imperialists[k1] = ret.Clone();
                    //        }
                    //        ret = CrossOverImperialists(Imperialists[k2], Imperialists[k1]);
                    //        if (ret.fitnessVal < Imperialists[k1].fitnessVal && ret.fitnessVal < Imperialists[k2].fitnessVal)
                    //        {
                    //            Imperialists[k2] = ret.Clone();
                    //        }
                    //    }
                    //}
                    
                    #endregion
                    for (int k2 = 0; k2 < ICA_Sols.Count; k2++)
                    {
                        if (ICA_Sols[k2].fitnessVal < (Gamma * Imperialists[k1].fitnessVal))
                        {
                            Solution ret = new Solution(Imperialists[k1].loc.Length);
                            ret = MoveImperialist(Imperialists[k1], ICA_Sols[k2]);
                            if (ret.fitnessVal < Imperialists[k1].fitnessVal)
                            {
                                Imperialists[k1] = ret.Clone();
                                //break;
                            }
                        }
                    }
                }
            }
            #endregion
            
            #region "Swap Clony with Imperialists"
            for (int k = 0; k < Imperialists.Count; k++)
            {
                for (int i = 0; i < ICA_Sols.Count; i++)
                {
                    if (ICA_Sols[i].attachedEmpire == Imperialists[k].attachedEmpire)
                    {
                        if (ICA_Sols[i].fitnessVal < Imperialists[k].fitnessVal)
                        {
                            Solution tmpSol = Imperialists[k].Clone();
                            Imperialists[k] = ICA_Sols[i].Clone();
                            ICA_Sols[i] = tmpSol.Clone();
                        }
                    }
                }
            }
            #endregion           
            
            #region "sort Imperialists"
            // sort Imperialists
            for (int k1 = 0; k1 < Imperialists.Count - 1; k1++)
            {
                for (int k2 = k1 + 1; k2 < Imperialists.Count; k2++)
                {
                    if (Imperialists[k2].fitnessVal < Imperialists[k1].fitnessVal)
                    {
                        Solution tmpSol = Imperialists[k2].Clone();
                        Imperialists[k2] = Imperialists[k1].Clone();
                        Imperialists[k1] = tmpSol.Clone();
                    }
                }
            }
            #endregion"
            
            #region "Imperialist Challenges"
            double WorstVal = double.MinValue;
            int minIndex = -1;

            for (int i = 0; i < ICA_Sols.Count; i++)
            {
                if (ICA_Sols[i].attachedEmpire == Imperialists[Imperialists.Count - 1].attachedEmpire)
                {
                    if (ICA_Sols[i].fitnessVal > WorstVal)
                    {
                        WorstVal = ICA_Sols[i].fitnessVal;
                        minIndex = i;
                    }
                }
            }

            double MaxTH = double.MinValue;
            double SumofNTH = 0;
            double[] TH = new double[Imperialists.Count];
            double[] NTH = new double[Imperialists.Count];
            double[] Z = new double[Imperialists.Count];
            double maxZ = double.MinValue;
            int ZIndex = 0;
            for (int k = 0; k < Imperialists.Count; k++)
            {
                double SumOfFitnesses = 0;
                int Count = 0;
                for (int i = 0; i < ICA_Sols.Count; i++)
                {
                    if (ICA_Sols[i].attachedEmpire == Imperialists[k].attachedEmpire)
                    {
                        Count++;
                        SumOfFitnesses += ICA_Sols[i].fitnessVal;
                    }
                }
                Imperialists[k].ColonyNumber = Count;
                //if (Count == 0) Count = 1;
                Imperialists[k].averageOfClonyfitness = SumOfFitnesses / (Count == 0?1:Count);
                TH[k] = Imperialists[k].fitnessVal + 0.5 * Imperialists[k].averageOfClonyfitness;
                if (TH[k] > MaxTH)
                {
                    MaxTH = TH[k];
                }
            }
            for (int k = 0; k < Imperialists.Count; k++)
            {
                NTH[k] = MaxTH - TH[k];
                SumofNTH += NTH[k];
            }
            for (int k = 0; k < Imperialists.Count; k++)
            {
                Z[k] = Math.Abs(NTH[k] / SumofNTH) - rnd.NextDouble();
                if (Z[k] > maxZ)
                {
                    maxZ = Z[k];
                    ZIndex = k;
                }
            }
            if (minIndex != -1)
            {
                ICA_Sols[minIndex].attachedEmpire = Imperialists[ZIndex].attachedEmpire;
            }
            #endregion
            
            #region "Imperialists Combination"
            
            Dictionary<int, Point> UniteImperialists = new Dictionary<int, Point>();
            for (int i = 0; i < Imperialists.Count; i++)
            {
                for (int j = i + 1; j < Imperialists.Count; j++)
                {
                    if (Imperialists[i].fitnessVal == Imperialists[j].fitnessVal)
                    {
                        UniteImperialists.Add(UniteImperialists.Count, new Point(Imperialists[i].attachedEmpire, Imperialists[j].attachedEmpire));
                        break;
                    }
                    //bool isUnique = true;
                    //Solution Imper1Sorted = MakeUp_Solution(Imperialists[i]);
                    //Solution Imper2Sorted = MakeUp_Solution(Imperialists[j]);
                    //for (int k = 0; k < Imper1Sorted.loc.Length; k++)
                    //{
                    //    if (Imper1Sorted.loc[k].position != Imper2Sorted.loc[k].position)
                    //    {
                    //        isUnique = false;
                    //        break;
                    //    }
                    //}
                    //if (isUnique)
                    //    UniteImperialists.Add(UniteImperialists.Count, new Point(Imperialists[i].attachedEmpire, Imperialists[j].attachedEmpire));
                }
            }
            foreach (int key in UniteImperialists.Keys)
            {
                for (int i = 0; i < ICA_Sols.Count; i++)
                {
                    if (ICA_Sols[i].attachedEmpire == UniteImperialists[key].Y)
                    {
                        ICA_Sols[i].attachedEmpire = UniteImperialists[key].X;
                    }
                }
            }
            
            #endregion
            
            #region "Imperialist elimination"
            // Remove Empty Imperialists
            if (Imperialists.Count > 1)
            {
                bool[] delete = new bool[Imperialists.Count];
                foreach (int k in Imperialists.Keys)
                {
                    delete[k] = false;
                    if (Imperialists[k].ColonyNumber == 0)
                    {
                        delete[k] = true;
                    }
                }

                for (int k = delete.Length - 1; k > 0; k--)
                {
                    if (delete[k] == true)
                    {
                        for (int i = k + 1; i < Imperialists.Count; i++)
                        {
                            Imperialists[i - 1] = Imperialists[i].Clone();
                        }
                        Imperialists.Remove(Imperialists.Count - 1);
                    }
                }
            }
            #endregion
            
            #region "Save Best Results"
            //////////////////////////////////////////////////////////////
            double BestValue = double.MaxValue;
            double AverageValue = 0;
            for (int i = 0; i < Imperialists.Count; i++)
            {
                if (Imperialists[i].fitnessVal < BestValue)
                {
                    BestValue = Imperialists[i].fitnessVal;
                    if (BestValue < BestGlobalValue)
                    {
                        BestGlobalValue = BestValue;
                        BestSol = Imperialists[i].Clone();
                        BestSol = MakeUp_Solution(BestSol);
                    }
                }
            }
            for (int i = 0; i < ICA_Sols.Count; i++)
            {
                AverageValue += ICA_Sols[i].fitnessVal;
                if (ICA_Sols[i].fitnessVal < BestValue)
                {
                    BestValue = ICA_Sols[i].fitnessVal;
                    if (BestValue < BestGlobalValue)
                    {
                        BestGlobalValue = BestValue;
                        BestSol = ICA_Sols[i].Clone();
                        BestSol = MakeUp_Solution(BestSol);
                    }
                }
            }
            AverageValue /= ICA_Sols.Count;
            #endregion
            return new double[3] { BestValue, AverageValue,Imperialists.Count };
        }

    }


}
