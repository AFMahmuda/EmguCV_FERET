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
    class FaceDetection
    {

        private static CascadeClassifier faceClassifier;

        public static void Init(CascadeClassifier _classifier)
        {
            faceClassifier = _classifier;
        }


        public static Rectangle Detect(Image<Gray, byte> source)
        {            
            //we put 75,75 (smaller than needed) so we can warn user if their face is to far.
            Rectangle[] result = faceClassifier.DetectMultiScale(source, 1.1, 5, new Size(75, 75), Size.Empty);

            //only process if exacly ONE face is detected
            if (result.Length == 1)
            {
                Rectangle temp = result.First();

                //we need to inflate and shift (up) image so hair, chin, and ears features not missed
                //before inflating and shifting, we need to check if altering the rectangle is actualy possible
                int heightInflate = 5, yOffset = -20;
                if (
                    temp.Top - (temp.Height / heightInflate) + (temp.Height / yOffset) > 0
                    &&
                    temp.Bottom + (temp.Width / heightInflate) - (temp.Height / yOffset) < source.Height)
                {
                    temp.Offset(0, result.First().Height / yOffset);
                    temp.Inflate(0, result.First().Height / heightInflate);
                    return temp;
                }
                else return Rectangle.Empty;
            }

            else
                return Rectangle.Empty;
        }

    }
}
