using System.Collections.Generic;
using System.Drawing;

namespace FERET_Login
{
    class SecurityStateManager : FaceStateManager
    {

        private static List<bool> matchHistory = new List<bool>();

        protected static STATE _state;
        public static STATE State
        {
            set
            {
                _state = value;
            }
            get
            {
                if (imagesHistory.Count < HistoryLimit)
                    _state = STATE.IDLE;
                else
                {
                    if (!IsMatch)
                        _state = STATE.NOT_MATCH;
                    else 
                        _state = CheckState();
                }

                return _state;
            }
        }

        private static bool IsMatch
        {
            get
            {
                int match = 0;
                if (matchHistory.Count < HistoryLimit)
                    return true;
                foreach (var item in matchHistory)
                {
                    //count only if face is DETECTED
                    if (!rectHistory.Equals(Rectangle.Empty))
                        match += (item) ? 1 : -1;
                }

                //return true if more than HALF of RECOGNIZED faces is MATCH
                bool result = (match >= 0) ? true : false;
                return result;
            }
        }


        public static void AddToHistory(bool match)
        {
            if (matchHistory.Count == HistoryLimit)
                matchHistory.RemoveAt(0);
            matchHistory.Add(match);
        }

        public new static void Clear()
        {
            imagesHistory.Clear();
            rectHistory.Clear();
            matchHistory.Clear();
        }



    }
}
