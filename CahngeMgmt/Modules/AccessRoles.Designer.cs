namespace ChangeMgmt.Modules
{
    partial class AccessRoles
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
            this.rOLLEACCESSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new ChangeMgmt.DS();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colACCES_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACCESS_CAT_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.eNGCATEGORYTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colACCESS_DESCR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACCESS_STATUS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.rOLLE_ACCESSTableAdapter = new ChangeMgmt.DSTableAdapters.ROLLE_ACCESSTableAdapter();
            this.eNG_CATEGORY_TYPETableAdapter = new ChangeMgmt.DSTableAdapters.ENG_CATEGORY_TYPETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOLLEACCESSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGCATEGORYTYPEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.rOLLEACCESSBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1020, 687);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // rOLLEACCESSBindingSource
            // 
            this.rOLLEACCESSBindingSource.DataMember = "ROLLE_ACCESS";
            this.rOLLEACCESSBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colACCES_NO,
            this.colACCESS_CAT_TYPE,
            this.colACCESS_DESCR,
            this.colACCESS_STATUS});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gridView1.RowUpdated += new DevExpress.XtraGrid.Views.Base.RowObjectEventHandler(this.gridView1_RowUpdated);
            // 
            // colACCES_NO
            // 
            this.colACCES_NO.FieldName = "ACCES_NO";
            this.colACCES_NO.Name = "colACCES_NO";
            this.colACCES_NO.Width = 92;
            // 
            // colACCESS_CAT_TYPE
            // 
            this.colACCESS_CAT_TYPE.Caption = "Тип";
            this.colACCESS_CAT_TYPE.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colACCESS_CAT_TYPE.FieldName = "ACCESS_CAT_TYPE";
            this.colACCESS_CAT_TYPE.Name = "colACCESS_CAT_TYPE";
            this.colACCESS_CAT_TYPE.Visible = true;
            this.colACCESS_CAT_TYPE.VisibleIndex = 0;
            this.colACCESS_CAT_TYPE.Width = 117;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TYPE_NO", "Номер", 20, DevExpress.Utils.FormatType.Numeric, "", false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TYPE_NAME", "Описание", 81, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TYPE_ADD", "Комментарий", 61, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.repositoryItemLookUpEdit1.DataSource = this.eNGCATEGORYTYPEBindingSource;
            this.repositoryItemLookUpEdit1.DisplayMember = "TYPE_NAME";
            this.repositoryItemLookUpEdit1.KeyMember = "TYPE_NO";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "TYPE_NO";
            // 
            // eNGCATEGORYTYPEBindingSource
            // 
            this.eNGCATEGORYTYPEBindingSource.DataMember = "ENG_CATEGORY_TYPE";
            this.eNGCATEGORYTYPEBindingSource.DataSource = this.dS;
            // 
            // colACCESS_DESCR
            // 
            this.colACCESS_DESCR.Caption = "Описание";
            this.colACCESS_DESCR.FieldName = "ACCESS_DESCR";
            this.colACCESS_DESCR.Name = "colACCESS_DESCR";
            this.colACCESS_DESCR.Visible = true;
            this.colACCESS_DESCR.VisibleIndex = 1;
            this.colACCESS_DESCR.Width = 390;
            // 
            // colACCESS_STATUS
            // 
            this.colACCESS_STATUS.Caption = "Статус";
            this.colACCESS_STATUS.FieldName = "ACCESS_STATUS";
            this.colACCESS_STATUS.Name = "colACCESS_STATUS";
            this.colACCESS_STATUS.Visible = true;
            this.colACCESS_STATUS.VisibleIndex = 2;
            this.colACCESS_STATUS.Width = 185;
            // 
            // rOLLE_ACCESSTableAdapter
            // 
            this.rOLLE_ACCESSTableAdapter.ClearBeforeFill = true;
            // 
            // eNG_CATEGORY_TYPETableAdapter
            // 
            this.eNG_CATEGORY_TYPETableAdapter.ClearBeforeFill = true;
            // 
            // AccessRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Name = "AccessRoles";
            this.Size = new System.Drawing.Size(1020, 687);
            this.Load += new System.EventHandler(this.AccessRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rOLLEACCESSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGCATEGORYTYPEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.BindingSource rOLLEACCESSBindingSource;
        private DS dS;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colACCES_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colACCESS_CAT_TYPE;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private System.Windows.Forms.BindingSource eNGCATEGORYTYPEBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colACCESS_DESCR;
        private DevExpress.XtraGrid.Columns.GridColumn colACCESS_STATUS;
        private DSTableAdapters.ROLLE_ACCESSTableAdapter rOLLE_ACCESSTableAdapter;
        private DSTableAdapters.ENG_CATEGORY_TYPETableAdapter eNG_CATEGORY_TYPETableAdapter;
    }
}
