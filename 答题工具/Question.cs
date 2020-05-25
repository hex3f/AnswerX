using MarkerMetro.Unity.WinLegacy.Threading;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace 答题工具
{
    public class Question
    {
        public int Q_ID;
        public string Q_TYPE;
        public string Q_ISSUE;
        public string Q_RIGHT;
        public string Q_CHOICE;
        public int Q_SCORE;

        //练习模式
        public bool ErrorAndNext = false;
        public string ErrorAndChoice = "";
        public bool ISLearnModeError = false;
        public bool FIXERROR = false;

        public Form QuestionForm;
        public Form _MAIN;
        public int ID;
        public int Score = 0;

        public string choice = "";
        public bool right;
        public Point point = new Point(0, 0);
        public bool StartUnOrder = false;
        /// <summary>
        /// 随机化选项
        /// </summary>
        public void UnOrderChoice()
        {
            if (Q_TYPE == "TrueOrFalse") return;
            string[] c = Q_CHOICE.Split(',');
            string ranNum = Tools.RandomNum(c.Length, 0, c.Length - 1);
            Thread.Sleep(2);
            string[] ranNumArray = ranNum.Split(',');
            string[] NewChoice = new string[c.Length];
            Q_CHOICE = "";
            for (int i = 0; i < c.Length; i++)
            {
                NewChoice[i] = c[Convert.ToInt32(ranNumArray[i])];
            }
            foreach (var item in NewChoice)
            {
                if (Q_CHOICE == "")
                {
                    Q_CHOICE += item;
                }
                else
                {
                    Q_CHOICE += "," + item;
                }
            }
        }
        public void Show()
        {
            switch (Q_TYPE)
            {
                case "Choice":
                    QuestionForm = new Choice(Q_ISSUE, Q_CHOICE, ID, this);
                    break;
                case "Multiple_Choice":
                    QuestionForm = new Multiple_Choice(Q_ISSUE, Q_CHOICE, ID, this);
                    break;
                case "TrueOrFalse":
                    QuestionForm = new Choice(Q_ISSUE, Q_CHOICE, ID, this);
                    break;
            }
            QuestionForm.Show();
        }
    }
}
