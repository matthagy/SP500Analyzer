namespace SP500Analyzer
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.priceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.stockList = new System.Windows.Forms.CheckedListBox();
            this.optionsGroup = new System.Windows.Forms.GroupBox();
            this.checkShift = new System.Windows.Forms.CheckBox();
            this.checkNormalize = new System.Windows.Forms.CheckBox();
            this.stockLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.priceChart)).BeginInit();
            this.optionsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // priceChart
            // 
            chartArea1.Name = "ChartArea1";
            this.priceChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.priceChart.Legends.Add(legend1);
            this.priceChart.Location = new System.Drawing.Point(0, 0);
            this.priceChart.Name = "priceChart";
            this.priceChart.Size = new System.Drawing.Size(488, 421);
            this.priceChart.TabIndex = 0;
            this.priceChart.Text = "chart1";
            // 
            // stockList
            // 
            this.stockList.CheckOnClick = true;
            this.stockList.FormattingEnabled = true;
            this.stockList.Location = new System.Drawing.Point(497, 23);
            this.stockList.Name = "stockList";
            this.stockList.Size = new System.Drawing.Size(281, 319);
            this.stockList.TabIndex = 1;
            this.stockList.SelectedIndexChanged += new System.EventHandler(this.stockList_SelectedIndexChanged);
            // 
            // optionsGroup
            // 
            this.optionsGroup.Controls.Add(this.checkShift);
            this.optionsGroup.Controls.Add(this.checkNormalize);
            this.optionsGroup.Location = new System.Drawing.Point(497, 351);
            this.optionsGroup.Name = "optionsGroup";
            this.optionsGroup.Size = new System.Drawing.Size(281, 70);
            this.optionsGroup.TabIndex = 2;
            this.optionsGroup.TabStop = false;
            this.optionsGroup.Text = "Options";
            // 
            // checkShift
            // 
            this.checkShift.AutoSize = true;
            this.checkShift.Location = new System.Drawing.Point(16, 44);
            this.checkShift.Name = "checkShift";
            this.checkShift.Size = new System.Drawing.Size(47, 17);
            this.checkShift.TabIndex = 4;
            this.checkShift.Text = "Shift";
            this.checkShift.UseVisualStyleBackColor = true;
            this.checkShift.CheckedChanged += new System.EventHandler(this.checkShift_CheckedChanged);
            // 
            // checkNormalize
            // 
            this.checkNormalize.AutoSize = true;
            this.checkNormalize.Location = new System.Drawing.Point(16, 21);
            this.checkNormalize.Name = "checkNormalize";
            this.checkNormalize.Size = new System.Drawing.Size(72, 17);
            this.checkNormalize.TabIndex = 3;
            this.checkNormalize.Text = "Normalize";
            this.checkNormalize.UseVisualStyleBackColor = true;
            this.checkNormalize.CheckedChanged += new System.EventHandler(this.checkNormalize_CheckedChanged);
            // 
            // stockLabel
            // 
            this.stockLabel.AutoSize = true;
            this.stockLabel.Location = new System.Drawing.Point(494, 5);
            this.stockLabel.Name = "stockLabel";
            this.stockLabel.Size = new System.Drawing.Size(129, 13);
            this.stockLabel.TabIndex = 3;
            this.stockLabel.Text = "Stocks (average opening)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 433);
            this.Controls.Add(this.stockLabel);
            this.Controls.Add(this.optionsGroup);
            this.Controls.Add(this.stockList);
            this.Controls.Add(this.priceChart);
            this.Name = "MainForm";
            this.Text = "SP500Analyzer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.priceChart)).EndInit();
            this.optionsGroup.ResumeLayout(false);
            this.optionsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart priceChart;
        private System.Windows.Forms.CheckedListBox stockList;
        internal System.Windows.Forms.GroupBox optionsGroup;
        private System.Windows.Forms.CheckBox checkNormalize;
        private System.Windows.Forms.CheckBox checkShift;
        private System.Windows.Forms.Label stockLabel;
    }
}

