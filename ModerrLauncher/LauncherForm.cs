using ModerrLauncher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MLCore;
using System.Threading;

namespace ModerrLauncher
{
    public partial class LauncherForm : Form
    {
        public LauncherForm()
        {
            Console.WriteLine("Launcher >> START THREAD");
            InitializeComponent();
            LauncherTray.ContextMenuStrip = new ContextMenuStrip();
            LauncherTray.ContextMenuStrip.BackColor = Color.FromArgb(40,40,40);
            LauncherTray.ContextMenuStrip.ForeColor = Color.FromArgb(250, 250, 250);
            LauncherTray.ContextMenuStrip.Font = new Font("Arial", 10, FontStyle.Bold);
            LauncherTray.ContextMenuStrip.AllowTransparency = true;
            LauncherTray.ContextMenuStrip.Items.Add("Otwórz").Click += TrayOpenLauncher;
            LauncherTray.ContextMenuStrip.Items.Add("Biblioteka gier").Click += TrayGames;
            LauncherTray.ContextMenuStrip.Items.Add("Znajomi").Click += TrayFriends;
            LauncherTray.ContextMenuStrip.Items.Add("Zgłoś błąd").Click += TrayReport;
            LauncherTray.ContextMenuStrip.Items.Add("Wyloguj się").Click += TrayLogout;
            LauncherTray.ContextMenuStrip.Items.Add("Wyjdź").Click += TrayQuit;
            LauncherTray.Visible = true;
            Program.StopSplashScreen();
        }

        private void TrayLogout(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TrayReport(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TrayFriends(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TrayGames(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TrayOpenLauncher(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void TrayQuit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Dispose();
        }
        private void LauncherTray_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            LauncherTray.ContextMenuStrip.Items[0].Enabled = false;
        }

        private void LauncherForm_Resize(object sender, EventArgs e)
        {
            if (WindowState.Equals(FormWindowState.Minimized))
            {
                Hide();
                LauncherTray.ContextMenuStrip.Items[0].Enabled = true;
            }
        }
    }
}
