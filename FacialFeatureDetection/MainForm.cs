using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FaceRecognitionProject
{
    public partial class MainForm : Form
    {
        public Capture capture;
        public String classifierFile = String.Empty;

        private ObjectDetector objectDetector;
        private DispatcherTimer timer;

        public MainForm()
        {
            InitializeComponent();
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            List<Rectangle> objects = new List<Rectangle>();
            Image<Bgr, Byte> currentFrame;

            //Get Current Frame            
            currentFrame = capture.QueryFrame();
            Image<Gray, byte> grayFrame = currentFrame.Convert<Gray, byte>();

            //detect object
            if (!classifierFile.Equals(String.Empty))
                objectDetector.Detect(grayFrame, objects);

            //Draw Box Around Face
            foreach (var box in objects)
                currentFrame.Draw(box, new Bgr(Color.Blue), 2);

            //Display current frame
            imageBoxCameraMain.Image = currentFrame;
        }



        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                capture = new Capture();
                capture.FlipHorizontal = true;

                timer = new DispatcherTimer();
                //Event for processing each frame in 20 ms interval
                timer.Tick += ProcessFrame;
                timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
                timer.Start();

                capture.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
        }


        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (capture != null)
            {
                timer.Stop();
                imageBoxCameraMain.Image = null;
                capture.Dispose();
            }
            buttonStop.Enabled = false;
            buttonStart.Enabled = true;
        }

        private void buttonLoadClassifier_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                classifierFile = openFileDialog.FileName;
                labelClassifier.Text = openFileDialog.SafeFileName;
                objectDetector = new ObjectDetector(classifierFile);
            }
        }
    }
}
