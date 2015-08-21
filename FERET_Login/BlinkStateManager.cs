using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FERET_Login
{
    class BlinkStateManager
    {
        private int stateHistoryLimit = 9;

        public bool faceDetected;
        public bool leftEyeDetected;
        public bool rightEyeDetected;

        private bool _isReady;
        public bool IsReady
        {
            set { _isReady = value; }
            get
            {
                int sum = 0;
                foreach (var item in StateHistory)
                {
                    if (item.Equals(STATE.READY))
                        sum++;
                }

                if (sum == stateHistoryLimit && LastAction.Equals(LAST_ACTION.NONE))
                    _isReady = true;
                else _isReady = false;
                return _isReady;
            }
        }

        public enum STATE
        {
            IDLE, LOOKING_FACE, LOOKING_BOTH_EYES, LOOKING_LEFT_EYE, LOOKING_RIGHT_EYE, READY
        }


        private STATE _state;
        public STATE State
        {
            set
            {
                _state = value;
            }
            get
            {
                STATE temp = _state;
                if (!faceDetected)
                    _state = STATE.LOOKING_FACE;
                else if (!leftEyeDetected && !rightEyeDetected)
                    _state = STATE.LOOKING_BOTH_EYES;
                else if (!leftEyeDetected)
                    _state = STATE.LOOKING_LEFT_EYE;
                else if (!rightEyeDetected)
                    _state = STATE.LOOKING_RIGHT_EYE;
                else
                    _state = STATE.READY;
                if (StateHistory.Count == stateHistoryLimit)
                    StateHistory.RemoveAt(0);
                StateHistory.Add(_state);
                return _state;
            }

        }


        public List<STATE> StateHistory = new List<STATE>();
        public void HistoryReset()
        {
            StateHistory.Clear();
        }


        public enum LAST_ACTION
        {
            NONE, BLINK, WINK_LEFT, WINK_RIGHT
        }

        private LAST_ACTION _lastAction;


        private STATE countState(int first, int last)
        {
            int ready, closedAll, closedLeft, closedRight, counter;
            ready = closedAll = closedLeft = closedRight = counter = 0;

            for (int current = first; current <= last; current++)
            {
                counter++;
                switch (StateHistory[current])
                {
                    case STATE.LOOKING_BOTH_EYES:
                        closedAll++;
                        break;
                    case STATE.LOOKING_LEFT_EYE:
                        closedLeft++;
                        break;
                    case STATE.LOOKING_RIGHT_EYE:
                        closedRight++;
                        break;
                    case STATE.READY:
                        ready++;
                        break;
                    default:
                        break;
                }
            }


            if (ready > stateHistoryLimit / (counter * 2))
                return STATE.READY;
            else if (closedAll > stateHistoryLimit / (counter * 2))
                return STATE.LOOKING_BOTH_EYES;
            else if (closedLeft > stateHistoryLimit / (counter * 2))
                return STATE.LOOKING_LEFT_EYE;
            else if (closedRight > stateHistoryLimit / (counter * 2))
                return STATE.LOOKING_RIGHT_EYE;
            else return STATE.READY;
        }

        public LAST_ACTION LastAction
        {
            set
            {
                _lastAction = value;
            }
            get
            {
                if (StateHistory.Count < stateHistoryLimit)
                    return LAST_ACTION.NONE;
                STATE firstState, secondState, thirdState;
                firstState = secondState = thirdState = STATE.IDLE;

                firstState = countState(0, stateHistoryLimit / 3 - 1);
                secondState = countState(stateHistoryLimit / 3, stateHistoryLimit * 2 / 3 - 1);
                thirdState = countState(stateHistoryLimit * 2 / 3, stateHistoryLimit - 1);

                if (firstState.Equals(STATE.READY) && thirdState.Equals(STATE.READY))
                {
                    switch (secondState)
                    {
                        case STATE.LOOKING_BOTH_EYES:
                            _lastAction = LAST_ACTION.BLINK;
                            break;
                        case STATE.LOOKING_LEFT_EYE:
                            _lastAction = LAST_ACTION.WINK_LEFT;
                            break;
                        case STATE.LOOKING_RIGHT_EYE:
                            _lastAction = LAST_ACTION.WINK_RIGHT;
                            break;
                        default:
                            _lastAction = LAST_ACTION.NONE;
                            break;
                    }
                }
                else
                    _lastAction = LAST_ACTION.NONE;
                return _lastAction;
            }
        }





    }
}
