namespace FERET_Login
{
    class TrainingStateManager : FaceStateManager
    {
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
                    _state = CheckState();
                return _state;
            }
        }
    }
}
