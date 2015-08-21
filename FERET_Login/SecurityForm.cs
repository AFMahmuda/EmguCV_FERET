using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FERET_Login
{
    public partial class SecurityForm : Form
    {

        private Capture capture;
        private CameraCapture camera;
        private FaceDetector faceDetector;
        private BlinkDetector blinkDetector;
        private FaceRecognition recognizer;
        private BlinkStateManager blinkStateManager;
        private TrainSecurityStateManager securityStateManager;

        private String status = String.Empty;

        private DispatcherTimer timer;


        private String name;
        public Rectangle facePos { set; get; }

        private String faceClassifier = Application.StartupPath + "\\Classifier\\haarcascade_frontalface_default.xml";
        private String eyePairClassifier = Application.StartupPath + "\\Classifier\\haarcascade_mcs_eyepair_big.xml";
        private String eyeClassifier = Application.StartupPath + "\\Classifier\\haarcascade_eye_tree_eyeglasses.xml";

        private int pauseBlinkDetectionFlag;

        public SecurityForm(String _name)
        {

            InitializeComponent();

            name = _name;



            capture = new Capture();
            camera = new CameraCapture(capture);

            blinkStateManager = new BlinkStateManager();
            securityStateManager = new TrainSecurityStateManager();

            faceDetector = new FaceDetector(new CascadeClassifier(faceClassifier));
            blinkDetector = new BlinkDetector(blinkStateManager, new CascadeClassifier(eyePairClassifier), new CascadeClassifier(eyeClassifier));

            recognizer = new FaceRecognition(new EigenFaceRecognizer(80, double.PositiveInfinity));


            labelInstruction.Text = "We will now capture a few images \nof your face";
            camera.Start();

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



            facePos = faceDetector.Detect(grayFrame);

            if (!facePos.Equals(Rectangle.Empty))
            {
                blinkStateManager.faceDetected = true;
                Image<Gray, byte> faceImage = grayFrame.Copy(facePos);
                blinkDetector.Detect(faceImage);

                labelActionData.Text = blinkStateManager.LastAction.ToString();
                labelStateData.Text = blinkStateManager.State.ToString();
                labelStateHistory.Text = "";
                foreach (var item in blinkStateManager.StateHistory)
                {
                    labelStateHistory.Text += item + "\n";
                }
                String result= recognizer.Recognize(faceImage);
                label2.Text = result;
                if (pauseBlinkDetectionFlag > 0) pauseBlinkDetectionFlag--;
                if (blinkStateManager.LastAction.Equals(BlinkStateManager.LAST_ACTION.BLINK) && pauseBlinkDetectionFlag == 0)
                {
                    if(name == result)
                        MessageBox.Show(name + result);
                    pauseBlinkDetectionFlag = 10;
                }

            }



            imageBox.Image = currentFrame;
        }





        private void SecurityForm_Load(object sender, EventArgs e)
        {

        }
    }
}
