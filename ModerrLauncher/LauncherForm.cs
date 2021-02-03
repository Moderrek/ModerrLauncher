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
            LoadUser();
            Program.checkConfig();
            pages = new Dictionary<Button, Form>
            {
                { buttonHome, new Pages.MainPage() },
                { buttonSearchGames, new Pages.BrowseGames() },
                { buttonSettings, new Pages.Settings() },
                { buttonDevour, new Pages.GameButton("Devour") }
            };
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
        }

        public async void LoadUser()
        {
            userNameLabel.Text = await Program.getName(Program.token);
        }

        #region Tray
        private void TrayLogout(object sender, EventArgs e)
        {
            Program.Logout();
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

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                LauncherTray.ContextMenuStrip.Items[0].Enabled = true;
            }
        }
        #endregion
        #region Pages
        public Dictionary<Button, Form> pages;
        public Form activePage = null;
        public Button activeButton = null;
        private void OpenPage(Button btn)
        {
            Form page;
            if (!pages.ContainsKey(btn))
            {
                childPanel.Controls.Remove(activePage);
                return;
            }
            page = pages[btn];
            if(activePage != null)
            {
                if(activePage.Name.Equals(page.Name))
                {
                    return;
                }
                childPanel.Controls.Remove(activePage);
            }
            ActivateButton(btn);
            activePage = page;
            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;
            childPanel.Controls.Add(page);
            childPanel.Tag = page;
            page.BringToFront();
            page.Show();
        }
        private void DisableButtons()
        {
            foreach (Control previousBtn in panelSidebar.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(25, 25, 25);
                    //previousBtn.ForeColor = Color.FromArgb(0, 126, 249);
                }
            }
        }
        private void ActivateButton(Button btnSender)
        {
            if (btnSender != null)
            {
                if (activeButton != btnSender)
                {
                    DisableButtons();
                    var color = Color.FromArgb(40, 40, 40);
                    activeButton = btnSender;
                    activeButton.BackColor = color;
                    //activeButton.ForeColor = Color.White;
                }
            }
        }
        #endregion

        private void btnClick(object sender, EventArgs e)
        {
            OpenPage((Button)sender);
        }
    }
}
