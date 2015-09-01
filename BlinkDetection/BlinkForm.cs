using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Threading;

namespace BlinkDetection
{
    public partial class BlinkForm : Form
    {
        private Capture capture;
        private Image<Bgr, Byte> currentFrame;

        private CascadeClassifier faceClassifier;
        private CascadeClassifier eyeClassifier;
        private CascadeClassifier eyePairClassifier;

        private Rectangle detectedFace = Rectangle.Empty;
        private Rectangle detectedLeftEye = Rectangle.Empty;
        private Rectangle detectedRightEye = Rectangle.Empty;
        private Rectangle detectedPairEyes = Rectangle.Empty;
       
        private DispatcherTimer timer;

        private int stateHistoryLimit = 9;

        private bool _isReady;
        private bool IsReady
        {
            set { _isReady = value; }
            get
            {
                int sum = 0;
                foreach (var item in StateHistory)
                {
                    if (item.Equals(STATE.READY))
                        sum++;
                }

                if (sum == stateHistoryLimit && LastAction.Equals(LAST_ACTION.NONE))
                    _isReady = true;
                else _isReady = false;
                return _isReady;
            }
        }

        public enum STATE
        {
            IDLE, LOOKING_FACE, LOOKING_BOTH_EYES, LOOKING_LEFT_EYE, LOOKING_RIGHT_EYE, READY
        }

        public enum LAST_ACTION
        {
            NONE, BLINK, WINK_LEFT, WINK_RIGHT
        }

        private STATE _state;
        public STATE State
        {
            set
            {
                _state = value;
            }
            get
            {
                STATE temp = _state;
                if (detectedFace.IsEmpty)
                    _state = STATE.LOOKING_FACE;
                else if (detectedLeftEye.IsEmpty && detectedRightEye.IsEmpty)
                    _state = STATE.LOOKING_BOTH_EYES;
                else if (detectedLeftEye.IsEmpty)
                    _state = STATE.LOOKING_LEFT_EYE;
                else if (detectedRightEye.IsEmpty)
                    _state = STATE.LOOKING_RIGHT_EYE;
                else
                    _state = STATE.READY;
                if (StateHistory.Count == stateHistoryLimit)
                    StateHistory.RemoveAt(0);
                StateHistory.Add(_state);
                return _state;
            }

        }
        private List<STATE> StateHistory = new List<STATE>();
        private LAST_ACTION _lastAction;
        public LAST_ACTION LastAction
        {
            set
            {
                _lastAction = value;
            }
            get
            {
                if (StateHistory.Count < stateHistoryLimit)
                    return _lastAction;
                STATE firstState, secondState, thirdState;
                firstState = secondState = thirdState = STATE.IDLE;
                int ready = 0, closedAll = 0, closedLeft = 0, closedRight = 0;
                for (int i = 0; i < stateHistoryLimit / 3; i++)
                {
                    if (StateHistory[i].Equals(STATE.READY))
                        ready++;
                    if (ready >= stateHistoryLimit / 6)
                        firstState = STATE.READY;
                }

                for (int i = stateHistoryLimit / 3; i < stateHistoryLimit * 2 / 3; i++)
                {
                    if (StateHistory[i] == STATE.LOOKING_BOTH_EYES)
                        closedAll++;
                    else if (StateHistory[i] == STATE.LOOKING_LEFT_EYE)
                        closedLeft++;
                    else if (StateHistory[i] == STATE.LOOKING_RIGHT_EYE)
                        closedRight++;

                    if (closedAll > stateHistoryLimit / 6)
                        secondState = STATE.LOOKING_BOTH_EYES;
                    else if (closedLeft > stateHistoryLimit / 6)
                        secondState = STATE.LOOKING_LEFT_EYE;
                    else if (closedRight > stateHistoryLimit / 6)
                        secondState = STATE.LOOKING_RIGHT_EYE;
                }

                ready = 0;
                for (int i = stateHistoryLimit * 2 / 3; i < stateHistoryLimit; i++)
                {
                    if (StateHistory[i] == STATE.READY)
                        ready++;
                    if (ready > stateHistoryLimit / 6)
                        thirdState = STATE.READY;
                }
                label2.Text =
                    "1# State " + firstState.ToString() + "\n" +
                    "2# State " + secondState.ToString() + "\n" +
                    "3# State " + thirdState.ToString() + "\n";
                if (firstState.Equals(STATE.READY) && thirdState.Equals(STATE.READY))
                {
                    if (secondState.Equals(STATE.LOOKING_BOTH_EYES))
                        _lastAction = LAST_ACTION.BLINK;
                    else if (secondState.Equals(STATE.LOOKING_LEFT_EYE))
                        _lastAction = LAST_ACTION.WINK_LEFT;
                    else if (secondState.Equals(STATE.LOOKING_RIGHT_EYE))
                        _lastAction = LAST_ACTION.WINK_RIGHT;
                    else
                        _lastAction = LAST_ACTION.NONE;
                }
                return _lastAction;
            }
        }


        public BlinkForm()
        {
            InitializeComponent();
            faceClassifier = new CascadeClassifier(Application.StartupPath + "\\Classifier\\haarcascade_frontalface_default.xml");
            eyePairClassifier = new CascadeClassifier(Application.StartupPath + "\\Classifier\\haarcascade_mcs_eyepair_big.xml");
            eyeClassifier = new CascadeClassifier(Application.StartupPath + "\\Classifier\\haarcascade_eye_tree_eyeglasses.xml");
            Detect();
        }


