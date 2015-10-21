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
    public partial class RegisterForm : Form
    {

        private String username = String.Empty;
        private String password = String.Empty;

        private bool _status;
        private bool Status
        {
            get
            {
                _status = (!username.Equals(String.Empty) && !password.Equals(String.Empty)) ? true : false;
                return _status;
            }
            set
            {
                _status = value;
            }
        }


        public RegisterForm()
        {
            InitializeComponent();
        }

        public RegisterForm(String _username, String _password)
        {
            InitializeComponent();

            buttonRegister.Enabled = false;

            textBoxUsername.ForeColor = Color.Black;
            textBoxUsername.Text = _username;

            textBoxPassword.ForeColor = Color.Black;
            textBoxPassword.Text = _password;
        }



        private void textBoxUsername_Enter(object sender, EventArgs e)
        {
            textBoxUsername.CharacterCasing = CharacterCasing.Lower;
            if (textBoxUsername.ForeColor == Color.Black)
                return;
            else
            {
                textBoxUsername.Text = String.Empty;
                textBoxUsername.ForeColor = Color.Black;
            }
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            TextBox a = sender as TextBox;
            if (a.ForeColor == Color.Black)
                return;
            else
            {
                a.PasswordChar = '*';
                a.Text = String.Empty;
                a.ForeColor = Color.Black;
            }

        }


        private void textBoxUsername_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxUsername.Text))
            {
                buttonRegister.Enabled = false;
                errorProvider.SetError(textBoxUsername, "Username required!");
                username = String.Empty;
            }
            else if (!Regex.IsMatch(textBoxUsername.Text, @"[a-z][a-z0-9]{4,10}"))
            {
                errorProvider.SetError(textBoxUsername, "Username invalid!");
                username = String.Empty;
            }

            else
            {
                errorProvider.SetError(textBoxUsername, null);
                username = textBoxUsername.Text;
            }


        }

        private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxPassword.Text))
            {
                buttonRegister.Enabled = false;
                errorProvider.SetError(textBoxPassword, "Password required!");
                password = String.Empty;
            }
            else
            {
                errorProvider.SetError(textBoxPassword2, null);
            }

        }

        private void textBoxPassword2_Validating(object sender, CancelEventArgs e)
        {
            if (!textBoxPassword2.Text.Equals(textBoxPassword.Text))
            {
                buttonRegister.Enabled = false;
                errorProvider.SetError(textBoxPassword2, "password didn't match previous entry");
                password = String.Empty;
            }
            else
            {
                errorProvider.SetError(textBoxPassword2, null);
                //                password = String.Copy(textBoxPassword2.Text);
                password = textBoxPassword2.Text;
            }
        }


        private void buttonRegister_Click(object sender, EventArgs e)
        {

            switch (Authorization.Register(textBoxUsername.Text, textBoxPassword.Text))
            {
                case 0:
                    Thread thread = new Thread(new ThreadStart(RunTrainingForm));
                    thread.Start();
                    this.Close();
                    break;
                default:

                    break;
            }


        }

        private void RunTrainingForm()
        {
            Application.Run(new TrainingForm(username));
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(RunLoginForm));
            thread.Start();
            this.Close();
        }

        private void RunLoginForm()
        {
            Application.Run(new LoginForm());
        }

        private void CheckStatus(object sender, EventArgs e)
        {
            if (Status)
                buttonRegister.Enabled = true;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
