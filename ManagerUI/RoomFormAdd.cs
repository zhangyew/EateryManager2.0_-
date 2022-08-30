using EateryManager.BLL;
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
    public partial class RoomFormAdd : Form
    {
        public RoomFormAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 添加房间类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string name = txtMC.Text;
            decimal xf = decimal.Parse(txtXF.Text);
            int rs = Convert.ToInt32(txtRS.Text);
            bool dz;
            if (cbDZ.Checked)
            {
                dz = true;
            }
            else
            {
                dz = false;
            }

            if (txtMC.Text == null || txtRS.Text == null || txtXF.Text == null)
            {
                MessageBox.Show("请输入完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            RoomType_BLL bll = new RoomType_BLL();

            if (bll.Repeat(name) > 0)
            {
                MessageBox.Show("房间名相同重复，请重新输入！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            bool r = bll.AddRoom(name, xf, rs, dz);
            if (r)
            {
                MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (RoomForm.roomForm != null)
                {
                    RoomForm.roomForm.LookingRoom();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }
    }
}
