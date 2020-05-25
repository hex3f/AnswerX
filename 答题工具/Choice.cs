using System;
using System.Drawing;
using System.Windows.Forms;

namespace 答题工具
{
    public partial class Choice : Form
    {

        private string data;
        private string title;
        private int id;
        private Button Up;
        private Button Down;
        private Button Done;
        private RadioButton[] AnswerButton;
        private Question question;
        private Label Title;
        public Choice(string _TITLE, string _DATA, int _ID, Question _QUESTION)
        {
            this.data = _DATA;
            this.title = _TITLE;
            this.id = _ID;
            this.question = _QUESTION;
            //添加题目标题Label控件
            int TitleLineCount = (Tools.TextLineValue(title, 24) - 1);
            Title = new Label
            {
                Font = new Font("黑体", 13f),
                Size = new Size(458, 20 + (TitleLineCount * 18)),
                Location = new Point(23, 15)
            };
            InitPosY += TitleLineCount * 18;

            Title.Text = (_ID + 1) + "." + title;
            Controls.Add(Title);

            //添加题目选项RadioButton控件
            string[] AnswerArray = data.Split(',');
            int count = AnswerArray.Length;
            AnswerButton = new RadioButton[count];

            for (int i = 0; i < count; i++)
            {
                int line = Tools.TextLineValue(AnswerArray[i], 26);
                AnswerButton[i] = new RadioButton()
                {
                    Font = new Font("黑体", 12f),
                    Size = new Size(442, 20 + line-- * 16),
                    Location = new Point(InitPosX, InitPosY)
                };
                if (AnswerArray[i] == _QUESTION.choice)
                {
                    AnswerButton[i].Checked = true;
                }
                InitPosY += 16 * line;  //每多一行文字 间隔数量
                AnswerButton[i].Text = AnswerArray[i];
                Controls.Add(AnswerButton[i]);
                InitPosY += 30;         //下一个控件的位置加多少
            }

            //添加按钮
            //上一题
            Up = new Button
            {
                Font = new Font("黑体", 10f),
                Size = new Size(80, 30),
                Location = new Point(50, InitPosY + 20)
            };
            Up.Click += new EventHandler(UP_Click);
            Up.Text = "上一题";
            //判断是否有上一题
            if (_ID == 0)
            {
                Up.Enabled = false;
            }

            //下一题
            Down = new Button
            {
                Font = new Font("黑体", 10f),
                Size = new Size(80, 30),
                Location = new Point(150, InitPosY + 20)
            };

            Down.Click += new EventHandler(DOWN_Click);
            //判断是否有下一题
            if (_ID == Main.test.Count - 1)
            {
                Down.Text = "交卷";
            }
            else
            {
                Down.Text = "下一题";
                //结束答题
                Done = new Button
                {
                    Font = new Font("黑体", 10f),
                    Size = new Size(80, 30),
                    Location = new Point(250, InitPosY + 20)
                };
                Done.Text = "结束答题";
                Done.Click += new EventHandler(CloseForm);
                Controls.Add(Done);
            }

            Controls.Add(Up);
            Controls.Add(Down);

            this.Size = new Size(518, InitPosY + 90);//窗体大小
            this.MaximizeBox = false;//禁止窗体最大化
            this.MinimizeBox = true;//启用窗体最小化
            this.FormBorderStyle = FormBorderStyle.FixedSingle;//禁止窗体的拉伸
            this.ControlBox = false;//隐藏控制按钮

            switch (question.Q_TYPE)
            {
                case "TrueOrFalse":
                    this.Text = "第 " + (question.ID + 1) + " 题" + " （判断题）";
                    break;
                case "Choice":
                    this.Text = "第 " + (question.ID + 1) + " 题" + " （单选题）";
                    break;
            }
            //设置窗体位置
            if (question.point == new Point(0, 0))
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = question.point;
            }

            if (question.ISLearnModeError)
            {
                Title.ForeColor = Color.Red;
                string[] Rmchoice = question.Q_RIGHT.Split(',');
                string tip = "正确答案：\n";
                foreach (var Rsingle in Rmchoice)
                {
                    tip += Rsingle + "\n";
                }
                int line = tip.Split('\n').Length;
                line += Tools.TextLineValue(tip, 26);
                Label LearnTip = new Label
                {
                    Font = new Font("黑体", 12f),
                    Size = new Size(442, 20 + line-- * 20),
                    Location = new Point(InitPosX, InitPosY + 70)

                };
                LearnTip.Text = tip;
                InitPosY += 30;         //下一个控件的位置加多少
                Controls.Add(LearnTip);
                this.Size = new Size(this.Size.Width, this.Size.Height + 40 + line * 10);
            }
        }

