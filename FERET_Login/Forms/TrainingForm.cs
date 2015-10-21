using Emgu.CV;
using Emgu.CV.Structure;
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
using System.Windows.Threading;

namespace FERET_Login
{
    public partial class TrainingForm : Form
    {
        private Capture capture;

        private DispatcherTimer timer;

        private String name;
        private int photoCounter;

        //classifier used in blink detection
        private String faceClassifier = Application.StartupPath + "\\Classifier\\haarcascade_frontalface_default.xml";
        private String eyePairClassifier = Application.StartupPath + "\\Classifier\\haarcascade_mcs_eyepair_big.xml";
        private String eyeClassifier = Application.StartupPath + "\\Classifier\\haarcascade_eye_tree_eyeglasses.xml";

        public TrainingForm()
        {
            InitializeComponent();
        }

        public TrainingForm(String _name)
        {

            InitializeComponent();

            name = _name;

            photoCounter = 3;

            capture = new Capture();
            CameraCapture.Init(capture);
            BlinkDetector.Init(new CascadeClassifier(eyePairClassifier), new CascadeClassifier(eyeClassifier));
            FaceDetection.Init(new CascadeClassifier(faceClassifier));
            TrainingStateManager.Clear();
            BlinkStateManager.Clear();

            labelInstruction.Text = "We will now capture a few images \nof your face";
            labelRemaining.Text = photoCounter + " more capture to finish";
            buttonFinish.Enabled = false;
            CameraCapture.Start();

            timer = new DispatcherTimer();
            timer.Tick += ProcessTrainFrame;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            timer.Start();

        }


        private void ProcessTrainFrame(object sender, EventArgs e)
        {

            //Get Current Frame            
            Mat currentFrame = capture.QueryFrame();
            Image<Gray, byte> grayFrame = currentFrame.ToImage<Gray, byte>();

            Rectangle facePos = FaceDetection.Detect(grayFrame);

            TrainingStateManager.AddToHistory(grayFrame.Copy(), facePos);

            PrintInstruction();


            if (!facePos.Equals(Rectangle.Empty))
            {
                BlinkStateManager.faceDetected = true;
                Image<Gray, byte> faceImage = grayFrame.Copy(facePos);

                CheckBlink(faceImage);
            }

            imageBox.Image = currentFrame;
        }

        private void CheckBlink(Image<Gray, byte> faceImage)
        {
            //print method for debugging purpose
            PrintBlinkInformations();
            BlinkDetector.Detect(faceImage);
            if (BlinkStateManager.LastAction.Equals(BlinkStateManager.LAST_ACTION.BLINK))
            {
                if (FaceRecognition.SaveTrainingData(faceImage, name))
                {
                    BlinkStateManager.Clear();
                    photoCounter--;

                    if (photoCounter <= 0)
                    {
                        buttonFinish.Enabled = true;
                        photoCounter = 0; 
                    }                        
                }
            }
            return;
        }


        private void PrintInstruction()
        {
            labelRemaining.Text = photoCounter + " more capture to finish";
            String instruction = "";
            switch (TrainingStateManager.State)
            {
                case TrainingStateManager.STATE.IDLE:
                    instruction = "Idle";
                    break;
                case TrainingStateManager.STATE.NOT_DETECTED:
                    instruction = "Face NOT detected!";
                    BlinkStateManager.Clear();
                    break;
                case TrainingStateManager.STATE.READY:
                    if (BlinkStateManager.IsReady)
                        instruction = "Ready! Please BLINK your eyes.";
                    else
                        instruction = "Looking for facial feature...";
                    break;
                case TrainingStateManager.STATE.FACE_NOT_STABLE:
                    instruction = "Please stay still.";
                    BlinkStateManager.Clear();
                    break;
                case TrainingStateManager.STATE.TOO_DARK:
                    instruction = "Too dark.";
                    BlinkStateManager.Clear();
                    break;
                case TrainingStateManager.STATE.TOO_BRIGHT:
                    instruction = "Too bright.";
                    BlinkStateManager.Clear();
                    break;
                case TrainingStateManager.STATE.TOO_FAR:
                    instruction = "Face too far.";
                    break;
                case TrainingStateManager.STATE.TOO_CLOSE:
                    instruction = "Face too close.";
                    break;
                default:
                    break;
            }
            labelInstruction.Text = instruction;
            return;
        }

        private void PrintBlinkInformations()
        {
            labelActionData.Text = BlinkStateManager.LastAction.ToString();
            labelStateData.Text = BlinkStateManager.State.ToString();
            labelStateHistory.Text = "";
            foreach (var item in BlinkStateManager.StateHistory)
            {
                labelStateHistory.Text += item + "\n";
            }
            return;
        }

        private void TrainingForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            CameraCapture.Stop();
            Thread thread = new Thread(new ThreadStart(RunLoginForm));
            thread.Start();
            this.Close();

        }

        private void RunLoginForm()
        {
            Application.Run(new LoginForm());
        }







    }
}
