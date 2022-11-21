namespace ChangeMgmt.Modules
{
    partial class Priority
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
            this.eNGPRIORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new ChangeMgmt.DS();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPRIOR_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRIOR_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPRIOR_DAYS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colPRIOR_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eNG_PRIORTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_PRIORTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPRIORBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.eNGPRIORBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(716, 546);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // eNGPRIORBindingSource
            // 
            this.eNGPRIORBindingSource.DataMember = "ENG_PRIOR";
            this.eNGPRIORBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPRIOR_NO,
            this.colPRIOR_NAME,
            this.colPRIOR_DAYS,
            this.colPRIOR_DESC});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colPRIOR_NO
            // 
            this.colPRIOR_NO.FieldName = "PRIOR_NO";
            this.colPRIOR_NO.Name = "colPRIOR_NO";
            this.colPRIOR_NO.Width = 78;
            // 
            // colPRIOR_NAME
            // 
            this.colPRIOR_NAME.Caption = "Наименование";
            this.colPRIOR_NAME.FieldName = "PRIOR_NAME";
            this.colPRIOR_NAME.Name = "colPRIOR_NAME";
            this.colPRIOR_NAME.Visible = true;
            this.colPRIOR_NAME.VisibleIndex = 0;
            this.colPRIOR_NAME.Width = 229;
            // 
            // colPRIOR_DAYS
            // 
            this.colPRIOR_DAYS.Caption = "Кол-во дней";
            this.colPRIOR_DAYS.ColumnEdit = this.repositoryItemCalcEdit1;
            this.colPRIOR_DAYS.FieldName = "PRIOR_DAYS";
            this.colPRIOR_DAYS.Name = "colPRIOR_DAYS";
            this.colPRIOR_DAYS.Visible = true;
            this.colPRIOR_DAYS.VisibleIndex = 1;
            this.colPRIOR_DAYS.Width = 172;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // colPRIOR_DESC
            // 
            this.colPRIOR_DESC.Caption = "Описание";
            this.colPRIOR_DESC.FieldName = "PRIOR_DESC";
            this.colPRIOR_DESC.Name = "colPRIOR_DESC";
            this.colPRIOR_DESC.Visible = true;
            this.colPRIOR_DESC.VisibleIndex = 2;
            this.colPRIOR_DESC.Width = 291;
            // 
            // eNG_PRIORTableAdapter
            // 
            this.eNG_PRIORTableAdapter.ClearBeforeFill = true;
            // 
            // Priority
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "Priority";
            this.Size = new System.Drawing.Size(716, 546);
            this.Load += new System.EventHandler(this.Priority_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPRIORBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource eNGPRIORBindingSource;
        private DS dS;
        private DevExpress.XtraGrid.Columns.GridColumn colPRIOR_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colPRIOR_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colPRIOR_DAYS;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colPRIOR_DESC;
        private DSTableAdapters.ENG_PRIORTableAdapter eNG_PRIORTableAdapter;
    }
}
