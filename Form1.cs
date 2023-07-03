using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineTranslator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (origin.Text != "")
            {
                BaiduAPI api = new BaiduAPI();
                string[] temp = origin.Text.Split(' ');
                string res = "";
                foreach (string a in temp)
                {
                    res += api.Translate(a.Trim());
                    if (a.Contains("\r\n"))
                    {
                        res += "\r\n";
                    }                    
                }
                result.Text = res;
                
            }
            else
            {
                MessageBox.Show("请输入内容再点击此按钮!", "6", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