        private int InitPosX = 32;
        private int InitPosY = 40;

        private void UP_Click(object sender, EventArgs e)
        {
            foreach (var item in AnswerButton)
            {
                if (item.Checked)
                {
                    question.choice = item.Text;
                    if (item.Text == question.Q_RIGHT)
                    {
                        question.right = true;
                        question.Score = question.Q_SCORE;
                    }
                    else
                    {
                        question.right = false;
                        question.Score = 0;
                    }
                }
            }
            if (Main.test[id - 1].ErrorAndNext)
            {
                Main.test[id - 1].choice = Main.test[id - 1].Q_RIGHT;
            }
            Main.test[id - 1].point = this.Location;
            Main.test[id - 1].Show();
            this.Close();
        }
        private void DOWN_Click(object sender, EventArgs e)
        {
            bool ISChoice = false;
            foreach (var item in AnswerButton)
            {
                if (item.Checked)
                {
                    ISChoice = true;
                    question.choice = item.Text;
                    if (item.Text == question.Q_RIGHT)
                    {
                        question.right = true;
                        question.Score = question.Q_SCORE;
                    }
                    else
                    {
                        question.right = false;
                        question.Score = 0;
                    }
                }
            }
            if (Main.LEARNMODE && question.ISLearnModeError)
            {
                question.choice = question.ErrorAndChoice;
                question.Score = 0;
            }
            if (!ISChoice)
            {
                MessageBox.Show("你还没有答题");
                return;
            }
            if (id == Main.test.Count - 1)
            {
                if (Main.LEARNMODE && !question.right)
                {
                    if (question.ISLearnModeError) return;
                    question.ErrorAndChoice = question.choice;
                    Title.ForeColor = Color.Red;
                    string[] Rmchoice = question.Q_RIGHT.Split(',');
                    string tip = "正确答案：\n";
                    foreach (var Rsingle in Rmchoice)
                    {
                        tip += Rsingle + "\n";
                    }
                    int line = tip.Split('\n').Length;
                    line += Tools.TextLineValue(tip, 26);
                    Label LearnTip = new Label
                    {
                        Font = new Font("黑体", 12f),
                        Size = new Size(442, 20 + line-- * 20),
                        Location = new Point(InitPosX, InitPosY + 70)

                    };
                    LearnTip.Text = tip;
                    InitPosY += 30;         //下一个控件的位置加多少
                    Controls.Add(LearnTip);
                    this.Size = new Size(this.Size.Width, this.Size.Height + 40 + line * 10);
                    question.ISLearnModeError = true;
                    return;
                }
                if (question.ErrorAndNext)
                {
                    question.choice = question.ErrorAndChoice;
                }
                if (question.ISLearnModeError)
                {
                    question.right = false;
                    question.ErrorAndNext = true;
                }
                DoneTest Done = new DoneTest(Main.test);
                Done.Show();
                this.Close();
            }
            else
            {
                if (Main.LEARNMODE && !question.right)
                {
                    if (question.ISLearnModeError) return;
                    question.ErrorAndChoice = question.choice;
                    Title.ForeColor = Color.Red;
                    string[] Rmchoice = question.Q_RIGHT.Split(',');
                    string tip = "正确答案：\n";
                    foreach (var Rsingle in Rmchoice)
                    {
                        tip += Rsingle + "\n";
                    }
                    int line = tip.Split('\n').Length;
                    line += Tools.TextLineValue(tip, 26);
                    Label LearnTip = new Label
                    {
                        Font = new Font("黑体", 12f),
                        Size = new Size(442, 20 + line-- * 20),
                        Location = new Point(InitPosX, InitPosY + 70)

                    };
                    LearnTip.Text = tip;
                    InitPosY += 30;         //下一个控件的位置加多少
                    Controls.Add(LearnTip);
                    this.Size = new Size(this.Size.Width, this.Size.Height + 40 + line * 10);
                    question.ISLearnModeError = true;
                    return;
                }
                if (question.ErrorAndNext)
                {
                    question.choice = question.ErrorAndChoice;
                }
                if (question.ISLearnModeError)
                {
                    question.right = false;
                    question.ErrorAndNext = true;
                }
                Main.test[id + 1].point = this.Location;
                Main.test[id + 1].Show();
                this.Close();
            }
        }
        private void CloseForm(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定结束考试吗？", "结束考试", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DoneTest Done = new DoneTest(Main.test);
                Done.Show();
                this.Close();
            }
        }
    }
}
