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
    class BlinkDetector
    {
        

        private static CascadeClassifier eyeClassifier;
        private static CascadeClassifier eyePairClassifier;

        public static void Init(CascadeClassifier _eyePairClassifier, CascadeClassifier _eyeClassifier)
        {
            eyePairClassifier = _eyePairClassifier;
            eyeClassifier = _eyeClassifier;

        }

        public static void Detect(Image<Gray, byte> face)
        {
            //normalize
            face._EqualizeHist();

            //need pair of eyes. if not present, left and right eyes considered not detected 
            Rectangle eyePairPos = DetectPairEyes(face);
            if (!eyePairPos.Equals(Rectangle.Empty))
            {
                //detecting each eyes
                Image<Gray, byte> eyePairImage = face.Copy(eyePairPos);
                BlinkStateManager.leftEyeDetected = DetectLeftEye(eyePairImage);
                BlinkStateManager.rightEyeDetected = DetectRighEye(eyePairImage);
            }
            else
            {
                BlinkStateManager.leftEyeDetected = false;
                BlinkStateManager.rightEyeDetected = false;
            }
        }



        //because this method only invoked if pair of eyes,
        //this method will check wether left eye opened or not (state of individual eye).
        private static bool DetectLeftEye(Image<Gray, byte> image)
        {
            //we only looking on half-left part of the image
            image = image.Copy(new Rectangle(0, 0, image.Width / 2, image.Height));
            Rectangle[] result = eyeClassifier.DetectMultiScale(image, 1.1, 3, new Size(20, 20), Size.Empty);
            if (result.Length >= 1)
                return true;
            else
                return false;
        }

        //same as DetectLeftEye. Only looking on half-right part of the image
        private static bool DetectRighEye(Image<Gray, byte> image)
        {
            image = image.Copy(new Rectangle(image.Width / 2, 0, image.Width / 2, image.Height));
            Rectangle[] result = eyeClassifier.DetectMultiScale(image, 1.1, 3, new Size(20, 20), Size.Empty);
            if (result.Length >= 1)
                return true;
            else
                return false;
        }

        //pair of eyes is detected even if one or both of eyes in closed state
        // because we only check pair of eyes inside a face, we only looking for one pair of eyes.
        private static Rectangle DetectPairEyes(Image<Gray, byte> image)
        {
            Rectangle[] eyePairs = eyePairClassifier.DetectMultiScale(image, 1.1, 5, new Size(70, 30), Size.Empty);

            //alter result for better accuracy
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
