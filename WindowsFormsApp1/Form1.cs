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
        private readonly string _folderMp4 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads\Downloaded Video\MP4");
        private readonly string _folderMp3 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Downloads\Downloaded Audio\MP3");
        private readonly string _appDir = AppDomain.CurrentDomain.BaseDirectory;
        private string _lastDownloadFolder = null;

        private const string YtDlpUrl = "https://github.com/yt-dlp/yt-dlp/releases/latest/download/yt-dlp.exe";
        private const string FfmpegZipUrl = "https://github.com/BtbN/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip";

        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory(_folderMp4);
            Directory.CreateDirectory(_folderMp3);
            SetButtonsEnabled(false);
            this.Load += async (s, e) => await EnsureToolsAsync();
        }

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

        private async void buttonMp4_Click(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(url)) return;
            _lastDownloadFolder = _folderMp4;

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
            string args = "--no-playlist --ffmpeg-location \"" + ffmpegPath + "\" --merge-output-format mp4 -f \"" + format + "\" --newline -o \"" + _folderMp4 + "\\%(title)s.%(ext)s\" \"" + url + "\"";
            await RunDownload(args);
        }

        private async void buttonMp3_Click(object sender, EventArgs e)
        {
            string url = textBoxUrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(url)) return;
            _lastDownloadFolder = _folderMp3;
            string ffmpegPath = Path.Combine(_appDir, "ffmpeg.exe");
            string[] bitrates = { "320", "192", "128", "96" };
            string bitrate = bitrates[comboBitrate.SelectedIndex];
            string args = "--no-playlist -x --audio-format mp3 --audio-quality " + bitrate + "K --ffmpeg-location \"" + ffmpegPath + "\" --newline -o \"" + _folderMp3 + "\\%(title)s.%(ext)s\" \"" + url + "\"";
            await RunDownload(args);
        }

        private void buttonOpenFolder_Click(object sender, EventArgs e)
        {
            if (_lastDownloadFolder != null && Directory.Exists(_lastDownloadFolder))
                Process.Start("explorer.exe", _lastDownloadFolder);
        }

        private async Task RunDownload(string arguments)
        {
            SetButtonsEnabled(false);
            SetProgress(0);
            SetStatus("Status: downloading rozpoczete...");
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
                proc.ErrorDataReceived += (s, ev) => { if (!string.IsNullOrEmpty(ev.Data)) SetStatus("Status: " + ev.Data); };
                proc.Start();
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                await Task.Run(() => proc.WaitForExit());
                if (proc.ExitCode == 0)
                {
                    SetProgress(100);
                    SetStatus("Status: downloading zakonczone! Folder: " + _lastDownloadFolder);
                    SetFolderLabel(_lastDownloadFolder);
                    SetOpenFolderEnabled(true);
                }
                else
                {
                    SetStatus("Status: download error (code: " + proc.ExitCode + ")");
                }
            }
            SetButtonsEnabled(true);
        }

        private static readonly Regex ProgressRegex = new Regex(@"\[download\]\s+([\d\.]+)%", RegexOptions.Compiled);

        private void ParseProgress(string line)
        {
            var match = ProgressRegex.Match(line);
            if (match.Success && double.TryParse(match.Groups[1].Value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double pct))
            {
                SetProgress((int)Math.Min(pct, 100));
                SetStatus("Status: downloading... " + pct.ToString("F1") + "%");
            }
        }

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
            if (labelFolder.InvokeRequired) labelFolder.Invoke(new Action(() => labelFolder.Text = "Folder: " + path));
            else labelFolder.Text = "Folder: " + path;
        }

        private void SetOpenFolderEnabled(bool enabled)
        {
            if (buttonOpenFolder.InvokeRequired) buttonOpenFolder.Invoke(new Action(() => buttonOpenFolder.Enabled = enabled));
            else buttonOpenFolder.Enabled = enabled;
        }

        private void SetButtonsEnabled(bool enabled)
        {
            if (buttonMp4.InvokeRequired) buttonMp4.Invoke(new Action(() => { buttonMp4.Enabled = enabled; buttonMp3.Enabled = enabled; }));
            else { buttonMp4.Enabled = enabled; buttonMp3.Enabled = enabled; }
        }
    }
}