using MLCore;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Windows.Forms;

namespace ModerrLauncher.Pages
{
    public partial class GameButton : Form
    {
        public string gameId;
        WebClient client = new WebClient();
        public GameButton(string gameName)
        {
            this.gameId = gameName;
            InitializeComponent();
            button3.Enabled = false;
            if (new DirectoryInfo(Path.Combine($@"{Program.getInstallPath()}\{gameId}\")).Exists)
            {
                button3.Text = "Graj";
                button3.Enabled = true;
            }
            else
            {
                button3.Text = "Pobierz";
                button3.Enabled = true;
            }
        }


        private static readonly string[] SizeSuffixes = { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        private static string SizeSuffix(long value, int decimalPlaces = 1)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }
            var i = 0;
            var dValue = (decimal)value;
            while (Math.Round(dValue, decimalPlaces) >= 1000)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n" + decimalPlaces + "}{1}", dValue, SizeSuffixes[i]);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            if (button3.Text.Equals("Graj"))
            {
                if(new FileInfo(Path.Combine($@"{Program.getInstallPath()}\{gameId}\DEVOUR.exe")).Exists)
                {
                    string path = Path.Combine($@"{Program.getInstallPath()}\{gameId}\DEVOUR.exe");
                    Process process = Process.Start(new ProcessStartInfo(path));
                    MLBox.Show($"{gameId}", "Uruchomiono Devour");
                    button3.Text = "Uruchomione";
                    button3.Enabled = false;
                    process.WaitForExit();
                    button3.Text = "Graj";
                    button3.Enabled = true;
                }
                else
                {
                    button3.Text = "Pobierz";
                    button3.Enabled = true;
                }
            }
            else
            {
                try
                {
                    MLBox.Show("Uwaga", "Do pobrania jest 2 GB\nZacznij pobierać");
                    client.DownloadProgressChanged += downloadChange;
                    client.DownloadFileCompleted += downloadComplete;
                    client.DownloadFileAsync(new Uri("https://moderr.pl/ML/games/Devour.zip"), Path.Combine($@"{Program.getInstallPath()}\{gameId}.zip"));
                }
                catch(Exception exception)
                {
                    MLBox.Show("Wystąpił bład", "Wystąpił problem podczas pobierania!");
                    Console.WriteLine(exception.Message);
                }
            }
        }

        private void downloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            if(e.Cancelled == true)
            {
                Console.WriteLine("Pobieranie anulowane");
                button3.Text = "Pobierz";
                button3.Enabled = true;
                return;
            }
            if(e.Error != null)
            {
                MLBox.Show("Wystąpił bład", "Wystąpił problem podczas pobierania!");
                Console.WriteLine(e.Error.Message);
                button3.Text = "Pobierz";
                button3.Enabled = true;
                return;
            }
            speedLabel.Text = "Downloaded";
            MLBox.Show($"{gameId}", $"Pomyślnie pobrano {gameId}\nTeraz trwa wypakowywanie możliwy lag");
            if(!new DirectoryInfo(Path.Combine($@"{Program.getInstallPath()}\{gameId}\")).Exists)
            {
                Directory.CreateDirectory(Path.Combine($@"{Program.getInstallPath()}\{gameId}\"));
            }
            using (ZipArchive archive = ZipFile.Open(Path.Combine($@"{Program.getInstallPath()}\{gameId}.zip"), ZipArchiveMode.Read))
            {
                speedLabel.Text = "Extracting ZIP";
                archive.ExtractToDirectory(Path.Combine($@"{Program.getInstallPath()}\{gameId}\"));
                button3.Text = "Graj";
                button3.Enabled = true;
                try
                {
                    File.Delete(Path.Combine($@"{Program.getInstallPath()}\{gameId}.zip"));
                    speedLabel.Text = "Pobrano i usunięto ZIP";
                }
                catch
                {
                    
                }
            }
        }

        private void downloadChange(object sender, DownloadProgressChangedEventArgs e)
        {
            speedLabel.Text = e.ProgressPercentage + $"% ( {SizeSuffix(e.BytesReceived, 2)} / {SizeSuffix(e.TotalBytesToReceive,2)} )";
        }

        private void buttonUninstall_Click(object sender, EventArgs e)
        {
            if (new DirectoryInfo(Path.Combine($@"{Program.getInstallPath()}\{gameId}\")).Exists)
            {
                MLBox.Show(gameId, "Odinstalowano pomyślnie");
                Directory.Delete(Path.Combine($@"{Program.getInstallPath()}\{gameId}\"));
            }
            else
            {
                MLBox.Show(gameId, "Najpierw musisz zainstalować grę");
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {

            client.CancelAsync();
            speedLabel.Text = "Anulowano pobieranie";
            MLBox.Show(gameId, "Anulowano pobieranie");
            try
            {
                File.Delete(Path.Combine($@"{Program.getInstallPath()}\{gameId}.zip"));
            }
            catch
            {

            }
        }
    }
}
