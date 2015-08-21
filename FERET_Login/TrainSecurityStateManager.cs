using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FERET_Login
{
    class TrainSecurityStateManager
    {



        public enum STATE
        {
            IDLE, READY, MULTIPLE_FACE_DETECTED, FACE_NOT_STABLE, TOO_DARK, TOO_BRIGHT, TOO_FAR, TOO_CLOSE
        }

        private STATE _security;
        public STATE SecurityForTrain
        {
            set
            {
                _security = value;
            }
            get
            {
                if (imagesHistory.Count < imageHistoryLimit)
                    _security = STATE.IDLE;
                else
                {
                    if (IsStable())
                    {
                        if (!IsSingleFace())
                        {
                            _security = STATE.MULTIPLE_FACE_DETECTED;
                        }
                        else
                        {
                            switch (CheckBrighness())
                            {
                                case -1:
                                    _security = STATE.TOO_DARK;
                                    break;
                                case 1:
                                    _security = STATE.TOO_BRIGHT;
                                    break;
                                default:
                                    switch (checkSize())
                                    {
                                        case -1:
                                            _security = STATE.TOO_FAR;
                                            break;
                                        case 1:
                                            _security = STATE.TOO_CLOSE;
                                            break;
                                        default:
                                            _security = STATE.READY;
                                            break;
                                    }
                                    break;
                            }
                        }


                    }
                    else
                        _security = STATE.FACE_NOT_STABLE;
                }

                return _security;
            }
        }

        private List<Image<Bgr, byte>> imagesHistory;

        private int imageHistoryLimit = 5;

        private bool IsStable()
        {
            return true;
        }

        private int CheckBrighness()
        {
            //            return -1;
            //          return 1;
            return 0;
        }

        private int checkSize()
        {
            //            return -1;
            //          return 1;
            return 0;
        }

        private bool IsSingleFace()
        {
            return true;
        }

    }
}
