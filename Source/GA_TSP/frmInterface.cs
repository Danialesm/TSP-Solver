using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GraphLib;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace TSP
{
    public partial class frmInterface : Form
    {
        double mult = 1;
        Bitmap bmp = null;
        bool ShowCities = false;
        clsGATSP GA;
        clsICATSP ICA;
        //clsNNICA NNICA;
        clsICABase ICABase;

        public frmInterface()
        {
            InitializeComponent();
        }
        private void cmdOpen_Click(object sender, EventArgs e)
        {
            DialogResult res = cmdlg.ShowDialog();
            if (res == DialogResult.OK)
            {
                ShowCities = false;
                this.Text = "TSP Solver - " + cmdlg.FileName.ToString();
                txtFileName.Text = cmdlg.FileName.ToString();
                fillData(cmdlg.FileName);
            }
        }
        double[,] weight_array = new double[0, 0];
        PointF[] cities = new PointF[0];
        PointF[] raw_cities = new PointF[0];
        String name = "";
        String type = "";
        String dimension = "";
        String weight_type = "";
        String weight_format = "";
        String display_type = "";

        public void fillData(string filename)
        {
            weight_array = new double[0, 0];
            cities = new PointF[0];
            raw_cities = new PointF[0];
            StreamReader reader = new StreamReader(filename);
            String res = reader.ReadToEnd();
            int counter = -1;
            String[] array = res.Split('\n').Where(val => val != "").ToArray();
            
            while (counter <= array.Length)
            {
                counter++;
                if (array[counter].Substring(0, 3).ToLower() == "eof")
                {
                    break;
                }

                if (array[counter].Length > 5)
                {
                    if (array[counter].Substring(0, 5).ToLower() == "name:")
                    {
                        name = array[counter].Substring(5).ToLower();
                        continue;
                    }
                    if (array[counter].Substring(0, 6).ToLower() == "name :")
                    {
                        name = array[counter].Substring(6).ToLower();
                        continue;
                    }
                }

                if (array[counter].Length > 5)
                {
                    if (array[counter].Substring(0, 5).ToLower() == "type:")
                    {
                        type = array[counter].Substring(5).ToLower();
                        continue;
                    }
                    if (array[counter].Substring(0, 6).ToLower() == "type :")
                    {
                        type = array[counter].Substring(6).ToLower();
                        continue;
                    }
                }
                if (array[counter].Length > 10)
                {
                    if (array[counter].Substring(0, 10).ToLower() == "dimension:")
                    {
                        dimension = array[counter].Substring(10).Trim();
                        weight_array = new double[int.Parse(dimension) + 1, int.Parse(dimension) + 1];
                        cities = new PointF[int.Parse(dimension) + 1];
                        raw_cities = new PointF[int.Parse(dimension) + 1];
                        continue;
                    }
                    if (array[counter].Substring(0, 11).ToLower() == "dimension :")
                    {
                        dimension = array[counter].Substring(11).Trim();
                        weight_array = new double[int.Parse(dimension) + 1, int.Parse(dimension) + 1];
                        cities = new PointF[int.Parse(dimension) + 1];
                        raw_cities = new PointF[int.Parse(dimension) + 1];
                        continue;
                    }
                }
                if (array[counter].Length > 17)
                {
                    if (array[counter].Substring(0, 17).ToLower() == "edge_weight_type:")
                    {
                        weight_type = array[counter].Substring(17).ToLower();
                        continue;
                    }
                    if (array[counter].Substring(0, 18).ToLower() == "edge_weight_type :")
                    {
                        weight_type = array[counter].Substring(18).ToLower();
                        continue;
                    }
                }
                if (array[counter].Length > 18)
                {
                    if (array[counter].Substring(0, 18).ToLower() == "display_data_type:")
                    {
                        display_type = array[counter].Substring(18).ToLower();
                        continue;
                    }
                    if (array[counter].Substring(0, 19).ToLower() == "display_data_type :")
                    {
                        display_type = array[counter].Substring(19).ToLower();
                        continue;
                    }
                }
                if (array[counter].Length > 19)
                {
                    if (array[counter].Substring(0, 19).ToLower() == "edge_weight_format:")
                    {
                        weight_format = array[counter].Substring(19).ToLower();
                        weight_format = weight_format.Trim();
                        continue;
                    }
                    if (array[counter].Substring(0, 20).ToLower() == "edge_weight_format :")
                    {
                        weight_format = array[counter].Substring(20).ToLower();
                        weight_format = weight_format.Trim();
                        continue;
                    }
                }
                if (array[counter].Length >= 19)
                {
                    if (array[counter].Substring(0, 19).ToLower() == "edge_weight_section")
                    {
                        string weights = "";
                        int additive_counter = 0;
                        for (int i = 1; i < array.Length; i++)
                        {
                            if (array[counter + i].Substring(0, 3).ToLower().Trim() == "eof")
                            {
                                counter = counter + i - 1;
                                break;
                            }
                            if (array[counter + i].Substring(0, 20).ToLower().Trim() == "display_data_section")
                            {
                                counter = counter + i - 1;
                                break;
                            }
                            else
                            {
                                weights = weights + array[counter + i].Trim() + " ";
                            }
                        }
                        string[] temporary_array = weights.Split(' ');
                        switch (weight_format)
                        {
                            case "full_matrix":
                                for (int i = 1; i < weight_array.GetLength(0); i++)
                                {
                                    for (int j = 1; j < weight_array.GetLength(0); j++)
                                    {
                                        for (int checker = 1; checker < 100; checker++)
                                        {
                                            if (temporary_array[additive_counter].Trim() != "")
                                            {
                                                break;
                                            }
                                            additive_counter++;
                                        }
                                        weight_array[i, j] = double.Parse(temporary_array[additive_counter]);
                                        additive_counter++;
                                    }
                                }
                                break;
                            case "upper_row":


                                break;
                            case "lower_diag_row":
                                for (int i = 1; i < weight_array.GetLength(0); i++)
                                {
                                    for (int j = 1; j <= i; j++)
                                    {
                                        weight_array[i, j] = double.Parse(temporary_array[additive_counter]);
                                        weight_array[j, i] = weight_array[i, j];
                                        additive_counter++;
                                    }
                                }
                                break;
                            default:
                                break;

                        }
                        continue;
                    }
                }
                if (array[counter].Length >= 18)
                {
                    if (array[counter].Substring(0, 18).ToLower() == "node_coord_section")
                    {
                        ShowCities = true;
                        int additive_counter = 0;
                        double Max_X = 0;
                        double Max_Y = 0;
                        double Min_X = 0;
                        double Min_Y = 0;
                        for (int i = counter + 1; i < counter + cities.Length; i++)
                        {
                            additive_counter++;
                            while (array[i].Replace("  ", " ") != array[i])
                            {
                                array[i] = array[i].Replace("  ", " ");
                            }
                            String[] point = array[i].Trim().Split(' ');
                            cities[additive_counter].X = float.Parse(point[1]);
                            cities[additive_counter].Y = float.Parse(point[2]);

                            raw_cities[additive_counter].X = float.Parse(point[1]);
                            raw_cities[additive_counter].Y = float.Parse(point[2]);

                            if (cities[additive_counter].X > Max_X) Max_X = cities[additive_counter].X;
                            if (cities[additive_counter].Y > Max_Y) Max_Y = cities[additive_counter].Y;
                            if (cities[additive_counter].X < Min_X) Min_X = cities[additive_counter].X;
                            if (cities[additive_counter].Y < Min_Y) Min_Y = cities[additive_counter].Y;
                        }
                        counter += cities.Length - 1;
                        if (((Max_X - Min_X)) < 900)
                        {
                            mult = 900 / (Max_X - Min_X);
                        }
                        else if (((Max_X - Min_X)) > 2000)
                        {
                            mult = 2000 / (Max_X - Min_X);
                        }
                        else
                        {
                            mult = 1;
                        }
                        bmp = new Bitmap((int)(1.2 * mult * (Max_X - Min_X)), (int)(1.2 * mult * (Max_Y - Min_Y)));
                        Graphics gr = Graphics.FromImage(bmp);
                        float width = bmp.Width / 800f;
                        for (int i = 1; i < cities.Length; i++)
                        {
                            float X = (float)(mult * (cities[i].X - 1 + 1.1 * Math.Abs(Min_X)));
                            float Y = (float)(mult * (cities[i].Y - 1 + 1.1 * Math.Abs(Min_Y)));
                            if (width > 1)
                            {
                                gr.DrawString(i.ToString(), new Font("Arial", 8 * (width)), Brushes.Black, new PointF(X - 1, Y - 1));
                            }
                            gr.DrawEllipse(Pens.Black, X - width / 2, Y - width / 2, width, width);
                        }
                        picPlot.Image = bmp;
                        picPlot.Invalidate();
                        if (weight_type.Trim() == "euc_2d" || weight_type.Trim() == "geo" || weight_type.Trim() == "ceil_2d" || weight_type.Trim() == "att")
                        {
                            for (int i = 1; i < weight_array.GetLength(0); i++)
                            {
                                for (int j = 1; j <= i; j++)
                                {
                                    if (weight_type.Trim() != "att")
                                    {
                                        weight_array[i, j] = distance(raw_cities[i], raw_cities[j]);
                                    }
                                    else
                                    {
                                        weight_array[i, j] = distanceAtt(raw_cities[i], raw_cities[j]);
                                    }
                                    weight_array[j, i] = weight_array[i, j];
                                }
                            }
                            for (int i = 1; i < cities.Length; i++)
                            {
                                cities[i].X = (float)(mult * (cities[i].X - 1 + 1.1 * Math.Abs(Min_X)));
                                cities[i].Y = (float)(mult * (cities[i].Y - 1 + 1.1 * Math.Abs(Min_Y)));
                            }
                        }
                    }
                }
                
                if (array[counter].Length >= 20)
                {
                    if (array[counter].Substring(0, 20).ToLower() == "display_data_section")
                    {
                        ShowCities = true;
                        int additive_counter = 0;
                        double Max_X = 0;
                        double Max_Y = 0;
                        double Min_X = 0;
                        double Min_Y = 0;
                        for (int i = counter + 1; i < counter + cities.Length; i++)
                        {
                            additive_counter++;
                            while (array[i].Replace("  ", " ") != array[i])
                            {
                                array[i] = array[i].Replace("  ", " ");
                            }
                            String[] point = array[i].Trim().Split(' ');
                            cities[additive_counter].X = float.Parse(point[1]);
                            cities[additive_counter].Y = float.Parse(point[2]);
                            if (cities[additive_counter].X > Max_X) Max_X = cities[additive_counter].X;
                            if (cities[additive_counter].Y > Max_Y) Max_Y = cities[additive_counter].Y;
                            if (cities[additive_counter].X < Min_X) Min_X = cities[additive_counter].X;
                            if (cities[additive_counter].Y < Min_Y) Min_Y = cities[additive_counter].Y;
                        }
                        counter += cities.Length - 1;
                        if (((Max_X - Min_X)) < 900)
                        {
                            mult = 900 / (Max_X - Min_X);
                        }
                        else if (((Max_X - Min_X)) > 2000)
                        {
                            mult = 2000 / (Max_X - Min_X);
                        }
                        else
                        {
                            mult = 1;
                        }
                        bmp = new Bitmap((int)(1.2 * mult * (Max_X - Min_X)), (int)(1.2 * mult * (Max_Y - Min_Y)));
                        Graphics gr = Graphics.FromImage(bmp);
                        float width = bmp.Width / 800f;
                        for (int i = 1; i < cities.Length; i++)
                        {
                            float X = (float)(mult * (cities[i].X - 1 + 1.1 * Math.Abs(Min_X)));
                            float Y = (float)(mult * (cities[i].Y - 1 + 1.1 * Math.Abs(Min_Y)));
                            if (width > 1)
                            {
                                gr.DrawString(i.ToString(), new Font("Arial", 8 * (width)), Brushes.Black, new PointF(X - 1, Y - 1));
                            }
                            gr.DrawEllipse(Pens.Black, X - width / 2, Y - width / 2, width, width);
                        }
                        for (int i = 1; i < cities.Length; i++)
                        {
                            cities[i].X = (float)(mult * (cities[i].X - 1 + 1.1 * Math.Abs(Min_X)));
                            cities[i].Y = (float)(mult * (cities[i].Y - 1 + 1.1 * Math.Abs(Min_Y)));
                        }
                        //Graphics grDraw = picPlot.CreateGraphics();
                        //grDraw.DrawImage(bmp, new Rectangle(0, 0, picPlot.Width, picPlot.Height));
                        picPlot.Image = bmp; 
                        picPlot.Invalidate();

                        continue;
                    }
                }
            }
            lblInfo.Text = "\r\n Name : " + name + "\r\n Dimension : " + dimension.Trim() +
                           "\r\n Type : " + type + "\r\n Weight Type : " + weight_type.Trim() +
                           "\r\n Plot Type : " + display_type;
            lblInfo.Invalidate();
        }

        private int distanceAtt(PointF A, PointF B)
        {
            double dx = A.X - B.X;
            double dy = A.Y - B.Y;

            double rij = Math.Sqrt((dx * dx + dy * dy) / 10.0);
            int dij = (int)Math.Round(rij);
            if (dij < rij) dij = dij + 1;
            return dij;
        }
        private double distance(PointF src, PointF dest)
        {
            return (int)Math.Round(Math.Sqrt((src.X - dest.X) * (src.X - dest.X) + (src.Y - dest.Y) * (src.Y - dest.Y)));
        }
        private void btnSolve_Click(object sender, EventArgs e)
        {
            Stop = false;
            int MaxEpoch = (int)numReg.Value;
            Random rnd = new Random(Environment.TickCount);
            GA = new clsGATSP(weight_array, (int)numPopulation.Value);

            plotter.DataSources.Clear();
            plotter.DataSources.Add(new DataSource());
            plotter.DataSources.Add(new DataSource());
            plotter.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
            for (int i = 0; i < plotter.DataSources.Count; i++)
            {
                plotter.DataSources[0].Name = "Best";
                plotter.DataSources[0].GraphColor = Color.Red;
                plotter.DataSources[1].Name = "Average";
                plotter.DataSources[1].GraphColor = Color.Green;
                plotter.DataSources[i].Length = MaxEpoch + 2;
                plotter.DataSources[i].AutoScaleY = true;
                plotter.DataSources[i].AutoScaleX = true;
                plotter.DataSources[i].SetDisplayRangeY(0, 6000000);
                plotter.DataSources[i].SetGridDistanceY(10000);
            }

            int info_counter = 0;
            bool endofepotch = false;
            while (endofepotch==false)
            {
                float [] ret = GA.RunEpoch();
                if (Math.Abs(ret[0] - ret[1]) < 10 || info_counter > MaxEpoch || Stop == true)
                {
                    endofepotch = true;
                    break;
                }
                
                plotter.DataSources[0].Samples[info_counter].x = info_counter;
                plotter.DataSources[0].Samples[info_counter].y = ret[0];

                plotter.DataSources[1].Samples[info_counter].x = info_counter;
                plotter.DataSources[1].Samples[info_counter].y = ret[1];
                lblVal.Text = "Best Value = " + ret[0].ToString("######.##") + "\r\n"+"Average Value = " + ret[1].ToString("######.##") ;

                Application.DoEvents();
                plotter.Refresh();
                info_counter++;
            }
            
            double bestVal2 = 0;
            if (ShowCities)
            {
                Chromosome BestSol = GA.GetBestSolution();
                Graphics gr = Graphics.FromImage(bmp);
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                gr.Clear(Color.White);
                for (int i = 0; i < cities.Length - 2; i++)
                {
                    bestVal2+=weight_array[BestSol.Gen[i].position, BestSol.Gen[i + 1].position];
                    gr.DrawLine(Pens.Blue, cities[BestSol.Gen[i].position].X, cities[BestSol.Gen[i].position].Y, cities[BestSol.Gen[i + 1].position].X, cities[BestSol.Gen[i + 1].position].Y);
                }
                bestVal2 += weight_array[BestSol.Gen[cities.Length - 2].position, BestSol.Gen[0].position];
                gr.DrawLine(Pens.Blue, cities[BestSol.Gen[cities.Length - 2].position].X, cities[BestSol.Gen[cities.Length - 2].position].Y, cities[BestSol.Gen[0].position].X, cities[BestSol.Gen[0].position].Y);
                float width = bmp.Width / 800f;
                for (int i = 1; i < cities.Length; i++)
                {
                    if (width > 1)
                    {
                        gr.DrawString(i.ToString(), new Font("Arial", 5 * (width)), Brushes.Black, new PointF(cities[i].X - 1, cities[i].Y - 1));
                    }
                    gr.DrawEllipse(Pens.Black, cities[i].X - width / 2, cities[i].Y - width / 2, width, width);
                }
                picLast.Image = bmp;
                picLast.Invalidate();
            }
            MessageBox.Show("Best Value Calculated: " + bestVal2.ToString());
            MessageBox.Show("Best Value : " + GA.BestGlobalValue.ToString());
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            Bitmap Bmp = new Bitmap(plotter.Width, plotter.Height);
            plotter.DrawToBitmap(Bmp, new Rectangle(0, 0, plotter.Width, plotter.Height));
            cmdSave.FileName = "";
            DialogResult res = cmdSave.ShowDialog();
            if (res == DialogResult.OK)
            {
                Bmp.Save(cmdSave.FileName);
            }
        }

        private void btnShowWeight_Click(object sender, EventArgs e)
        {
            frmShowWeights frm = new frmShowWeights(weight_array);
            frm.Show();
        }

        private void btnSaveMap_Click(object sender, EventArgs e)
        {
            cmdSave.FileName = "";
            DialogResult res = cmdSave.ShowDialog();
            if (res == DialogResult.OK)
            {
                bmp.Save(cmdSave.FileName);
            }

        }

        bool Stop = false;
        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore", "http://myweb.sabanciuniv.edu/danialesm/");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore", "mailto:danialesm@sabanciuniv.edu");
        }

        private void btnSolveICA_Click(object sender, EventArgs e)
        {
            double MaxTimeTorun = double.Parse(txtMaxTime.Text);
            Stopwatch stp = new Stopwatch();

            Stop = false;
            int MaxEpoch = (int)numEpoch.Value;
            Random rnd = new Random(Environment.TickCount);
            ICA = new clsICATSP(weight_array, (int)numPopICA.Value, (int)numImperialists.Value);
            ICA.init();

            plotterICA.DataSources.Clear();
            plotterICA.DataSources.Add(new DataSource());
            plotterICA.DataSources.Add(new DataSource());
            plotterICA.DataSources.Add(new DataSource());
            plotterICA.PanelLayout = PlotterGraphPaneEx.LayoutMode.NORMAL;
            for (int i = 0; i < plotterICA.DataSources.Count; i++)
            {
                plotterICA.DataSources[0].Name = "Best";
                plotterICA.DataSources[0].GraphColor = Color.Red;
                plotterICA.DataSources[1].Name = "Average";
                plotterICA.DataSources[1].GraphColor = Color.Green;
                plotterICA.DataSources[2].Name = "Imperialists";
                plotterICA.DataSources[2].GraphColor = Color.Yellow;
                plotterICA.DataSources[i].Length = MaxEpoch + 2;
                plotterICA.DataSources[i].AutoScaleY = true;
                plotterICA.DataSources[i].AutoScaleX = true;
                plotterICA.DataSources[i].SetDisplayRangeY(0, 6000000);
                plotterICA.DataSources[i].SetGridDistanceY(10000);
            }

            int info_counter = 0;
            bool endofepotch = false;

            if (chkImperialist.Checked == true)
                ICA.UseNewOperator = true;
            else
                ICA.UseNewOperator = false;
            stp.Start();
            while (endofepotch == false)
            {
                double[] ret = ICA.RunEpoch();
                if ((stp.ElapsedMilliseconds / 1000.0) > MaxTimeTorun)
                {
                    endofepotch = true;
                    break;
                }
                if (/*Math.Abs(ret[0] - ret[1]) < 10 ||*/ info_counter > MaxEpoch || Stop == true)
                {
                    endofepotch = true;
                    break;
                }

                plotterICA.DataSources[0].Samples[info_counter].x = info_counter;
                plotterICA.DataSources[0].Samples[info_counter].y = (float)ret[0];

                plotterICA.DataSources[1].Samples[info_counter].x = info_counter;
                plotterICA.DataSources[1].Samples[info_counter].y = (float)ret[1];

                plotterICA.DataSources[2].Samples[info_counter].x = info_counter;
                plotterICA.DataSources[2].Samples[info_counter].y = (float)ret[2];
                lblValICA.Text = "Best Value = " + ret[0].ToString("######.##") + "\r\nAverage Value = " + ret[1].ToString("######.##") + "\r\nTime = " + (stp.ElapsedMilliseconds / 1000.0).ToString("###.###");

                Application.DoEvents();
                plotterICA.Refresh();
                info_counter++;
            }
            stp.Stop();
            double bestVal2 = 0;
            if (ShowCities)
            {
                Graphics gr = Graphics.FromImage(bmp);
                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                gr.Clear(Color.White);
                for (int i = 0; i < cities.Length - 2; i++)
                {
                    bestVal2 += weight_array[ICA.BestSol.loc[i].position, ICA.BestSol.loc[i + 1].position];
                    gr.DrawLine(Pens.Blue, cities[ICA.BestSol.loc[i].position].X, cities[ICA.BestSol.loc[i].position].Y, cities[ICA.BestSol.loc[i + 1].position].X, cities[ICA.BestSol.loc[i + 1].position].Y);
                }
                bestVal2 += weight_array[ICA.BestSol.loc[cities.Length - 2].position, ICA.BestSol.loc[0].position];
                gr.DrawLine(Pens.Blue, cities[ICA.BestSol.loc[cities.Length - 2].position].X, cities[ICA.BestSol.loc[cities.Length - 2].position].Y, cities[ICA.BestSol.loc[0].position].X, cities[ICA.BestSol.loc[0].position].Y);
                float width = bmp.Width / 800f;
                for (int i = 1; i < cities.Length; i++)
                {
                    if (width > 1)
                    {
                        gr.DrawString(i.ToString(), new Font("Arial", 5 * (width)), Brushes.Black, new PointF(cities[i].X - 1, cities[i].Y - 1));
                    }
                    gr.DrawEllipse(Pens.Black, cities[i].X - width / 2, cities[i].Y - width / 2, width, width);
                }
                picLast.Image = bmp;
                picLast.Invalidate();
            }
            
            MessageBox.Show("Best Value Calculated: " + bestVal2.ToString());
            MessageBox.Show("Best Value : " + ICA.BestGlobalValue.ToString());
        }

        private void btnSaveImageICA_Click(object sender, EventArgs e)
        {
            Bitmap Bmp = new Bitmap(plotterICA.Width, plotterICA.Height);
            plotterICA.DrawToBitmap(Bmp, new Rectangle(0, 0, plotterICA.Width, plotterICA.Height));
            cmdSave.FileName = "";
            DialogResult res = cmdSave.ShowDialog();
            if (res == DialogResult.OK)
            {
                Bmp.Save(cmdSave.FileName);
            }
        }

        private void btnStopICA_Click(object sender, EventArgs e)
        {
            Stop = true;
        }

        private void cmdLearn_Click(object sender, EventArgs e)
        {
            int numN = (int)(numNN.Value);
            Bitmap SOMbmp = new Bitmap(bmp.Width, bmp.Height);
            Graphics grSOM = Graphics.FromImage(SOMbmp);

            grSOM.Clear(Color.White);

            float width = bmp.Width / 800f;
            float X0 = 0, Y0 = 0;
            for (int i = 1; i < cities.Length; i++)
            {
                X0 += cities[i].X;
                Y0 += cities[i].Y;
                if (width > 1)
                {
                    grSOM.DrawString(i.ToString(), new Font("Arial", 5 * (width)), Brushes.Black, new PointF(cities[i].X - 1, cities[i].Y - 1));
                }
                grSOM.DrawEllipse(Pens.Black, cities[i].X - width / 2, cities[i].Y - width / 2, width, width);
            }
            X0 /= (cities.Length - 1) + (int)nudDX.Value;
            Y0 /= (cities.Length - 1) + (int)nudDy.Value;

            clsSOMTSP SomTSP = new clsSOMTSP(numN, cities, X0, Y0, bmp.Width / (int)nudR.Value, bmp.Height / (int)nudR.Value, (double)(txtLanda.Value));
            Graphics gr = picSOM.CreateGraphics();    
            // Learning phase
            int MaxEpoch = (int)numEDU.Value;
            for (int numLearn = 0; numLearn < MaxEpoch; numLearn++)
            {
                SomTSP.Learn(MaxEpoch, numLearn);
                lblSOM.Text = "Num Epoch : " + numLearn.ToString() + "/" + MaxEpoch.ToString();
                if (numLearn % 100 == 0)
                {
                    if (chkShow.Checked == true)
                    {
                        //Draw Current State
                        grSOM.Clear(Color.White);
                        for (int i = 1; i < cities.Length; i++)
                        {
                            if (width > 1)
                            {
                                grSOM.DrawString(i.ToString(), new Font("Arial", 5 * (width)), Brushes.Black, new PointF(cities[i].X - 1, cities[i].Y - 1));
                            }
                            grSOM.DrawEllipse(Pens.Black, cities[i].X - width / 2, cities[i].Y - width / 2, width, width);
                        }
                        for (int i = 0; i < numN - 2; i++)
                        {
                            grSOM.DrawEllipse(Pens.Black, SomTSP.Weights[i].X - width / 2, SomTSP.Weights[i].Y - width / 2, width, width);
                            grSOM.DrawLine(Pens.DarkBlue, SomTSP.Weights[i].X, SomTSP.Weights[i].Y, SomTSP.Weights[i + 1].X, SomTSP.Weights[i + 1].Y);
                        }
                        grSOM.DrawEllipse(Pens.Black, SomTSP.Weights[numN - 2].X - width / 2, SomTSP.Weights[numN - 2].Y - width / 2, width, width);
                        grSOM.DrawLine(Pens.DarkBlue, SomTSP.Weights[numN - 2].X, SomTSP.Weights[numN - 2].Y, SomTSP.Weights[0].X, SomTSP.Weights[0].Y);

                        gr.DrawImage(SOMbmp, 0, 0, picSOM.Width, picSOM.Height);
                    }
                    Application.DoEvents();
                }
            }
            SomTSP.FineTune();

            //Removing unnecessary points from tour
            SomTSP.RemoveUnnecessary();
            grSOM.Clear(Color.White);
            for (int i = 1; i < cities.Length; i++)
            {
                if (width > 1)
                {
                    grSOM.DrawString(i.ToString(), new Font("Arial", 5 * (width)), Brushes.Black, new PointF(cities[i].X - 1, cities[i].Y - 1));
                }
                grSOM.DrawEllipse(Pens.Black, cities[i].X - width / 2, cities[i].Y - width / 2, width, width);
            }
            for (int i = 0; i < SomTSP.Weights.Length - 2; i++)
            {
                grSOM.DrawEllipse(Pens.Black, SomTSP.Weights[i].X - width / 2, SomTSP.Weights[i].Y - width / 2, width, width);
                grSOM.DrawLine(Pens.Red, SomTSP.Weights[i].X, SomTSP.Weights[i].Y, SomTSP.Weights[i + 1].X, SomTSP.Weights[i + 1].Y);
            }
            grSOM.DrawEllipse(Pens.Black, SomTSP.Weights[SomTSP.Weights.Length - 2].X - width / 2, SomTSP.Weights[SomTSP.Weights.Length - 2].Y - width / 2, width, width);
            grSOM.DrawLine(Pens.Red, SomTSP.Weights[SomTSP.Weights.Length - 2].X, SomTSP.Weights[SomTSP.Weights.Length - 2].Y, SomTSP.Weights[0].X, SomTSP.Weights[0].Y);
            picSOM.Image = SOMbmp;
            picSOM.Invalidate();
            Application.DoEvents();
            if (SomTSP.findTourValue(weight_array) != -1)
            {
                lblSOM.Text = "Tour Value without deleting = " + SomTSP.findTourValue(weight_array).ToString();
            }
            else
            {
                lblSOM.Text = "Uncoveged network";
            }
        }

        private void butMake_Click(object sender, EventArgs e)
        {
            DialogResult res = openBMP.ShowDialog();
            DialogResult res1 = saveTSP.ShowDialog();
            if (res == DialogResult.OK && res1 == DialogResult.OK)
            {
                List<PointF> cr_cities = new List<PointF>();
                Bitmap bm = new Bitmap(openBMP.FileName);
                for (int i = 0; i < bm.Width; i++)
                {
                    for (int j = 0; j < bm.Height; j++)
                    {
                        if (bm.GetPixel(i, j) == Color.FromArgb(0,255,0))
                        {
                            cr_cities.Add(new PointF(i, j));
                        }
                    }
                }
                try
                {
                    StreamWriter sr = new StreamWriter(saveTSP.FileName);
                    sr.WriteLine("NAME: " + saveTSP.FileName);
                    sr.WriteLine("TYPE: TSP");
                    sr.WriteLine("DIMENSION: " + cr_cities.Count);
                    sr.WriteLine("EDGE_WEIGHT_TYPE: EUC_2D");
                    sr.WriteLine("DISPLAY_DATA_TYPE: COORD_DISPLAY");
                    sr.WriteLine("NODE_COORD_SECTION");

                    for (int i = 0; i < cr_cities.Count; i++)
                    {
                        sr.WriteLine((i + 1).ToString() + " " + cr_cities[i].X.ToString() + " " + cr_cities[i].Y);
                    }
                    sr.WriteLine("EOF");
                    sr.Close();
                }
                catch(Exception){}
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm = (Bitmap)picSOM.Image.Clone();
                DialogResult res = cmdSave.ShowDialog();
                if (res == DialogResult.OK)
                {
                    bm.Save(cmdSave.FileName);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message,"Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stop = true;
        }

        bool stopMem = false;
        private void btnStopMem_Click(object sender, EventArgs e)
        {
            stopMem = true;
        }

        private void btnSolvememetic_Click(object sender, EventArgs e)
        {
            stopMem = false;
            Stopwatch stp = new Stopwatch();
            double TimeToReach = 0;
            double LastCost = double.MaxValue;
            int numPop = (int)(numMEMpop.Value);
            int NumNN = 5 * cities.Length;
            Bitmap MEMSOMbmp = new Bitmap(bmp.Width, bmp.Height);
            Graphics grMEMSOM = Graphics.FromImage(MEMSOMbmp);
            PointF[] MemBestweights;
            grMEMSOM.Clear(Color.White);

            float width = bmp.Width / 800f;
            for (int i = 1; i < cities.Length; i++)
            {
                if (width > 1)
                    grMEMSOM.DrawString(i.ToString(), new Font("Arial", 5 * (width)), Brushes.Black, new PointF(cities[i].X - 1, cities[i].Y - 1));
                grMEMSOM.DrawEllipse(Pens.Black, cities[i].X - width / 2, cities[i].Y - width / 2, width, width);
            }

            stp.Start();
            clsMemeticSOM MEMSomTSP = new clsMemeticSOM(NumNN, numPop, weight_array, cities, bmp.Width, bmp.Height);
            Graphics gr = picMEMSOM.CreateGraphics();

            // Learning phase
            int MaxEpoch = (int)numMEMEDU.Value;
            for (int numLearn = 0; numLearn < MaxEpoch; numLearn++)
            {
                if (stopMem == true)
                    break;
                MEMSomTSP.RunEpoch(MaxEpoch, numLearn);
                if (MEMSomTSP.BestFitness < LastCost)
                {
                    LastCost = MEMSomTSP.BestFitness;
                    TimeToReach = stp.ElapsedMilliseconds / 1000.0; 
                }
                lblMEMSOM.Text = "Num Epoch : " + numLearn.ToString() + "/" + MaxEpoch.ToString() + "\r\nBest fitness : " + MEMSomTSP.BestFitness.ToString("##.###") + " - Time of Reach : " + TimeToReach.ToString("####.####") + "\r\nTime Elapsed : " + (stp.ElapsedMilliseconds / 1000.0).ToString("####.####");
                if (numLearn % 20 == 0)
                {
                    if (chkMEMShow.Checked == true)
                    {
                        //Draw Current State
                        grMEMSOM.Clear(Color.White);
                        for (int i = 1; i < cities.Length; i++)
                        {
                            if (width > 1)
                            {
                                grMEMSOM.DrawString(i.ToString(), new Font("Arial", 5 * (width)), Brushes.Black, new PointF(cities[i].X - 1, cities[i].Y - 1));
                            }
                            grMEMSOM.DrawEllipse(Pens.Black, cities[i].X - width / 2, cities[i].Y - width / 2, width, width);
                        }

                        MemBestweights = MEMSomTSP.GetBestWeights();
                        for (int i = 0; i < NumNN - 2; i++)
                        {
                            grMEMSOM.DrawEllipse(Pens.Black, MemBestweights[i].X - width / 2, MemBestweights[i].Y - width / 2, width, width);
                            grMEMSOM.DrawLine(Pens.DarkBlue, MemBestweights[i].X, MemBestweights[i].Y, MemBestweights[i + 1].X, MemBestweights[i + 1].Y);
                        }
                        grMEMSOM.DrawEllipse(Pens.Black, MemBestweights[NumNN - 2].X - width / 2, MEMSomTSP.BestResult.Weights[NumNN - 2].Y - width / 2, width, width);
                        grMEMSOM.DrawLine(Pens.DarkBlue, MemBestweights[NumNN - 2].X, MemBestweights[NumNN - 2].Y, MemBestweights[0].X, MemBestweights[0].Y);

                        gr.DrawImage(MEMSOMbmp, 0, 0, picSOM.Width, picSOM.Height);
                        picMEMSOM.Image = MEMSOMbmp;
                        //picMEMSOM.Invalidate();
                    }
                    Application.DoEvents();
                }
            }
            stp.Stop();
            grMEMSOM.Clear(Color.White);
            MemBestweights = MEMSomTSP.GetBestWeights();

            for (int i = 1; i < cities.Length; i++)
            {
                if (width > 1)
                {
                    grMEMSOM.DrawString(i.ToString(), new Font("Arial", 5 * (width)), Brushes.Black, new PointF(cities[i].X - 1, cities[i].Y - 1));
                }
                grMEMSOM.DrawEllipse(Pens.Black, cities[i].X - width / 2, cities[i].Y - width / 2, width, width);
            }
            for (int i = 0; i < MemBestweights.Length - 2; i++)
            {
                grMEMSOM.DrawEllipse(Pens.Black, MemBestweights[i].X - width / 2, MemBestweights[i].Y - width / 2, width, width);
                grMEMSOM.DrawLine(Pens.Red, MemBestweights[i].X, MemBestweights[i].Y, MemBestweights[i + 1].X, MemBestweights[i + 1].Y);
            }
            grMEMSOM.DrawEllipse(Pens.Black, MemBestweights[MemBestweights.Length - 2].X - width / 2, MemBestweights[MemBestweights.Length - 2].Y - width / 2, width, width);
            grMEMSOM.DrawLine(Pens.Red, MemBestweights[MemBestweights.Length - 2].X, MemBestweights[MemBestweights.Length - 2].Y, MemBestweights[0].X, MemBestweights[0].Y);
            picMEMSOM.Image = MEMSOMbmp;
            picMEMSOM.Invalidate();
            Application.DoEvents();
            lblMEMSOM.Text = "Tour Value = " + MEMSomTSP.BestFitness.ToString() + "\r\nTime of Reach : " + TimeToReach.ToString("####.####") + "\r\nTotal : " + (stp.ElapsedMilliseconds / 1000.0).ToString("###.###");
        }

        private void btnSaveMemSOM_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm = (Bitmap)picMEMSOM.Image.Clone();
                DialogResult res = cmdSave.ShowDialog();
                if (res == DialogResult.OK)
                {
                    bm.Save(cmdSave.FileName);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error");
            }
        }


        private void btnStopICABase_Click(object sender, EventArgs e)
        {
            Stop = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string optimumfilename = txtFileName.Text.Substring(0, txtFileName.Text.IndexOf('.')) + ".opt.tour";
            if (File.Exists(optimumfilename))
            {
                double tourlength = 0;
                string str = File.ReadAllText(optimumfilename);
                for (int i = 0; i < 100; i++)
                {
                    str = str.Replace("  ", " ");
                }
                str = str.Replace(" ", "\r\n");


                string[] alllines = str.Split(new char[] { '\n', '\r' }).ToArray().Where(x => x != "").ToArray();
                if (ShowCities)
                {
                    float width = bmp.Width / 800f;
                    Graphics gr = Graphics.FromImage(bmp);
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    gr.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    Pen p = new Pen(Color.Black);
                    p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                    int startIndex = 0;
                    int currentCity = 0, nextCity = 0;
                    for (int st = 0; st < alllines.Length; st++)
                    {
                        if (alllines[st] == "TOUR_SECTION")
                        {
                            startIndex = st + 1;
                            break;
                        }
                    }

                    int firstCity = int.Parse(alllines[startIndex]);
                    for (int i = startIndex; i < alllines.Length - 1; i++)
                    {
                        if (int.Parse(alllines[i + 1]) != -1 && alllines[i + 1] != "EOF")
                        {
                            currentCity = int.Parse(alllines[i]);
                            nextCity = int.Parse(alllines[i + 1]);
                            tourlength += weight_array[currentCity, nextCity]; //(int)Math.Round(distance(raw_cities[currentCity], raw_cities[nextCity]));

                            gr.DrawLine(p, cities[currentCity].X, cities[currentCity].Y, cities[nextCity].X, cities[nextCity].Y);
                        }
                        else
                            break;
                    }
                    gr.DrawLine(p, cities[nextCity].X, cities[nextCity].Y, cities[firstCity].X, cities[firstCity].Y);
                    tourlength += weight_array[nextCity, firstCity]; //(int)Math.Round(distance(raw_cities[nextCity], raw_cities[firstCity]));
                    picLast.Image = bmp;
                    picLast.Invalidate();
                    lblTourlength.Text = "Tour :\r\n" + tourlength.ToString("##.###"); 
                    Application.DoEvents();
                }
            }
            else
            {
                MessageBox.Show("Optimum tour file could n't loaded", "error");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics gr = Graphics.FromImage(bmp);
            gr.Clear(Color.White);
            picLast.Image = bmp;
            picLast.Invalidate();

            Application.DoEvents();
        }

        private PointF DrawCities(Graphics grSOM,Pen color, List<PointF> Assigned_cities_drawing)
        {
            float X0 = 0, Y0 = 0;
            float width = bmp.Width / 200f;
            for (int i = 1; i < Assigned_cities_drawing.Count; i++)
            {
                X0 += Assigned_cities_drawing[i].X;
                Y0 += Assigned_cities_drawing[i].Y;
                grSOM.FillEllipse(color.Brush, Assigned_cities_drawing[i].X - width / 2, Assigned_cities_drawing[i].Y - width / 2, width, width);
            }
            return new PointF((float)(X0 / (Assigned_cities_drawing.Count - 1)), (float)(Y0 / (Assigned_cities_drawing.Count - 1)));
        }

        private void btnBubble_Click(object sender, EventArgs e)
        {
            bool Iteration_as_termination = chkItTerm.Checked;
            int num_individual = (int)nudBubbleIndv.Value;
            int Stop_iteration = (int)nudStopIteration.Value;
            float MAX_WIDTH = 0, MAX_HEIGHT = 0;
            Random rnd = new Random();
            double epsilon = 0.001;
            double C = 0.5;
            switch (cmbSetting.SelectedIndex)
            {
                case 1:
                    epsilon = 0.1;
                    C = 0.1; 
                    break;
                case 2:
                    epsilon = 0.01;
                    C = 0.1; 
                    break;
                case 3:
                    epsilon = 0.001;
                    C = 0.1; 
                    break;
                case 4:
                    epsilon = 0.1;
                    C = 0.5; 
                    break;
                case 5:
                    epsilon = 0.01;
                    C = 0.5; 
                    break;
                case 6:
                    epsilon = 0.001;
                    C = 0.5; 
                    break;
                case 7:
                    epsilon = 0.1;
                    C = 0.9; 
                    break;
                case 8:
                    epsilon = 0.01;
                    C = 0.9; 
                    break;
                case 9:
                    epsilon = 0.001;
                    C = 0.9; 
                    break;
            }

            int numberOfCells = (int)nudBubGroup.Value;
            float width = bmp.Width / 600f;
            Font DrawingCityFont = new  Font("Arial", 5 * (width));
            Font DrawingFont = new  Font("Times New Roman", 15 * (width));
            Pen[] Colors = new Pen[10] { new Pen(Color.Blue, width), new Pen(Color.Red, width), new Pen(Color.Green, width), new Pen(Color.Orange, width),
                                      new Pen(Color.Pink, width), new Pen(Color.Violet, width), new Pen(Color.YellowGreen, width),new Pen(Color.Olive, width), new Pen(Color.Navy, width),
                                      new Pen(Color.Magenta,width)};
            Colors[0].DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            Colors[1].DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            Colors[2].DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Colors[3].DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            Colors[4].DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            Colors[5].DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            Colors[6].DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
            Colors[7].DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            Colors[8].DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
            Colors[9].DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            Dictionary<int, List<PointF>> Assigned_cities = new Dictionary<int, List<PointF>>();
            Dictionary<int, PointF> Cells = new Dictionary<int, PointF>(numberOfCells);
            ConcurrentDictionary<int, List<clsSOMTSP>> Evolving_Cell = new ConcurrentDictionary<int, List<clsSOMTSP>>();
            clsSOMTSP BestSeenMap = new clsSOMTSP(0, new PointF[0], 0);

            Bitmap SOMbmp = new Bitmap(bmp.Width, bmp.Height);
            Graphics grSOM = Graphics.FromImage(SOMbmp);
            Graphics gr = picBubble.CreateGraphics();
            grSOM.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
            grSOM.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            grSOM.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;


            double pondering_delay = 0.0;//(numberOfCells == 1) ? 0 : (1.0 / numberOfCells);  //TODO: Check Different Values

            int[] BestIndividual_index = new int[numberOfCells];
            int[] WorstIndividuals_index = new int[numberOfCells];
            //int[] NumberOfStoppedFrame = new int[numberOfCells];
            bool[] IsStop = new bool[numberOfCells];
            bool[] KillTask = new bool[numberOfCells];

            int Recalculation_Period = 1;
            int cnt_Merge = 0;
            int numLearn = 0;
            int MaxEpoch = (int)nudBubMaxIt.Value;
            bool[,] isNeighborhood = new bool[numberOfCells, numberOfCells];

            int StartTime = Environment.TickCount;
            float ReachedTime = 0;
            #region "K-Mean Assignments"
            grSOM.Clear(Color.White);

            for (int i = 1; i < cities.Length; i++)
            {
                if (cities[i].X > MAX_WIDTH)
                    MAX_WIDTH = cities[i].X;
                if (cities[i].Y > MAX_HEIGHT)
                    MAX_HEIGHT = cities[i].Y;

                if (width > 1)
                {
                    grSOM.DrawString(i.ToString(), new Font("Arial", 5 * (width)), Brushes.Black, new PointF(cities[i].X - 1, cities[i].Y - 1));
                }
                grSOM.DrawEllipse(Pens.Black, cities[i].X - width / 2, cities[i].Y - width / 2, width, width);
            }
            // SOMbmp.Save("C:\\Users\\Danial\\Desktop\\bef_clustering.bmp");
            // dividing into number of cells by K-mean Algorithm
            for (int i = 0; i < numberOfCells; i++)
            {
                int random_city_index = 1 + (int)Math.Round(rnd.NextDouble() * (cities.Length - 3));
                Cells.Add(i, cities[random_city_index]);
                //Cells.Add(i, cities[1 + i]);
                Assigned_cities.Add(i, new List<PointF>());
            }

            double Changed_distance = 1000;
            while (Changed_distance > 10)
            {
                // Clearing previous assignment
                Changed_distance = 0;
                for (int i = 0; i < numberOfCells; i++)
                {
                    Assigned_cities[i].Clear();
                    Assigned_cities[i].Add(new PointF(0, 0));
                }

                // Assigning cities
                for (int j = 1; j < cities.Length; j++)
                {
                    double Min_dist = double.MaxValue;
                    int Min_index = -1;
                    for (int i = 0; i < numberOfCells; i++)
                    {
                        double dist = distance(cities[j], Cells[i]);
                        if (dist < Min_dist)
                        {
                            Min_index = i;
                            Min_dist = dist;
                        }
                    }
                    Assigned_cities[Min_index].Add(cities[j]);
                }

                // Updating new location for centroid and draw assigned cities
                for (int i = 0; i < numberOfCells; i++)
                {
                    PointF newPos = DrawCities(grSOM, Colors[i], Assigned_cities[i]);
                    Changed_distance += distance(newPos, Cells[i]);
                    Cells[i] = newPos;

                    gr.DrawImage(SOMbmp, 0, 0, picBubble.Width, picBubble.Height);
                }
            }
            for (int i = 0; i < Cells.Count; i++)
            {
                List<clsSOMTSP> items = new List<clsSOMTSP>();
                for (int j = 0; j < num_individual; j++)
                {
                    float FirstX0 = Cells[i].X + (float)(Math.Pow(-1, Math.Round(100 * rnd.NextDouble())) * (bmp.Width / 10) * (rnd.NextDouble()));
                    float FirstY0 = Cells[i].Y + (float)(Math.Pow(-1, Math.Round(100 * rnd.NextDouble())) * (bmp.Height / 10) * (rnd.NextDouble()));
                    double local_beta = 1 + 0.3 * Assigned_cities[i].Count; //0.08 * Assigned_cities[i].Count;
                    items.Add(new clsSOMTSP(Assigned_cities[i].Count * 5, Assigned_cities[i].ToArray(), FirstX0, FirstY0, bmp.Width / (50f * rnd.Next(1, 3)), bmp.Height / (50f * rnd.Next(1, 3)), 10000 * rnd.NextDouble(), local_beta));
                }
                Evolving_Cell.TryAdd(i, items);
            }
            //SOMbmp.Save("C:\\Users\\Edris\\Desktop\\aft_clustering.bmp");

            #region "Calculating whether pair of i and j are neighborhood"
            for (int i = 0; i < Cells.Count; i++)
            {
                for (int j = 0; j < Cells.Count; j++)
                {
                    if (i != j)
                    {
                        bool res = false;
                        for (int k = 0; k < Cells.Count; k++)
                        {
                            for (int l = 0; l < Cells.Count; l++)
                            {
                                if (k != i && k != j && l != i && l != j)
                                {
                                    res = IsIntersecting(Cells[i], Cells[j], Cells[k], Cells[l]);
                                    if (res == true)
                                        break;
                                }
                            }
                            if (res == true)
                                break;
                        }
                        if (res == true)
                            isNeighborhood[i, j] = false;
                        else
                        {
                            // Checking closeness of two regions
                            #region "Recalculating Neighborhoods"
                            int cnt_dist = 0;
                            double dist1 = distance(Cells[i], Cells[j]);
                            double dist2 = 0;
                            for (int dst = 0; dst < Cells.Count; dst++)
                            {
                                if (dst != i)
                                {
                                    cnt_dist++;
                                    dist2 += distance(Cells[i], Cells[dst]);
                                }
                            }
                            dist2 /= cnt_dist;
                            if (dist1 < dist2)
                            {
                                isNeighborhood[i, j] = true;
                                isNeighborhood[j, i] = true;
                            }
                            else
                                isNeighborhood[i, j] = false;
                            #endregion
                        }
                    }
                }
            }
            #endregion
            #endregion

            #region "Learning phase"

            int[] numRegionalLearn = new int[numberOfCells];
            var RegionalLearners = Enumerable.Range(0, numberOfCells).Select(i => Task.Factory.StartNew(() =>
                {
                    lock (numRegionalLearn){ numRegionalLearn[i] = 0; }
                    int last_best_seen = 0;
                    double previous_best = double.MaxValue;
                    //double previous_total_cost = 0;
                    //double current_total_cost = 0;
                    while (true)
                    {
                        lock (KillTask)
                        {
                            if (KillTask[i] == true)
                                break;
                        }


                        lock (IsStop)
                        {
                            if (IsStop[i])
                            {
                                Thread.Sleep(50);     //break for a while to be assigned to new cities;
                                continue;
                            }
                        }
                        lock (numRegionalLearn) { numRegionalLearn[i]++; }


                        int item_index = -1;

                        double WorstTour = double.MinValue;
                        double BestTour = double.MaxValue;

                        List<clsSOMTSP> values;
                        bool ret = Evolving_Cell.TryGetValue(i, out values);
                        if (!ret) throw new Exception("Evolving_Cell for " + i + " not found");
                        //current_total_cost = 0;
                        foreach (clsSOMTSP item in values)
                        {
                            item_index++;
                            int applied_it = 0;
                            lock (numRegionalLearn){ applied_it = numRegionalLearn[i]; }


                            for (int numCity = 0; numCity < values.First().CitiesImporter.Length; numCity++)
                                item.LearnMunicipality((int)(MaxEpoch + cnt_Merge * pondering_delay * MaxEpoch), applied_it);

                            if (numLearn % Recalculation_Period == 0)
                            {
                                //Replacing Worst individual with Best Individual
                                double tourValue = 0;
                                if (Evolving_Cell.Count > 1)
                                    tourValue = item.findTourLength();
                                else
                                {
                                    item.CitiesImporter = cities;
                                    tourValue = item.FindCurrentValue(weight_array);
                                }
                                item.CurrentValue = tourValue;
                                //current_total_cost += tourValue;
                                if (tourValue > WorstTour)
                                {
                                    WorstTour = tourValue;
                                    lock (WorstIndividuals_index) { WorstIndividuals_index[i] = item_index; }
                                }
                                if (tourValue < BestTour)
                                {
                                    BestTour = tourValue;
                                    lock (BestIndividual_index) { BestIndividual_index[i] = item_index; }
                                }
                            }
                        }

                        
                        if (numLearn % Recalculation_Period == 0)
                        {
                            int wi, bi;
                            lock (WorstIndividuals_index) { wi = WorstIndividuals_index[i]; }
                            lock (BestIndividual_index) { bi = BestIndividual_index[i]; }

                            lock (values)
                            {
                                if (Evolving_Cell.Count == 1)
                                {
                                    if (BestSeenMap.CurrentValue > values[bi].CurrentValue || BestSeenMap.CurrentValue == 0)
                                    {
                                        ReachedTime = (Environment.TickCount - StartTime) / 1000.0f;
                                        BestSeenMap = values[bi].Clone();
                                    }
                                }

                                if ((previous_best - values[bi].CurrentValue) / (values[bi].CurrentValue) > (epsilon * Evolving_Cell.Count)) // at least 1 percent benefit in determined duration
                                {
                                    previous_best = values[bi].CurrentValue;
                                    lock (numRegionalLearn) { last_best_seen = numRegionalLearn[i]; }
                                }

                                if (Evolving_Cell.Count > 1)
                                    values[wi] = values[bi].Clone();
                                else
                                    values[wi] = BestSeenMap.Clone();
                            }
                        }

                        
                        try
                        {
                            int last_seen_duration = 0, current_it = 0;
                            lock (numRegionalLearn) {current_it = numRegionalLearn[i];}
                            last_seen_duration = current_it - last_best_seen;

                            if (last_seen_duration > 10 / Math.Exp(-C * Evolving_Cell.Count()))
                            {
                                last_best_seen = current_it;
                                previous_best = double.MaxValue;
                                lock (IsStop) { IsStop[i] = true; }
                            }
                            if ((current_it > Stop_iteration) && (Iteration_as_termination == true))
                            {
                                lock (IsStop) { IsStop[i] = true; }
                            }
                        }
                        catch (Exception) { }
                    }
                }, TaskCreationOptions.LongRunning)).ToArray();
            Task.WaitAll();
            
            #endregion

            Task.Factory.StartNew(() =>
            {
                int firstKey = Evolving_Cell.Keys.First();
                while (true)
                {
                    int numRL = 0;
                    bool stop = false;
                    lock (IsStop) { stop = IsStop[firstKey]; }
                    lock (numRegionalLearn) { numRL = numRegionalLearn[firstKey]; }

                    if (Evolving_Cell.Count == 1 && stop)
                    {
                        #region "Final Answer Preparation"
                        List<clsSOMTSP> values;

                        Evolving_Cell.TryGetValue(firstKey, out values);

                        lock (values)
                        {
                            //BestSeenMap.Redistribute();
                            BestSeenMap.BreakTie();
                            BestSeenMap.CitiesImporter = cities;
                            BestSeenMap.FineTune();
                            BestSeenMap.RemoveUnnecessary();


                            grSOM.Clear(Color.White);
                            for (int k = 1; k < cities.Length; k++)
                            {
                                if (width > 1)
                                    grSOM.DrawString(k.ToString(), DrawingCityFont, Brushes.Black, new PointF(cities[k].X - 1, cities[k].Y - 1));
                                grSOM.DrawEllipse(Pens.Black, cities[k].X - width / 2, cities[k].Y - width / 2, width, width);
                            }

                            for (int k = 0; k < BestSeenMap.Weights.Length - 1; k++)
                            {
                                grSOM.DrawEllipse(Colors[firstKey], BestSeenMap.Weights[k].X - width / 2, BestSeenMap.Weights[k].Y - width / 2, width, width);
                                grSOM.DrawLine(Colors[firstKey], BestSeenMap.Weights[k].X, BestSeenMap.Weights[k].Y, BestSeenMap.Weights[k + 1].X, BestSeenMap.Weights[k + 1].Y);
                            }
                            grSOM.DrawLine(Colors[firstKey], BestSeenMap.Weights[BestSeenMap.Weights.Length - 1].X, BestSeenMap.Weights[BestSeenMap.Weights.Length - 1].Y, BestSeenMap.Weights[firstKey].X, BestSeenMap.Weights[firstKey].Y);
                            gr.DrawImage(SOMbmp, 0, 0, picBubble.Width, picBubble.Height);

                            if (BestSeenMap.findTourValue(weight_array) != -1)
                            {
                                lblReportBub.BeginInvoke(new Action(() =>
                                {
                                    lblReportBub.Text = "Tour Value without deleting = " + BestSeenMap.findTourValue(weight_array).ToString() + "\r\nReached Time = " + ReachedTime.ToString("##0.##") + "  -  Final Time = " + ((Environment.TickCount - StartTime) / 1000.0).ToString("##.##");
                                }));
                            }
                            else
                            {
                                lblReportBub.BeginInvoke(new Action(() => { lblReportBub.Text = "Uncoveged network"; }));
                            }
                        }
                        #endregion

                        picBubble.Image = SOMbmp;
                        picBubble.Invalidate();
                        Application.DoEvents();
                        break;
                    }

                    #region "Merging Part"
                    for (int i = 0; i < numberOfCells; i++)
                    {
                        if (Evolving_Cell.ContainsKey(i))
                        {
                            bool isStop_i = false;
                            lock(IsStop){isStop_i = IsStop[i];}
                            if (isStop_i)
                            {
                                double minD = double.MaxValue;
                                int min_index = -1;
                                for (int j = i + 1; j < numberOfCells; j++) // Symmetric distance
                                {
                                    if (Evolving_Cell.ContainsKey(j))
                                    {
                                        bool stopJ = false;
                                        lock (IsStop)
                                        {
                                            stopJ = IsStop[j];
                                        }
                                        int numRL_i, numRL_j;
                                        lock (numRegionalLearn)
                                        {
                                            numRL_i = numRegionalLearn[i];
                                            numRL_j = numRegionalLearn[j];
                                        }

                                        if (stopJ && (isNeighborhood[i, j] || (Evolving_Cell.Count <= 2) /*|| Math.Max(numRL_i, numRL_j) > MaxEpoch / 1.2*/))
                                        {
                                            double dist_cen = distance(Cells[i], Cells[j]);
                                            if (dist_cen < minD)
                                            {
                                                minD = dist_cen;
                                                min_index = j;
                                            }
                                        }
                                    }
                                }
                                int numRL_i2, numRL_min;
                                lock (numRegionalLearn)
                                {
                                        numRL_i2 = numRegionalLearn[i];
                                        if (min_index != -1)
                                            numRL_min = numRegionalLearn[min_index];
                                        else
                                            numRL_min = 0;
                                }

                                if (min_index != -1 && (isNeighborhood[i, min_index] || (Evolving_Cell.Count <= 2) /*|| Math.Max(numRL_i2, numRL_min) > MaxEpoch / 1.2 */))
                                {
                                    // Updating Neighborhoods
                                    for (int kk = 0; kk < numberOfCells; kk++)
                                    {
                                        isNeighborhood[i, kk] = isNeighborhood[min_index, kk] = (isNeighborhood[min_index, kk] || isNeighborhood[i, kk]);
                                        isNeighborhood[kk, i] = isNeighborhood[kk, min_index] = (isNeighborhood[kk, min_index] || isNeighborhood[kk, i]);
                                    }

                                    List<clsSOMTSP> valuesI, valuesMin;
                                    Evolving_Cell.TryGetValue(i, out valuesI);
                                    Evolving_Cell.TryGetValue(min_index, out valuesMin);
                                    lock (valuesI)
                                    {
                                        lock (BestIndividual_index)
                                        {
                                            valuesI[BestIndividual_index[i]].Redistribute();
                                        }
                                    }
                                    lock (valuesMin)
                                    {
                                        lock (BestIndividual_index)
                                        {
                                            valuesMin[BestIndividual_index[min_index]].Redistribute();
                                        }
                                    }

                                    cnt_Merge++;

                                    int num_city_i = Evolving_Cell[i].First().CitiesImporter.Length;
                                    int num_city_min = Evolving_Cell[min_index].First().CitiesImporter.Length;

                                    bool res;
                                    lock (valuesI)
                                    {
                                        lock (valuesMin)
                                        {
                                            lock (BestIndividual_index)
                                            {
                                                res = valuesI[BestIndividual_index[i]].Merge(valuesMin[BestIndividual_index[min_index]]);
                                                for (int ii = 0; ii < valuesI.Count; ii++)
                                                {
                                                    valuesI[ii]._baseBeta = 1 + 0.3 * valuesI[ii].CitiesImporter.Count(); //0.08 * Assigned_cities[i].Count;
                                                    if (ii != BestIndividual_index[i])
                                                    {
                                                        int dest = rnd.Next(valuesMin.Count - 1);
                                                        res = valuesI[ii].Merge(valuesMin[dest]);
                                                    }
                                                    if (Evolving_Cell.Count == 2)
                                                        valuesI[ii].CitiesImporter = cities;  // It means we are at final phase
                                                }
                                            }
                                        }
                                    }


                                    lock (IsStop) { IsStop[i] = false; }
                                    lock (numRegionalLearn) { numRegionalLearn[i] = Math.Max(numRegionalLearn[i], numRegionalLearn[min_index]); /*(int)((num_city_i * numRegionalLearn[i] + num_city_min * numRegionalLearn[min_index]) / (num_city_min + num_city_i));*/ }
                                    lock (KillTask) { KillTask[min_index] = true; }

                                    Application.DoEvents();
                                    Cells[i] = new PointF((num_city_i * Cells[i].X + num_city_min * Cells[min_index].X) / (num_city_i + num_city_min), (num_city_i * Cells[i].Y + num_city_min * Cells[min_index].Y) / (num_city_i + num_city_min));
                                    Cells.Remove(min_index);
                                    List<clsSOMTSP> rev;
                                    Evolving_Cell.TryRemove(min_index, out rev);
                                    Application.DoEvents();
                                }
                            }
                        }
                    }
                    #endregion
                    Thread.Sleep(50);
                }

            }, TaskCreationOptions.LongRunning);

            #region "Thread - Drawer"
            if (chkBubble.Checked == true)
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        int numRL = 0;
                        bool stop = false;

                        int firstKey = Evolving_Cell.Keys.First();
                        lock (IsStop) { stop = IsStop[firstKey]; }
                        lock (numRegionalLearn) { numRL = numRegionalLearn[firstKey]; }

                        if (Evolving_Cell.Count == 1 && stop)
                            break;

                        #region "Drawing parts"
                        double approximated_cost = 0;

                        #region "Drawing Cities"
                        grSOM.Clear(Color.White);
                        for (int k = 1; k < cities.Length; k++)
                        {
                            if (width > 1)
                                grSOM.DrawString(k.ToString(), DrawingCityFont, Brushes.Black, new PointF(cities[k].X - 1, cities[k].Y - 1));
                            grSOM.DrawEllipse(Pens.Black, cities[k].X - width / 2, cities[k].Y - width / 2, width, width);
                        }
                        #endregion

                        for (int i = 0; i < numberOfCells; i++)
                        {
                            if (Evolving_Cell.ContainsKey(i))
                            {
                                List<clsSOMTSP> valuesI;
                                Evolving_Cell.TryGetValue(i, out valuesI);
                                lock (valuesI)
                                {
                                    lock (BestIndividual_index)
                                    {
                                        approximated_cost += valuesI[BestIndividual_index[i]].CurrentValue;
                                        for (int k = 0; k < valuesI[BestIndividual_index[i]].Weights.Length - 1; k++)
                                        {
                                            grSOM.DrawEllipse(Colors[i], valuesI[BestIndividual_index[i]].Weights[k].X - width / 2,
                                                                            valuesI[BestIndividual_index[i]].Weights[k].Y - width / 2, width, width);
                                            grSOM.DrawLine(Colors[i], valuesI[BestIndividual_index[i]].Weights[k].X,
                                                                        valuesI[BestIndividual_index[i]].Weights[k].Y,
                                                                        valuesI[BestIndividual_index[i]].Weights[k + 1].X,
                                                                        valuesI[BestIndividual_index[i]].Weights[k + 1].Y);
                                        }
                                        grSOM.DrawLine(Colors[i], valuesI[BestIndividual_index[i]].Weights[valuesI[BestIndividual_index[i]].Weights.Length - 1].X,
                                            valuesI[BestIndividual_index[i]].Weights[valuesI[BestIndividual_index[i]].Weights.Length - 1].Y,
                                            valuesI[BestIndividual_index[i]].Weights[0].X,
                                            valuesI[BestIndividual_index[i]].Weights[0].Y);
                                    }
                                }                                
                            }
                        }
                        int MaxIt = int.MinValue;
                        lock (numRegionalLearn)
                        {
                            MaxIt = numRegionalLearn.Max();
                            if (BestSeenMap.CurrentValue != 0)
                                grSOM.DrawString(MaxIt.ToString() + " - " + BestSeenMap.CurrentValue.ToString() + " / " + ((Environment.TickCount - StartTime) / 1000.0f).ToString("#.#"), DrawingFont, Brushes.Black, new PointF(0, 0));
                            else
                                grSOM.DrawString(MaxIt.ToString() + " - " + approximated_cost.ToString("#.#") + " / " + ((Environment.TickCount - StartTime) / 1000.0f).ToString("#.#"), DrawingFont, Brushes.Black, new PointF(0, 0));
                        }
                        gr.DrawImage(SOMbmp, 0, 0, picBubble.Width, picBubble.Height);
                        Application.DoEvents();

                        #endregion
                        Thread.Sleep(300);
                    }
                }, TaskCreationOptions.LongRunning);
            }
            else
            {
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        bool stop = false;
                        int firstKey = Evolving_Cell.Keys.First();
                        lock (IsStop) { stop = IsStop[firstKey]; }

                        if (Evolving_Cell.Count == 1 && stop)
                            break;

                        #region "Drawing parts"
                            if (numLearn % Recalculation_Period == 0)
                            {
                                grSOM.Clear(Color.White);
                                int MaxIt = int.MinValue;
                                lock (numRegionalLearn)
                                {
                                    MaxIt = numRegionalLearn.Max();
                                    grSOM.DrawString(MaxIt.ToString() + " - " + BestSeenMap.CurrentValue.ToString() + " / " + ((Environment.TickCount - StartTime) / 1000.0f).ToString("#.#"), DrawingFont, Brushes.Black, new PointF(0, 0));
                                }

                                gr.DrawImage(SOMbmp, 0, 0, picBubble.Width, picBubble.Height);
                                Application.DoEvents();
                            }
                        #endregion
                        Thread.Sleep(300);
                    }
                }, TaskCreationOptions.LongRunning);
            }
            #endregion
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap bm = (Bitmap)picBubble.Image.Clone();
                DialogResult res = cmdSave.ShowDialog();
                if (res == DialogResult.OK)
                {
                    bm.Save(cmdSave.FileName);
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message, "Error");
            }

        }

        private void btnSaveImageOfMap_Click(object sender, EventArgs e)
        {
            cmdSave.FileName = "";
            DialogResult res = cmdSave.ShowDialog();
            if (res == DialogResult.OK)
            {
                picPlot.Image.Save(cmdSave.FileName);
            }
        }


    }
}
