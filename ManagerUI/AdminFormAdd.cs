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
    public partial class AdminFormAdd : Form
    {
        public AdminFormAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        Admins_BLL bll = new Admins_BLL();

        private void button2_Click(object sender, EventArgs e)
        {
            string yhm = txtYHM.Text;
            string pwd = txtPWD.Text;
            string pwd2 = txtPWD2.Text;
            string name = txtName.Text;

            if (string.IsNullOrEmpty(yhm) ||
                string.IsNullOrEmpty(pwd) ||
                string.IsNullOrEmpty(pwd2) ||
                string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }
            if (!pwd.Equals(pwd2))
            {
                MessageBox.Show("两次密码不一致，请重新输入!");
                return;
            }

            Admins a = new Admins();
            a.UserName = yhm;
            a.TrueName = name;
            a.UserPwd = pwd;
            if (bll.Add(a) != 0)
            {
                 MessageBox.Show("管理员添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (SystemForm.systemForm != null)
                {
                    SystemForm.systemForm.LookingAdmins();
                }
            }
            else
            {
                MessageBox.Show("管理员添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }


        }
    }
}
