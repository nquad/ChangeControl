namespace ChangeMgmt
{
    partial class Category
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Category));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTasks = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.eNGCATEGORYBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new ChangeMgmt.DS();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCAT_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCAT_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCAT_TYPE_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.eNGCATEGORYTYPEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.colCAT_ADD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eNG_CATEGORYTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_CATEGORYTableAdapter();
            this.eNG_CATEGORY_TYPETableAdapter = new ChangeMgmt.DSTableAdapters.ENG_CATEGORY_TYPETableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGCATEGORYBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGCATEGORYTYPEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnTasks);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 46);
            this.panel1.TabIndex = 0;
            // 
            // btnTasks
            // 
            this.btnTasks.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTasks.Appearance.Options.UseFont = true;
            this.btnTasks.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTasks.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnTasks.ImageOptions.Image")));
            this.btnTasks.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnTasks.Location = new System.Drawing.Point(0, 0);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(370, 46);
            this.btnTasks.TabIndex = 0;
            this.btnTasks.Text = "Назначить // Уведомить";
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.DataSource = this.eNGCATEGORYBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(0, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(370, 405);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // eNGCATEGORYBindingSource
            // 
            this.eNGCATEGORYBindingSource.DataMember = "ENG_CATEGORY";
            this.eNGCATEGORYBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.ActiveFilterString = "[CAT_TYPE_NO] In (1, 2)";
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCAT_NO,
            this.colCAT_NAME,
            this.colCAT_TYPE_NO,
            this.colCAT_ADD});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 25;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCAT_TYPE_NO, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowLoaded += new DevExpress.XtraGrid.Views.Base.RowEventHandler(this.gridView1_RowLoaded);
            this.gridView1.DataSourceChanged += new System.EventHandler(this.gridView1_DataSourceChanged);
            // 
            // colCAT_NO
            // 
            this.colCAT_NO.FieldName = "CAT_NO";
            this.colCAT_NO.Name = "colCAT_NO";
            // 
            // colCAT_NAME
            // 
            this.colCAT_NAME.Caption = "Категория";
            this.colCAT_NAME.FieldName = "CAT_NAME";
            this.colCAT_NAME.Name = "colCAT_NAME";
            this.colCAT_NAME.Visible = true;
            this.colCAT_NAME.VisibleIndex = 1;
            this.colCAT_NAME.Width = 129;
            // 
            // colCAT_TYPE_NO
            // 
            this.colCAT_TYPE_NO.Caption = "Тип";
            this.colCAT_TYPE_NO.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colCAT_TYPE_NO.FieldName = "CAT_TYPE_NO";
            this.colCAT_TYPE_NO.Name = "colCAT_TYPE_NO";
            this.colCAT_TYPE_NO.Visible = true;
            this.colCAT_TYPE_NO.VisibleIndex = 2;
            this.colCAT_TYPE_NO.Width = 156;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
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
            // colCAT_ADD
            // 
            this.colCAT_ADD.Caption = "Описание";
            this.colCAT_ADD.FieldName = "CAT_ADD";
            this.colCAT_ADD.Name = "colCAT_ADD";
            this.colCAT_ADD.Visible = true;
            this.colCAT_ADD.VisibleIndex = 3;
            this.colCAT_ADD.Width = 348;
            // 
            // eNG_CATEGORYTableAdapter
            // 
            this.eNG_CATEGORYTableAdapter.ClearBeforeFill = true;
            // 
            // eNG_CATEGORY_TYPETableAdapter
            // 
            this.eNG_CATEGORY_TYPETableAdapter.ClearBeforeFill = true;
            // 
            // Category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 469);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Category";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Назначить задачи";
            this.Load += new System.EventHandler(this.Category_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGCATEGORYBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGCATEGORYTYPEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnTasks;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DS dS;
        private System.Windows.Forms.BindingSource eNGCATEGORYBindingSource;
        private DSTableAdapters.ENG_CATEGORYTableAdapter eNG_CATEGORYTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colCAT_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colCAT_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colCAT_TYPE_NO;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colCAT_ADD;
        private System.Windows.Forms.BindingSource eNGCATEGORYTYPEBindingSource;
        private DSTableAdapters.ENG_CATEGORY_TYPETableAdapter eNG_CATEGORY_TYPETableAdapter;
    }
}