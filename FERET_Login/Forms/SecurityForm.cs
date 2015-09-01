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
    public partial class SecurityForm : Form
    {

        private Capture capture;

        private String status = String.Empty;

        private DispatcherTimer timer;


        private String username;
        private String detected;
        public Rectangle facePos { set; get; }

        private String faceClassifier = Application.StartupPath + "\\Classifier\\haarcascade_frontalface_default.xml";
        private String eyePairClassifier = Application.StartupPath + "\\Classifier\\haarcascade_mcs_eyepair_big.xml";
        private String eyeClassifier = Application.StartupPath + "\\Classifier\\haarcascade_eye_tree_eyeglasses.xml";


        public SecurityForm()
        {

            InitializeComponent();

            username = Authorization.username;

            capture = new Capture();
            CameraCapture.Init(capture);
            BlinkDetector.Init(new CascadeClassifier(eyePairClassifier), new CascadeClassifier(eyeClassifier));
            FaceDetection.Init(new CascadeClassifier(faceClassifier));
            SecurityStateManager.Clear();
            BlinkStateManager.Clear();

            labelInstruction.Text = "We will now capture a few images \nof your face";

            CameraCapture.Start();

            timer = new DispatcherTimer();
            timer.Tick += ProcessSecurityFrame;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();

        }

        private void ProcessSecurityFrame(object sender, EventArgs e)
        {

            //Get Current Frame            
            Image<Bgr, byte> currentFrame = capture.QueryFrame();
            Image<Gray, byte> grayFrame = currentFrame.Convert<Gray, byte>();

            facePos = FaceDetection.Detect(grayFrame);
            SecurityStateManager.AddToHistory(grayFrame.Copy(), facePos);
            PrintInstruction();


            if (!facePos.Equals(Rectangle.Empty))
            {
                BlinkStateManager.faceDetected = true;
                Image<Gray, byte> faceImage = grayFrame.Copy(facePos);

                detected = FaceRecognition.Recognize(faceImage);

                SecurityStateManager.AddToHistory(username.Equals(detected));

                checkBlink(faceImage);

            }

            imageBox.Image = currentFrame;
        }

        private void checkBlink(Image<Gray, byte> faceImage)
        {
            printInformation();
            BlinkDetector.Detect(faceImage);
            if (BlinkStateManager.LastAction.Equals(BlinkStateManager.LAST_ACTION.BLINK))
            {
                if (username.Equals(detected))
                {

                    Thread thread = new Thread(new ThreadStart(RunMainForm));
                    thread.Start();
                    this.Close();
                }
            }
            return;
        }

        private void PrintInstruction()
        {
            String instruction = "";
            switch (SecurityStateManager.State)
            {
                case SecurityStateManager.STATE.IDLE:
                    instruction = "Idle";
                    break;
                case SecurityStateManager.STATE.NOT_DETECTED:
                    instruction = "Face NOT detected!";
                    BlinkStateManager.Clear();
                    break;
                case SecurityStateManager.STATE.NOT_MATCH:
                    MessageBox.Show("Face doesn't match : " + username);
                    Thread thread = new Thread(new ThreadStart(RunLoginForm));
                    thread.Start();
                    this.Close();
                    break;
                case SecurityStateManager.STATE.READY:
                    if (BlinkStateManager.IsReady)
                        instruction = "Ready! Please BLINK your eyes.";
                    else
                        instruction = "Looking for facial feature...";
                    break;
                case SecurityStateManager.STATE.FACE_NOT_STABLE:
                    instruction = "Please stay still.";
                    BlinkStateManager.Clear();
                    break;
                case SecurityStateManager.STATE.TOO_DARK:
                    instruction = "Too dark.";
                    BlinkStateManager.Clear();
                    break;
                case SecurityStateManager.STATE.TOO_BRIGHT:
                    instruction = "Too bright.";
                    BlinkStateManager.Clear();
                    break;
                case SecurityStateManager.STATE.TOO_FAR:
                    instruction = "Face too far.";
                    BlinkStateManager.Clear();
                    break;
                case SecurityStateManager.STATE.TOO_CLOSE:
                    instruction = "Face too close.";
                    break;
                default:
                    break;
            }
            labelInstruction.Text = instruction;

            return;
        }


        private void RunLoginForm()
        {
            CameraCapture.Stop();
            Application.Run(new LoginForm());
        }


        private void RunMainForm()
        {
            CameraCapture.Stop();
            Application.Run(new MainForm());
        }

        private void SecurityForm_Load(object sender, EventArgs e)
        {
            if (!FaceRecognition.Retrain())
                MessageBox.Show("Not trained");
        }

        private void printInformation()
        {
            labelActionData.Text = BlinkStateManager.LastAction.ToString();
            labelStateData.Text = BlinkStateManager.State.ToString();
            
            labelStateHistory.Text = "";
            foreach (var item in BlinkStateManager.StateHistory)
                labelStateHistory.Text += item + "\n";
            
            labelResult.Text = "username :" + username + "\ndetected :" + detected;
        }


    }
}
