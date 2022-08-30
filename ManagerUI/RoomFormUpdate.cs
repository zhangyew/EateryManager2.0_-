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
    public partial class RoomFormUpdate : Form
    {
        public RoomFormUpdate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 房间编号
        /// </summary>
        public string id { set; get; }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

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


            bool r = bll.UpdateRoom(name, xf, rs, dz,id);
            if (r)
            {
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (RoomForm.roomForm != null)
                {
                    RoomForm.roomForm.LookingRoom();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }
        /// <summary>
        /// 加载信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomFormUpdate_Load(object sender, EventArgs e)
        {
            RoomType_BLL bll = new RoomType_BLL();

            foreach (var item in bll.LookRomm(id))
            {
                txtMC.Text = item.RTName;
                txtRS.Text = item.RTNum.ToString();
                txtXF.Text = item.RTMin.ToString();
                if (item.RTIsDis == true)
                {
                    cbDZ.Checked = true;
                }
                else
                {
                    cbDZ.Checked = false;
                }
            }
        }
    }
}
