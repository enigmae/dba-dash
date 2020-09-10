﻿namespace DBAChecksGUI
{
    partial class Summary
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
            this.dgvSummary = new System.Windows.Forms.DataGridView();
            this.Instance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoryDumpStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorruptionStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastGoodCheckDBStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullBackupStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiffBackupStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogBackupStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LogShippingStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DriveStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.JobStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AGStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileFreeSpaceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollectionErrorStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SnapshotAgeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UptimeStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsRefresh = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvSummary
            // 
            this.dgvSummary.AllowUserToAddRows = false;
            this.dgvSummary.AllowUserToDeleteRows = false;
            this.dgvSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvSummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Instance,
            this.MemoryDumpStatus,
            this.CorruptionStatus,
            this.LastGoodCheckDBStatus,
            this.AlertStatus,
            this.FullBackupStatus,
            this.DiffBackupStatus,
            this.LogBackupStatus,
            this.LogShippingStatus,
            this.DriveStatus,
            this.JobStatus,
            this.AGStatus,
            this.FileFreeSpaceStatus,
            this.CollectionErrorStatus,
            this.SnapshotAgeStatus,
            this.UptimeStatus});
            this.dgvSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSummary.Location = new System.Drawing.Point(0, 31);
            this.dgvSummary.Name = "dgvSummary";
            this.dgvSummary.ReadOnly = true;
            this.dgvSummary.RowHeadersVisible = false;
            this.dgvSummary.RowHeadersWidth = 51;
            this.dgvSummary.RowTemplate.Height = 24;
            this.dgvSummary.Size = new System.Drawing.Size(1800, 182);
            this.dgvSummary.TabIndex = 0;
            this.dgvSummary.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSummary_ColumnHeaderMouseClick);
            this.dgvSummary.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvSummary_RowAdded);
            // 
            // Instance
            // 
            this.Instance.DataPropertyName = "Instance";
            this.Instance.HeaderText = "Instance";
            this.Instance.MinimumWidth = 6;
            this.Instance.Name = "Instance";
            this.Instance.ReadOnly = true;
            this.Instance.Width = 82;
            // 
            // MemoryDumpStatus
            // 
            this.MemoryDumpStatus.HeaderText = "Memory Dump";
            this.MemoryDumpStatus.MinimumWidth = 6;
            this.MemoryDumpStatus.Name = "MemoryDumpStatus";
            this.MemoryDumpStatus.ReadOnly = true;
            this.MemoryDumpStatus.Width = 109;
            // 
            // CorruptionStatus
            // 
            this.CorruptionStatus.DataPropertyName = "DetectedCorruptionDate ";
            this.CorruptionStatus.HeaderText = "Corruption";
            this.CorruptionStatus.MinimumWidth = 6;
            this.CorruptionStatus.Name = "CorruptionStatus";
            this.CorruptionStatus.ReadOnly = true;
            this.CorruptionStatus.Width = 93;
            // 
            // LastGoodCheckDBStatus
            // 
            this.LastGoodCheckDBStatus.HeaderText = "Last Good Check DB";
            this.LastGoodCheckDBStatus.MinimumWidth = 6;
            this.LastGoodCheckDBStatus.Name = "LastGoodCheckDBStatus";
            this.LastGoodCheckDBStatus.ReadOnly = true;
            this.LastGoodCheckDBStatus.Width = 121;
            // 
            // AlertStatus
            // 
            this.AlertStatus.HeaderText = "Alerts";
            this.AlertStatus.MinimumWidth = 6;
            this.AlertStatus.Name = "AlertStatus";
            this.AlertStatus.ReadOnly = true;
            this.AlertStatus.Width = 66;
            // 
            // FullBackupStatus
            // 
            this.FullBackupStatus.HeaderText = "Full Backup";
            this.FullBackupStatus.MinimumWidth = 6;
            this.FullBackupStatus.Name = "FullBackupStatus";
            this.FullBackupStatus.ReadOnly = true;
            this.FullBackupStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.FullBackupStatus.Width = 92;
            // 
            // DiffBackupStatus
            // 
            this.DiffBackupStatus.HeaderText = "Diff Backup";
            this.DiffBackupStatus.MinimumWidth = 6;
            this.DiffBackupStatus.Name = "DiffBackupStatus";
            this.DiffBackupStatus.ReadOnly = true;
            this.DiffBackupStatus.Width = 91;
            // 
            // LogBackupStatus
            // 
            this.LogBackupStatus.HeaderText = "Log Backup";
            this.LogBackupStatus.MinimumWidth = 6;
            this.LogBackupStatus.Name = "LogBackupStatus";
            this.LogBackupStatus.ReadOnly = true;
            this.LogBackupStatus.Width = 93;
            // 
            // LogShippingStatus
            // 
            this.LogShippingStatus.HeaderText = "Log Shipping";
            this.LogShippingStatus.MinimumWidth = 6;
            this.LogShippingStatus.Name = "LogShippingStatus";
            this.LogShippingStatus.ReadOnly = true;
            // 
            // DriveStatus
            // 
            this.DriveStatus.HeaderText = "Drive Space";
            this.DriveStatus.MinimumWidth = 6;
            this.DriveStatus.Name = "DriveStatus";
            this.DriveStatus.ReadOnly = true;
            this.DriveStatus.Width = 94;
            // 
            // JobStatus
            // 
            this.JobStatus.HeaderText = "Agent Jobs";
            this.JobStatus.MinimumWidth = 6;
            this.JobStatus.Name = "JobStatus";
            this.JobStatus.ReadOnly = true;
            this.JobStatus.Width = 89;
            // 
            // AGStatus
            // 
            this.AGStatus.HeaderText = "Availability Groups";
            this.AGStatus.MinimumWidth = 6;
            this.AGStatus.Name = "AGStatus";
            this.AGStatus.ReadOnly = true;
            this.AGStatus.Width = 124;
            // 
            // FileFreeSpaceStatus
            // 
            this.FileFreeSpaceStatus.HeaderText = "File FreeSpace";
            this.FileFreeSpaceStatus.MinimumWidth = 6;
            this.FileFreeSpaceStatus.Name = "FileFreeSpaceStatus";
            this.FileFreeSpaceStatus.ReadOnly = true;
            this.FileFreeSpaceStatus.Width = 109;
            // 
            // CollectionErrorStatus
            // 
            this.CollectionErrorStatus.HeaderText = "DBAChecks Errors";
            this.CollectionErrorStatus.MinimumWidth = 6;
            this.CollectionErrorStatus.Name = "CollectionErrorStatus";
            this.CollectionErrorStatus.ReadOnly = true;
            this.CollectionErrorStatus.Width = 125;
            // 
            // SnapshotAgeStatus
            // 
            this.SnapshotAgeStatus.HeaderText = "Snapshot Age";
            this.SnapshotAgeStatus.MinimumWidth = 6;
            this.SnapshotAgeStatus.Name = "SnapshotAgeStatus";
            this.SnapshotAgeStatus.ReadOnly = true;
            this.SnapshotAgeStatus.Width = 103;
            // 
            // UptimeStatus
            // 
            this.UptimeStatus.HeaderText = "Instance Uptime";
            this.UptimeStatus.MinimumWidth = 6;
            this.UptimeStatus.Name = "UptimeStatus";
            this.UptimeStatus.ReadOnly = true;
            this.UptimeStatus.Width = 115;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsRefresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1800, 31);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsRefresh
            // 
            this.tsRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsRefresh.Image = global::DBAChecksGUI.Properties.Resources._112_RefreshArrow_Green_16x16_72;
            this.tsRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsRefresh.Name = "tsRefresh";
            this.tsRefresh.Size = new System.Drawing.Size(29, 28);
            this.tsRefresh.Text = "Refresh";
            this.tsRefresh.Click += new System.EventHandler(this.tsRefresh_Click);
            // 
            // Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvSummary);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Summary";
            this.Size = new System.Drawing.Size(1800, 213);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSummary)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instance;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoryDumpStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorruptionStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastGoodCheckDBStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullBackupStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiffBackupStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogBackupStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn LogShippingStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn DriveStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn AGStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileFreeSpaceStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollectionErrorStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn SnapshotAgeStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn UptimeStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsRefresh;
    }
}
