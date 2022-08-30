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
    public partial class FromLodaing : Form
    {
        public FromLodaing()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mm = txtMM.Text;
            string yhm = cboMC.Text;

            Admins stu = new Admins()
            {
                UserName = yhm,
                UserPwd = mm 
            };
            Admins_BLL bll = new Admins_BLL();
            bool res = bll.CheckUserInfo(stu);
            if (res)
            {
                MessageBox.Show("登陆成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MainForm tj = new MainForm();
                this.Hide();
                tj.ShowDialog();
            }
            else
            { 
                MessageBox.Show("登陆失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void FromLodaing_Load(object sender, EventArgs e)
        {
            Admins_BLL bll = new Admins_BLL();
            cboMC.ValueMember = "UserID";
            cboMC.DisplayMember = "UserName";
            //DataTable table = bll.QuanXian;
            List<Admins> list = bll.Quanxian().ToList();
            cboMC.DataSource = list;
        }
    }
}
