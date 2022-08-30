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
    public partial class VipFormAddUpdate : Form
    {
        public VipFormAddUpdate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 会员编号
        /// </summary>
        public string id { set; get; }

        /// <summary>
        /// 窗口状态 0 = 添加 / 1 = 修改
        /// </summary>
        public int Magical { set; get; }

        Vips_BLL bll = new Vips_BLL();
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VipFormAddUpdate_Load(object sender, EventArgs e)
        {
            //绑定下拉框
            cboDJ.ValueMember = "VGID";
            cboDJ.DisplayMember = "VGName";
            List<VipGrade> list = bll.Quanxian().ToList();
            cboDJ.DataSource = list;
            cboXB.SelectedIndex = 0;

            //获取最大编号
            int y = bll.LookMIX();
            if (Magical == 0)
            {
                txtBH.Text = (y + 1).ToString();
            }
            //状态为1时显示需要修改的信息
            if (Magical == 1)
            {
                Vips v = new Vips();
                v = bll.GetModel(Convert.ToInt32(id));
                txtBH.Text = v.VipID.ToString();
                txtXM.Text = v.VipName;
                txtDH.Text = v.VipTel;
                cboXB.Text = v.VipSex;
                cboDJ.SelectedValue =Convert.ToInt32(v.VGID);
            }
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //获取信息
            string xm = txtXM.Text;
            string dh = txtDH.Text;
            int dj = (int)cboDJ.SelectedValue;
            string xb = cboXB.Text;
            //非空验证
            if (
                    string.IsNullOrEmpty(xm) ||
                    string.IsNullOrEmpty(dh) ||
                    string.IsNullOrEmpty(xb))
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }
            //填充数据
            Vips v = new Vips();
            v.VipName = xm;
            v.VipTel = dh;
            v.VGID = dj.ToString();
            v.VipSex = xb;
            v.VipEndDate = dtpRQ.Value;
            v.VipID =Convert.ToInt32(id);
            //状态为0 即为新增
            if (Magical == 0)
            {
                if (bll.Add(v) != 0)
                {
                    MessageBox.Show("会员添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    if (VipManagerForm.vipManagerForm != null)
                    {
                        VipManagerForm.vipManagerForm.Looking();
                    }
                }
                else
                {
                    MessageBox.Show("会员添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            //状态为1 即为修改
            if (Magical == 1)
            {
                if (bll.Update(v)==true)
                {
                    MessageBox.Show("会员信息修改成功！");
                    if (VipManagerForm.vipManagerForm != null)
                    {
                        VipManagerForm.vipManagerForm.Looking();
                    }
                }
                else
                {
                    MessageBox.Show("会员信息修改失败！");
                    return;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
