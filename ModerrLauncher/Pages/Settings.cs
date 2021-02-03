using MLCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModerrLauncher.Pages
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            installDirText.Text = Program.getInstallPath();
        }

        private void btnChangeInstallDir_Click(object sender, EventArgs e)
        {
            try
            {
                using (var folderBrowser = new FolderBrowserDialog())
                {
                    folderBrowser.RootFolder = Environment.SpecialFolder.ProgramFiles;
                    DialogResult result = folderBrowser.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath))
                    {
                        Program.setInstallPath(folderBrowser.SelectedPath);
                        installDirText.Text = folderBrowser.SelectedPath;
                        MLBox.Show("Nowe ustawienie", "Pomyślnie ustawiono nową ścieżke instalacji!");
                    }
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                MLBox.Show("Wystąpił problem", "Wystąpił błąd podczas próby ustawienia nowej ścieżki");
            }

        }
    }
}
