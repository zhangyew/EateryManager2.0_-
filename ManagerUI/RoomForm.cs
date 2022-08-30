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
    public partial class RoomForm : Form
    {
        public static RoomForm roomForm;
        public RoomForm()
        {
            InitializeComponent();
            roomForm = this;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 窗台加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoomForm_Load(object sender, EventArgs e)
        {
            //绑定下拉框
            RoomType_BLL bll = new RoomType_BLL();
            cboLX.ValueMember = "RTID";
            cboLX.DisplayMember = "RTName";
            List<RoomType> list = bll.Quanxian().ToList();
            cboLX.DataSource = list;


            LookingRoom();
            LookingTables();
            ChangeListViewColor(lvCT);
            ChangeListViewColor(lvFJ);
        }
        /// <summary>
        /// 显示餐台详情
        /// </summary>
        public void LookingTables()
        {
            int id = cboLX.SelectedIndex;
            lvCT.Items.Clear();
            Tables_BLL bll = new Tables_BLL();
            string xx = "";
            foreach (var item in bll.Looking(id))
            {
                if (item.TableState == 0)
                {
                    xx = "可用";
                }
                if (item.TableState == 1)
                {
                    xx = "占用";
                }
                if (item.TableState == 2)
                {
                    xx = "预订";
                }
                if (item.TableState == 3)
                {
                    xx = "停用";
                }
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.TableName.ToString();
                lvi.SubItems.AddRange
                    (
                    new[] {
                    item.RTID.ToString(),
                    xx,
                    item.TableArea.ToString(),
                    item.TableID.ToString()
                    }

                    );
                lvCT.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 显示房间类型
        /// </summary>
        public void LookingRoom()
        {
            lvFJ.Items.Clear();
            RoomType_BLL bll = new RoomType_BLL();
            foreach (var item in bll.Looking())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.RTID.ToString();
                lvi.SubItems.AddRange
                    (
                    new[] {
                    item.RTName.ToString(),
                    item.RTMin.ToString(),
                    item.RTIsDis==true?"打折":"不打折",
                    item.RTNum.ToString() }
                    );
                lvFJ.Items.Add(lvi);
            }
        }
        /// <summary>
        /// 根据选项显示信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboLX_SelectedIndexChanged(object sender, EventArgs e)
        {
            LookingTables();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RoomFormAdd tj = new RoomFormAdd();
            tj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvFJ.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvFJ.SelectedItems[0].SubItems[0].Text;
            RoomFormUpdate tj = new RoomFormUpdate();
            tj.id = id;
            tj.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TableFormAdd tj = new TableFormAdd();
            tj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lvCT.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvCT.SelectedItems[0].SubItems[4].Text;
            TableFormUpdate tj = new TableFormUpdate();
            tj.id = id;
            tj.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (lvFJ.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvFJ.SelectedItems[0].SubItems[0].Text;
            DialogResult result = MessageBox.Show("确定删除该消息吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == result)
            {
                RoomType_BLL bll = new RoomType_BLL();
                bool r = bll.DeleteRoom(id);
                if (r)
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LookingRoom();
                    LookingTables();
                }
                else
                {
                    MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lvCT.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvCT.SelectedItems[0].SubItems[4].Text;
            DialogResult result = MessageBox.Show("确定删除该消息吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == result)
            {
                Tables_BLL bll = new Tables_BLL();
                bool r = bll.DeleteRoom(id);
                if (r)
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LookingTables();
                }
                else
                {
                    MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
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

    }
}
