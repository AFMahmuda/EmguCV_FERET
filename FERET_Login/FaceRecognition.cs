using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace FERET_Login
{
    static class FaceRecognition
    {

        private static FaceRecognizer recognizer;

        public static bool IsTrained { set; get; }
        private static FaceRecognizer faceRecognizer = new EigenFaceRecognizer(80, double.PositiveInfinity);
        private static List<Image<Gray, byte>> trainingImages = new List<Image<Gray, byte>>();
        private static List<String> labels = new List<string>();
        private static List<int> labelsID = new List<int>();
        private static String EigenLabel;
        private static float EigenDistance = 0;
        private static int EigenThreshold = 2000, countTrain = 0;

        public static bool Retrain()
        {
            return IsTrained = LoadTrainingData(Application.StartupPath + "\\TrainedFaces");
        }

        private static bool ReadXML(String folder)
        {
            if (File.Exists(folder + "\\TrainedLabels.xml"))
            {
                countTrain = 0;
                labels.Clear();
                labelsID.Clear();
                trainingImages.Clear();

                FileStream filestream = File.OpenRead(folder + "\\TrainedLabels.xml");
                long fileLength = filestream.Length;
                byte[] xmlBytes = new byte[fileLength];
                filestream.Read(xmlBytes, 0, (int)fileLength);
                filestream.Close();
                filestream.Dispose();

                MemoryStream xmlStream = new MemoryStream(xmlBytes);
                using (XmlReader xmlReader = XmlTextReader.Create(xmlStream))
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.IsStartElement())
                        {
                            switch (xmlReader.Name)
                            {
                                case "NAME":
                                    if (xmlReader.Read())
                                    {
                                        labelsID.Add(labels.Count);
                                        labels.Add(xmlReader.Value.Trim());
                                        countTrain += 1;
                                    }
                                    break;
                                case "FILE":
                                    if (xmlReader.Read())

                                        trainingImages.Add(new Image<Gray, byte>(folder + "\\" + xmlReader.Value.Trim()));

                                    break;
                            }
                        }
                    }
                }
                xmlStream.Dispose();
                filestream.Dispose();
                return true;
            }
            else
                return false;

        }

        private static bool LoadTrainingData(String folder)
        {

            if (ReadXML(folder))
            {
                if (countTrain != 0)
                    try
                    {
                        faceRecognizer.Train(trainingImages.ToArray(), labelsID.ToArray());
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                return true;
            }
            else
                return false;
        }


        private static void WriteXML(String name, String filename)
        {
            XmlDocument xmlFile = new XmlDocument();
            if (File.Exists(Application.StartupPath + "\\TrainedFaces\\TrainedLabels.xml"))
            {

                bool loading = true;
                while (loading)
                {
                    try
                    {
                        xmlFile.Load(Application.StartupPath + "\\TrainedFaces\\TrainedLabels.xml");
                        loading = false;
                    }
                    catch
                    {
                        xmlFile = null;
                        xmlFile = new XmlDocument();
                        Thread.Sleep(10);
                    }
                }



                XmlElement root = xmlFile.DocumentElement;

                XmlElement face_D = xmlFile.CreateElement("FACE");
                XmlElement name_D = xmlFile.CreateElement("NAME");
                XmlElement file_D = xmlFile.CreateElement("FILE");


                name_D.InnerText = name;
                file_D.InnerText = filename;

                face_D.AppendChild(name_D);
                face_D.AppendChild(file_D);
                root.AppendChild(face_D);

                xmlFile.Save(Application.StartupPath + "\\TrainedFaces\\TrainedLabels.xml");
            }

            else
            {
                FileStream fileStream = File.OpenWrite(Application.StartupPath + "\\TrainedFaces\\TrainedLabels.xml");
                using (XmlWriter xmlWriter = XmlWriter.Create(fileStream))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Faces_For_Training");

                    xmlWriter.WriteStartElement("FACE");
                    xmlWriter.WriteElementString("NAME", name);
                    xmlWriter.WriteElementString("FILE", filename);
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                }
                fileStream.Dispose();

            }

        }

        public static bool SaveTrainingData(Image<Gray, byte> image, String name)
        {
            image = image.Resize(200, 200, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC, false);//resize
            image._EqualizeHist();

            String uniqueNumber = DateTime.Now.ToString("yyMMddHHmmss");
            String filename = "face_" + name + "_" + uniqueNumber + ".jpg";

            if (!Directory.Exists(Application.StartupPath + "\\TrainedFaces\\"))
                Directory.CreateDirectory(Application.StartupPath + "\\TrainedFaces\\");

            image.ToBitmap().Save(Application.StartupPath + "\\TrainedFaces\\" + filename, ImageFormat.Jpeg);

            WriteXML(name, filename);

            return true;
        }


        public static String Recognize(Image<Gray, byte> source, int threshold = 1000)
        {
            Image<Gray, byte> face = source.Resize(200, 200, Emgu.CV.CvEnum.INTER.CV_INTER_LINEAR, false);
            face._EqualizeHist();

            if (IsTrained)
            {
                try
                {

                    FaceRecognizer.PredictionResult ER = faceRecognizer.Predict(face);
                    if (ER.Label == -1)
                    {
                        EigenLabel = "Unknown -1";
                        EigenDistance = 0;
                        return EigenLabel;
                    }
                    else
                    {
                        EigenLabel = labels[ER.Label];
                        EigenDistance = (float)ER.Distance;
                        if (threshold > -1) EigenThreshold = threshold;
                        if (EigenDistance > EigenThreshold) return EigenLabel;
                        else return "Unknown, nearest: " +EigenLabel +" "+ EigenDistance;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }

            }
            return "Unknown";
        }


    }
}
