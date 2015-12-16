using Emgu.CV;

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
