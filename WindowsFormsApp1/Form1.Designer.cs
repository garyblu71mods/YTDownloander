namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Button buttonMp4;
        private System.Windows.Forms.Button buttonMp3;
        private System.Windows.Forms.Label labelQuality;
        private System.Windows.Forms.ComboBox comboQuality;
        private System.Windows.Forms.Label labelBitrate;
        private System.Windows.Forms.ComboBox comboBitrate;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.Button buttonOpenFolder;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.labelUrl = new System.Windows.Forms.Label();
            this.textBoxUrl = new System.Windows.Forms.TextBox();
            this.buttonMp4 = new System.Windows.Forms.Button();
            this.buttonMp3 = new System.Windows.Forms.Button();
            this.labelQuality = new System.Windows.Forms.Label();
            this.comboQuality = new System.Windows.Forms.ComboBox();
            this.labelBitrate = new System.Windows.Forms.Label();
            this.comboBitrate = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelFolder = new System.Windows.Forms.Label();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.labelUrl.Text = "Paste YouTube link:";
            this.labelUrl.Location = new System.Drawing.Point(12, 12);
            this.labelUrl.Size = new System.Drawing.Size(460, 18);

            this.textBoxUrl.Location = new System.Drawing.Point(12, 34);
            this.textBoxUrl.Size = new System.Drawing.Size(460, 22);
            this.textBoxUrl.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;

            this.buttonMp4.Text = "Download MP4 (video)";
            this.buttonMp4.Location = new System.Drawing.Point(12, 70);
            this.buttonMp4.Size = new System.Drawing.Size(225, 34);
            this.buttonMp4.Click += new System.EventHandler(this.buttonMp4_Click);

            this.buttonMp3.Text = "Download MP3 (audio)";
            this.buttonMp3.Location = new System.Drawing.Point(247, 70);
            this.buttonMp3.Size = new System.Drawing.Size(225, 34);
            this.buttonMp3.Click += new System.EventHandler(this.buttonMp3_Click);

            this.labelQuality.Text = "MP4 Quality:";
            this.labelQuality.Location = new System.Drawing.Point(12, 116);
            this.labelQuality.Size = new System.Drawing.Size(80, 20);

            this.comboQuality.Location = new System.Drawing.Point(96, 113);
            this.comboQuality.Size = new System.Drawing.Size(376, 24);
            this.comboQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQuality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.comboQuality.Items.AddRange(new object[] { "Best", "1080p", "720p", "480p", "360p" });
            this.comboQuality.SelectedIndex = 0;

            this.labelBitrate.Text = "MP3 Bitrate:";
            this.labelBitrate.Location = new System.Drawing.Point(12, 143);
            this.labelBitrate.Size = new System.Drawing.Size(80, 20);

            this.comboBitrate.Location = new System.Drawing.Point(96, 140);
            this.comboBitrate.Size = new System.Drawing.Size(376, 24);
            this.comboBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBitrate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.comboBitrate.Items.AddRange(new object[] { "320 kbps (best)", "192 kbps", "128 kbps", "96 kbps" });
            this.comboBitrate.SelectedIndex = 0;

            this.progressBar.Location = new System.Drawing.Point(12, 175);
            this.progressBar.Size = new System.Drawing.Size(460, 22);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;

            this.labelStatus.Text = "Status: waiting...";
            this.labelStatus.Location = new System.Drawing.Point(12, 202);
            this.labelStatus.Size = new System.Drawing.Size(460, 20);
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;

            this.labelFolder.Text = "";
            this.labelFolder.Location = new System.Drawing.Point(12, 226);
            this.labelFolder.Size = new System.Drawing.Size(460, 18);
            this.labelFolder.ForeColor = System.Drawing.Color.Gray;
            this.labelFolder.Font = new System.Drawing.Font("Segoe UI", 7.5f);
            this.labelFolder.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;

            this.buttonOpenFolder.Text = "Open download folder";
            this.buttonOpenFolder.Location = new System.Drawing.Point(12, 250);
            this.buttonOpenFolder.Size = new System.Drawing.Size(460, 30);
            this.buttonOpenFolder.Enabled = false;
            this.buttonOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Top
                | System.Windows.Forms.AnchorStyles.Left
                | System.Windows.Forms.AnchorStyles.Right;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 295);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.buttonMp4);
            this.Controls.Add(this.buttonMp3);
            this.Controls.Add(this.labelQuality);
            this.Controls.Add(this.comboQuality);
            this.Controls.Add(this.labelBitrate);
            this.Controls.Add(this.comboBitrate);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.buttonOpenFolder);
            this.Icon = new System.Drawing.Icon(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "app.ico"));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YT Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

