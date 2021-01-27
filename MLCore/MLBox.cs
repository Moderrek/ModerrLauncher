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
    public partial class MLBoxForm : Form
    {
        public MLBoxForm(string title, string description, string btnName = "Okej")
        {
            InitializeComponent();
            this.Text = title;
            this.labelTitle.Text = title;
            this.labelDescription.Text = description;
            this.btn.Text = btnName;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }

    public class MLBox
    {
        public static void Show(string title, string description)
        {
            MLBoxForm box = new MLBoxForm(title, description);
            box.ShowDialog();
        }
    }
}
