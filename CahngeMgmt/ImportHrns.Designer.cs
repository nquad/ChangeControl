namespace ChangeMgmt
{
    partial class ImportHrns
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
            this.dS = new ChangeMgmt.DS();
            this.eNGHRNSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eNG_HRNSTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_HRNSTableAdapter();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colHRNS_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_NAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_DATAADD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_ZMENOV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_PROJECT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_FAMILY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_GEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_DRAW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_CUSTNUMB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_INDEX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_DESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colHRNS_SAFETY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_CHGDESC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colHRNS_COMMENT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.colHRNS_CAPNUM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_OLDREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_NEWREF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_DATAORDER = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_EOL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRNS_IMGE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.colHRNS_CAP_TYPE = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGHRNSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eNGHRNSBindingSource
            // 
            this.eNGHRNSBindingSource.DataMember = "ENG_HRNS";
            this.eNGHRNSBindingSource.DataSource = this.dS;
            // 
            // eNG_HRNSTableAdapter
            // 
            this.eNG_HRNSTableAdapter.ClearBeforeFill = true;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.eNGHRNSBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1,
            this.repositoryItemMemoEdit2,
            this.repositoryItemImageEdit1,
            this.repositoryItemMemoEdit3});
            this.gridControl1.Size = new System.Drawing.Size(1098, 609);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHRNS_NO,
            this.colHRNS_NAME,
            this.colHRNS_DATAADD,
            this.colHRNS_ZMENOV,
            this.colHRNS_PROJECT,
            this.colHRNS_FAMILY,
            this.colHRNS_GEN,
            this.colHRNS_DRAW,
            this.colHRNS_CUSTNUMB,
            this.colHRNS_INDEX,
            this.colHRNS_DESC,
            this.colHRNS_SAFETY,
            this.colHRNS_CHGDESC,
            this.colHRNS_COMMENT,
            this.colHRNS_CAPNUM,
            this.colHRNS_OLDREF,
            this.colHRNS_NEWREF,
            this.colHRNS_DATAORDER,
            this.colHRNS_EOL,
            this.colHRNS_IMGE,
            this.colHRNS_CAP_TYPE});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colHRNS_CAP_TYPE, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colHRNS_NO
            // 
            this.colHRNS_NO.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_NO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_NO.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_NO.FieldName = "HRNS_NO";
            this.colHRNS_NO.Name = "colHRNS_NO";
            this.colHRNS_NO.OptionsColumn.AllowEdit = false;
            // 
            // colHRNS_NAME
            // 
            this.colHRNS_NAME.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_NAME.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_NAME.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_NAME.Caption = "LEONI";
            this.colHRNS_NAME.FieldName = "HRNS_NAME";
            this.colHRNS_NAME.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colHRNS_NAME.Name = "colHRNS_NAME";
            this.colHRNS_NAME.OptionsColumn.AllowEdit = false;
            this.colHRNS_NAME.Visible = true;
            this.colHRNS_NAME.VisibleIndex = 0;
            // 
            // colHRNS_DATAADD
            // 
            this.colHRNS_DATAADD.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_DATAADD.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_DATAADD.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_DATAADD.Caption = "Дата внесения в файл";
            this.colHRNS_DATAADD.FieldName = "HRNS_DATAADD";
            this.colHRNS_DATAADD.Name = "colHRNS_DATAADD";
            this.colHRNS_DATAADD.OptionsColumn.AllowEdit = false;
            this.colHRNS_DATAADD.Visible = true;
            this.colHRNS_DATAADD.VisibleIndex = 1;
            this.colHRNS_DATAADD.Width = 90;
            // 
            // colHRNS_ZMENOV
            // 
            this.colHRNS_ZMENOV.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_ZMENOV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_ZMENOV.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_ZMENOV.Caption = "Номер Зменовки";
            this.colHRNS_ZMENOV.FieldName = "HRNS_ZMENOV";
            this.colHRNS_ZMENOV.Name = "colHRNS_ZMENOV";
            this.colHRNS_ZMENOV.OptionsColumn.AllowEdit = false;
            this.colHRNS_ZMENOV.Visible = true;
            this.colHRNS_ZMENOV.VisibleIndex = 2;
            // 
            // colHRNS_PROJECT
            // 
            this.colHRNS_PROJECT.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_PROJECT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_PROJECT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_PROJECT.Caption = "Проект";
            this.colHRNS_PROJECT.FieldName = "HRNS_PROJECT";
            this.colHRNS_PROJECT.Name = "colHRNS_PROJECT";
            this.colHRNS_PROJECT.OptionsColumn.AllowEdit = false;
            this.colHRNS_PROJECT.Visible = true;
            this.colHRNS_PROJECT.VisibleIndex = 3;
            // 
            // colHRNS_FAMILY
            // 
            this.colHRNS_FAMILY.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_FAMILY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_FAMILY.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_FAMILY.Caption = "Семейство";
            this.colHRNS_FAMILY.FieldName = "HRNS_FAMILY";
            this.colHRNS_FAMILY.Name = "colHRNS_FAMILY";
            this.colHRNS_FAMILY.OptionsColumn.AllowEdit = false;
            this.colHRNS_FAMILY.Visible = true;
            this.colHRNS_FAMILY.VisibleIndex = 4;
            this.colHRNS_FAMILY.Width = 83;
            // 
            // colHRNS_GEN
            // 
            this.colHRNS_GEN.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_GEN.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_GEN.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_GEN.Caption = "Поколение";
            this.colHRNS_GEN.FieldName = "HRNS_GEN";
            this.colHRNS_GEN.Name = "colHRNS_GEN";
            this.colHRNS_GEN.OptionsColumn.AllowEdit = false;
            this.colHRNS_GEN.Visible = true;
            this.colHRNS_GEN.VisibleIndex = 5;
            this.colHRNS_GEN.Width = 96;
            // 
            // colHRNS_DRAW
            // 
            this.colHRNS_DRAW.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_DRAW.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_DRAW.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_DRAW.Caption = "Номер чертежа";
            this.colHRNS_DRAW.FieldName = "HRNS_DRAW";
            this.colHRNS_DRAW.Name = "colHRNS_DRAW";
            this.colHRNS_DRAW.OptionsColumn.AllowEdit = false;
            this.colHRNS_DRAW.Visible = true;
            this.colHRNS_DRAW.VisibleIndex = 6;
            this.colHRNS_DRAW.Width = 133;
            // 
            // colHRNS_CUSTNUMB
            // 
            this.colHRNS_CUSTNUMB.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_CUSTNUMB.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_CUSTNUMB.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_CUSTNUMB.Caption = "Номер жгута заказчика";
            this.colHRNS_CUSTNUMB.FieldName = "HRNS_CUSTNUMB";
            this.colHRNS_CUSTNUMB.Name = "colHRNS_CUSTNUMB";
            this.colHRNS_CUSTNUMB.OptionsColumn.AllowEdit = false;
            this.colHRNS_CUSTNUMB.Visible = true;
            this.colHRNS_CUSTNUMB.VisibleIndex = 7;
            this.colHRNS_CUSTNUMB.Width = 133;
            // 
            // colHRNS_INDEX
            // 
            this.colHRNS_INDEX.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_INDEX.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_INDEX.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_INDEX.Caption = "Индекс";
            this.colHRNS_INDEX.FieldName = "HRNS_INDEX";
            this.colHRNS_INDEX.Name = "colHRNS_INDEX";
            this.colHRNS_INDEX.OptionsColumn.AllowEdit = false;
            this.colHRNS_INDEX.Visible = true;
            this.colHRNS_INDEX.VisibleIndex = 8;
            this.colHRNS_INDEX.Width = 128;
            // 
            // colHRNS_DESC
            // 
            this.colHRNS_DESC.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_DESC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_DESC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_DESC.Caption = "Описание в чертеже";
            this.colHRNS_DESC.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colHRNS_DESC.FieldName = "HRNS_DESC";
            this.colHRNS_DESC.Name = "colHRNS_DESC";
            this.colHRNS_DESC.OptionsColumn.AllowEdit = false;
            this.colHRNS_DESC.Visible = true;
            this.colHRNS_DESC.VisibleIndex = 9;
            this.colHRNS_DESC.Width = 178;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            // 
            // colHRNS_SAFETY
            // 
            this.colHRNS_SAFETY.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_SAFETY.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_SAFETY.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_SAFETY.Caption = "Safety";
            this.colHRNS_SAFETY.FieldName = "HRNS_SAFETY";
            this.colHRNS_SAFETY.Name = "colHRNS_SAFETY";
            this.colHRNS_SAFETY.OptionsColumn.AllowEdit = false;
            this.colHRNS_SAFETY.Visible = true;
            this.colHRNS_SAFETY.VisibleIndex = 11;
            // 
            // colHRNS_CHGDESC
            // 
            this.colHRNS_CHGDESC.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_CHGDESC.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_CHGDESC.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_CHGDESC.Caption = "Описание изменения";
            this.colHRNS_CHGDESC.ColumnEdit = this.repositoryItemMemoEdit2;
            this.colHRNS_CHGDESC.FieldName = "HRNS_CHGDESC";
            this.colHRNS_CHGDESC.Name = "colHRNS_CHGDESC";
            this.colHRNS_CHGDESC.OptionsColumn.AllowEdit = false;
            this.colHRNS_CHGDESC.Visible = true;
            this.colHRNS_CHGDESC.VisibleIndex = 12;
            this.colHRNS_CHGDESC.Width = 336;
            // 
            // repositoryItemMemoEdit2
            // 
            this.repositoryItemMemoEdit2.Name = "repositoryItemMemoEdit2";
            // 
            // colHRNS_COMMENT
            // 
            this.colHRNS_COMMENT.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_COMMENT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_COMMENT.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_COMMENT.Caption = "Комментарий D&D";
            this.colHRNS_COMMENT.ColumnEdit = this.repositoryItemMemoEdit3;
            this.colHRNS_COMMENT.FieldName = "HRNS_COMMENT";
            this.colHRNS_COMMENT.Name = "colHRNS_COMMENT";
            this.colHRNS_COMMENT.OptionsColumn.AllowEdit = false;
            this.colHRNS_COMMENT.Visible = true;
            this.colHRNS_COMMENT.VisibleIndex = 13;
            this.colHRNS_COMMENT.Width = 233;
            // 
            // repositoryItemMemoEdit3
            // 
            this.repositoryItemMemoEdit3.Name = "repositoryItemMemoEdit3";
            // 
            // colHRNS_CAPNUM
            // 
            this.colHRNS_CAPNUM.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_CAPNUM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_CAPNUM.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_CAPNUM.Caption = "P/n новых компонентов в CapH";
            this.colHRNS_CAPNUM.FieldName = "HRNS_CAPNUM";
            this.colHRNS_CAPNUM.Name = "colHRNS_CAPNUM";
            this.colHRNS_CAPNUM.OptionsColumn.AllowEdit = false;
            this.colHRNS_CAPNUM.Visible = true;
            this.colHRNS_CAPNUM.VisibleIndex = 14;
            this.colHRNS_CAPNUM.Width = 98;
            // 
            // colHRNS_OLDREF
            // 
            this.colHRNS_OLDREF.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_OLDREF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_OLDREF.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_OLDREF.Caption = "Старая (заменяемая референция)";
            this.colHRNS_OLDREF.FieldName = "HRNS_OLDREF";
            this.colHRNS_OLDREF.Name = "colHRNS_OLDREF";
            this.colHRNS_OLDREF.OptionsColumn.AllowEdit = false;
            this.colHRNS_OLDREF.Visible = true;
            this.colHRNS_OLDREF.VisibleIndex = 15;
            this.colHRNS_OLDREF.Width = 108;
            // 
            // colHRNS_NEWREF
            // 
            this.colHRNS_NEWREF.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_NEWREF.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_NEWREF.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_NEWREF.Caption = "Новая (заменяющая референция)";
            this.colHRNS_NEWREF.FieldName = "HRNS_NEWREF";
            this.colHRNS_NEWREF.Name = "colHRNS_NEWREF";
            this.colHRNS_NEWREF.OptionsColumn.AllowEdit = false;
            this.colHRNS_NEWREF.Visible = true;
            this.colHRNS_NEWREF.VisibleIndex = 16;
            this.colHRNS_NEWREF.Width = 117;
            // 
            // colHRNS_DATAORDER
            // 
            this.colHRNS_DATAORDER.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_DATAORDER.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_DATAORDER.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_DATAORDER.Caption = "Прогнозируемая дата заказа жгута";
            this.colHRNS_DATAORDER.FieldName = "HRNS_DATAORDER";
            this.colHRNS_DATAORDER.Name = "colHRNS_DATAORDER";
            this.colHRNS_DATAORDER.OptionsColumn.AllowEdit = false;
            this.colHRNS_DATAORDER.Visible = true;
            this.colHRNS_DATAORDER.VisibleIndex = 17;
            this.colHRNS_DATAORDER.Width = 155;
            // 
            // colHRNS_EOL
            // 
            this.colHRNS_EOL.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_EOL.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_EOL.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_EOL.Caption = "Прогнозируемая дата выхода из потребляемости";
            this.colHRNS_EOL.FieldName = "HRNS_EOL";
            this.colHRNS_EOL.Name = "colHRNS_EOL";
            this.colHRNS_EOL.OptionsColumn.AllowEdit = false;
            this.colHRNS_EOL.Visible = true;
            this.colHRNS_EOL.VisibleIndex = 18;
            this.colHRNS_EOL.Width = 102;
            // 
            // colHRNS_IMGE
            // 
            this.colHRNS_IMGE.AppearanceHeader.Options.UseTextOptions = true;
            this.colHRNS_IMGE.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colHRNS_IMGE.AppearanceHeader.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.colHRNS_IMGE.Caption = "Картинка";
            this.colHRNS_IMGE.ColumnEdit = this.repositoryItemImageEdit1;
            this.colHRNS_IMGE.FieldName = "HRNS_IMGE";
            this.colHRNS_IMGE.Name = "colHRNS_IMGE";
            this.colHRNS_IMGE.OptionsColumn.AllowEdit = false;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // colHRNS_CAP_TYPE
            // 
            this.colHRNS_CAP_TYPE.Caption = "CAPH/XC";
            this.colHRNS_CAP_TYPE.FieldName = "HRNS_CAP_TYPE";
            this.colHRNS_CAP_TYPE.Name = "colHRNS_CAP_TYPE";
            this.colHRNS_CAP_TYPE.Visible = true;
            this.colHRNS_CAP_TYPE.VisibleIndex = 10;
            // 
            // ImportHrns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 609);
            this.Controls.Add(this.gridControl1);
            this.Name = "ImportHrns";
            this.Text = "Загрузка";
            this.Load += new System.EventHandler(this.ImportHrns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGHRNSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DS dS;
        private System.Windows.Forms.BindingSource eNGHRNSBindingSource;
        private DSTableAdapters.ENG_HRNSTableAdapter eNG_HRNSTableAdapter;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_NAME;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_DATAADD;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_ZMENOV;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_PROJECT;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_FAMILY;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_GEN;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_DRAW;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_CUSTNUMB;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_INDEX;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_DESC;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_SAFETY;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_CHGDESC;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit2;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_COMMENT;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit3;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_CAPNUM;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_OLDREF;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_NEWREF;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_DATAORDER;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_EOL;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_IMGE;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colHRNS_CAP_TYPE;
    }
}