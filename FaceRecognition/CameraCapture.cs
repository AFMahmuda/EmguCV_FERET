using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FaceRecognitionProject
{
    public static class CameraCapture
    {
        public static ImageBox ImageBoxOutput { set; get; }
        public static Capture Capture { set; get; }
        private static Image<Bgr, Byte> currentFrame;
        private static String faceClasifier = Application.StartupPath +"\\haarcascade_frontalface_default.xml";
        private static List<Rectangle> detectedFaces = new List<Rectangle>();
        public static int Count { set; get; }
        public static String Description { set; get; }
        private static DispatcherTimer timer;




        public static void StartMainCam()
        {
            if (ImageBoxOutput != null)
            {
                try
                {
                    FaceDetection.Init(faceClasifier);
                    if (!FaceRecognition.IsTrained)
                        MessageBox.Show("Please Train First");
                    else
                        FaceRecognition.Retrain();
                    Capture = new Capture();
                    Capture.FlipHorizontal = true;
                    //Event for processing frame
                    timer = new DispatcherTimer();
                    timer.Tick += ProcessFrame;
                    timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
                    timer.Start();
                    Capture.Start();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static void StartTrainCam()
        {
            if (ImageBoxOutput != null)
            {
                try
                {
                    FaceDetection.Init(faceClasifier);
                    Capture = new Capture();
                    Capture.FlipHorizontal = true;
                    //Event for processing frame
                    timer = new DispatcherTimer();
                    timer.Tick += ProcessTrainFrame;
                    timer.Interval = new TimeSpan(0, 0, 0, 0, 50);
                    timer.Start();
                    Capture.Start();
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }


        public static void StopCam()
        {
            if (ImageBoxOutput != null && Capture != null)
            {
                timer.Stop();
                Capture.Dispose();
                ImageBoxOutput.Image = null;
                Capture = null;
                FaceDetection.Dispose();
            }

        }


        private static void ProcessFrame(object sender, EventArgs e)
        {

            detectedFaces.Clear();
            //Get Current Frame            
            currentFrame = Capture.QueryFrame();
            Image<Gray, byte> grayFrame = currentFrame.Convert<Gray, byte>();

            //Detect Faces in current frame
            FaceDetection.Detect(grayFrame, detectedFaces);

            Description = "";
            String name = "";
            MCvFont font = new MCvFont(FONT.CV_FONT_HERSHEY_TRIPLEX, 0.5d, 0.5d);
            foreach (var box in detectedFaces)
            {
                //Recognize each face
                name = FaceRecognition.Recognize(grayFrame, box, 2000); 

                //Draw box and name Around Face
                currentFrame.Draw(box, new Bgr(Color.Blue), 2);
                currentFrame.Draw(name, ref font, new Point(box.Left+5, box.Bottom-5), new Bgr(Color.Aqua));

               
                Description += name + " ";
            }

            Count = detectedFaces.Count;
            //Display current frame
            Count = detectedFaces.Count;
            ImageBoxOutput.Image = currentFrame;

        }


        private static void ProcessTrainFrame(object sender, EventArgs e)
        {
            detectedFaces.Clear();
            //Get Current Frame            
            currentFrame = Capture.QueryFrame();
            Image<Gray, byte> grayFrame = currentFrame.Convert<Gray, byte>();

            //Detect Faces in current frame
            FaceDetection.Detect(grayFrame, detectedFaces);

            //Can only Train if there is only one face detected
            if (detectedFaces.Count == 1)
            {
                currentFrame.Draw(detectedFaces[0], new Bgr(Color.Green), 2);
            }

            else
                detectedFaces.Clear();

            //Display current frame
            ImageBoxOutput.Image = currentFrame;

        }



        public static void Train(String name)
        {
            if (detectedFaces.Count == 1)
            {
                Image<Gray, byte> gray = currentFrame.Convert<Gray, byte>(); //grayscale

                gray = gray.Copy(CameraCapture.detectedFaces[0]);//crop

                if (FaceRecognition.SaveTrainingData(gray, name))
                    MessageBox.Show("Success!");
                FaceRecognition.Retrain();
            }
        }
    }
}
