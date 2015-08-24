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


        private String name;
        public Rectangle facePos { set; get; }

        private String faceClassifier = Application.StartupPath + "\\Classifier\\haarcascade_frontalface_default.xml";
        private String eyePairClassifier = Application.StartupPath + "\\Classifier\\haarcascade_mcs_eyepair_big.xml";
        private String eyeClassifier = Application.StartupPath + "\\Classifier\\haarcascade_eye_tree_eyeglasses.xml";

        private int pauseBlinkDetectionFlag;

        public SecurityForm()
        {

            InitializeComponent();

            name = Authorization.username;




            capture = new Capture();
            CameraCapture.Init(capture);
            BlinkDetector.Init(new CascadeClassifier(eyePairClassifier), new CascadeClassifier(eyeClassifier));
            FaceDetection.Init(new CascadeClassifier(faceClassifier));



            labelInstruction.Text = "We will now capture a few images \nof your face";
            CameraCapture.Start();

            timer = new DispatcherTimer();
            timer.Tick += ProcessTrainFrame;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
            timer.Start();

        }

        private void ProcessTrainFrame(object sender, EventArgs e)
        {



            //Get Current Frame            
            Image<Bgr, byte> currentFrame = capture.QueryFrame();
            Image<Gray, byte> grayFrame = currentFrame.Convert<Gray, byte>();



            facePos = FaceDetection.Detect(grayFrame);

            if (!facePos.Equals(Rectangle.Empty))
            {
                BlinkStateManager.faceDetected = true;
                Image<Gray, byte> faceImage = grayFrame.Copy(facePos);
                BlinkDetector.Detect(faceImage);

                labelActionData.Text = BlinkStateManager.LastAction.ToString();
                labelStateData.Text = BlinkStateManager.State.ToString();
                labelStateHistory.Text = "";
                foreach (var item in BlinkStateManager.StateHistory)
                {
                    labelStateHistory.Text += item + "\n";
                }
                String result= FaceRecognition.Recognize(faceImage); 
                label2.Text = result;
                if (pauseBlinkDetectionFlag > 0) pauseBlinkDetectionFlag--;
                if (BlinkStateManager.LastAction.Equals(BlinkStateManager.LAST_ACTION.BLINK) && pauseBlinkDetectionFlag == 0)
                {
                    if (name.Equals(result))
                    {
                        Thread thread = new Thread(new ThreadStart(RunMainForm));
                        thread.Start();
                        this.Close();       
                    }
                    pauseBlinkDetectionFlag = 10;
                }

            }
            imageBox.Image = currentFrame;
        }

        private void RunMainForm()
        {
            Application.Run(new MainForm());
        }


        private void SecurityForm_Load(object sender, EventArgs e)
        {
            FaceRecognition.Retrain();
        }
    }
}
