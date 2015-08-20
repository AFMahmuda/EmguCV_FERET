using Emgu.CV;
using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FERET_Login
{
    class CameraCapture
    {
        public Capture capture;
        public ImageBox imageBox;


        public CameraCapture(Capture _capture, ImageBox _imageBox)
        {
            capture = _capture;
            imageBox = _imageBox;            
        }

        public void Start(){

        }

        public void Stop() { 
        }




    }
}
