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
    public partial class FormSolutions : Form
    {
        public FormSolutions()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormSolutionView formSolutionView = new FormSolutionView(FormMain.paths[listBoxSolutions.SelectedIndex]);
            formSolutionView.ShowDialog();
        }
    }
}
