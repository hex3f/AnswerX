using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ThirdParty.Json.LitJson;

namespace 答题工具
{
    public partial class Main : Form
    {
        public static List<Question> test = new List<Question>();
        public static List<List<Question>> ITEMTest = new List<List<Question>>();
        public static List<Question> READYTest = new List<Question>();
        public Dictionary<string, List<Question>> TestList = new Dictionary<string, List<Question>>();
        public static List<Question> WrongTest = new List<Question>();
        public int WrongQuestion = 0;
        public int Score = 0;
        public static bool LEARNMODE = false;
        private IniFiles ini;
        private int ERRORFile = 0;
        public static Dictionary<string, List<Question>> ALLTEST = new Dictionary<string, List<Question>>();

        private void Form1_Load(object sender, EventArgs e)
        {
            ///配置文件
            ini = new IniFiles(Application.StartupPath + @"\Config.ini");

            if (ini.ExistINIFile())
            {
                try
                {
                    this.Location = new Point(Convert.ToInt32(ini.IniReadValue("CONFIG", "LocationX")), Convert.ToInt32(ini.IniReadValue("CONFIG", "LocationY")));
                    this.UnOrderChoice.Checked = Convert.ToBoolean(ini.IniReadValue("CONFIG", "UnOrderChoice"));
                    this.UnOrderTest.Checked = Convert.ToBoolean(ini.IniReadValue("CONFIG", "UnOrderTest"));
                    this.LearningMode.Checked = Convert.ToBoolean(ini.IniReadValue("CONFIG", "LearnMode"));
                    this.TESTCOUNT.Text = ini.IniReadValue("CONFIG", "TESTCOUNT");
                }
                catch (Exception)
                {
                    MessageBox.Show("读取Config.ini出错");
                }
            }
            else
            {
                Rectangle rec = Screen.GetWorkingArea(this);
                int SH = rec.Height;
                int SW = rec.Width;
                this.Location = new Point(SH / 2, SW / 2);
            }
            //读取路径下的信息
            DirectoryInfo folder = new DirectoryInfo(@"Question");//文件夹名为Question，放在软件根目录下
            //循环文件夹下指定文件的信息
            for (int i = 0; i < folder.GetFiles("*.json").Count(); i++)
            {
                try
                {
                    List<Question> ItemList = JsonMapper.ToObject<List<Question>>(File.ReadAllText("Question/" + folder.GetFiles("*.json")[i].Name));
                    TestList.Add(folder.GetFiles("*.json")[i].Name, ItemList);
                    FileList.Items.Add(folder.GetFiles("*.json")[i].Name);//在文件列表里添加卷子
                }
                catch (Exception)
                {
                    ERRORFile++;
                    MessageBox.Show("卷子内容出错 - " + folder.GetFiles("*.json")[i].Name);
                }
            }

            if (ERRORFile != 0)
            {
                this.Text = "答题器 - 捕获到" + ERRORFile + "张错误卷子";
            }
            else
            {
                this.Text = "AnswerX";
            }
        }
        private void STARTTEST(int _TESTCOUNT)
        {
            for (int i = 0; i < FileList.Items.Count; i++)
            {
                if (FileList.GetItemChecked(i))
                {
                    ITEMTest.Add(TestList[FileList.Items[i].ToString()]);
                }
            }
            foreach (var item in ITEMTest)
            {
                foreach (var item2 in item)
                {
                    READYTest.Add(item2);
                }
            }
            if (UnOrderTest.Checked)
            {
                string QuestionNumStand;
                string[] QuestionNum;
                if (_TESTCOUNT == 1)
                {
                    QuestionNumStand = Tools.RandomNum(_TESTCOUNT, 0, READYTest.Count);
                    QuestionNum = new string[1] { QuestionNumStand };
                }
                else
                {
                    QuestionNumStand = Tools.RandomNum(_TESTCOUNT, 0, READYTest.Count);
                    QuestionNum = QuestionNumStand.Split(',');
                }

                for (int i = 0; i < _TESTCOUNT; i++)
                {
                    try
                    {
                        test.Add(READYTest[Convert.ToInt32(QuestionNum[i])]);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(_TESTCOUNT.ToString());
                    }
                    test[i].ID = i;
                    test[i]._MAIN = this;
                    if (UnOrderChoice.Checked)
                    {
                        test[i].UnOrderChoice();
                    }
                }
            }
            else
            {
                if (!UnOrderTest.Checked)
                {
                    _TESTCOUNT++;
                    for (int i = 0; i < _TESTCOUNT - 1; i++)
                    {
                        test.Add(READYTest[i]);
                        test[i].ID = i;
                        test[i]._MAIN = this;
                        if (UnOrderChoice.Checked)
                        {
                            test[i].UnOrderChoice();
                        }
                    }
                }
            }
            test[0].Show();
        }
        public Main()
        {
            InitializeComponent();
        }
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            ini.IniWriteValue("CONFIG", "LocationX", this.Location.X.ToString());
            ini.IniWriteValue("CONFIG", "LocationY", this.Location.Y.ToString());
            ini.IniWriteValue("CONFIG", "UnOrderChoice", this.UnOrderChoice.Checked.ToString());
            ini.IniWriteValue("CONFIG", "UnOrderTest", this.UnOrderTest.Checked.ToString());
            ini.IniWriteValue("CONFIG", "LearnMode", this.LearningMode.Checked.ToString());
            ini.IniWriteValue("CONFIG", "LearnMode", this.LearningMode.Checked.ToString());
            ini.IniWriteValue("CONFIG", "TESTCOUNT", this.TESTCOUNT.Text);
        }
        private void Start_Click(object sender, EventArgs e)
        {
            LEARNMODE = LearningMode.Checked;//练习模式
            if (TESTCOUNT.Text == "")
            {
                MessageBox.Show("没有填写题目数量");
                return;
            }
            for (int i = 0; i < FileList.Items.Count; i++)
            {
                if (FileList.GetItemChecked(i))
                {
                    goto Start;
                }
            }
            MessageBox.Show("没有选择卷子");
            return;
        Start: if (Convert.ToInt32(TESTCOUNT.Text) <= READYTest.Count && Convert.ToInt32(TESTCOUNT.Text) != 0)
            {
                this.Enabled = false;
                STARTTEST(Convert.ToInt32(TESTCOUNT.Text));
            }
            else
            {
                MessageBox.Show("数量错误");
            }
        }
        private void TESTCOUNT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = false;
            //这是允许输入退格键
            if (e.KeyChar != '\b')
            {
                //这是允许输入0-9数字 
                if ((e.KeyChar < '0') || (e.KeyChar > '9'))
                {
                    e.Handled = true;
                    return;
                }
            }
        }
        private void FileList_MouseUp(object sender, MouseEventArgs e)
        {
            ITEMTest.Clear();
            READYTest.Clear();
            for (int i = 0; i < FileList.Items.Count; i++)
            {
                if (FileList.GetItemChecked(i))
                {
                    ITEMTest.Add(TestList[FileList.Items[i].ToString()]);
                }
            }
            foreach (var item in ITEMTest)
            {
                foreach (var item2 in item)
                {
                    READYTest.Add(item2);
                }
            }
            if (READYTest.Count == 0)
            {
                AllCount.Text = "还没有选择试卷";
            }
            else
            {
                AllCount.Text = "共有：" + READYTest.Count.ToString() + "题";
            }
        }
        private void FileList_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            ITEMTest.Clear();
            READYTest.Clear();
            for (int i = 0; i < FileList.Items.Count; i++)
            {
                if (FileList.GetItemChecked(i))
                {
                    ITEMTest.Add(TestList[FileList.Items[i].ToString()]);
                }
            }
            foreach (var item in ITEMTest)
            {
                foreach (var item2 in item)
                {
                    READYTest.Add(item2);
                }
            }
            AllCount.Text = READYTest.Count.ToString();
        }
    }
}
