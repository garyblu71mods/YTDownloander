using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly string _appDir = AppDomain.CurrentDomain.BaseDirectory;
        private string _lastDownloadFolder = null;

        private const string YtDlpUrl    = "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
        private const string FfmpegZipUrl = "https://github.com/BtbN/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip";
        private const string DonateUrl   = "https://www.paypal.com/paypalme/GaryBlu71";
        private const string SettingsFile = "settings.cfg";

        private string _mp4Folder;
        private string _mp3Folder;

        public Form1()
        {
            InitializeComponent();
            LoadSettings();
            SetButtonsEnabled(false);
            this.Load += async (s, e) => await EnsureToolsAsync();
        }

        // ── Settings ────────────────────────────────────────────────────────
        private string SettingsPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "YTDownloader", SettingsFile);

        private void LoadSettings()
        {
            string defaultMp4 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads\Downloaded Video\MP4");
            string defaultMp3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads\Downloaded Audio\MP3");

            _mp4Folder = defaultMp4;
            _mp3Folder = defaultMp3;

            if (File.Exists(SettingsPath))
            {
                foreach (var line in File.ReadAllLines(SettingsPath))
                {
                    var parts = line.Split(new char[] { '=' }, 2);
                    if (parts.Length != 2) continue;
                    if (parts[0] == "Mp4Folder") _mp4Folder = parts[1];
                    if (parts[0] == "Mp3Folder") _mp3Folder = parts[1];
                }
            }

            Directory.CreateDirectory(_mp4Folder);
            Directory.CreateDirectory(_mp3Folder);
            textBoxMp4Folder.Text = _mp4Folder;
            textBoxMp3Folder.Text = _mp3Folder;
        }

        private void SaveSettings()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(SettingsPath));
            File.WriteAllLines(SettingsPath, new[]
            {
                "Mp4Folder=" + _mp4Folder,
                "Mp3Folder=" + _mp3Folder
            });
        }

        // ── Folder browse ────────────────────────────────────────────────────
        private void buttonBrowseMp4_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog { SelectedPath = _mp4Folder, Description = "Select MP4 download folder" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _mp4Folder = dlg.SelectedPath;
                    textBoxMp4Folder.Text = _mp4Folder;
                    SaveSettings();
                }
            }
        }

        private void buttonBrowseMp3_Click(object sender, EventArgs e)
        {
            using (var dlg = new FolderBrowserDialog { SelectedPath = _mp3Folder, Description = "Select MP3 download folder" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    _mp3Folder = dlg.SelectedPath;
                    textBoxMp3Folder.Text = _mp3Folder;
                    SaveSettings();
                }
            }
        }

        // ── Auto-fetch title when URL is pasted ──────────────────────────────
        private async void textBoxUrl_Leave(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(url) || !url.StartsWith("http")) return;
            if (!string.IsNullOrWhiteSpace(textBoxFileName.Text)) return;

            textBoxFileName.Text = "Fetching title...";
            string title = await FetchTitleAsync(url);
            textBoxFileName.Text = SanitizeFileName(title);
        }

        private async Task<string> FetchTitleAsync(string url)
        {
            try
            {
                string ytDlpPath = Path.Combine(_appDir, "yt-dlp.exe");
                var psi = new ProcessStartInfo
                {
                    FileName = ytDlpPath,
                    Arguments = "--get-title --no-playlist \"" + url + "\"",
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true
                };
                using (var proc = Process.Start(psi))
                {
                    string output = await Task.Run(() => proc.StandardOutput.ReadToEnd());
                    proc.WaitForExit();
                    return output.Trim();
                }
            }
            catch { return string.Empty; }
        }

        private static string SanitizeFileName(string name)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
                name = name.Replace(c, '_');
            return name.Trim();
        }

        // ── Tools auto-download ──────────────────────────────────────────────
        private async Task EnsureToolsAsync()
        {
            await DownloadIfMissingAsync("yt-dlp.exe", YtDlpUrl, false, null);
            await DownloadIfMissingAsync("ffmpeg.exe", FfmpegZipUrl, true, "ffmpeg-master-latest-win64-gpl/bin/ffmpeg.exe");
            SetButtonsEnabled(true);
            SetStatus("Status: ready.");
            SetProgress(0);
        }

        private async Task DownloadIfMissingAsync(string fileName, string url, bool isZip, string zipEntry)
        {
            string dest = Path.Combine(_appDir, fileName);
            if (File.Exists(dest)) return;
            SetStatus("Status: downloading " + fileName + "...");
            SetProgress(0);
            string tempFile = dest + ".tmp";
            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += (s, e) => SetProgress(e.ProgressPercentage);
                await client.DownloadFileTaskAsync(new Uri(url), tempFile);
            }
            if (isZip)
            {
                SetStatus("Status: extracting " + fileName + "...");
                await Task.Run(() =>
                {
                    using (var zip = ZipFile.OpenRead(tempFile))
                    {
                        var entry = zip.GetEntry(zipEntry);
                        if (entry != null) entry.ExtractToFile(dest, true);
                    }
                });
                File.Delete(tempFile);
            }
            else
            {
                File.Move(tempFile, dest);
            }
        }

        // ── Download buttons ─────────────────────────────────────────────────
        private async void buttonMp4_Click(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(url)) return;
            _lastDownloadFolder = _mp4Folder;

            string format;
            switch (comboQuality.SelectedIndex)
            {
                case 1: format = "bestvideo[height<=1080][ext=mp4]+bestaudio[ext=m4a]/best[height<=1080][ext=mp4]"; break;
                case 2: format = "bestvideo[height<=720][ext=mp4]+bestaudio[ext=m4a]/best[height<=720][ext=mp4]"; break;
                case 3: format = "bestvideo[height<=480][ext=mp4]+bestaudio[ext=m4a]/best[height<=480][ext=mp4]"; break;
                case 4: format = "bestvideo[height<=360][ext=mp4]+bestaudio[ext=m4a]/best[height<=360][ext=mp4]"; break;
                default: format = "bestvideo[ext=mp4]+bestaudio[ext=m4a]/bestvideo+bestaudio/best"; break;
            }

            string ffmpegPath = Path.Combine(_appDir, "ffmpeg.exe");
            string output = GetOutputTemplate(_mp4Folder, "mp4");
            string args = "--no-playlist --ffmpeg-location \"" + ffmpegPath + "\" --merge-output-format mp4 -f \"" + format + "\" --newline -o \"" + output + "\" \"" + url + "\"";
            await RunDownload(args);
        }

        private async void buttonMp3_Click(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(url)) return;
            _lastDownloadFolder = _mp3Folder;

            string[] bitrates = { "320", "192", "128", "96" };
            string bitrate = bitrates[comboBitrate.SelectedIndex];
            string ffmpegPath = Path.Combine(_appDir, "ffmpeg.exe");
            string output = GetOutputTemplate(_mp3Folder, "mp3");
            string args = "--no-playlist -x --audio-format mp3 --audio-quality " + bitrate + "K --ffmpeg-location \"" + ffmpegPath + "\" --newline -o \"" + output + "\" \"" + url + "\"";
            await RunDownload(args);
        }

        private string GetOutputTemplate(string folder, string ext)
        {
            string name = textBoxFileName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) || name == "Fetching title...")
                return folder + "\\%(title)s.%(ext)s";
            return folder + "\\" + SanitizeFileName(name) + "." + ext;
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            if (_lastDownloadFolder != null && Directory.Exists(_lastDownloadFolder))
                Process.Start("explorer.exe", _lastDownloadFolder);
        }

        private void linkLabelDonate_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(DonateUrl);
        }

        // ── Download core ────────────────────────────────────────────────────
        private async Task RunDownload(string arguments)
        {
            SetButtonsEnabled(false);
            SetProgress(0);
            SetStatus("Status: starting download...");
            string ytDlpPath = Path.Combine(_appDir, "yt-dlp.exe");
            var psi = new ProcessStartInfo
            {
                FileName = ytDlpPath,
                Arguments = arguments,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };
            using (var proc = new Process { StartInfo = psi, EnableRaisingEvents = true })
            {
                proc.OutputDataReceived += (s, ev) => { if (!string.IsNullOrEmpty(ev.Data)) ParseProgress(ev.Data); };
                proc.ErrorDataReceived  += (s, ev) =>
                {
                    if (!string.IsNullOrEmpty(ev.Data) && !ev.Data.StartsWith("WARNING"))
                        SetStatus("Status: " + ev.Data);
                };
                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                await Task.Run(() => proc.WaitForExit());
                if (proc.ExitCode == 0)
                {
                    SetProcessingMode(false);
                    SetProgress(100);
                    SetStatus("Status: download complete!");
                    SetFolderLabel(_lastDownloadFolder);
                    SetOpenFolderEnabled(true);
                    this.Invoke(new Action(() => textBoxFileName.Clear()));
                }
                else
                {
                    SetStatus("Status: download error (code: " + proc.ExitCode + ")");
                }
            }
            SetButtonsEnabled(true);
        }

        private static readonly Regex ProgressRegex = new Regex(@"\[download\]\s+([\d\.]+)%", RegexOptions.Compiled);
        private static readonly Regex ProcessingRegex = new Regex(@"\[(Merger|ExtractAudio|ffmpeg)\]", RegexOptions.Compiled);

        private void ParseProgress(string line)
        {
            if (ProcessingRegex.IsMatch(line))
            {
                SetProcessingMode(true);
                return;
            }
            var match = ProgressRegex.Match(line);
            if (match.Success && double.TryParse(match.Groups[1].Value,
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double pct))
            {
                SetProgress((int)Math.Min(pct, 100));
                SetStatus("Status: downloading... " + pct.ToString("F1") + "%");
            }
        }

        private void SetProcessingMode(bool processing)
        {
            if (progressBar.InvokeRequired)
            {
                progressBar.Invoke(new Action(() => SetProcessingMode(processing)));
                return;
            }
            if (processing)
            {
                progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
                progressBar.MarqueeAnimationSpeed = 30;
                labelStatus.Text = "Status: processing... please wait";
            }
            else
            {
                progressBar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
                progressBar.Value = 100;
            }
        }

        // ── UI helpers ───────────────────────────────────────────────────────
        private void SetProgress(int value)
        {
            if (progressBar.InvokeRequired) progressBar.Invoke(new Action(() => progressBar.Value = value));
            else progressBar.Value = value;
        }

        private void SetStatus(string text)
        {
            if (labelStatus.InvokeRequired) labelStatus.Invoke(new Action(() => labelStatus.Text = text));
            else labelStatus.Text = text;
        }

        private void SetFolderLabel(string path)
        {
            if (labelFolder.InvokeRequired) labelFolder.Invoke(new Action(() => labelFolder.Text = "Saved to: " + path));
            else labelFolder.Text = "Saved to: " + path;
        }

        private void SetOpenFolderEnabled(bool enabled)
        {
            if (buttonOpenFolder.InvokeRequired) buttonOpenFolder.Invoke(new Action(() => buttonOpenFolder.Enabled = enabled));
            else buttonOpenFolder.Enabled = enabled;
        }

        private void SetButtonsEnabled(bool enabled)
        {
            if (buttonMp4.InvokeRequired)
                buttonMp4.Invoke(new Action(() => { buttonMp4.Enabled = enabled; buttonMp3.Enabled = enabled; }));
            else { buttonMp4.Enabled = enabled; buttonMp3.Enabled = enabled; }
        }
    }
}