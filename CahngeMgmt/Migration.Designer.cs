namespace ChangeMgmt
{
    partial class Migration
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
            this.btnUsers = new System.Windows.Forms.Button();
            this.ds = new ChangeMgmt.DS();
            this.enG_USERSTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_USERSTableAdapter();
            this.eNGUSERSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnProcess = new System.Windows.Forms.Button();
            this.eNGHRNSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eNG_HRNSTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_HRNSTableAdapter();
            this.eNGPROCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eNG_PROCTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_PROCTableAdapter();
            this.eNGPRIORBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eNG_PRIORTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_PRIORTableAdapter();
            this.btnTasks = new System.Windows.Forms.Button();
            this.enG_PROC_TASKSTableAdapter = new ChangeMgmt.DSTableAdapters.ENG_PROC_TASKSTableAdapter();
            this.eNGPROC_TASKSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnTasksOther = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGUSERSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGHRNSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPRIORBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROC_TASKSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(39, 26);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(75, 23);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.Text = "Users";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // ds
            // 
            this.ds.DataSetName = "DS";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // enG_USERSTableAdapter
            // 
            this.enG_USERSTableAdapter.ClearBeforeFill = true;
            // 
            // eNGUSERSBindingSource
            // 
            this.eNGUSERSBindingSource.DataMember = "ENG_USERS";
            this.eNGUSERSBindingSource.DataSource = this.ds;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(120, 26);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(75, 23);
            this.btnProcess.TabIndex = 0;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // eNGHRNSBindingSource
            // 
            this.eNGHRNSBindingSource.DataMember = "ENG_HRNS";
            this.eNGHRNSBindingSource.DataSource = this.ds;
            // 
            // eNG_HRNSTableAdapter
            // 
            this.eNG_HRNSTableAdapter.ClearBeforeFill = true;
            // 
            // eNGPROCBindingSource
            // 
            this.eNGPROCBindingSource.DataMember = "ENG_PROC";
            this.eNGPROCBindingSource.DataSource = this.ds;
            // 
            // eNG_PROCTableAdapter
            // 
            this.eNG_PROCTableAdapter.ClearBeforeFill = true;
            // 
            // eNGPRIORBindingSource
            // 
            this.eNGPRIORBindingSource.DataMember = "ENG_PRIOR";
            this.eNGPRIORBindingSource.DataSource = this.ds;
            // 
            // eNG_PRIORTableAdapter
            // 
            this.eNG_PRIORTableAdapter.ClearBeforeFill = true;
            // 
            // btnTasks
            // 
            this.btnTasks.Location = new System.Drawing.Point(201, 26);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(75, 23);
            this.btnTasks.TabIndex = 0;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = true;
            this.btnTasks.Click += new System.EventHandler(this.btnTasks_Click);
            // 
            // enG_PROC_TASKSTableAdapter
            // 
            this.enG_PROC_TASKSTableAdapter.ClearBeforeFill = true;
            // 
            // eNGPROC_TASKSBindingSource
            // 
            this.eNGPROC_TASKSBindingSource.DataMember = "ENG_PROC_TASKS";
            this.eNGPROC_TASKSBindingSource.DataSource = this.ds;
            // 
            // btnTasksOther
            // 
            this.btnTasksOther.Location = new System.Drawing.Point(282, 26);
            this.btnTasksOther.Name = "btnTasksOther";
            this.btnTasksOther.Size = new System.Drawing.Size(114, 23);
            this.btnTasksOther.TabIndex = 1;
            this.btnTasksOther.Text = "NotStartedTasks";
            this.btnTasksOther.UseVisualStyleBackColor = true;
            this.btnTasksOther.Click += new System.EventHandler(this.btnTasksOther_Click);
            // 
            // Migration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 565);
            this.Controls.Add(this.btnTasksOther);
            this.Controls.Add(this.btnTasks);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.btnUsers);
            this.Name = "Migration";
            this.Text = "Migration";
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGUSERSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGHRNSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPRIORBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eNGPROC_TASKSBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsers;
        private DS ds;
        private DSTableAdapters.ENG_USERSTableAdapter enG_USERSTableAdapter;
        private System.Windows.Forms.BindingSource eNGUSERSBindingSource;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.BindingSource eNGHRNSBindingSource;
        private DSTableAdapters.ENG_HRNSTableAdapter eNG_HRNSTableAdapter;
        private System.Windows.Forms.BindingSource eNGPROCBindingSource;
        private DSTableAdapters.ENG_PROCTableAdapter eNG_PROCTableAdapter;
        private System.Windows.Forms.BindingSource eNGPRIORBindingSource;
        private DSTableAdapters.ENG_PRIORTableAdapter eNG_PRIORTableAdapter;
        private System.Windows.Forms.Button btnTasks;
        private DSTableAdapters.ENG_PROC_TASKSTableAdapter enG_PROC_TASKSTableAdapter;
        private System.Windows.Forms.BindingSource eNGPROC_TASKSBindingSource;
        private System.Windows.Forms.Button btnTasksOther;
    }
}