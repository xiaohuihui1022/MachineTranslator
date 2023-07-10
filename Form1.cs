using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (origin.Text != "")
            {
                Thread thread = new Thread(translator);
                thread.IsBackground = true;
                // 开启线程
                thread.Start();
            }
            else
            {
                MessageBox.Show("请输入内容再点击此按钮!", "6", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void translator()
        {
            BaiduAPI api = new BaiduAPI();
            string[] temp = origin.Text.Split(' ');
            string res = "";
            foreach (string a in temp)
            {
                status.Text = "正在翻译：" + a;
                res += api.Translate(a.Trim());
                if (a.Contains("\r\n"))
                {
                    res += "\r\n";
                }
            }
            result.Text = res;
            status.Text = "翻译完成。";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
