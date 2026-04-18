namespace WindowsFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxUrl;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.Label labelMp4Folder;
        private System.Windows.Forms.TextBox textBoxMp4Folder;
        private System.Windows.Forms.Button buttonBrowseMp4;
        private System.Windows.Forms.Label labelMp3Folder;
        private System.Windows.Forms.TextBox textBoxMp3Folder;
        private System.Windows.Forms.Button buttonBrowseMp3;
        private System.Windows.Forms.Label labelQuality;
        private System.Windows.Forms.ComboBox comboQuality;
        private System.Windows.Forms.Label labelBitrate;
        private System.Windows.Forms.ComboBox comboBitrate;
        private System.Windows.Forms.Button buttonMp4;
        private System.Windows.Forms.Button buttonMp3;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelFolder;
        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.LinkLabel linkLabelDonate;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.labelUrl           = new System.Windows.Forms.Label();
            this.textBoxUrl         = new System.Windows.Forms.TextBox();
            this.labelFileName      = new System.Windows.Forms.Label();
            this.textBoxFileName    = new System.Windows.Forms.TextBox();
            this.labelMp4Folder     = new System.Windows.Forms.Label();
            this.textBoxMp4Folder   = new System.Windows.Forms.TextBox();
            this.buttonBrowseMp4    = new System.Windows.Forms.Button();
            this.labelMp3Folder     = new System.Windows.Forms.Label();
            this.textBoxMp3Folder   = new System.Windows.Forms.TextBox();
            this.buttonBrowseMp3    = new System.Windows.Forms.Button();
            this.labelQuality       = new System.Windows.Forms.Label();
            this.comboQuality       = new System.Windows.Forms.ComboBox();
            this.labelBitrate       = new System.Windows.Forms.Label();
            this.comboBitrate       = new System.Windows.Forms.ComboBox();
            this.buttonMp4          = new System.Windows.Forms.Button();
            this.buttonMp3          = new System.Windows.Forms.Button();
            this.progressBar        = new System.Windows.Forms.ProgressBar();
            this.labelStatus        = new System.Windows.Forms.Label();
            this.labelFolder        = new System.Windows.Forms.Label();
            this.buttonOpenFolder   = new System.Windows.Forms.Button();
            this.linkLabelDonate    = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();

            // labelUrl
            this.labelUrl.Text = "Paste YouTube link:";
            this.labelUrl.Location = new System.Drawing.Point(12, 12);
            this.labelUrl.Size = new System.Drawing.Size(536, 18);

            // textBoxUrl
            this.textBoxUrl.Location = new System.Drawing.Point(12, 32);
            this.textBoxUrl.Size = new System.Drawing.Size(536, 22);
            this.textBoxUrl.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textBoxUrl.Leave += new System.EventHandler(this.textBoxUrl_Leave);

            // labelFileName
            this.labelFileName.Text = "File name:";
            this.labelFileName.Location = new System.Drawing.Point(12, 62);
            this.labelFileName.Size = new System.Drawing.Size(75, 20);
            this.labelFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // textBoxFileName
            this.textBoxFileName.Location = new System.Drawing.Point(90, 60);
            this.textBoxFileName.Size = new System.Drawing.Size(458, 22);
            this.textBoxFileName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // labelMp4Folder
            this.labelMp4Folder.Text = "MP4 folder:";
            this.labelMp4Folder.Location = new System.Drawing.Point(12, 92);
            this.labelMp4Folder.Size = new System.Drawing.Size(75, 20);
            this.labelMp4Folder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // textBoxMp4Folder
            this.textBoxMp4Folder.Location = new System.Drawing.Point(90, 90);
            this.textBoxMp4Folder.Size = new System.Drawing.Size(378, 22);
            this.textBoxMp4Folder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textBoxMp4Folder.ReadOnly = true;

            // buttonBrowseMp4
            this.buttonBrowseMp4.Text = "Browse";
            this.buttonBrowseMp4.Location = new System.Drawing.Point(472, 88);
            this.buttonBrowseMp4.Size = new System.Drawing.Size(76, 26);
            this.buttonBrowseMp4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.buttonBrowseMp4.Click += new System.EventHandler(this.buttonBrowseMp4_Click);

            // labelMp3Folder
            this.labelMp3Folder.Text = "MP3 folder:";
            this.labelMp3Folder.Location = new System.Drawing.Point(12, 122);
            this.labelMp3Folder.Size = new System.Drawing.Size(75, 20);
            this.labelMp3Folder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // textBoxMp3Folder
            this.textBoxMp3Folder.Location = new System.Drawing.Point(90, 120);
            this.textBoxMp3Folder.Size = new System.Drawing.Size(378, 22);
            this.textBoxMp3Folder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textBoxMp3Folder.ReadOnly = true;

            // buttonBrowseMp3
            this.buttonBrowseMp3.Text = "Browse";
            this.buttonBrowseMp3.Location = new System.Drawing.Point(472, 118);
            this.buttonBrowseMp3.Size = new System.Drawing.Size(76, 26);
            this.buttonBrowseMp3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.buttonBrowseMp3.Click += new System.EventHandler(this.buttonBrowseMp3_Click);

            // labelQuality
            this.labelQuality.Text = "MP4 Quality:";
            this.labelQuality.Location = new System.Drawing.Point(12, 154);
            this.labelQuality.Size = new System.Drawing.Size(78, 20);
            this.labelQuality.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // comboQuality
            this.comboQuality.Location = new System.Drawing.Point(90, 152);
            this.comboQuality.Size = new System.Drawing.Size(170, 24);
            this.comboQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboQuality.Items.AddRange(new object[] { "Best", "1080p", "720p", "480p", "360p" });
            this.comboQuality.SelectedIndex = 0;

            // labelBitrate
            this.labelBitrate.Text = "MP3 Bitrate:";
            this.labelBitrate.Location = new System.Drawing.Point(278, 154);
            this.labelBitrate.Size = new System.Drawing.Size(78, 20);
            this.labelBitrate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // comboBitrate
            this.comboBitrate.Location = new System.Drawing.Point(358, 152);
            this.comboBitrate.Size = new System.Drawing.Size(190, 24);
            this.comboBitrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBitrate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.comboBitrate.Items.AddRange(new object[] { "320 kbps (best)", "192 kbps", "128 kbps", "96 kbps" });
            this.comboBitrate.SelectedIndex = 0;

            // buttonMp4
            this.buttonMp4.Text = "Download MP4 (video)";
            this.buttonMp4.Location = new System.Drawing.Point(12, 186);
            this.buttonMp4.Size = new System.Drawing.Size(260, 34);
            this.buttonMp4.Click += new System.EventHandler(this.buttonMp4_Click);

            // buttonMp3
            this.buttonMp3.Text = "Download MP3 (audio)";
            this.buttonMp3.Location = new System.Drawing.Point(288, 186);
            this.buttonMp3.Size = new System.Drawing.Size(260, 34);
            this.buttonMp3.Click += new System.EventHandler(this.buttonMp3_Click);

            // progressBar
            this.progressBar.Location = new System.Drawing.Point(12, 230);
            this.progressBar.Size = new System.Drawing.Size(536, 22);
            this.progressBar.Minimum = 0;
            this.progressBar.Maximum = 100;
            this.progressBar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // labelStatus
            this.labelStatus.Text = "Status: waiting...";
            this.labelStatus.Location = new System.Drawing.Point(12, 258);
            this.labelStatus.Size = new System.Drawing.Size(536, 20);
            this.labelStatus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // labelFolder
            this.labelFolder.Text = "";
            this.labelFolder.Location = new System.Drawing.Point(12, 280);
            this.labelFolder.Size = new System.Drawing.Size(536, 18);
            this.labelFolder.ForeColor = System.Drawing.Color.Gray;
            this.labelFolder.Font = new System.Drawing.Font("Segoe UI", 7.5f);
            this.labelFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // buttonOpenFolder
            this.buttonOpenFolder.Text = "Open download folder";
            this.buttonOpenFolder.Location = new System.Drawing.Point(12, 302);
            this.buttonOpenFolder.Size = new System.Drawing.Size(420, 30);
            this.buttonOpenFolder.Enabled = false;
            this.buttonOpenFolder.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);

            // linkLabelDonate
            this.linkLabelDonate.Text = "Contribute";
            this.linkLabelDonate.Location = new System.Drawing.Point(440, 308);
            this.linkLabelDonate.Size = new System.Drawing.Size(108, 18);
            this.linkLabelDonate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.linkLabelDonate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelDonate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelDonate_LinkClicked);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 344);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.textBoxUrl);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.textBoxFileName);
            this.Controls.Add(this.labelMp4Folder);
            this.Controls.Add(this.textBoxMp4Folder);
            this.Controls.Add(this.buttonBrowseMp4);
            this.Controls.Add(this.labelMp3Folder);
            this.Controls.Add(this.textBoxMp3Folder);
            this.Controls.Add(this.buttonBrowseMp3);
            this.Controls.Add(this.labelQuality);
            this.Controls.Add(this.comboQuality);
            this.Controls.Add(this.labelBitrate);
            this.Controls.Add(this.comboBitrate);
            this.Controls.Add(this.buttonMp4);
            this.Controls.Add(this.buttonMp3);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.labelFolder);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.linkLabelDonate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YT Downloader";
            this.Icon = new System.Drawing.Icon(System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "app.ico"));
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}