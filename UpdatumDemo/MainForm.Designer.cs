namespace UpdatumDemo
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblVersion = new Label();
            lblCurrentVersion = new Label();
            btnCheckUpdates = new Button();
            btnAutoUpdate = new Button();
            groupBox1 = new GroupBox();
            lblStatus = new Label();
            lblUpdateInfo = new Label();
            txtChangelog = new TextBox();
            lblChangelog = new Label();
            progressBar = new ProgressBar();
            lblProgress = new Label();
            groupBox2 = new GroupBox();
            lblInfo = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.Location = new Point(12, 9);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(370, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Updatum Demo Application";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 9F);
            lblVersion.ForeColor = SystemColors.ControlDarkDark;
            lblVersion.Location = new Point(12, 41);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(95, 15);
            lblVersion.TabIndex = 1;
            lblVersion.Text = "Current Version: ";
            // 
            // lblCurrentVersion
            // 
            lblCurrentVersion.AutoSize = true;
            lblCurrentVersion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurrentVersion.ForeColor = SystemColors.ControlDarkDark;
            lblCurrentVersion.Location = new Point(107, 41);
            lblCurrentVersion.Name = "lblCurrentVersion";
            lblCurrentVersion.Size = new Size(37, 15);
            lblCurrentVersion.TabIndex = 2;
            lblCurrentVersion.Text = "1.0.0";
            // 
            // btnCheckUpdates
            // 
            btnCheckUpdates.Font = new Font("Segoe UI", 10F);
            btnCheckUpdates.Location = new Point(12, 80);
            btnCheckUpdates.Name = "btnCheckUpdates";
            btnCheckUpdates.Size = new Size(200, 40);
            btnCheckUpdates.TabIndex = 3;
            btnCheckUpdates.Text = "Check for Updates";
            btnCheckUpdates.UseVisualStyleBackColor = true;
            btnCheckUpdates.Click += btnCheckUpdates_Click;
            // 
            // btnAutoUpdate
            // 
            btnAutoUpdate.Font = new Font("Segoe UI", 10F);
            btnAutoUpdate.Location = new Point(218, 80);
            btnAutoUpdate.Name = "btnAutoUpdate";
            btnAutoUpdate.Size = new Size(200, 40);
            btnAutoUpdate.TabIndex = 4;
            btnAutoUpdate.Text = "Enable Auto-Update Timer";
            btnAutoUpdate.UseVisualStyleBackColor = true;
            btnAutoUpdate.Click += btnAutoUpdate_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblStatus);
            groupBox1.Controls.Add(lblUpdateInfo);
            groupBox1.Controls.Add(txtChangelog);
            groupBox1.Controls.Add(lblChangelog);
            groupBox1.Controls.Add(progressBar);
            groupBox1.Controls.Add(lblProgress);
            groupBox1.Location = new Point(12, 136);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(606, 270);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Update Information";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 9F);
            lblStatus.Location = new Point(16, 29);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(145, 15);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status: Ready to check...";
            // 
            // lblUpdateInfo
            // 
            lblUpdateInfo.AutoSize = true;
            lblUpdateInfo.Font = new Font("Segoe UI", 9F);
            lblUpdateInfo.ForeColor = SystemColors.HotTrack;
            lblUpdateInfo.Location = new Point(16, 51);
            lblUpdateInfo.Name = "lblUpdateInfo";
            lblUpdateInfo.Size = new Size(0, 15);
            lblUpdateInfo.TabIndex = 4;
            // 
            // txtChangelog
            // 
            txtChangelog.Font = new Font("Consolas", 9F);
            txtChangelog.Location = new Point(16, 98);
            txtChangelog.Multiline = true;
            txtChangelog.Name = "txtChangelog";
            txtChangelog.ReadOnly = true;
            txtChangelog.ScrollBars = ScrollBars.Vertical;
            txtChangelog.Size = new Size(574, 120);
            txtChangelog.TabIndex = 3;
            // 
            // lblChangelog
            // 
            lblChangelog.AutoSize = true;
            lblChangelog.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblChangelog.Location = new Point(16, 77);
            lblChangelog.Name = "lblChangelog";
            lblChangelog.Size = new Size(69, 15);
            lblChangelog.TabIndex = 2;
            lblChangelog.Text = "Changelog:";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(16, 240);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(574, 13);
            progressBar.TabIndex = 1;
            // 
            // lblProgress
            // 
            lblProgress.AutoSize = true;
            lblProgress.Font = new Font("Segoe UI", 8F);
            lblProgress.ForeColor = SystemColors.ControlDarkDark;
            lblProgress.Location = new Point(16, 224);
            lblProgress.Name = "lblProgress";
            lblProgress.Size = new Size(0, 13);
            lblProgress.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lblInfo);
            groupBox2.Location = new Point(12, 412);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(606, 145);
            groupBox2.TabIndex = 6;
            groupBox2.TabStop = false;
            groupBox2.Text = "How It Works";
            // 
            // lblInfo
            // 
            lblInfo.Font = new Font("Segoe UI", 9F);
            lblInfo.Location = new Point(16, 25);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(574, 110);
            lblInfo.TabIndex = 0;
            lblInfo.Text = "This app uses Updatum to auto-update from GitHub Releases.\r\n\r\n1. Click \"Check for Updates\" to manually check for new versions\r\n2. Click \"Enable Auto-Update Timer\" to check every 6 hours automatically\r\n3. When an update is found, you'll see the changelog and can install it\r\n4. The app will download the update, install it, and restart";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 570);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(btnAutoUpdate);
            Controls.Add(btnCheckUpdates);
            Controls.Add(lblCurrentVersion);
            Controls.Add(lblVersion);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Updatum Demo";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblVersion;
        private Label lblCurrentVersion;
        private Button btnCheckUpdates;
        private Button btnAutoUpdate;
        private GroupBox groupBox1;
        private Label lblProgress;
        private ProgressBar progressBar;
        private TextBox txtChangelog;
        private Label lblChangelog;
        private Label lblUpdateInfo;
        private Label lblStatus;
        private GroupBox groupBox2;
        private Label lblInfo;
    }
}
