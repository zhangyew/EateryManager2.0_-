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
    public partial class TableFormUpdate : Form
    {
        public TableFormUpdate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 餐台编号
        /// </summary>
        public string id { set; get; }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TableFormUpdate_Load(object sender, EventArgs e)
        {
            //绑定下拉框
            Tables_BLL bll = new Tables_BLL();
            cboLX.ValueMember = "RTID";
            cboLX.DisplayMember = "RTName";
            List<RoomType> list = bll.FanJian().ToList();
            cboLX.DataSource = list;

            // 显示修改信息
            foreach (var item in bll.LookRomm(id))
            {
                txtMC.Text = item.TableName;
                txtQY.Text = item.TableArea;
                cboLX.SelectedValue = Convert.ToInt32(item.RTID);
            }
        }
        /// <summary>
        /// 修改信息
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



            bool r = bll.UpdateTable(name, lx, qy, id);
            if (r)
            {
                MessageBox.Show("修改成功！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (RoomForm.roomForm != null)
                {
                    RoomForm.roomForm.LookingTables();
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("修改失败！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }




    }
}
