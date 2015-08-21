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
        private Capture capture;

        public CameraCapture(Capture _capture)
        {
            capture = _capture;
        }

        public void Start()
        {
            capture.Start();
            capture.FlipHorizontal = true;
        }

        public void Stop()
        {
            capture.Stop();
        }




    }
}
