# YTDownloader

A simple Windows Forms application for downloading YouTube videos and audio using [yt-dlp](https://github.com/yt-dlp/yt-dlp) and [FFmpeg](https://ffmpeg.org/).

## Features

- 📥 Download YouTube videos as **MP4** (4K / 1080p / 720p / best available)
- 🎵 Download YouTube audio as **MP3**
- 🔧 Automatically downloads `yt-dlp.exe` and `ffmpeg.exe` on first launch
- 📂 Saves files to:
  - `Downloads\Downloaded Video\MP4` (video)
  - `Downloads\Downloaded Audio\MP3` (audio)
- 🖱️ Button to open the download folder after downloading

## Requirements

- Windows 10 or later
- [.NET Framework 4.7.2](https://dotnet.microsoft.com/en-us/download/dotnet-framework/net472)
- Internet connection (for first-time tool download and for downloading videos)

## How to Use

1. Clone or download this repository
2. Open `YTDowlnoad.slnx` in **Visual Studio**
3. Build and run the project (`F5`)
4. On first launch the app will automatically download `yt-dlp.exe` and `ffmpeg.exe`
5. Paste a YouTube URL into the text box
6. Choose the desired quality / format
7. Click **Download MP4** or **Download MP3**

## Building from Source

```
git clone https://github.com/garyblu71mods/YTDownloander.git
cd YTDownloander
```

Open `YTDowlnoad.slnx` in Visual Studio 2022 or later and press **Build → Build Solution**.

## Dependencies

| Tool | Source |
|------|--------|
| yt-dlp | https://github.com/yt-dlp/yt-dlp |
| FFmpeg | https://github.com/BtbN/FFmpeg-Builds |

Both tools are downloaded automatically at runtime and are **not** included in the repository.

## License

This project is open source. Feel free to fork and modify it.
