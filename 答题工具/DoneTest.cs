using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace 答题工具
{
    public partial class DoneTest : Form
    {
        public List<Question> test;
        private int SCORE;
        private int RIGHTCount;
        private int WRONGCount;
        private string webHtml;
        private int QCount = 0;
        public DoneTest(List<Question> _TEST)
        {
            this.test = _TEST;
            InitializeComponent();

            foreach (var item in test)
            {
                SCORE += item.Score;
                if (item.right)
                {
                    RIGHTCount++;
                }
                else
                {
                    WRONGCount++;
                }
            }
            WebBrowser web = new WebBrowser
            {
                Dock = DockStyle.Fill,
            };
            this.Text = "答对" + RIGHTCount + "题，" + "答错" + WRONGCount + "题， 得" + SCORE + "分。";
            webHtml += "<html>" +
                "<head>" +
                "<style type='text/css'>" +
                "body {font-family: sans-serif;}" +
                "</style>" +
                "</head>" +
                "<body>";
            webHtml += "<h2>答题结果：</h2>";

            foreach (var item in test)
            {
                QCount++;
                if (item.right)
                {
                    webHtml += "<div style='background:#CCFFCC;border:1px solid black;margin-bottom:10px;padding:10px;'><font size='4'>" + QCount + "." + item.Q_ISSUE + "</font><div style='padding-bottom:10px;'></div>";
                }
                else
                {
                    webHtml += "<div style='background:#FFB6C1;border:1px solid black;margin-bottom:10px;padding:10px;'><font size='4'>" + QCount + "." + item.Q_ISSUE + "</font><div style='padding-bottom:10px;'></div>";
                }
                switch (item.Q_TYPE)
                {
                    case "Choice":
                        string[] ChoiceAnswerArray = item.Q_CHOICE.Split(',');
                        for (int i = 0; i < ChoiceAnswerArray.Length; i++)
                        {
                            if (item.right)
                            {
                                if (item.choice == ChoiceAnswerArray[i])
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio' checked='checked' disabled='false'/><font>" + ChoiceAnswerArray[i] + "</font></label></br>";
                                }
                                else
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio'disabled='false'/><font>" + ChoiceAnswerArray[i] + "</font></label></br>";
                                }
                            }
                            else
                            {
                                if (item.choice == ChoiceAnswerArray[i])
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio' checked='checked' disabled='false'/><font>" + ChoiceAnswerArray[i] + "</font></label></br>";
                                }
                                else if (item.Q_RIGHT == ChoiceAnswerArray[i])
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio' disabled='false'/><font>" + ChoiceAnswerArray[i] + "</font></label></br>";
                                }
                                else
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio' disabled='false'/><font>" + ChoiceAnswerArray[i] + "</font></label></br>";
                                }
                            }
                        }
                        if (!item.right) { webHtml += "<div style='padding-left:10px;padding-top:15px;'><font style='font-weight:bold;' color='green'>正确答案：" + item.Q_RIGHT + "</font></div>"; }
                        break;
                    case "TrueOrFalse":
                        string[] TrueOrFalseAnswerArray = item.Q_CHOICE.Split(',');
                        for (int i = 0; i < TrueOrFalseAnswerArray.Length; i++)
                        {
                            if (item.right)
                            {
                                if (item.choice == TrueOrFalseAnswerArray[i])
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio' checked='checked'disabled = 'false'/><font>" + TrueOrFalseAnswerArray[i] + "</font></label></br>";
                                }
                                else
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio' disabled='false'/><font>" + TrueOrFalseAnswerArray[i] + "</font></label></br>";
                                }
                            }
                            else
                            {
                                if (item.choice == TrueOrFalseAnswerArray[i])
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio' checked='checked' disabled='false'/><font>" + TrueOrFalseAnswerArray[i] + "</font></label></br>";
                                }
                                else if (item.Q_RIGHT == TrueOrFalseAnswerArray[i])
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio' disabled='false'/><font>" + TrueOrFalseAnswerArray[i] + "</font></label></br>";
                                }
                                else
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='radio' disabled='false'/><font>" + TrueOrFalseAnswerArray[i] + "</font></label></br>";
                                }
                            }
                        }
                        if (!item.right) { webHtml += "<div style='padding-left:10px;padding-top:15px;'><font color='green' style='font-weight:bold;'>正确答案：" + item.Q_RIGHT + "</font></div>"; }
                        break;
                    case "Multiple_Choice":
                        string[] MChoiceAnswerArray = item.Q_CHOICE.Split(',');
                        if (item.choice == "")
                        {
                            foreach (var _MChoiceAnswerList in MChoiceAnswerArray)
                            {
                                webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='checkbox' disabled='false'/><font>" + _MChoiceAnswerList + "</font></label></br>";
                            }
                            webHtml += "<div style='padding-left:10px;padding-top:15px;'><font color='green' style='font-weight:bold;'>正确答案：</br>";
                            foreach (var right in item.Q_RIGHT.Split(','))
                            {
                                webHtml += right + "</br>";
                            }
                            webHtml += "</font></div>";
                        }
                        else
                        {
                            string[] MChoice = item.choice.Split(',');
                            List<string> MChoiceAnswerList = new List<string>();
                            for (int i = 0; i < MChoiceAnswerArray.Length; i++)
                            {
                                MChoiceAnswerList.Add(MChoiceAnswerArray[i]);
                            }
                            for (int i = 0; i < MChoiceAnswerList.Count; i++)
                            {
                                foreach (var mchoice in MChoice)
                                {
                                    if (mchoice == MChoiceAnswerList[i])
                                    {
                                        MChoiceAnswerList.Remove(MChoiceAnswerList[i]);
                                    }
                                }
                            }

                            if (item.right)
                            {
                                foreach (var _MChoiceAnswerList in MChoiceAnswerList)
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='checkbox' disabled='false'/><font>" + _MChoiceAnswerList + "</font></label></br>";
                                }
                                foreach (var _MChoice in MChoice)
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='checkbox' checked='checked' disabled='false'/><font>" + _MChoice + "</font></label></br>";
                                }
                            }
                            else
                            {
                                foreach (var _MChoiceAnswerList in MChoiceAnswerList)
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='checkbox' disabled='false'/><font>" + _MChoiceAnswerList + "</font></label></br>";
                                }
                                foreach (var _MChoice in MChoice)
                                {
                                    webHtml += "<label><input name=' " + item.Q_ISSUE + "' type='checkbox' checked='checked' disabled='false'/><font>" + _MChoice + "</font></label></br>";
                                }
                            }
                            if (!item.right)
                            {
                                webHtml += "<div style='padding-left:10px;padding-top:15px;'><font color='green'>正确答案：</br>";
                                foreach (var right in item.Q_RIGHT.Split(','))
                                {
                                    webHtml += right + "</br>";
                                }
                                webHtml += "</font></div>";
                            }
                        }
                        break;
                }
                webHtml += "</div>";
            }
            webHtml += "</body></html>";
            //MessageBox.Show(webHtml);
            web.DocumentText = webHtml;
            Controls.Add(web);
        }

        private void DoneTest_FormClosed(object sender, FormClosedEventArgs e)
        {
            bool PUSHWrong = true;
            int wrongCount = 0;
            foreach (var item in test)
            {
                PUSHWrong = true;
                if (item.right == false)
                {
                    wrongCount++;
                    if (Main.WrongTest.Count == 0)
                    {
                        Main.WrongTest.Add(item);
                        continue;
                    }
                    foreach (var item2 in Main.WrongTest)
                    {
                        if (item.Q_ISSUE == item2.Q_ISSUE)
                        {
                            PUSHWrong = false;
                        }
                    }
                    if (PUSHWrong)
                    {
                        Main.WrongTest.Add(item);
                    }
                }
            }
            if (wrongCount == 0)
            {
                Application.Exit();
                Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                return;
            }
            if (MessageBox.Show("是否保存错题数据？", "退出", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                Application.Exit();
                Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                return;
            }
            List<WrongTest> wrongtests = new List<WrongTest>();
            string jsonStr = "";
            foreach (var item in Main.WrongTest)
            {
                wrongtests.Add(new WrongTest(item.Q_ID, item.Q_TYPE, item.Q_ISSUE, item.Q_RIGHT, item.Q_CHOICE, item.Q_SCORE));
            }
            jsonStr = JsonConvert.SerializeObject(wrongtests);
            string path = Tools.SavaProcess(jsonStr);
            Application.Exit();
            Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
