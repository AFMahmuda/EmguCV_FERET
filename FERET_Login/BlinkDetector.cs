using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERET_Login
{
    static class BlinkDetector
    {
        static Rectangle face;
        private static CascadeClassifier eyeClassifier;
        private static CascadeClassifier eyePairClassifier;

        public static void Init(CascadeClassifier _eyePairClassifier, CascadeClassifier _eyeClassifier)
        {
            eyePairClassifier = _eyePairClassifier;
            eyeClassifier = _eyeClassifier;
        }

        public static void Detect(Image<Gray, byte> _face)
        {
            Rectangle eyePairPos = DetectEyePair(_face);

            if (!eyePairPos.Equals(Rectangle.Empty))
            {
                Image<Gray, byte> eyePairImage = _face.Copy(eyePairPos);
                BlinkStateManager.leftEyeDetected = DetectLeftEye(eyePairImage);
                BlinkStateManager.rightEyeDetected = DetectRighEye(eyePairImage);
            }
            else
            {
                BlinkStateManager.leftEyeDetected = false;
                BlinkStateManager.rightEyeDetected = false;
            }
        }



        private static bool DetectLeftEye(Image<Gray, byte> image)
        {

            image = image.Copy(new Rectangle(0, 0, image.Width / 2, image.Height));
            Rectangle[] result = eyeClassifier.DetectMultiScale(image, 1.1, 3, new Size(20, 20), Size.Empty);
            if (result.Length >= 1)
                return true;
            else
                return false;
        }

        private static bool DetectRighEye(Image<Gray, byte> image)
        {
            image = image.Copy(new Rectangle(image.Width / 2, 0, image.Width / 2, image.Height));
            Rectangle[] result = eyeClassifier.DetectMultiScale(image, 1.1, 3, new Size(20, 20), Size.Empty);
            if (result.Length >= 1)
                return true;
            else
                return false;
        }

        private static Rectangle DetectEyePair(Image<Gray, byte> image)
        {
            Rectangle[] eyePairs = eyePairClassifier.DetectMultiScale(image, 1.1, 5, new Size(70, 30), Size.Empty);

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



    }
}
