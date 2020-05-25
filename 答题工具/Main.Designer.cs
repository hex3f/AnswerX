namespace 答题工具
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.HomePage = new System.Windows.Forms.TabPage();
            this.About = new System.Windows.Forms.TabPage();
            this.LearningMode = new System.Windows.Forms.CheckBox();
            this.AllCount = new System.Windows.Forms.Label();
            this.TESTCOUNT = new System.Windows.Forms.TextBox();
            this.qcount = new System.Windows.Forms.Label();
            this.FileList = new System.Windows.Forms.CheckedListBox();
            this.UnOrderChoice = new System.Windows.Forms.CheckBox();
            this.UnOrderTest = new System.Windows.Forms.CheckBox();
            this.Start = new System.Windows.Forms.Button();
            this.Introduce = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.AboutText = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.HomePage.SuspendLayout();
            this.About.SuspendLayout();
            this.Introduce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.HomePage);
            this.tabControl1.Controls.Add(this.Introduce);
            this.tabControl1.Controls.Add(this.About);
            this.tabControl1.Location = new System.Drawing.Point(7, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(505, 289);
            this.tabControl1.TabIndex = 12;
            // 
            // HomePage
            // 
            this.HomePage.Controls.Add(this.Start);
            this.HomePage.Controls.Add(this.LearningMode);
            this.HomePage.Controls.Add(this.AllCount);
            this.HomePage.Controls.Add(this.TESTCOUNT);
            this.HomePage.Controls.Add(this.qcount);
            this.HomePage.Controls.Add(this.FileList);
            this.HomePage.Controls.Add(this.UnOrderChoice);
            this.HomePage.Controls.Add(this.UnOrderTest);
            this.HomePage.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.HomePage.Location = new System.Drawing.Point(4, 22);
            this.HomePage.Name = "HomePage";
            this.HomePage.Padding = new System.Windows.Forms.Padding(3);
            this.HomePage.Size = new System.Drawing.Size(497, 263);
            this.HomePage.TabIndex = 0;
            this.HomePage.Text = "主程序";
            this.HomePage.UseVisualStyleBackColor = true;
            // 
            // About
            // 
            this.About.Controls.Add(this.label1);
            this.About.Controls.Add(this.pictureBox1);
            this.About.Controls.Add(this.AboutText);
            this.About.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.About.Location = new System.Drawing.Point(4, 22);
            this.About.Name = "About";
            this.About.Padding = new System.Windows.Forms.Padding(3);
            this.About.Size = new System.Drawing.Size(497, 263);
            this.About.TabIndex = 1;
            this.About.Text = "关于";
            this.About.UseVisualStyleBackColor = true;
            // 
            // LearningMode
            // 
            this.LearningMode.AutoSize = true;
            this.LearningMode.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LearningMode.Location = new System.Drawing.Point(400, 159);
            this.LearningMode.Name = "LearningMode";
            this.LearningMode.Size = new System.Drawing.Size(91, 20);
            this.LearningMode.TabIndex = 20;
            this.LearningMode.Text = "练习模式";
            this.LearningMode.UseVisualStyleBackColor = true;
            // 
            // AllCount
            // 
            this.AllCount.AutoSize = true;
            this.AllCount.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AllCount.Location = new System.Drawing.Point(4, 160);
            this.AllCount.Name = "AllCount";
            this.AllCount.Size = new System.Drawing.Size(120, 16);
            this.AllCount.TabIndex = 19;
            this.AllCount.Text = "还没有选择试卷";
            // 
            // TESTCOUNT
            // 
            this.TESTCOUNT.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TESTCOUNT.Location = new System.Drawing.Point(425, 185);
            this.TESTCOUNT.Name = "TESTCOUNT";
            this.TESTCOUNT.Size = new System.Drawing.Size(66, 29);
            this.TESTCOUNT.TabIndex = 16;
            this.TESTCOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TESTCOUNT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TESTCOUNT_KeyPress);
            // 
            // qcount
            // 
            this.qcount.AutoSize = true;
            this.qcount.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qcount.Location = new System.Drawing.Point(331, 191);
            this.qcount.Name = "qcount";
            this.qcount.Size = new System.Drawing.Size(88, 16);
            this.qcount.TabIndex = 18;
            this.qcount.Text = "题目数量：";
            // 
            // FileList
            // 
            this.FileList.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FileList.FormattingEnabled = true;
            this.FileList.Location = new System.Drawing.Point(6, 6);
            this.FileList.Name = "FileList";
            this.FileList.Size = new System.Drawing.Size(485, 151);
            this.FileList.TabIndex = 17;
            this.FileList.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.FileList_ItemCheck_1);
            this.FileList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FileList_MouseUp);
            // 
            // UnOrderChoice
            // 
            this.UnOrderChoice.AutoSize = true;
            this.UnOrderChoice.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UnOrderChoice.Location = new System.Drawing.Point(206, 159);
            this.UnOrderChoice.Name = "UnOrderChoice";
            this.UnOrderChoice.Size = new System.Drawing.Size(91, 20);
            this.UnOrderChoice.TabIndex = 15;
            this.UnOrderChoice.Text = "随机选项";
            this.UnOrderChoice.UseVisualStyleBackColor = true;
            // 
            // UnOrderTest
            // 
            this.UnOrderTest.AutoSize = true;
            this.UnOrderTest.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.UnOrderTest.Location = new System.Drawing.Point(303, 159);
            this.UnOrderTest.Name = "UnOrderTest";
            this.UnOrderTest.Size = new System.Drawing.Size(91, 20);
            this.UnOrderTest.TabIndex = 14;
            this.UnOrderTest.Text = "随机题目";
            this.UnOrderTest.UseVisualStyleBackColor = true;
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Start.Location = new System.Drawing.Point(392, 224);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(100, 30);
            this.Start.TabIndex = 21;
            this.Start.Text = "开始答题";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Introduce
            // 
            this.Introduce.Controls.Add(this.richTextBox1);
            this.Introduce.Location = new System.Drawing.Point(4, 22);
            this.Introduce.Name = "Introduce";
            this.Introduce.Size = new System.Drawing.Size(497, 263);
            this.Introduce.TabIndex = 2;
            this.Introduce.Text = "使用说明";
            this.Introduce.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("黑体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.Location = new System.Drawing.Point(3, 3);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(491, 257);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // AboutText
            // 
            this.AboutText.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.AboutText.Location = new System.Drawing.Point(3, 72);
            this.AboutText.Name = "AboutText";
            this.AboutText.ReadOnly = true;
            this.AboutText.Size = new System.Drawing.Size(491, 188);
            this.AboutText.TabIndex = 2;
            this.AboutText.Text = "AnswerX\n软件版本：1.0.0\n软件作者：hex3f\n联系方式：hex3f@outlook.com\n开发语言：C#\n框架：.NET Framework 4\n" +
    "软件开源地址：github.com/hex3f/AnswerX\n本软件遵循CC BY 4.0协议";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AnswerX.Properties.Resources.answerX;
            this.pictureBox1.Location = new System.Drawing.Point(6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(72, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "AnswerX";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 300);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "AnswerX";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.HomePage.ResumeLayout(false);
            this.HomePage.PerformLayout();
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            this.Introduce.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage HomePage;
        private System.Windows.Forms.TabPage About;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.CheckBox LearningMode;
        private System.Windows.Forms.Label AllCount;
        private System.Windows.Forms.TextBox TESTCOUNT;
        private System.Windows.Forms.Label qcount;
        private System.Windows.Forms.CheckedListBox FileList;
        private System.Windows.Forms.CheckBox UnOrderChoice;
        private System.Windows.Forms.CheckBox UnOrderTest;
        private System.Windows.Forms.TabPage Introduce;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox AboutText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

