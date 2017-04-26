using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TSP
{
    class clsSOMTSP
    {
        public int ColonyNumber = 0;
        public int attachedEmpire = -1;
        public double averageOfClonyfitness = 0;

        public double _baseBeta = 50;
        //public bool isStopped = false;
        public int numberOfStoppedframe = 0;
        private double[,] cities_d;

        public int[,] d;
        public int[] Wins;
        public PointF[] Weights;
        private PointF[] Cities;
        public PointF[] CitiesImporter
        {
            get { return Cities; }
            set { Cities = value; }
        }
        private double landa = 100;
        public double CurrentValue;
        Random rnd = new Random(Environment.TickCount);
        public float firstX0, firstY0, firstWidth, firstHeight;

        public clsSOMTSP(int numNN, PointF[] inpCities, float X0, float Y0, float widthOfArea, float heightOfArea, double inpLanda, double inpBeta = 50)
        {
            _baseBeta = inpBeta;
            attachedEmpire = -1;
            Cities = inpCities;
            landa = inpLanda;
            double numCities = inpCities.Length - 1;
            //initialize Weights
            Weights = new PointF[numNN];
            Wins = new int[numNN];
            cities_d = new double[Cities.Length, Cities.Length];
            for (int i = 0; i < numNN; i++)
            {
                Weights[i].X = (float)(X0 + widthOfArea * Math.Cos(i * (360.0 / numNN) * Math.PI / 180.0));
                Weights[i].Y = (float)(Y0 + heightOfArea * Math.Sin(i * (360.0 / numNN) * Math.PI / 180.0));
            }
            firstX0 = X0; firstY0 = Y0; firstWidth = widthOfArea; firstHeight = heightOfArea;
            FindAllWeights_Array();
            //FindAllD();
        }

        public clsSOMTSP(int numNN, PointF[] inpCities, double inpLanda, bool isFirst)
        {
            attachedEmpire = -1;
            Cities = inpCities;
            landa = inpLanda;
            double numCities = inpCities.Length - 1;
            //initialize Weights
            Weights = new PointF[numNN];
            Wins = new int[numNN];
            cities_d = new double[Cities.Length, Cities.Length];
            //if (isFirst == true)
            {
                FindAllWeights_Array();
                //FindAllD();
            }
        }

        public clsSOMTSP(int numNN, PointF[] inpCities, double inpLanda)
        {
            attachedEmpire = -1;
            Cities = inpCities;
            landa = inpLanda;
            double numCities = inpCities.Length - 1;

            //initialize Weights
            Weights = new PointF[numNN];
            Wins = new int[numNN];
            cities_d = new double[Cities.Length, Cities.Length];

            float X0 = 0, Y0 = 0;

            float minX = float.MaxValue, minY = float.MaxValue;
            float maxX = float.MinValue, maxY = float.MinValue;

            for (int i = 0; i < inpCities.Length; i++)
            {
                X0 += inpCities[i].X;
                Y0 += inpCities[i].Y;
                if (inpCities[i].X > maxX)
                    maxX = inpCities[i].X;
                else if (inpCities[i].X < minX)
                    minX = inpCities[i].X;
                else if (inpCities[i].Y < minY)
                    minY = inpCities[i].Y;
                else if (inpCities[i].Y > maxY)
                    maxY = inpCities[i].Y;
            }
            X0 /= inpCities.Length;
            Y0 /= inpCities.Length;

            float widthOfArea = (maxX - minX) / (float)(0.5 + (10 - 0.5) * rnd.NextDouble());
            float heightOfArea = (maxY - minY) / (float)(0.5 + (10 - 0.5) * rnd.NextDouble());

            X0 += rnd.Next((int)(-widthOfArea / 2), (int)(widthOfArea / 2));
            Y0 += rnd.Next((int)(-heightOfArea / 2), (int)(heightOfArea / 2));
            for (int i = 0; i < numNN; i++)
            {
                Weights[i].X = (float)(X0 + widthOfArea * Math.Cos(i * (360 / numNN)));
                Weights[i].Y = (float)(Y0 + heightOfArea * Math.Sin(i * (360 / numNN)));
            }
            firstX0 = X0; firstY0 = Y0; firstWidth = widthOfArea; firstHeight = heightOfArea;
            FindAllWeights_Array();
            //FindAllD();
        }

        public clsSOMTSP Clone()
        {
            clsSOMTSP tmp = new clsSOMTSP(Wins.Length, Cities, landa, false);
            tmp.Weights = (PointF[])this.Weights.Clone();
            tmp.Wins = (int[])this.Wins.Clone();
            //tmp.cities_d = (double[,])this.cities_d.Clone();
            tmp.CurrentValue = this.CurrentValue;
            tmp.attachedEmpire = this.attachedEmpire;
            tmp.ColonyNumber = this.ColonyNumber;
            tmp.averageOfClonyfitness = this.averageOfClonyfitness;
            tmp._baseBeta = this._baseBeta;
            //tmp.d = (int[,])d.Clone();

            tmp.firstX0 = this.firstX0;
            tmp.firstY0 = this.firstY0;
            tmp.firstWidth = this.firstWidth;
            tmp.firstHeight = this.firstHeight;
            tmp.landa = this.landa;

            return tmp;
        }

        public void Learn(int MaxLearnEpoch, int CurrentEpoch)
        {
            if (Cities.Length == 1)
                return;

            double beta = ((double)CurrentEpoch / MaxLearnEpoch) * _baseBeta;
            int RandomCityIndex = rnd.Next(1, Cities.Length);
            int weightIndex = FindBMU(Cities[RandomCityIndex]);
            Wins[weightIndex]++;

            double Dx = 0, Dy = 0, numBj = 0;
            double Distancefraction = ((Cities.Length - 1) / 2.0);
            for (int i = 0; i < Weights.Length; i++)
            {
                double dist_i = di(i, weightIndex);
                if (dist_i < Distancefraction)
                {
                    numBj++;

                    double Wi = Math.Pow(1 - dist_i / Distancefraction, beta);
                    float newWX = (float)(Weights[i].X + Wi * (Cities[RandomCityIndex].X - Weights[i].X));
                    float newWY = (float)(Weights[i].Y + Wi * (Cities[RandomCityIndex].Y - Weights[i].Y));

                    Dx += (float)(newWX - Weights[i].X);
                    Dy += (float)(newWY - Weights[i].Y);

                    Weights[i].X = newWX;
                    Weights[i].Y = newWY;
                }
            }
            Dx /= numBj; Dy /= numBj;
            double fractionX = (1 / (Weights.Length - numBj)) * Dx;
            double fractionY = (1 / (Weights.Length - numBj)) * Dy;
            for (int i = 0; i < Weights.Length; i++)
            {
                if (di(i, weightIndex) > Distancefraction)
                {
                    Weights[i].X = (float)(Weights[i].X - fractionX);
                    Weights[i].Y = (float)(Weights[i].Y - fractionY);
                }
            }
        }

        public double LearnMunicipality(int MaxLearnEpoch, int CurrentEpoch)
        {
            if (Cities.Length == 1)
                return 0;

            double beta = ((double)CurrentEpoch / MaxLearnEpoch) * _baseBeta;
            int RandomCityIndex = rnd.Next(1, Cities.Length);
            int weightIndex = FindBMU(Cities[RandomCityIndex]);
            Wins[weightIndex]++;

            double ChangeRate = Math.Sqrt(distance(Weights[weightIndex], Cities[RandomCityIndex]));
            double Dx = 0, Dy = 0, numBj = 0;
            double Distancefraction = ((Cities.Length - 1) / 2.0);


            for (int i = 0; i < Weights.Length; i++)
            {
                double dist_i = di(i, weightIndex);
                if (dist_i < Distancefraction)
                {
                    numBj++;

                    double Wi = Math.Pow(1 - dist_i / Distancefraction, beta);
                    float newWX = (float)(Weights[i].X + Wi * (Cities[RandomCityIndex].X - Weights[i].X));
                    float newWY = (float)(Weights[i].Y + Wi * (Cities[RandomCityIndex].Y - Weights[i].Y));

                    Dx += (float)(newWX - Weights[i].X);
                    Dy += (float)(newWY - Weights[i].Y);

                    Weights[i].X = newWX;
                    Weights[i].Y = newWY;
                }
            }
            Dx /= numBj; Dy /= numBj;
            float fractionX = (float)((1 / (Weights.Length - numBj)) * Dx);
            float fractionY = (float)((1 / (Weights.Length - numBj)) * Dy);
            for (int i = 0; i < Weights.Length; i++)
            {
                if (di(i, weightIndex) > Distancefraction)
                {
                    Weights[i].X = (Weights[i].X - fractionX);
                    Weights[i].Y = (Weights[i].Y - fractionY);
                }
            }
            return (ChangeRate);
        }

        public double FindCurrentValue(double[,] weight_array)
        {
            clsSOMTSP cloned = this.Clone();
            cloned.FineTune();
            cloned.RemoveUnnecessary();

            return cloned.EXfindTourValue(weight_array);
        }

        public void FineTune()
        {
            int MinIndex = 0;
            double dist = double.MaxValue;
            double MinDist = double.MaxValue;
            Wins = new int[Wins.Length];

            for (int k = 1; k < Cities.Length; k++)
            {
                MinIndex = 0;
                dist = double.MaxValue;
                MinDist = double.MaxValue;
                for (int j = 0; j < Weights.Length; j++)
                {
                    if (Wins[j] == 0)
                    {
                        dist = distance(Weights[j], Cities[k]);
                        if (dist < MinDist)
                        {
                            MinIndex = j;
                            MinDist = dist;
                        }
                    }
                }
                Weights[MinIndex] = Cities[k];
                Wins[MinIndex] = 1;
            }
        }

        private void FindAllWeights_Array()
        {
            cities_d = new double[Cities.Length, Cities.Length];
            for (int i = 1; i < Cities.Length; i++)
                for (int j = 1; j < Cities.Length; j++)
                    cities_d[i, j] = Math.Sqrt(distance(Cities[i], Cities[j]));
        }

        private void FindAllD()
        {
            d = new int[Weights.Length, Weights.Length];
            for (int i = 0; i < Weights.Length; i++)
            {
                for (int weightIndex = 0; weightIndex < i; weightIndex++)
                {
                    int dist = Math.Abs(i - weightIndex);
                    d[i, weightIndex] = Math.Min(dist, Weights.Length - dist);
                    d[weightIndex, i] = d[i, weightIndex];
                }
            }
        }

        private int di(int start, int dest) // I have added this because of memory problem
        {
            int dist = Math.Abs(start - dest);
            return Math.Min(dist, Weights.Length - dist);
        }

        private int FindBMU(PointF City)
        {
            double Mind = double.MaxValue, dist = 0;
            int MinIndex = -1;
            for (int i = 0; i < Weights.Length; i++)
            {
                dist = distance(Weights[i], City) + landa * ((double)Wins[i] / (1 + Wins[i]));
                if (dist < Mind)
                {
                    Mind = dist;
                    MinIndex = i;
                }
            }
            return MinIndex;
        }

        private double distance(PointF Weight, PointF City)
        {
            double DX = (City.X - Weight.X);
            double DY = (City.Y - Weight.Y);
            return (DX * DX + DY * DY);
        }

        internal void RemoveUnnecessary()
        {
            int lastWin = -1;
            for (int i = 0; i < Weights.Length; i++)
            {
                if (Wins[i] == 0)
                {
                    if (lastWin != -1)
                        Weights[i] = Weights[lastWin];
                    else
                        for (int j = Weights.Length - 1; j > 0; j--)
                        {
                            if (Wins[j] == 1)
                            {
                                lastWin = j;
                                Weights[i] = Weights[lastWin];
                                break;
                            }
                        }

                }
                else
                    lastWin = i;
            }
        }

        public int FindRealIndex(PointF weight)
        {
            int CurrentIndex = -1;
            double MinD = double.MaxValue;

            for (int j = 1; j < Cities.Length; j++)
            {
                double dist = distance(Cities[j], weight);
                if (dist < MinD)
                {
                    MinD = dist;
                    CurrentIndex = j;
                }
            }
            return CurrentIndex;
        }

        private int ExFindRealIndex(PointF weight)
        {
            int CurrentIndex = -1;
            for (int j = 1; j < Cities.Length; j++)
            {
                if (Cities[j] == weight)
                {
                    CurrentIndex = j;
                    break;
                }
            }
            return CurrentIndex;
        }

        internal double findTourValue(double[,] weight_array)
        {
            double dist = 0;
            int currentIndex, nextIndex, firstIndex, EndIndex;
            firstIndex = FindRealIndex(Weights[0]);
            EndIndex = FindRealIndex(Weights[Weights.Length - 1]);


            for (int i = 0; i < Weights.Length - 1; i++)
            {
                currentIndex = FindRealIndex(Weights[i]);
                nextIndex = FindRealIndex(Weights[i + 1]);

                dist += weight_array[currentIndex, nextIndex];
            }
            dist += weight_array[EndIndex, firstIndex];
            return dist;
        }

        internal double findTourLength()
        {
            clsSOMTSP cloned = this.Clone();
            cloned.Cities = this.Cities;
            cloned.FineTune();
            cloned.RemoveUnnecessary();

            return (cloned.EXfindTourValue(cities_d));
        }

        internal double EXfindTourValue(double[,] weight_array)
        {
            double dist = 0;
            int currentIndex = -1, nextIndex = -1, firstIndex = -1, EndIndex = -1;
            firstIndex = ExFindRealIndex(Weights[0]);
            EndIndex = ExFindRealIndex(Weights[Weights.Length - 1]);

            for (int i = 0; i < Weights.Length - 1; i++)
            {
                if (Weights[i] != Weights[i + 1])
                {
                    if (currentIndex == -1)
                        currentIndex = ExFindRealIndex(Weights[i]);
                    nextIndex = ExFindRealIndex(Weights[i + 1]);
                    dist += weight_array[currentIndex, nextIndex];
                    currentIndex = nextIndex;
                }
            }
            dist += weight_array[EndIndex, firstIndex];
            return dist;
        }

        internal bool Merge(clsSOMTSP neighbour)
        {
            // finding nearest city between current TSP and neighbour
            PointF[] Copy_Of_Weights = new PointF[Weights.Length + neighbour.Weights.Length];
            PointF[] Copy_Of_Cities = new PointF[Cities.Length + neighbour.Cities.Length - 1];
            int[] Copy_Of_Wins = new int[Weights.Length + neighbour.Weights.Length];
            int merger_counter = 0;
            
            double min_dist = double.MaxValue;
            int min_index_src = -1, min_index_dst = -1, min_index_dst_1 = 0, min_index_src_1 = 0;
            PointF A, B, C, D;

            //double toleration = 1;
            for (int ii = 0; ii < Weights.Length; ii++)
            {
                for (int jj = 0; jj < neighbour.Weights.Length; jj++)
                {
                    double dist = distance(Weights[ii], neighbour.Weights[jj]);
                    if (dist < min_dist /** toleration*/)
                    {
                        //toleration = 1 + rnd.NextDouble() * 0.01;
                        min_dist = dist;
                        min_index_src = ii;
                        min_index_dst = jj;
                    }
                }
            }
            PointF[] Candidate_C = new PointF[2];
            int[] Candidate_C_Index = new int[2];

            PointF[] Candidate_D = new PointF[2];
            int[] Candidate_D_Index = new int[2];
            bool[] Directions = new bool[2];

            A = D = Weights[min_index_src];
            B = C = neighbour.Weights[min_index_dst];

            bool NotAssigned = true;
            for (int ii = min_index_dst; ii >= 0; ii--)
            {
                if (neighbour.FindRealIndex(neighbour.Weights[ii]) != neighbour.FindRealIndex(B))
                {
                    Candidate_C[0] = neighbour.Weights[ii];
                    Candidate_C_Index[0] = ii;
                    NotAssigned = false;
                    break;
                }
            }
            if (NotAssigned == true)
            {
                for (int ii = neighbour.Weights.Length - 1; ii > min_index_dst; ii--)
                {
                    if (neighbour.FindRealIndex(neighbour.Weights[ii]) != neighbour.FindRealIndex(B))
                    {
                        Candidate_C[0] = neighbour.Weights[ii];
                        Candidate_C_Index[0] = ii;
                        break;
                    }
                }
            }

            NotAssigned = true;
            for (int ii = min_index_dst; ii < neighbour.Weights.Length; ii++)
            {
                if (neighbour.FindRealIndex(neighbour.Weights[ii]) != neighbour.FindRealIndex(B))
                {
                    Candidate_C[1] = neighbour.Weights[ii];
                    Candidate_C_Index[1] = ii;
                    NotAssigned = false;
                    break;
                }
            }
            if (NotAssigned == true)
            {
                for (int ii = 0; ii < min_index_dst; ii++)
                {
                    if (neighbour.FindRealIndex(neighbour.Weights[ii]) != neighbour.FindRealIndex(B))
                    {
                        Candidate_C[1] = neighbour.Weights[ii];
                        Candidate_C_Index[1] = ii;
                        break;
                    }
                }
            }

            NotAssigned = true;
            for (int ii = min_index_src; ii < Weights.Length; ii++)
            {
                if (FindRealIndex(Weights[ii]) != FindRealIndex(A))
                {
                    Candidate_D[0] = Weights[ii];
                    Candidate_D_Index[0] = ii;
                    NotAssigned = false;
                    break;
                }
            }
            if (NotAssigned == true)
            {
                for (int ii = 0; ii < min_index_src; ii++)
                {
                    if (FindRealIndex(Weights[ii]) != FindRealIndex(A))
                    {
                        Candidate_D[0] = Weights[ii];
                        Candidate_D_Index[0] = ii;
                        break;
                    }
                }
            }

            NotAssigned = true;
            for (int ii = min_index_src; ii >= 0; ii--)
            {
                if (FindRealIndex(Weights[ii]) != FindRealIndex(A))
                {
                    Candidate_D[1] = Weights[ii];
                    Candidate_D_Index[1] = ii;
                    NotAssigned = false;
                    break;
                }
            }
            if (NotAssigned == true)
            {
                for (int ii = Weights.Length - 1; ii > min_index_src; ii--)
                {
                    if (FindRealIndex(Weights[ii]) != FindRealIndex(A))
                    {
                        Candidate_D[1] = Weights[ii];
                        Candidate_D_Index[1] = ii;
                        break;
                    }
                }
            }

            double min_dist_vec = double.MaxValue;
            for (int numC = 0; numC < 2; numC++)
            {
                for (int numD = 0; numD < 2; numD++)
                {
                    if (distance(Candidate_C[numC], Candidate_D[numD]) < min_dist_vec)
                    {
                        min_dist_vec = distance(Candidate_C[numC], Candidate_D[numD]);
                        C = Candidate_C[numC];
                        D = Candidate_D[numD];
                        min_index_dst_1 = Candidate_C_Index[numC];
                        min_index_src_1 = Candidate_D_Index[numD];
                        if (numC == 0)
                            Directions[0] = false;   // Decrease
                        else
                            Directions[0] = true;    // Increase

                        if (numD == 0)
                            Directions[1] = true;    // Increase
                        else
                            Directions[1] = false;    // Decrease
                    }
                }
            }


            Copy_Of_Weights[merger_counter] = Weights[min_index_src];  //A
            Copy_Of_Wins[merger_counter] = Wins[min_index_src];
            merger_counter++;


            if (Directions[0] == false)
            {
                int k = min_index_dst;
                while (true)
                {
                    if (k == min_index_dst_1)           // we reached to C from B
                        break;

                    Copy_Of_Weights[merger_counter] = neighbour.Weights[k];
                    Copy_Of_Wins[merger_counter] = neighbour.Wins[k];
                    merger_counter++;

                    if (k == neighbour.Weights.Length - 1)
                        k = 0;
                    else
                        k++;
                }
            }
            else
            {
                int k = min_index_dst;
                while (true)
                {
                    if (k == min_index_dst_1)           // we reached to C from B
                        break;

                    Copy_Of_Weights[merger_counter] = neighbour.Weights[k];
                    Copy_Of_Wins[merger_counter] = neighbour.Wins[k];
                    merger_counter++;

                    if (k == 0)
                        k = neighbour.Weights.Length - 1;
                    else
                        k--;
                }
            }

            Copy_Of_Weights[merger_counter] = neighbour.Weights[min_index_dst_1];  //C
            Copy_Of_Wins[merger_counter] = neighbour.Wins[min_index_dst_1];
            merger_counter++;


            if (Directions[1] == true)
            {
                int k = min_index_src_1;
                while (true)
                {
                    if (k == min_index_src)           // we reached to D from A
                        break;

                    Copy_Of_Weights[merger_counter] = Weights[k];
                    Copy_Of_Wins[merger_counter] = Wins[k];
                    merger_counter++;

                    if (k == Weights.Length - 1)
                        k = 0;
                    else
                        k++;
                }
            }
            else
            {
                int k = min_index_src_1;
                while (true)
                {
                    if (k == min_index_src)           // we reached to D from A
                        break;

                    Copy_Of_Weights[merger_counter] = Weights[k];
                    Copy_Of_Wins[merger_counter] = Wins[k];
                    merger_counter++;

                    if (k == 0)
                        k = Weights.Length - 1;
                    else
                        k--;
                }
            }

            Array.Resize(ref Copy_Of_Weights, merger_counter);
            Array.Resize(ref Copy_Of_Wins, merger_counter);

            for (int i = 0; i < Cities.Length; i++)
                Copy_Of_Cities[i] = Cities[i];
            for (int i = 1; i < neighbour.Cities.Length; i++)
                Copy_Of_Cities[Cities.Length + i - 1] = neighbour.Cities[i];

            Cities = Copy_Of_Cities;
            Weights = Copy_Of_Weights;
            Wins = Copy_Of_Wins;

            BreakTie();
            FindAllWeights_Array();
            //FindAllD();
            return true;
        }

        bool IsIntersecting(PointF A, PointF B, PointF C, PointF D)
        {
            float denominator = ((B.X - A.X) * (D.Y - C.Y)) - ((B.Y - A.Y) * (D.X - C.X));
            float numerator1 = ((A.Y - C.Y) * (D.X - C.X)) - ((A.X - C.X) * (D.Y - C.Y));
            float numerator2 = ((A.Y - C.Y) * (B.X - A.X)) - ((A.X - C.X) * (B.Y - A.Y));

            if ((A.Y == B.Y) && (D.Y == C.Y) && (A.Y == D.Y))
            {
                if ((A.X < C.X && B.X < C.X) || (A.X > C.X && B.X > C.X) || (A.X < D.X && B.X < D.X) || (A.X > D.X && B.X > D.X))
                    return false;

            }

            if ((A.X == B.X) && (D.X == C.X) && (A.X == D.X))
            {
                if ((A.Y < C.Y && B.Y < C.Y) || (A.Y > C.Y && B.Y > C.Y) || (A.Y < D.Y && B.Y < D.Y) || (A.Y > D.Y && B.Y > D.Y))
                    return false;
            }

            // Detect coincident lines (has a problem, read below)
            if (denominator == 0) return false; // numerator1 == 0 && numerator2 == 0;

            float r = numerator1 / denominator;
            float s = numerator2 / denominator;

            return (r >= 0 && r <= 1) && (s >= 0 && s <= 1); // 0 and 1 removed because they may be in sequence
        }

        public void BreakTie()
        {
            //Redistribute();
            int i = 0, j = 0;
            while (i < Weights.Length - 1)
            {
                j = 0;
                while (j < i - 1)
                {
                    if (IsIntersecting(Weights[i], Weights[i + 1], Weights[j], Weights[j + 1]))
                    {
                        Swap(i, j);
                    }
                    j++;
                }
                i++;
            }
            return;
        }

        private void Swap(int i, int j)
        {
            PointF[] CopyOfWeights = (PointF[])Weights.Clone();
            int[] CopyOfWins = (int[])Wins.Clone();

            for (int k = j; k <= i; k++)
            {
                CopyOfWeights[k] = Weights[i - k + j];
                CopyOfWins[k] = Wins[i - k + j];
            }

            Weights = CopyOfWeights;
            Wins = CopyOfWins;
        }

        public void Redistribute()
        {
            for (int check_c = 0; check_c < 3; check_c++)
            {
                int i = 0;
                PointF[] CopyOfWeights = (PointF[])Weights.Clone();
                int[] Copy_Of_Wins = (int[])Wins.Clone();

                PointF FirstChange;
                int FirstChangeIndex = -1;
                while (i < Weights.Length - 1)
                {
                    int pres_i = i;
                    if (distance(CopyOfWeights[i], CopyOfWeights[i + 1]) < 3)
                    {
                        for (int j = i + 1; j < Weights.Length; j++)
                        {
                            if (distance(CopyOfWeights[i], CopyOfWeights[j]) >= 3)
                            {
                                FirstChange = CopyOfWeights[j];
                                FirstChangeIndex = j;
                                break;
                            }
                        }
                        if (FirstChangeIndex != -1)
                        {
                            for (int k = FirstChangeIndex; k < Weights.Length; k++)
                            {
                                if (distance(CopyOfWeights[k], CopyOfWeights[FirstChangeIndex]) >= 3)
                                {
                                    // Redistribute them again
                                    int num_node = (k - i) - 1;
                                    if (num_node < 0)
                                        break;
                                    float dx = (float)(CopyOfWeights[k - 1].X - CopyOfWeights[i].X) / num_node;
                                    float dy = (float)(CopyOfWeights[k - 1].Y - CopyOfWeights[i].Y) / num_node;
                                    if (Math.Sqrt(dx * dx + dy * dy) > 5)
                                    {
                                        for (int counter = i + 1; counter < k; counter++)
                                        {
                                            CopyOfWeights[counter].X = CopyOfWeights[i].X + ((counter - i) * dx);
                                            CopyOfWeights[counter].Y = CopyOfWeights[i].Y + ((counter - i) * dy);
                                        }
                                        i = k - 1;
                                        break;
                                    }
                                    else
                                    {
                                        // Remove all in between.
                                        for (int counter = i + 1; counter < Weights.Length - num_node; counter++)
                                        {
                                            CopyOfWeights[counter] = CopyOfWeights[counter + (k - i - 1)];
                                            Copy_Of_Wins[counter] = Copy_Of_Wins[counter + (k - i - 1)];
                                        }
                                        Array.Resize(ref CopyOfWeights, Weights.Length - num_node);
                                        Weights = CopyOfWeights;
                                        Wins = Copy_Of_Wins;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Remove all in the end.
                            Array.Resize(ref CopyOfWeights, i + 1);
                            Array.Resize(ref Copy_Of_Wins, i + 1);
                            Weights = CopyOfWeights;
                            Wins = Copy_Of_Wins;
                            break;
                        }
                    }
                    i++;

                    if (i <= pres_i)
                        i = pres_i + 1;
                }
                Weights = CopyOfWeights;
                Wins = Copy_Of_Wins;

            }
        }
    }
}
