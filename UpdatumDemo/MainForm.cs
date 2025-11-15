using System.ComponentModel;

namespace UpdatumDemo;

public partial class MainForm : Form
{
    private bool autoUpdateEnabled = false;

    public MainForm()
    {
        InitializeComponent();

        // Display current version
        lblCurrentVersion.Text = Updater.CurrentVersion;

        // Wire up progress tracking
        Updater.AppUpdater.PropertyChanged += OnUpdaterPropertyChanged;
    }

    private async void btnCheckUpdates_Click(object sender, EventArgs e)
    {
        btnCheckUpdates.Enabled = false;
        lblStatus.Text = "Status: Checking for updates...";
        lblUpdateInfo.Text = "";
        txtChangelog.Text = "";
        progressBar.Value = 0;
        lblProgress.Text = "";

        try
        {
            var updateFound = await Updater.AppUpdater.CheckForUpdatesAsync();

            if (!updateFound)
            {
                lblStatus.Text = "Status: You are running the latest version!";
                lblUpdateInfo.Text = "";
                MessageBox.Show(
                    this,
                    $"You are running the latest version ({Updater.CurrentVersion}).",
                    "No Updates Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                return;
            }

            var latestVersion = Updater.AppUpdater.LatestRelease?.TagName ?? "Unknown";
            var changelog = Updater.AppUpdater.GetChangelog();

            lblStatus.Text = $"Status: Update available!";
            lblUpdateInfo.Text =
                $"New version {latestVersion} is available (Current: {Updater.CurrentVersion})";
            txtChangelog.Text = changelog;

            var result = MessageBox.Show(
                this,
                $"A new version is available!\n\n"
                    + $"Current version: {Updater.CurrentVersion}\n"
                    + $"Latest version: {latestVersion}\n\n"
                    + $"Download and install now?",
                "Update Available",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information
            );

            if (result == DialogResult.Yes)
            {
                lblStatus.Text = "Status: Downloading update...";
                var asset = await Updater.AppUpdater.DownloadUpdateAsync();

                if (asset == null)
                {
                    lblStatus.Text = "Status: Download failed!";
                    MessageBox.Show(
                        this,
                        "Failed to download the update. Please try again later.",
                        "Update Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }

                lblStatus.Text = "Status: Installing update...";
                // This will terminate the process and run the installer
                await Updater.AppUpdater.InstallUpdateAsync(asset);
            }
            else
            {
                lblStatus.Text = "Status: Update postponed";
            }
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Status: Error occurred!";
            MessageBox.Show(
                this,
                $"Error while checking for updates:\n{ex.Message}",
                "Update Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
            );
        }
        finally
        {
            btnCheckUpdates.Enabled = true;
        }
    }

    private void btnAutoUpdate_Click(object sender, EventArgs e)
    {
        autoUpdateEnabled = !autoUpdateEnabled;

        if (autoUpdateEnabled)
        {
            // Check every 6 hours
            Updater.AppUpdater.AutoUpdateCheckTimer.Interval = TimeSpan
                .FromHours(6)
                .TotalMilliseconds;
            Updater.AppUpdater.UpdateFound += OnAutoUpdateFound;
            Updater.AppUpdater.AutoUpdateCheckTimer.Start();

            btnAutoUpdate.Text = "Disable Auto-Update Timer";
            lblStatus.Text = "Status: Auto-update enabled (checks every 6 hours)";
            MessageBox.Show(
                this,
                "Auto-update timer enabled. The app will check for updates every 6 hours.",
                "Auto-Update Enabled",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        else
        {
            Updater.AppUpdater.AutoUpdateCheckTimer.Stop();
            Updater.AppUpdater.UpdateFound -= OnAutoUpdateFound;

            btnAutoUpdate.Text = "Enable Auto-Update Timer";
            lblStatus.Text = "Status: Auto-update disabled";
            MessageBox.Show(
                this,
                "Auto-update timer disabled.",
                "Auto-Update Disabled",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }

    private async void OnAutoUpdateFound(object? sender, EventArgs e)
    {
        // When the timer finds an update, trigger the check
        if (InvokeRequired)
        {
            Invoke(() => btnCheckUpdates_Click(sender ?? this, e));
        }
        else
        {
            btnCheckUpdates_Click(sender ?? this, e);
        }
    }

    private void OnUpdaterPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Updater.AppUpdater.DownloadedPercentage))
        {
            if (InvokeRequired)
            {
                Invoke(() => UpdateProgressUI());
            }
            else
            {
                UpdateProgressUI();
            }
        }
    }

    private void UpdateProgressUI()
    {
        var percentage = Updater.AppUpdater.DownloadedPercentage;
        var downloaded = Updater.AppUpdater.DownloadedMegabytes;

        progressBar.Value = (int)Math.Min(percentage, 100);
        lblProgress.Text = $"Downloaded: {downloaded:F2} MB ({percentage:F1}%)";
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            Updater.AppUpdater.PropertyChanged -= OnUpdaterPropertyChanged;
            Updater.AppUpdater.UpdateFound -= OnAutoUpdateFound;

            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }
}