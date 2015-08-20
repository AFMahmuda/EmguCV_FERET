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

namespace FERET_Login
{
    public partial class RegisterForm : Form
    {
        public LoginForm loginForm {get;set;}
        private Authorization auth {set;get;}

        public RegisterForm()
        {
            InitializeComponent();
            buttonRegister.Enabled = false;
        }

        private void textBoxFullName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxFullName.Text))
                buttonRegister.Enabled = false;
        }   

        private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxEmail.Text))
                buttonRegister.Enabled = false;
        }

        private void textBoxUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxUsername.Text))
                buttonRegister.Enabled = false;
        }

        private void textBoxPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPassword.Text))
                buttonRegister.Enabled = false;
        }

        private void textBoxPassword2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPassword2.Text))
                buttonRegister.Enabled = false;
        }

        private void radioButtonGenreF_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonGenreM_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register();
            loginForm.Show();
            this.Close();
        }

        private void Register()
        {
            throw new NotImplementedException();
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }


    }
}
