using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStar
{
    public partial class FormMain : Form
    {
        Random random;
        public static List<List<IVertex>> paths;
        public static List<long> times;

        public FormMain()
        {
            InitializeComponent();
            random = new Random();
            dataGridViewField.RowCount = Convert.ToInt32(numericUpDownDimension.Value);
            dataGridViewField.ColumnCount = Convert.ToInt32(numericUpDownDimension.Value);
            for (int i = 0; i < dataGridViewField.RowCount; i++)
                for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                    dataGridViewField[j, i].Value = -1;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void numericUpDownDimension_ValueChanged(object sender, EventArgs e)
        {
            dataGridViewField.RowCount = Convert.ToInt32(numericUpDownDimension.Value);
            dataGridViewField.ColumnCount = Convert.ToInt32(numericUpDownDimension.Value);
            for (int i = 0; i < dataGridViewField.RowCount; i++)
                for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                    dataGridViewField[j, i].Value = -1;
        }

        private void buttonRandom_Click(object sender, EventArgs e)
        {
            int N;
            do
            {
                for (int i = 0; i < dataGridViewField.RowCount; i++)
                    for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                        dataGridViewField[j, i].Value = -1;
                for (int i = 0; i < dataGridViewField.RowCount; i++)
                    for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                    {
                        int x;
                        do
                        {
                            x = random.Next(Convert.ToInt32(Math.Pow(dataGridViewField.RowCount, 2)));
                        } while (ContainsInGrid(x));
                        dataGridViewField[j, i].Value = x;
                        Application.DoEvents();
                    }
                N = 0;
                for (int i = 0; i < dataGridViewField.RowCount; i++)
                    for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                        if (Convert.ToInt32(dataGridViewField[j, i].Value) != 0)
                        {
                            for (int ii = i; ii < dataGridViewField.RowCount; ii++)
                                for (int jj = ii == i ? j : 0; jj < dataGridViewField.ColumnCount; jj++)
                                    if (Convert.ToInt32(dataGridViewField[jj, ii].Value) != 0 && Convert.ToInt32(dataGridViewField[jj, ii].Value) < Convert.ToInt32(dataGridViewField[j, i].Value))
                                        N++;
                        }

            } while (N%2==1);
        }

        bool ContainsInGrid(int x)
        {
            for (int i = 0; i < dataGridViewField.RowCount; i++)
                for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                    if (Convert.ToInt32(dataGridViewField[j, i].Value) == x)
                        return true;
            return false;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            paths = new List<List<IVertex>>();
            times = new List<long>();
            System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            GameGraph game = new GameGraph(Convert.ToUInt32(numericUpDownDimension.Value));
            uint[,] state = new uint[Convert.ToUInt32(numericUpDownDimension.Value), Convert.ToUInt32(numericUpDownDimension.Value)];
            for (int i = 0; i < dataGridViewField.RowCount; i++)
                for (int j = 0; j < dataGridViewField.ColumnCount; j++)
                    state[i, j] = Convert.ToUInt32(dataGridViewField[j, i].Value);
            GameVertex start = new GameVertex(Convert.ToUInt32(numericUpDownDimension.Value), state);
            uint[,] goalState = new uint[Convert.ToUInt32(numericUpDownDimension.Value), Convert.ToUInt32(numericUpDownDimension.Value)];
            uint k = 0;
            for (int i = 0; i < Convert.ToUInt32(numericUpDownDimension.Value); i++)
                for (int j = 0; j < Convert.ToUInt32(numericUpDownDimension.Value); j++, k++)
                    goalState[i, j] = k;
            GameVertex goal = new GameVertex(Convert.ToUInt32(numericUpDownDimension.Value), goalState);
            AStar astar = new AStar(Convert.ToDouble(textBoxOmega.Text), game, start, goal);
            bool flag = true;
            do
            {
                try
                {
                    stopwatch.Start();
                    paths.Add(astar.GetWay());
                    stopwatch.Stop();
                    times.Add(stopwatch.ElapsedMilliseconds);
                }
                catch (Exception)
                {
                    flag = false;
                } 
            } while (flag);
            FormSolutions formSolutions = new FormSolutions();
            for (int i = 0; i < paths.Count; i++)
            {
                formSolutions.listBoxSolutions.Items.Add("Solution " + i);
                formSolutions.chartProfile.Series[0].Points.AddXY(times[i], Convert.ToDouble(paths.Last().Count) / Convert.ToDouble(paths[i].Count));
            }

            formSolutions.ShowDialog();
        }
    }
}
