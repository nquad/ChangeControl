namespace ChangeMgmt.Modules
{
    partial class Status
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
            this.eNGSTATUSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new ChangeMgmt.DS();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTATUS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTATUS_DAYS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.colSTATUS_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eNG_STATUSTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_STATUSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGSTATUSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.eNGSTATUSBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCalcEdit1});
            this.gridControl1.Size = new System.Drawing.Size(704, 522);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // eNGSTATUSBindingSource
            // 
            this.eNGSTATUSBindingSource.DataMember = "ENG_STATUS";
            this.eNGSTATUSBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTATUS_NO,
            this.colSTATUS_NAME,
            this.colSTATUS_DAYS,
            this.colSTATUS_DESC});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colSTATUS_NO
            // 
            this.colSTATUS_NO.FieldName = "STATUS_NO";
            this.colSTATUS_NO.Name = "colSTATUS_NO";
            this.colSTATUS_NO.Width = 80;
            // 
            // colSTATUS_NAME
            // 
            this.colSTATUS_NAME.Caption = "Наименование";
            this.colSTATUS_NAME.FieldName = "STATUS_NAME";
            this.colSTATUS_NAME.Name = "colSTATUS_NAME";
            this.colSTATUS_NAME.Visible = true;
            this.colSTATUS_NAME.VisibleIndex = 0;
            this.colSTATUS_NAME.Width = 204;
            // 
            // colSTATUS_DAYS
            // 
            this.colSTATUS_DAYS.ColumnEdit = this.repositoryItemCalcEdit1;
            this.colSTATUS_DAYS.FieldName = "STATUS_DAYS";
            this.colSTATUS_DAYS.Name = "colSTATUS_DAYS";
            this.colSTATUS_DAYS.Width = 201;
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            // 
            // colSTATUS_DESC
            // 
            this.colSTATUS_DESC.Caption = "Описание";
            this.colSTATUS_DESC.FieldName = "STATUS_DESC";
            this.colSTATUS_DESC.Name = "colSTATUS_DESC";
            this.colSTATUS_DESC.Visible = true;
            this.colSTATUS_DESC.VisibleIndex = 1;
            this.colSTATUS_DESC.Width = 488;
            // 
            // eNG_STATUSTableAdapter
            // 
            this.eNG_STATUSTableAdapter.ClearBeforeFill = true;
            // 
            // Status
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "Status";
            this.Size = new System.Drawing.Size(704, 522);
            this.Load += new System.EventHandler(this.Status_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGSTATUSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource eNGSTATUSBindingSource;
        private DS dS;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS_DAYS;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colSTATUS_DESC;
        private DSTableAdapters.ENG_STATUSTableAdapter eNG_STATUSTableAdapter;
    }
}
