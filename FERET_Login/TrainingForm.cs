using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERET_Login
{
    public partial class TrainingForm : Form
    {
        public Capture capture;


        public TrainingForm()
        {
            InitializeComponent();
        }

        public TrainingForm(String name)
        {
            InitializeComponent();
            labelInstruction.Text = "We will now capture a few images \nof your faces";
            Thread.Sleep(2000);
        }

        private void FirstTimeTrainingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
