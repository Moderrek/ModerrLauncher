using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MLCore
{
    public partial class NewGameButton : UserControl
    {
        public string gameId;
        public NewGameButton(Image background)
        {
            InitializeComponent();
            this.BackgroundImage = background;
        }
        public NewGameButton()
        {
            InitializeComponent();
        }
    }
}
