using System;
using System.Collections.Generic;

namespace 答题工具
{
    class Tools
    {
        /// <summary>
        /// 判断字符串一行多少字有多少
        /// </summary>
        /// <param name="_TEXT"></param>
        /// <param name="_WORDCOUNT"></param>
        /// <returns></returns>
        public static int TextLineValue(string _TEXT, int _WORDCOUNT)
        {
            if (_TEXT.Length % _WORDCOUNT != 0)
            {
                return _TEXT.Length / _WORDCOUNT + 1;
            }
            return _TEXT.Length / _WORDCOUNT;
        }

        /// <summary>
        /// 生成随机数字串
        /// </summary>
        /// <param name="n"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public static string RandomNum(int _COUNT, int _MIN, int _MAX)
        {
            List<int> list = new List<int>();
            int[] numArry = new int[_COUNT];
            string NUM = "";
            for (int i = _MIN - 1; i < _MAX + 1; i++)
            {
                list.Add(i);
            }

            for (int i = 0; i < _COUNT; i++)
            {
                int n = new Random().Next(1, list.Count);
                numArry[i] = list[n];
                list.RemoveAt(n);
            }

            foreach (var item in numArry)
            {
                if (NUM == "")
                {
                    NUM += item;
                }
                else
                {
                    NUM += "," + item;
                }
            }
            return NUM;
        }
        /// <summary>
        /// 保存数据data到文件的处理过程；
        /// </summary>
        /// <param name="data"></param>
        public static String SavaProcess(string data)
        {
            System.DateTime currentTime = System.DateTime.Now;
            //获取当前日期的前一天转换成ToFileTime
            string strYMD = DateTime.Now.ToString("yyyy-MM-dd HH点mm分ss秒");
            //按照日期建立一个文件名
            string FileName = "错题 " + strYMD + ".json";
            //设置目录
            string CurDir = System.AppDomain.CurrentDomain.BaseDirectory + @"Question\";
            //判断路径是否存在
            if (!System.IO.Directory.Exists(CurDir))
            {
                System.IO.Directory.CreateDirectory(CurDir);
            }
            //不存在就创建
            String FilePath = CurDir + FileName;
            //文件覆盖方式添加内容
            System.IO.StreamWriter file = new System.IO.StreamWriter(FilePath, false);
            //保存数据到文件
            file.Write(data);
            //关闭文件
            file.Close();
            //释放对象
            file.Dispose();
            return FilePath;
        }
    }
}
