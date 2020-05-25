namespace 答题工具
{
    class WrongTest
    {
        public int Q_ID;
        public string Q_TYPE;
        public string Q_ISSUE;
        public string Q_RIGHT;
        public string Q_CHOICE;
        public int Q_SCORE;

        public WrongTest(int _ID, string _TYPE, string _ISSUE, string _RIGHT, string _CHOICE, int _SCORE)
        {
            this.Q_ID = _ID;
            this.Q_TYPE = _TYPE;
            this.Q_ISSUE = _ISSUE;
            this.Q_RIGHT = _RIGHT;
            this.Q_CHOICE = _CHOICE;
            this.Q_SCORE = _SCORE;
        }
    }
}
