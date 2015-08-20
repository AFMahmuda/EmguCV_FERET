using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERET_Login
{
    public partial class LoginForm : Form
    {

        private RegisterForm registerForm { set; get; }
        public LoginForm()
        {
            InitializeComponent();
        }



        private void textBoxUsername_Validating(object sender, EventArgs e)
        {
            textBoxUsername.CharacterCasing = CharacterCasing.Lower;
            if (textBoxUsername.ForeColor == Color.Black)
                return;
            else
            {
                textBoxUsername.Text = "";
                textBoxUsername.ForeColor = Color.Black;
            }
        }


        private void textBoxPassword_Validating(object sender, EventArgs e)
        {
            textBoxPassword.PasswordChar = '*';
            if (textBoxPassword.ForeColor == Color.Black)
                return;
            else
            {
                textBoxPassword.Text = "";
                textBoxPassword.ForeColor = Color.Black;
            }


        }

        private void textBoxPassword_Validate(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPassword.Text))
                errorProvider.SetError(textBoxPassword, "Password required!");
            else if (!Regex.IsMatch(textBoxPassword.Text, @"[A-Za-z][A-Za-z0-9]{4,10}"))
                errorProvider.SetError(textBoxPassword, "Password invalid!");
            else
                errorProvider.SetError(textBoxPassword, null);
        }

        private void textBoxUsername_Validate(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUsername.Text))
                errorProvider.SetError(textBoxUsername, "Username required!");
            else if (!Regex.IsMatch(textBoxUsername.Text, @"[a-z][a-z0-9]{4,10}"))
                errorProvider.SetError(textBoxUsername, "Username invalid!");
            else
                errorProvider.SetError(textBoxUsername, null);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(RunMainForm));
            thread.Start();
            this.Close();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            registerForm = new RegisterForm();
            registerForm.loginForm = this;
            registerForm.Show();
            this.Hide();
        }


        private void RunMainForm()
        {
            Application.Run(new MainForm());
        }
    }
}
