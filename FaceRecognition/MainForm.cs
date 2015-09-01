using Emgu.CV;
using System;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FaceRecognitionProject
{
    public partial class MainForm : Form
    {
        private DispatcherTimer timer;


        public MainForm()
        {
            InitializeComponent();
            CameraCapture.ImageBoxOutput = imageBoxCameraMain;
            CameraCapture.Count = 0;
            FaceRecognition.Init(Application.StartupPath + "\\TrainedFaces");
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }


        private void buttonStart_Click(object sender, EventArgs e)
        {

            CameraCapture.StartMainCam();
            timer = new DispatcherTimer();
            timer.Tick += ShowInformation;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }


        private void buttonStop_Click(object sender, EventArgs e)
        {
            CameraCapture.StopCam();
            if (timer != null)
                timer.Stop();
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
        }
        private void ShowInformation(object sender, EventArgs e)
        {
            labelDetected.Text = "Detected " + CameraCapture.Count;
            labelDescription.Text = "Desc " + CameraCapture.Description;           
        }


        private void buttonCapture_Click(object sender, EventArgs e)
        {
            CameraCapture.Train(textBoxName.Text);
        }


        private void MainTabSelected()
        {
            CameraCapture.StopCam();
            CameraCapture.ImageBoxOutput = imageBoxCameraMain;           
            CameraCapture.StartMainCam();
            timer = new DispatcherTimer();
            timer.Tick += ShowInformation;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }


        private void TrainTabSelected()
        {
            CameraCapture.StopCam();
            CameraCapture.ImageBoxOutput = imageBoxCameraTrain;
            CameraCapture.StartTrainCam();
            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }



        private void ChangeTab(object sender, EventArgs e)
        {
            switch (TabControl1.SelectedIndex)
            {
                case 0:
                    MainTabSelected();
                    break;
                case 1:
                    TrainTabSelected();
                    break;
            }
        }
    }
}
