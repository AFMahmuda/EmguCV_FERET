using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FERET_Login
{
    class BlinkStateManager
    {
        private static int stateHistoryLimit = 9;

        //state of eyes
        public static bool faceDetected;
        public static bool leftEyeDetected;
        public static bool rightEyeDetected;

        //determine if ALL the state so far is READY
        private static bool _isReady;
        public static bool IsReady
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

                if (sum == stateHistoryLimit)
                    _isReady = true;
                else _isReady = false;
                return _isReady;
            }
        }

        public enum STATE
        {
            LOOKING_FACE, LOOKING_BOTH_EYES, LOOKING_LEFT_EYE, LOOKING_RIGHT_EYE, READY
        }

        //determine current state or action of blink detector
        private static STATE _state;
        public static STATE State
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

                //add current state to 'queue' list
                if (StateHistory.Count == stateHistoryLimit)
                    StateHistory.RemoveAt(0);
                StateHistory.Add(_state);

                return _state;
            }
        }


        public static List<STATE> StateHistory = new List<STATE>();
        public static void Clear()
        {
            StateHistory.Clear();
        }


        public enum LAST_ACTION
        {
            NONE, BLINK, WINK_LEFT, WINK_RIGHT
        }



        //look for mode of range of state in stateHistory list.
        //to be considered a state, it must populate more than half of given range 
        private static STATE countState(int first, int last)
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

            int half = stateHistoryLimit / (counter * 2);
            if (ready > half)
                return STATE.READY;
            else if (closedAll > half)
                return STATE.LOOKING_BOTH_EYES;
            else if (closedLeft > half)
                return STATE.LOOKING_LEFT_EYE;
            else if (closedRight > half)
                return STATE.LOOKING_RIGHT_EYE;
            else return STATE.READY;
        }

        private static LAST_ACTION _lastAction;
        public static LAST_ACTION LastAction
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


                //count per 1/3 of stateHistory
                firstState = countState(0, stateHistoryLimit / 3 - 1);
                secondState = countState(stateHistoryLimit / 3, stateHistoryLimit * 2 / 3 - 1);
                thirdState = countState(stateHistoryLimit * 2 / 3, stateHistoryLimit - 1);

                //action is deefined by second state. only if the first and secon states are ready
                if (firstState.Equals(STATE.READY) && thirdState.Equals(STATE.READY))
                {
                    //add this condition so we dount return multiple blink in a row.
                    if (_lastAction.Equals(LAST_ACTION.NONE))
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
