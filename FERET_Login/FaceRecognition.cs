using Emgu.CV;
using Emgu.CV.Face;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace FERET_Login
{
    class FaceRecognition
    {

        //xml file properties
        private static String folder = "TrainedFaces";
        private static String file = "TrainedLabels.xml";
        private static String folderpath { get { return Application.StartupPath + "\\" + folder; } }
        private static String filepath { get { return folderpath + "\\" + file; } }

        //due to bug in openCV, second parameter of EigenFacerecognizer need to be double.PositiveInfinity
        //so we need to put threshold on a different var. 80 and 2000 are recommended values
        private static FaceRecognizer faceRecognizer = new EigenFaceRecognizer(150, double.PositiveInfinity);
        private static int EigenThreshold = 2000;

        //face recognizer label is an integer so we need another list name to get labels (name)
        private static List<String> labels = new List<string>();
        private static List<int> labelsID = new List<int>();
        private static List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
       
        //training and test data need to be on the sime size
        private static int width = 200;
        private static int height = 200;

        public static bool Retrain()
        {
            return LoadTrainingData();
        }


        private static bool LoadTrainingData()
        {
            if (XMLManager.ReadXMLForTraining(folder, file, labelsID, labels, trainingImages))
            {
                if (trainingImages.Count != 0)
                    try
                    {
                        //two parameters need to be on the same size (COUNT)
                        //each image need to be on the same size (height and width)
                        faceRecognizer.Train(trainingImages.ToArray(), labelsID.ToArray());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                        return false;
                    }
                return true;
            }
            else
                return false;
        }

        public static bool SaveTrainingData(Image<Gray, byte> image, String name)
        {
            //normalize and resize image
            Image<Gray, byte> face = image.Resize(width, height, Emgu.CV.CvEnum.Inter.Linear);
            face._EqualizeHist();

            //create unique filename
            String uniqueNumber = DateTime.Now.ToString("yyMMddHHmmss");
            String imageFilename = "face_" + name + "_" + uniqueNumber + ".jpg";

            //save image on disk
            if (!Directory.Exists(folderpath))
                Directory.CreateDirectory(folderpath);
            face.ToBitmap().Save(folderpath + "\\" + imageFilename, ImageFormat.Jpeg);

            //save record of image
            XMLManager.WriteXMLForTraining(filepath, name, imageFilename);

            return true;
        }


        public static String Recognize(Image<Gray, byte> source, int threshold = -1)
        {
            //if threshold parameter is set ( not default [-1] ), we use parameter value as threshold
            //else, use EigenThreshold's value as threshold (2000)
            if (threshold > -1) EigenThreshold = threshold;

            //normalize and resize image
            Image<Gray, byte> face = source.Resize(width, height, Emgu.CV.CvEnum.Inter.Linear, false);
            face._EqualizeHist();

            try
            {
                String eigenLabel = "";
                FaceRecognizer.PredictionResult result = faceRecognizer.Predict(face);
                if (result.Label == -1)
                    return "Unknown -1";

                else
                {
                    float eigenDistance;
                    //result is INT, we need STRING
                    eigenLabel = labels[result.Label];
                    eigenDistance = (float)result.Distance;
                    if (eigenDistance > EigenThreshold) 
                        return eigenLabel;
                    else 
                        return "Unknown " + eigenDistance;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return "Unknown -2";
        }
    }
}
