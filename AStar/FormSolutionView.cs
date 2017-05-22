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
    public partial class FormSolutionView : Form
    {
        List<IVertex> path;

        public FormSolutionView(List<IVertex> path)
        {
            InitializeComponent();
            this.path = path;
            for (int i = 0; i < path.Count; i++)
                listBox1.Items.Add("Состояние " + i);
            dataGridView1.RowCount = (int)((GameVertex)path[0]).Dimension;
            dataGridView1.ColumnCount = (int)((GameVertex)path[0]).Dimension;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ((GameVertex)path[0]).Dimension; i++)
                for (int j = 0; j < ((GameVertex)path[0]).Dimension; j++)
                    dataGridView1[j, i].Value = ((GameVertex)path[listBox1.SelectedIndex]).State[i, j];
        }
    }
}
