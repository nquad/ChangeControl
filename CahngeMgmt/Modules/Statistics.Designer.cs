namespace ChangeMgmt.Modules
{
    partial class Statistics
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            this.eNGPROCTASKSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new ChangeMgmt.DS();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.eNG_PROC_TASKSTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_PROC_TASKSTableAdapter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROCTASKSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            this.SuspendLayout();
            // 
            // eNGPROCTASKSBindingSource
            // 
            this.eNGPROCTASKSBindingSource.DataMember = "ENG_PROC_TASKS";
            this.eNGPROCTASKSBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chartControl1
            // 
            this.chartControl1.DataAdapter = this.eNG_PROC_TASKSTableAdapter;
            this.chartControl1.DataSource = this.eNGPROCTASKSBindingSource;
            xyDiagram1.AxisX.Title.MaxLineCount = 2;
            xyDiagram1.AxisX.Title.Text = "Задачи";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.Title.WordWrap = true;
            xyDiagram1.AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisX.VisualRange.Auto = false;
            xyDiagram1.AxisX.VisualRange.MaxValueSerializable = "J";
            xyDiagram1.AxisX.VisualRange.MinValueSerializable = "A";
            xyDiagram1.AxisX.WholeRange.Auto = false;
            xyDiagram1.AxisX.WholeRange.MaxValueSerializable = "J";
            xyDiagram1.AxisX.WholeRange.MinValueSerializable = "A";
            xyDiagram1.AxisY.Title.Text = "Кол-во";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 0);
            this.chartControl1.Name = "chartControl1";
            series1.ArgumentDataMember = "TASK_DESC";
            series1.DataSource = this.eNGPROCTASKSBindingSource;
            series1.FilterString = "[TASK_USER_NO] = 1";
            series1.LegendName = "Default Legend";
            series1.Name = "Просроченые";
            series1.ValueDataMembersSerializable = "TASK_CAT_NO";
            series2.ArgumentDataMember = "TASK_DESC";
            series2.DataSource = this.eNGPROCTASKSBindingSource;
            series2.FilterString = "[TASK_USER_NO] = 2";
            series2.Name = "Открыто";
            series2.ValueDataMembersSerializable = "TASK_CAT_NO";
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.chartControl1.Size = new System.Drawing.Size(962, 671);
            this.chartControl1.TabIndex = 0;
            // 
            // eNG_PROC_TASKSTableAdapter
            // 
            this.eNG_PROC_TASKSTableAdapter.ClearBeforeFill = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Statistics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chartControl1);
            this.Name = "Statistics";
            this.Size = new System.Drawing.Size(962, 671);
            this.Load += new System.EventHandler(this.Statistics_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROCTASKSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DSTableAdapters.ENG_PROC_TASKSTableAdapter eNG_PROC_TASKSTableAdapter;
        private System.Windows.Forms.BindingSource eNGPROCTASKSBindingSource;
        private DS dS;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.Timer timer1;
    }
}
