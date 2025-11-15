using System.ComponentModel;
using System.Reflection;
using Updatum;

namespace UpdatumDemo;

internal static class Updater
{
    // Configure with your GitHub username and repository name
    private const string GitHubOwner = "aherrick"; // Change this to your GitHub username

    private const string GitHubRepo = "updatumdemo"; // Change this to your repository name

    // One global instance, as the docs recommend
    internal static readonly UpdatumManager AppUpdater = new(GitHubOwner, GitHubRepo)
    {
        // For MSI installers: basic UI
        InstallUpdateWindowsInstallerArguments = "/qb",
    };

    /// <summary>
    /// Gets the current application version
    /// </summary>
    internal static string CurrentVersion
    {
        get
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            return version != null ? $"{version.Major}.{version.Minor}.{version.Build}" : "Unknown";
        }
    }

    /// <summary>
    /// Check for updates and prompt user to install if available
    /// </summary>
    internal static async Task CheckAndMaybeUpdateAsync(IWin32Window owner, bool silent = false)
    {
        try
        {
            var updateFound = await AppUpdater.CheckForUpdatesAsync();

            if (!updateFound)
            {
                if (!silent)
                {
                    MessageBox.Show(
                        owner,
                        $"You are running the latest version ({CurrentVersion}).",
                        "No Updates Available",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                return;
            }

            var changelog = AppUpdater.GetChangelog();
            var latestVersion = AppUpdater.LatestRelease?.TagName ?? "Unknown";

            var result = MessageBox.Show(
                owner,
                $"A new version is available!\n\n"
                    + $"Current version: {CurrentVersion}\n"
                    + $"Latest version: {latestVersion}\n\n"
                    + $"Changelog:\n{changelog}\n\n"
                    + $"Download and install now?",
                "Update Available",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result != DialogResult.Yes)
            {
                return;
            }

            // Wire up progress tracking (optional but nice)
            AppUpdater.PropertyChanged += AppUpdaterOnPropertyChanged;

            var asset = await AppUpdater.DownloadUpdateAsync();
            if (asset == null)
            {
                MessageBox.Show(
                    owner,
                    "Failed to download the update. Please try again later.",
                    "Update Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            // This will usually terminate your process and run the installer / updater
            await AppUpdater.InstallUpdateAsync(asset);
        }
        catch (Exception ex)
        {
            if (!silent)
            {
                MessageBox.Show(
                    owner,
                    $"Error while checking for updates:\n{ex.Message}",
                    "Update Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }

    private static void AppUpdaterOnPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(UpdatumManager.DownloadedPercentage))
        {
            // Example: log progress; you could instead update a custom progress form
            Console.WriteLine(
                $"Downloaded: {AppUpdater.DownloadedMegabytes:F2} MB ({AppUpdater.DownloadedPercentage:F1}%)"
            );
        }
    }
}