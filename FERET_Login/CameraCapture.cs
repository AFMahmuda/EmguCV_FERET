using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FERET_Login
{
    class CameraCapture
    {
        private static Capture capture;

        public static void Init(Capture _capture)
        {
            capture = _capture;
        }

        public static void Start()
        {
            capture.Start();

            //give mirror effect
            capture.FlipHorizontal = true;
        }

        public static void Stop()
        {
            capture.Stop();
            capture.Dispose();
        }
    }
}
