# YT Downloader

A simple Windows desktop app for downloading YouTube videos and audio.

![.NET Framework](https://img.shields.io/badge/.NET%20Framework-4.7.2-blue)
![Platform](https://img.shields.io/badge/platform-Windows-lightgrey)

## Features
- Download YouTube videos as **MP4** (Best / 1080p / 720p / 480p / 360p)
- Download YouTube audio as **MP3** (320 / 192 / 128 / 96 kbps)
- Auto-fetches video title as filename (editable before download)
- Custom save folders for MP4 and MP3 (saved between sessions)
- Progress bar with processing indicator
- Opens download folder after completion
- `yt-dlp.exe` and `ffmpeg.exe` are **downloaded automatically** on first launch

## Requirements
- Windows 10 / 11
- .NET Framework 4.7.2 (pre-installed on Windows 10+)
- Internet connection (first launch downloads yt-dlp and ffmpeg automatically)

## Installation
1. Download `YTDownloader.zip` from [Releases](../../releases)
2. Extract all files to any folder
3. Run `YTDownloader.exe`
4. On first launch the app will automatically download `yt-dlp.exe` and `ffmpeg.exe`

## Usage
1. Paste a YouTube link into the URL field
2. Wait for the title to auto-fill in the **File name** field (or type your own)
3. Select MP4 quality or MP3 bitrate
4. Click **Download MP4** or **Download MP3**
5. Click **Open download folder** when done

## Default save locations
| Format | Folder |
|--------|--------|
| MP4 | `Downloads\Downloaded Video\MP4` |
| MP3 | `Downloads\Downloaded Audio\MP3` |

Folders can be changed in the app using the **Browse** buttons.

## Powered by
- [yt-dlp](https://github.com/yt-dlp/yt-dlp)
- [FFmpeg](https://ffmpeg.org)

## Support
If you find this app useful, consider contributing:  
[![Donate](https://img.shields.io/badge/Donate-PayPal-blue)](https://www.paypal.com/paypalme/GaryBlu71)