using EateryManager.BLL;
using EateryManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagerUI
{
    public partial class VGradeFormAdd : Form
    {
        public VGradeFormAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        VipGrade_BLL bll = new VipGrade_BLL();
        private void button2_Click(object sender, EventArgs e)
        {
            string mc = txtMC.Text;
            string dj = txtDJ.Text;

            if (string.IsNullOrEmpty(mc) ||
                string.IsNullOrEmpty(dj))
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }

            VipGrade v = new VipGrade();

            v.VGName = mc;
            v.VGDiscount =double.Parse(dj);

            if (bll.Add(v)!=0)
            {
                MessageBox.Show("等级添加成功！");
                if (SystemForm.systemForm != null)
                {
                    SystemForm.systemForm.LookingVIP();
                }
            }
            else
            {
                MessageBox.Show("等级添加失败！");
            }
        }
    }
}
