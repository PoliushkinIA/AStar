namespace AStar
{
    partial class FormSolutions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartProfile = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxSolutions = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // chartProfile
            // 
            chartArea5.Name = "ChartArea1";
            this.chartProfile.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.chartProfile.Legends.Add(legend5);
            this.chartProfile.Location = new System.Drawing.Point(12, 25);
            this.chartProfile.Name = "chartProfile";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "ПП";
            this.chartProfile.Series.Add(series5);
            this.chartProfile.Size = new System.Drawing.Size(354, 309);
            this.chartProfile.TabIndex = 0;
            this.chartProfile.Text = "chartProfile";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Профиль производительности:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(378, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Решения:";
            // 
            // listBoxSolutions
            // 
            this.listBoxSolutions.FormattingEnabled = true;
            this.listBoxSolutions.Location = new System.Drawing.Point(381, 25);
            this.listBoxSolutions.Name = "listBoxSolutions";
            this.listBoxSolutions.Size = new System.Drawing.Size(203, 277);
            this.listBoxSolutions.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(415, 308);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Показать решение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormSolutions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 346);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxSolutions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSolutions";
            this.ShowInTaskbar = false;
            this.Text = "Профиль производительности";
            ((System.ComponentModel.ISupportInitialize)(this.chartProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartProfile;
        public System.Windows.Forms.ListBox listBoxSolutions;
        private System.Windows.Forms.Button button1;
    }
}