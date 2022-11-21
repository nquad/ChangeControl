namespace ChangeMgmt.Modules
{
    partial class Family
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
            this.eNGFAMILYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eNG_FAMILYTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_FAMILYTableAdapter();
            this.colFAMIL_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAMIL_PROJECT_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAMIL_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFAMIL_ADD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.eNGPROJECTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eNG_PROJECTTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_PROJECTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGFAMILYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROJECTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.eNGFAMILYBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(720, 559);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFAMIL_NO,
            this.colFAMIL_PROJECT_NO,
            this.colFAMIL_NAME,
            this.colFAMIL_ADD});
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
            // eNGFAMILYBindingSource
            // 
            this.eNGFAMILYBindingSource.DataMember = "ENG_FAMILY";
            this.eNGFAMILYBindingSource.DataSource = this.dS;
            // 
            // eNG_FAMILYTableAdapter
            // 
            this.eNG_FAMILYTableAdapter.ClearBeforeFill = true;
            // 
            // colFAMIL_NO
            // 
            this.colFAMIL_NO.FieldName = "FAMIL_NO";
            this.colFAMIL_NO.Name = "colFAMIL_NO";
            this.colFAMIL_NO.Visible = true;
            this.colFAMIL_NO.VisibleIndex = 0;
            this.colFAMIL_NO.Width = 80;
            // 
            // colFAMIL_PROJECT_NO
            // 
            this.colFAMIL_PROJECT_NO.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colFAMIL_PROJECT_NO.FieldName = "FAMIL_PROJECT_NO";
            this.colFAMIL_PROJECT_NO.Name = "colFAMIL_PROJECT_NO";
            this.colFAMIL_PROJECT_NO.Visible = true;
            this.colFAMIL_PROJECT_NO.VisibleIndex = 1;
            this.colFAMIL_PROJECT_NO.Width = 201;
            // 
            // colFAMIL_NAME
            // 
            this.colFAMIL_NAME.FieldName = "FAMIL_NAME";
            this.colFAMIL_NAME.Name = "colFAMIL_NAME";
            this.colFAMIL_NAME.Visible = true;
            this.colFAMIL_NAME.VisibleIndex = 2;
            this.colFAMIL_NAME.Width = 201;
            // 
            // colFAMIL_ADD
            // 
            this.colFAMIL_ADD.FieldName = "FAMIL_ADD";
            this.colFAMIL_ADD.Name = "colFAMIL_ADD";
            this.colFAMIL_ADD.Visible = true;
            this.colFAMIL_ADD.VisibleIndex = 3;
            this.colFAMIL_ADD.Width = 203;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROJ_NO", "PROJ_NO", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROJ_NAME", "PROJ_NAME", 83, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("PROJ_ADD", "PROJ_ADD", 63, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit1.DataSource = this.eNGPROJECTBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "PROJ_NAME";
            this.repositoryItemLookUpEdit1.KeyMember = "PROJ_NO";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "PROJ_NO";
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
            // Family
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "Family";
            this.Size = new System.Drawing.Size(720, 559);
            this.Load += new System.EventHandler(this.Family_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGFAMILYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROJECTBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource eNGFAMILYBindingSource;
        private DS dS;
        private DevExpress.XtraGrid.Columns.GridColumn colFAMIL_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colFAMIL_PROJECT_NO;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource eNGPROJECTBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFAMIL_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colFAMIL_ADD;
        private DSTableAdapters.ENG_FAMILYTableAdapter eNG_FAMILYTableAdapter;
        private DSTableAdapters.ENG_PROJECTTableAdapter eNG_PROJECTTableAdapter;
    }
}
