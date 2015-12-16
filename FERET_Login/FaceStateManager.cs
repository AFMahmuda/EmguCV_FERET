using Emgu.CV;
using Emgu.CV.Structure;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FERET_Login
{
    abstract class FaceStateManager
    {

        public enum STATE
        {
            IDLE, NOT_DETECTED, NOT_MATCH, READY, FACE_NOT_STABLE, TOO_DARK, TOO_BRIGHT, TOO_FAR, TOO_CLOSE
        }

        protected static List<Image<Gray, byte>> imagesHistory = new List<Image<Gray, byte>>();
        protected static List<Rectangle> rectHistory = new List<Rectangle>();

        protected static int HistoryLimit = 20;

        protected static STATE CheckState()
        {
            STATE _state = STATE.IDLE;
            switch (CheckBrighness())
            {
                case -1:
                    _state = STATE.TOO_DARK;
                    break;
                case 1:
                    _state = STATE.TOO_BRIGHT;
                    break;
                case 0:
                    if (!IsDetected)
                        _state = STATE.NOT_DETECTED;
                    else if (!IsStable)
                        _state = STATE.FACE_NOT_STABLE;
                    else
                        switch (checkSize())
                        {
                            case -1:
                                _state = STATE.TOO_FAR;
                                break;
                            case 1:
                                _state = STATE.TOO_CLOSE;
                                break;
                            case 0:
                                _state = STATE.READY;
                                break;
                        }
                    break;
            }
            return _state;
        }


        protected static bool IsDetected
        {
            get
            {
                int counter = 0;

                foreach (var item in rectHistory)
                {
                    if (!(item.Equals(Rectangle.Empty)))
                        counter++;
                }
                if (counter < .5 * HistoryLimit)
                    return false;
                else return true;
            }
        }

        protected static bool IsStable
        {
            get
            {
                int counter = 0;
                bool last = (rectHistory.First().Equals(Rectangle.Empty)) ? false : true;
                foreach (var item in rectHistory)
                {
                    bool current = (item.Equals(Rectangle.Empty)) ? false : true;
                    counter += (last == current) ? 0 : 1;
                }
                if (counter < .5 * HistoryLimit)
                    return true;
                else return false;
            }
        }

        protected static int CheckBrighness()
        {

            double grayIntensity = imagesHistory.Last().GetSum().Intensity / (imagesHistory.Last().Size.Height * imagesHistory.Last().Size.Width);

            if (grayIntensity < 100)
                return -1;
            else if (grayIntensity > 200)
                return 1;
            return 0;
        }

        protected static int checkSize()
        {
            float meanSize = 0;
            int counter = 0;
            foreach (var item in rectHistory)
            {
                counter++;
                if (!item.Equals(Rectangle.Empty))
                    meanSize += item.Width * item.Height;
            }
            meanSize /= counter;
            meanSize /= imagesHistory.First().Height * imagesHistory.First().Width;

            if (meanSize > .5)
                return 1;
            else if (meanSize < .16)
                return -1;
            else
                return 0;
        }

        public static void AddToHistory(Image<Gray, byte> currentFrame, Rectangle facePos)
        {
            if (imagesHistory.Count == HistoryLimit)
            {
                imagesHistory.RemoveAt(0);
                rectHistory.RemoveAt(0);
            }

            imagesHistory.Add(currentFrame);
            rectHistory.Add(facePos);
        }

        public static void Clear()
        {
            imagesHistory.Clear();
            rectHistory.Clear();
        }


    }
}
