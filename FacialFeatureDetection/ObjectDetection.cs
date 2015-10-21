using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceRecognitionProject
{
    public class ObjectDetector: IDisposable
    {
        private CascadeClassifier Classifier;

        public ObjectDetector()
        {

        }

        public ObjectDetector(String classifierFile)
        {
            Classifier = new CascadeClassifier(classifierFile);
        }

        public void Detect(Image<Gray, Byte> sourceImage, List<Rectangle> objects)
        {
            //normalize image
            sourceImage._EqualizeHist();


            //detect objects
            Rectangle[] detectedObjects = Classifier.DetectMultiScale(sourceImage, 1.1, 3, new Size(40, 40), Size.Empty);
            
            //add detected face(s) to the list
            objects.AddRange(detectedObjects);
        }

        public void Dispose()
        {
            Classifier.Dispose();
        }
    }
}