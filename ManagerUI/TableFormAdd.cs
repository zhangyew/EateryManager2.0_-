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
    public partial class TableFormAdd : Form
    {
        public TableFormAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TableFormAdd_Load_1(object sender, EventArgs e)
        {
            //绑定下拉框
            Tables_BLL bll = new Tables_BLL();
            cboLX.ValueMember = "RTID";
            cboLX.DisplayMember = "RTName";
            List<RoomType> list = bll.FanJian().ToList();
            cboLX.DataSource = list;
        }
        /// <summary>
        /// 添加餐桌
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string name = txtMC.Text;
            string qy = txtQY.Text;
            int lx = (int)cboLX.SelectedValue;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(qy))
            {
                MessageBox.Show("请输入完整信息！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            Tables_BLL bll = new Tables_BLL();

            if (bll.Repeat(name) > 0)
            {
                MessageBox.Show("房间名相同重复，请重新输入！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            bool r = bll.AddTables(name, lx, qy);
            if (r)
            {
                MessageBox.Show("添加成功！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (RoomForm.roomForm != null)
                {
                    RoomForm.roomForm.LookingTables();
                }
                if (MainForm.mainForm != null)
                {
                    MainForm.mainForm.BinRoomType();
                }
            }
            else
            {
                MessageBox.Show("添加失败！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        }
    }
}
