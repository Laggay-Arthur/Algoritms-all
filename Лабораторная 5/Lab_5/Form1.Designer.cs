namespace Lab_5
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Counting = new System.Windows.Forms.Button();
            this.couthop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.downLimit = new System.Windows.Forms.TextBox();
            this.upLimit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Graph = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(1, 1);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Red;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(800, 410);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Counting
            // 
            this.Counting.Location = new System.Drawing.Point(319, 426);
            this.Counting.Name = "Counting";
            this.Counting.Size = new System.Drawing.Size(75, 23);
            this.Counting.TabIndex = 1;
            this.Counting.Text = "Расчитать";
            this.Counting.UseVisualStyleBackColor = true;
            this.Counting.Click += new System.EventHandler(this.Counting_Click);
            // 
            // couthop
            // 
            this.couthop.Location = new System.Drawing.Point(1, 429);
            this.couthop.Name = "couthop";
            this.couthop.Size = new System.Drawing.Size(100, 20);
            this.couthop.TabIndex = 2;
            this.couthop.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 414);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Кол-во разбиений";
            // 
            // downLimit
            // 
            this.downLimit.Location = new System.Drawing.Point(107, 429);
            this.downLimit.Name = "downLimit";
            this.downLimit.Size = new System.Drawing.Size(100, 20);
            this.downLimit.TabIndex = 4;
            this.downLimit.Text = "-1";
            // 
            // upLimit
            // 
            this.upLimit.Location = new System.Drawing.Point(213, 429);
            this.upLimit.Name = "upLimit";
            this.upLimit.Size = new System.Drawing.Size(100, 20);
            this.upLimit.TabIndex = 4;
            this.upLimit.Text = "4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 413);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Min";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 413);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Max";
            // 
            // Graph
            // 
            this.Graph.Location = new System.Drawing.Point(400, 427);
            this.Graph.Name = "Graph";
            this.Graph.Size = new System.Drawing.Size(75, 23);
            this.Graph.TabIndex = 5;
            this.Graph.Text = "График";
            this.Graph.UseVisualStyleBackColor = true;
            this.Graph.Click += new System.EventHandler(this.Graph_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Graph);
            this.Controls.Add(this.upLimit);
            this.Controls.Add(this.downLimit);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.couthop);
            this.Controls.Add(this.Counting);
            this.Controls.Add(this.chart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button Counting;
        private System.Windows.Forms.TextBox couthop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox downLimit;
        private System.Windows.Forms.TextBox upLimit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Graph;
    }
}

