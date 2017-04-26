using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TSP
{
    public partial class frmShowWeights : Form
    {
        double[,] weights;
        public frmShowWeights()
        {
            InitializeComponent();
        }
        public frmShowWeights(double[,] in_weights)
        {
            weights = in_weights;
            InitializeComponent();
        }

        private void frmShowWeights_Load(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < weights.GetUpperBound(0); i++)
                {
                    dataGridView1.Columns.Add((i + 1).ToString(), (i + 1).ToString());
                }
                for (int i = 0; i < weights.GetUpperBound(0) - 1; i++)
                {
                    dataGridView1.Rows.Add(new object[] { });
                    dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }
                for (int i = 0; i < weights.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < weights.GetUpperBound(0); j++)
                    {
                        dataGridView1[i, j].Value = weights[i + 1, j + 1];
                    }
                }
            }
            catch(Exception s)
            {
                MessageBox.Show(s.ToString(), "Error");
            }
          
        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = SFD1.ShowDialog();
            if (res.ToString() != "")
            {
                StreamWriter SWriter = new StreamWriter(SFD1.FileName);

                for (int i = 0; i < weights.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < weights.GetUpperBound(0); j++)
                    {
                        SWriter.Write(weights[i + 1, j + 1].ToString() + "\t");
                    }
                    SWriter.Write("\r\n");
                }
                SWriter.Close();
            }
        }
    }
}
