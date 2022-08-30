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
    public partial class VGradeFormUpdate : Form
    {
        public VGradeFormUpdate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 等级编号
        /// </summary>
        public string id { set; get; }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        VipGrade_BLL bll = new VipGrade_BLL();
        private void VGradeFormUpdate_Load(object sender, EventArgs e)
        {
            VipGrade v = new VipGrade();
            v= bll.GetModel(Convert.ToInt32(id));
            txtDJ.Text = (v.VGDiscount).ToString();
            txtMC.Text = v.VGName;
        }

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
            v.VGDiscount = double.Parse(dj);
            v.VGID = Convert.ToInt32(id);

            if (bll.Update(v) == true)
            {
                MessageBox.Show("等级修改成功！");
                if (SystemForm.systemForm != null)
                {
                    SystemForm.systemForm.LookingVIP();
                }
            }
            else
            {
                MessageBox.Show("等级修改失败！");
            }
        }
    }
}
