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
    public static class FaceDetection
    {
        private static CascadeClassifier faceClassifier;

        public static void Init(String classifier)
        {
            faceClassifier = new CascadeClassifier(classifier);
        }

        public static void Detect(Image<Gray, Byte> sourceImage, List<Rectangle> faces)
        {
            
            //normalize image
            sourceImage._EqualizeHist();

            //detect faces
            Rectangle[] detectedFaces = faceClassifier.DetectMultiScale(sourceImage, 1.1, 10, new Size(100, 100), Size.Empty);

            int heightInflate = 5, yOffset = -20;

            for (int i = 0; i < detectedFaces.Length; i++)
            {
                if (
                    detectedFaces[i].Top - (detectedFaces[i].Height / heightInflate) + (detectedFaces[i].Height / yOffset) > 0
                    &&
                    detectedFaces[i].Bottom + (detectedFaces[i].Width / heightInflate) - (detectedFaces[i].Height / yOffset) < sourceImage.Height)
                {
                    Rectangle temp = detectedFaces[i];
                    temp.Offset(0, detectedFaces[i].Height / yOffset);
                    temp.Inflate(0, detectedFaces[i].Height / heightInflate);
                    faces.Add(temp);
                }
            }
        }

        public static void Dispose()
        {
            faceClassifier.Dispose();
        }
    }
}