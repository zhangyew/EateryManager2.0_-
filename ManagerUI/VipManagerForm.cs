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
    public partial class VipManagerForm : Form
    {
        public static VipManagerForm vipManagerForm;
        public VipManagerForm()
        {
            InitializeComponent();
            vipManagerForm = this;
        }

        private void VipManagerForm_Load(object sender, EventArgs e)
        {
            Looking();
            ChangeListViewColor(lvVIP);
        }
        Vips_BLL bll = new Vips_BLL();

        /// 隔行变色   应用隔行变色
        /// </summary> 
        /// <param name="listView">需要隔行变色的ListView控件名称</param>
        private void ChangeListViewColor(ListView listView)
        {
            listView.OwnerDraw = true;
            listView.DrawColumnHeader += ListView_DrawColumnHeader;
            listView.DrawSubItem += ListView_DrawSubItem;
        }

        /// <summary>
        /// 绘制表头[避免表头消失]
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawText(TextFormatFlags.Default);
        }

        /// <summary>
        /// 绘制隔行变色列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                //选中时的颜色
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(198, 219, 181)), e.Bounds);
            }
            else
            {
                //其他列执行隔行变色
                if (e.ItemIndex % 2 == 0)
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(239, 255, 231)), e.Bounds);
                else
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 255)), e.Bounds);
            }
            e.DrawText(TextFormatFlags.Default);
        }

        /// <summary>
        /// 显示会员信息
        /// </summary>
        public void Looking()
        {
            lvVIP.Items.Clear();
            string x = txtCX.Text;
            foreach (var item in bll.Looking(x))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.VipID.ToString();
                lvi.SubItems.AddRange(
                    new[]
                    {
                        item.VipName.ToString(),
                        item.VipSex,
                        item.VGID,
                        item.VGDiscount.ToString("f2"),
                        item.VipTel,
                        item.VipStartDate.ToString(),
                        item.VipEndDate.ToString()
                    }
                    );
                lvVIP.Items.Add(lvi);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Looking();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            VipFormAddUpdate tj = new VipFormAddUpdate();
            tj.Magical = 0;
            tj.ShowDialog();
        }
        /// <summary>
        /// 删除会员信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (lvVIP.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvVIP.SelectedItems[0].SubItems[0].Text;
            DialogResult result = MessageBox.Show("确定删除该消息吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == result)
            {
                bool r = bll.DeleteType(id);
                if (r)
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Looking();
                }
                else
                {
                    MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (lvVIP.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvVIP.SelectedItems[0].SubItems[0].Text;
            VipFormAddUpdate tj = new VipFormAddUpdate();
            tj.id = id;
            tj.Magical = 1;
            tj.ShowDialog();
        }
    }
}
