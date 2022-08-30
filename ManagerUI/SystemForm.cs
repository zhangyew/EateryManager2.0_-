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
    public partial class SystemForm : Form
    {
        public static SystemForm systemForm;
        public SystemForm()
        {
            InitializeComponent();
            systemForm = this;
        }

        private void SystemForm_Load(object sender, EventArgs e)
        {
            LookingAdmins();
            LookingVIP();
            ChangeListViewColor(lvGLY);
            ChangeListViewColor(lvVIP);
        }

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


        Admins_BLL bll = new Admins_BLL();
        VipGrade_BLL _bll = new VipGrade_BLL();
        /// <summary>
        /// 显示会员管理信息
        /// </summary>
        public void LookingVIP()
        {
            lvVIP.Items.Clear();
            foreach (var item in _bll.Looking())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.VGID.ToString();
                lvi.SubItems.Add(item.VGName.ToString());
                double d = double.Parse(item.VGDiscount.ToString());
                lvi.SubItems.Add(d.ToString("f2"));
                lvVIP.Items.Add(lvi);
            }

        }

        /// <summary>
        /// 显示管理员信息
        /// </summary>
        public void LookingAdmins()
        {
            lvGLY.Items.Clear();
            foreach (var item in bll.Looking())
            {
                ListViewItem lvi = new ListViewItem();
                //lvi.Text = item.UserID.ToString();
                lvi.SubItems.Add(item.UserID.ToString());
                lvi.SubItems.Add(item.TrueName);
                lvGLY.Items.Add(lvi);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminFormAdd tj = new AdminFormAdd();
            tj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvGLY.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvGLY.SelectedItems[0].SubItems[1].Text;
            AdminFormUpdate tj = new AdminFormUpdate();
            tj.id = id;
            tj.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            VGradeFormAdd tj = new VGradeFormAdd();
            tj.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (lvVIP.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvVIP.SelectedItems[0].SubItems[0].Text;
            VGradeFormUpdate tj = new VGradeFormUpdate();
            tj.id = id;
            tj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lvGLY.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvGLY.SelectedItems[0].SubItems[1].Text;
            DialogResult result = MessageBox.Show("确定删除该消息吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == result)
            {
                Admins_BLL bll = new Admins_BLL();
                bool r = bll.DeleteType(id);
                if (r)
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LookingAdmins();
                    LookingVIP();
                }
                else
                {
                    MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
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
                VipGrade_BLL bll = new VipGrade_BLL();
                bool r = bll.DeleteType(id);
                if (r)
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LookingAdmins();
                    LookingVIP();
                }
                else
                {
                    MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

        }
    }
}