        public void Detect()
        {
            capture = new Capture();
            capture.FlipHorizontal = true;
            capture.Start();

            timer = new DispatcherTimer();
            timer.Tick += ProcessFrame;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timer.Start();

        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            currentFrame = capture.QueryFrame();

            detectedFace = DetectFace(currentFrame);
            if (!detectedFace.IsEmpty)
            {
                labelInformationFace.Text = ": " + detectedFace.Size.ToString() + "\n";
                currentFrame.Draw(detectedFace, new Bgr(Color.Blue), 1);
                detectedPairEyes = DetectEyePair(currentFrame.Copy(detectedFace));

                if (!detectedPairEyes.IsEmpty)
                {
                    detectedPairEyes.Offset(detectedFace.Location);
                    labelInformationEyePair.Text = ": " + detectedPairEyes.Size.ToString() + "\n";
                    currentFrame.Draw(detectedPairEyes, new Bgr(Color.Red), 1);

                    detectedLeftEye = DetectLeftEye(currentFrame.Copy(detectedPairEyes));
                    detectedRightEye = DetectRighEye(currentFrame.Copy(detectedPairEyes));
                    if (!detectedLeftEye.IsEmpty)
                    {
                        detectedLeftEye.Offset(detectedPairEyes.Location);
                        labelInformationEyeLeft.Text = ": " + detectedLeftEye.Size.ToString() + "\n";
                        currentFrame.Draw(detectedLeftEye, new Bgr(Color.Green), 1);
                    }

                    if (!detectedRightEye.IsEmpty)
                    {
                        detectedRightEye.Offset(detectedPairEyes.Location);
                        labelInformationEyeRight.Text = ": " + detectedRightEye.Size.ToString() + "\n";
                        currentFrame.Draw(detectedRightEye, new Bgr(Color.Green), 1);
                    }
                }
                else
                {
                    detectedLeftEye = Rectangle.Empty;
                    detectedRightEye = Rectangle.Empty;
                }
            }
            else
            {
                detectedPairEyes = Rectangle.Empty;
                detectedLeftEye = Rectangle.Empty;
                detectedRightEye = Rectangle.Empty;
            }
            labelStateData.Text = State.ToString();
            labelActionData.Text = LastAction.ToString();
            if (IsReady)
                labelInstruction.Text = "Ready! Blink, or Wink!";
            else if (LastAction.Equals(LAST_ACTION.BLINK))
                labelInstruction.Text = "BLINK Detected!";
            else if (LastAction.Equals(LAST_ACTION.WINK_LEFT) || LastAction.Equals(LAST_ACTION.WINK_RIGHT))
                labelInstruction.Text = "WINK Detected!";
            else
                labelInstruction.Text = "Please Wait ... ";
            ;
            labelStateHistory.Text = "";
            int a = 1;
            foreach (var item in StateHistory)
            {
                labelStateHistory.Text += a++ + " " + item.ToString() + "\n";
            }

            imageBoxCam.Image = currentFrame;
        }

        private Rectangle DetectLeftEye(Image<Bgr, byte> image)
        {
            Image<Gray, byte> gray = image.Convert<Gray, byte>();
            gray = gray.Copy(new Rectangle(0, 0, image.Width / 2, image.Height));
            gray._EqualizeHist();
            Rectangle[] result = eyeClassifier.DetectMultiScale(gray, 1.1, 3, new Size(30, 30), Size.Empty);
            if (result.Length >= 1)
            {
                return result.First();
            }
            else
                return Rectangle.Empty;
        }

        private Rectangle DetectRighEye(Image<Bgr, byte> image)
        {
            Image<Gray, byte> gray = image.Convert<Gray, byte>();
            gray = gray.Copy(new Rectangle(image.Width / 2, 0, image.Width / 2, image.Height));
            gray._EqualizeHist();
            Rectangle[] result = eyeClassifier.DetectMultiScale(gray, 1.1, 3, new Size(30, 30), Size.Empty);


            if (result.Length >= 1)
            {
                Rectangle temp = result.First();
                temp.Offset(image.Width / 2, 0);
                return temp;
            }
            else
                return Rectangle.Empty;
        }

        private Rectangle DetectEyePair(Image<Bgr, byte> image)
        {
            Image<Gray, byte> gray = image.Convert<Gray, byte>();
            gray._EqualizeHist();
            Rectangle[] eyePairs = eyePairClassifier.DetectMultiScale(gray, 1.1, 5, new Size(100, 30), Size.Empty);

            if (eyePairs.Length >= 1)
            {
                Rectangle eyePair = eyePairs.First();
                eyePair.Inflate(0, eyePair.Height / 3);
                eyePair.Offset(0, -eyePair.Height / 16);
                return eyePair;
            }
            else
                return Rectangle.Empty;
        }

        private Rectangle DetectFace(Image<Bgr, byte> image)
        {
            Image<Gray, byte> gray = image.Convert<Gray, byte>();
            gray._EqualizeHist();
            Rectangle[] result = faceClassifier.DetectMultiScale(gray, 1.1, 10, new Size(150, 150), Size.Empty);
            if (result.Length >= 1)
                return result.First();
            else
                return Rectangle.Empty;
        }



        private void Dispose(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            capture.Stop();
            capture.Dispose();
            faceClassifier.Dispose();
            eyePairClassifier.Dispose();
            eyeClassifier.Dispose();
        }

        private void labelInstruction_Click(object sender, EventArgs e)
        {

        }

        private void BlinkForm_Load(object sender, EventArgs e)
        {

        }
    }
}
