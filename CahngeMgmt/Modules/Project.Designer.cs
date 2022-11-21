namespace ChangeMgmt.Modules
{
    partial class Project
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dS = new ChangeMgmt.DS();
            this.eNGPROJECTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eNG_PROJECTTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_PROJECTTableAdapter();
            this.colPROJ_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROJ_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROJ_ADD = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROJECTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.eNGPROJECTBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(716, 492);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPROJ_NO,
            this.colPROJ_NAME,
            this.colPROJ_ADD});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eNGPROJECTBindingSource
            // 
            this.eNGPROJECTBindingSource.DataMember = "ENG_PROJECT";
            this.eNGPROJECTBindingSource.DataSource = this.dS;
            // 
            // eNG_PROJECTTableAdapter
            // 
            this.eNG_PROJECTTableAdapter.ClearBeforeFill = true;
            // 
            // colPROJ_NO
            // 
            this.colPROJ_NO.FieldName = "PROJ_NO";
            this.colPROJ_NO.Name = "colPROJ_NO";
            this.colPROJ_NO.Visible = true;
            this.colPROJ_NO.VisibleIndex = 0;
            this.colPROJ_NO.Width = 68;
            // 
            // colPROJ_NAME
            // 
            this.colPROJ_NAME.FieldName = "PROJ_NAME";
            this.colPROJ_NAME.Name = "colPROJ_NAME";
            this.colPROJ_NAME.Visible = true;
            this.colPROJ_NAME.VisibleIndex = 1;
            this.colPROJ_NAME.Width = 310;
            // 
            // colPROJ_ADD
            // 
            this.colPROJ_ADD.FieldName = "PROJ_ADD";
            this.colPROJ_ADD.Name = "colPROJ_ADD";
            this.colPROJ_ADD.Visible = true;
            this.colPROJ_ADD.VisibleIndex = 2;
            this.colPROJ_ADD.Width = 307;
            // 
            // Project
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "Project";
            this.Size = new System.Drawing.Size(716, 492);
            this.Load += new System.EventHandler(this.Project_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROJECTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource eNGPROJECTBindingSource;
        private DS dS;
        private DevExpress.XtraGrid.Columns.GridColumn colPROJ_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPROJ_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colPROJ_ADD;
        private DSTableAdapters.ENG_PROJECTTableAdapter eNG_PROJECTTableAdapter;
    }
}
