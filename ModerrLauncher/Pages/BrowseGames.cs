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
    public partial class BrowseGames : Form
    {
        public BrowseGames()
        {
            InitializeComponent();
            AddGame(new NewGameButton());
            AddGame(new NewGameButton());
            AddGame(new NewGameButton());
        }
        // gamesPanel

        private void AddGame(NewGameButton btn)
        {
            gamesPanel.Controls.Add(btn);
            gamesPanel.Tag = btn;
            btn.BringToFront();
            btn.Show();
        }
    }
}
