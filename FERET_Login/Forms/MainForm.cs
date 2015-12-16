using System;
using System.Threading;
using System.Windows.Forms;

namespace FERET_Login
{
    public partial class MainForm : Form
    {
        private String username;
        public MainForm()
        {
            InitializeComponent();
            username = Authorization.username;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            labelWelcome.Text = "Welcome " + username;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            if (Authorization.Logout())
            {
                Thread thread = new Thread(new ThreadStart(RunLoginForm));
                thread.Start();
                this.Close();
            }
            

        }

        private void RunLoginForm()
        {
            Application.Run(new LoginForm());
        }

    }
}
