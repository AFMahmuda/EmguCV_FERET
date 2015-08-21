using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FERET_Login
{
    class BlinkDetector
    {
        Rectangle face;
        private BlinkStateManager stateManager;
        private CascadeClassifier eyeClassifier;
        private CascadeClassifier eyePairClassifier;

        public BlinkDetector(BlinkStateManager _stateManager, CascadeClassifier _eyePairClassifier, CascadeClassifier _eyeClassifier)
        {
            stateManager = _stateManager;
            eyeClassifier = _eyeClassifier;
            eyePairClassifier = _eyePairClassifier;
        }

        public void Detect(Image<Gray, byte> _face)
        {
            Rectangle eyePairPos = DetectEyePair(_face);

            if (!eyePairPos.Equals(Rectangle.Empty))
            {
                Image<Gray, byte> eyePairImage = _face.Copy(eyePairPos);
                stateManager.leftEyeDetected = DetectLeftEye(eyePairImage);
                stateManager.rightEyeDetected = DetectRighEye(eyePairImage);
            }
            else
            {
                stateManager.leftEyeDetected = false;
                stateManager.rightEyeDetected = false;
            }
        }



        private bool DetectLeftEye(Image<Gray, byte> image)
        {

            image = image.Copy(new Rectangle(0, 0, image.Width / 2, image.Height));
            Rectangle[] result = eyeClassifier.DetectMultiScale(image, 1.1, 3, new Size(20, 20), Size.Empty);
            if (result.Length >= 1)
                return true;
            else
                return false;
        }

        private bool DetectRighEye(Image<Gray, byte> image)
        {
            image = image.Copy(new Rectangle(image.Width / 2, 0, image.Width / 2, image.Height));
            Rectangle[] result = eyeClassifier.DetectMultiScale(image, 1.1, 3, new Size(20, 20), Size.Empty);
            if (result.Length >= 1)
                return true;
            else
                return false;
        }

        private Rectangle DetectEyePair(Image<Gray, byte> image)
        {
            Rectangle[] eyePairs = eyePairClassifier.DetectMultiScale(image, 1.1, 5, new Size(70, 20), Size.Empty);

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
