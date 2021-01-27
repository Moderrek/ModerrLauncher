using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MLCore;

namespace ModerrLauncher
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            button1.Enabled = false;
            buttonCreateAccount.Enabled = false;
        }

        private void textBoxLogin_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBoxLogin.Text) && !string.IsNullOrWhiteSpace(textBoxPassword.Text);
        }
        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBoxLogin.Text) && !string.IsNullOrWhiteSpace(textBoxPassword.Text);
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            string login = textBoxLogin.Text;
            textBoxLogin.Text = "";
            string password = textBoxPassword.Text;
            textBoxPassword.Text = "";
            bool remember = checkBoxRemeberMe.Checked;
            checkBoxRemeberMe.Checked = false;
            //MLBox.Show("Logowanie", $"Login: {login}\nPass: {password}\nRemember me: {remember}");
            Program.LogInAsync(login, password, remember);
        }

        #region ButtonQuit
        private void buttonQuit_MouseHover(object sender, EventArgs e)
        {
            buttonQuit.BackColor = Color.LightCoral;
        }
        private void buttonQuit_MouseLeave(object sender, EventArgs e)
        {
            buttonQuit.BackColor = Color.FromArgb(40, 40, 40);
        }
        private void buttonQuit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        #endregion

        private async void buttonRegister_Click(object sender, EventArgs e)
        {
            buttonCreateAccount.Enabled = false;
            string name = textBoxRegisterName.Text;
            textBoxRegisterName.Text = "";
            string email = textBoxRegisterEmail.Text;
            textBoxRegisterEmail.Text = "";
            string password = textBoxRegisterPassword.Text;
            textBoxRegisterPassword.Text = "";
            Regex reg = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            if (!reg.IsMatch(email))
            {
                MLBox.Show("Wystąpił problem podczas rejestrowania", "Podany email jest nieprawidłowy!");
                return;
            }
            bool canCreate;
            try
            {
                canCreate = await Program.CheckExistsAsync(name, email);
            }
            catch(Exception exception)
            {
                MLBox.Show("Wystąpił problem", exception.Message);
                return;
            }
            if (canCreate)
            {
                Program.CreateAccount(name, email, password);
                panelRegister.Visible = false;
                panelLogIn.Visible = true;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            panelLogIn.Visible = false;
            panelRegister.Visible = true;
        }

        private void textBoxRegisterName_TextChanged(object sender, EventArgs e)
        {
            buttonCreateAccount.Enabled = !string.IsNullOrWhiteSpace(textBoxRegisterName.Text) && !string.IsNullOrWhiteSpace(textBoxRegisterEmail.Text) && !string.IsNullOrWhiteSpace(textBoxRegisterPassword.Text);
        }

        private void textBoxRegisterEmail_TextChanged(object sender, EventArgs e)
        {
            buttonCreateAccount.Enabled = !string.IsNullOrWhiteSpace(textBoxRegisterName.Text) && !string.IsNullOrWhiteSpace(textBoxRegisterEmail.Text) && !string.IsNullOrWhiteSpace(textBoxRegisterPassword.Text);
        }

        private void textBoxRegisterPassword_TextChanged(object sender, EventArgs e)
        {
            buttonCreateAccount.Enabled = !string.IsNullOrWhiteSpace(textBoxRegisterName.Text) && !string.IsNullOrWhiteSpace(textBoxRegisterEmail.Text) && !string.IsNullOrWhiteSpace(textBoxRegisterPassword.Text);
        }
    }
}
