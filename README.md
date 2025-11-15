# Updatum Demo - Windows Forms Auto-Updater

A complete .NET 10 Windows Forms application demonstrating automatic updates using [Updatum](https://github.com/sn4k3/Updatum) from GitHub Releases.

## Features

- ✅ Automatic version checking from GitHub Releases
- ✅ Display changelog before updating
- ✅ Download progress tracking
- ✅ One-click update installation
- ✅ Optional auto-update timer (checks every 6 hours)
- ✅ Clean, modern Windows Forms UI
- ✅ Automatic versioning via GitHub Actions

## How It Works

1. **Build & Release**: GitHub Actions automatically builds and publishes releases with version `1.0.X` (X = run number)
2. **Update Check**: The app queries your GitHub repository for the latest release
3. **User Choice**: If a newer version exists, users see the changelog and can choose to update
4. **Auto-Install**: The app downloads the update, installs it, and restarts

## Setup Instructions

### 1. Configure Your Repository

Edit `UpdatumDemo/Updater.cs` and replace the placeholder values:

```csharp
private const string GitHubOwner = "your-github-username";    // e.g., "aherrick"
private const string GitHubRepo = "your-repo-name";           // e.g., "UpdatumDemo"
```

### 2. Push to GitHub

Push this code to your public GitHub repository:

```bash
git init
git add .
git commit -m "Initial commit"
git branch -M main
git remote add origin https://github.com/your-username/your-repo.git
git push -u origin main
```

### 3. Trigger First Release

Go to your repository on GitHub:
1. Navigate to **Actions** tab
2. Click **Auto Release WinForms (Updatum)** workflow
3. Click **Run workflow** → **Run workflow**

This creates your first release: `v1.0.1`

### 4. Download & Test

1. Go to **Releases** in your GitHub repo
2. Download `UpdatumDemo_win-x64_v1.0.1.zip`
3. Extract and run `UpdatumDemo.exe`
4. Click **Check for Updates** to test (it should say you're on the latest version)

### 5. Test Auto-Update

To test the update flow:

1. Modify the app (e.g., change button text in `MainForm.Designer.cs`)
2. Commit and push changes
3. Trigger the workflow again (this creates `v1.0.2`)
4. Run your old `v1.0.1` app
5. Click **Check for Updates**
6. You'll see the changelog and option to update!

## Project Structure

```
UpdatumAppExample/
├── .github/
│   └── workflows/
│       └── release-auto.yml      # GitHub Actions workflow
├── UpdatumDemo/
│   ├── MainForm.cs               # Main UI logic
│   ├── MainForm.Designer.cs      # UI designer file
│   ├── Updater.cs                # Updatum integration
│   ├── Program.cs                # Entry point
│   └── UpdatumDemo.csproj        # Project file
└── UpdatumDemo.sln               # Solution file
```

## Configuration Options

### Change Base Version

In `.github/workflows/release-auto.yml`, modify:

```powershell
$baseVersion = "1.0"  # Change to "2.0" for v2.0.X releases
```

### Customize Asset Names

The workflow creates files named: `UpdatumDemo_win-x64_v1.0.X.zip`

To change the app name, update these locations:
1. `.github/workflows/release-auto.yml` → `$appName` variable
2. `UpdatumDemo.csproj` → `<AssemblyName>` property

### Auto-Update Timer

The app includes an optional timer that checks every 6 hours:
- Click **Enable Auto-Update Timer** in the UI
- Modify interval in `MainForm.cs`:
  ```csharp
  Updater.AppUpdater.AutoUpdateCheckTimer.Interval = TimeSpan.FromHours(6).TotalMilliseconds;
  ```

## Building Locally

### Prerequisites
- .NET 10 SDK
- Windows 10/11
- Visual Studio 2022 or VS Code

### Build Commands

```bash
# Restore packages
dotnet restore

# Build
dotnet build

# Run
dotnet run --project UpdatumDemo/UpdatumDemo.csproj

# Publish self-contained
dotnet publish UpdatumDemo/UpdatumDemo.csproj -c Release -r win-x64 --self-contained true
```

## How Updatum Works

Updatum checks your GitHub Releases API:
```
https://api.github.com/repos/your-username/your-repo/releases/latest
```

It looks for assets matching:
- Runtime identifier: `win-x64`
- Version pattern: `_vX.Y.Z.zip`

When an update is found:
1. Compares version tags (e.g., `v1.0.2` > `v1.0.1`)
2. Downloads the ZIP asset
3. Extracts and replaces files
4. Restarts the application

## Customization Ideas

- **Multi-platform**: Add `win-arm64`, `linux-x64` builds to the workflow
- **MSI Installer**: Change ZIP to MSI and configure `InstallUpdateWindowsInstallerArguments`
- **Beta Channel**: Create separate workflows for stable/beta releases
- **Custom UI**: Replace MessageBox with custom forms for progress/changelog
- **Silent Updates**: Remove user prompts and auto-install updates

## Troubleshooting

### "No updates available" when one exists
- Verify `GitHubOwner` and `GitHubRepo` in `Updater.cs`
- Check that releases are public (not draft)
- Ensure asset name matches pattern: `AppName_win-x64_vX.Y.Z.zip`

### Download fails
- Check internet connection
- Verify GitHub token has access (public repos don't need auth)
- Check asset size isn't too large

### Update doesn't restart app
- Ensure the ZIP contains the executable
- Check file permissions after extraction
- Review Updatum logs (enable console to see output)

## Version Scheme

This app uses **automatic versioning**:
- Format: `MAJOR.MINOR.BUILD`
- Example: `1.0.37`
  - `1.0` = manually set base version
  - `37` = GitHub Actions run number (auto-increments)

To bump major/minor versions, edit the workflow file.

## Resources

- [Updatum GitHub Repository](https://github.com/sn4k3/Updatum)
- [GitHub Releases Documentation](https://docs.github.com/en/repositories/releasing-projects-on-github/about-releases)
- [.NET Publish Documentation](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-publish)

## License

This demo is provided as-is for educational purposes. Modify freely for your own projects.

---

**Made with ❤️ using Updatum**
