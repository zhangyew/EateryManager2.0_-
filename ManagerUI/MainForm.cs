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
    public partial class MainForm : Form
    {
        public static MainForm mainForm;
        public MainForm()
        {
            InitializeComponent();
            mainForm = this;
        }

        private void 退出系统ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            looking();
            try
            {
                //绑定房间类型
                BinRoomType();
            }
            catch (Exception ex)
            {
                //错误提示
                MessageBox.Show("程序执行中发生错误，错误信息为：" + ex.Message, "程序发生错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 显示餐台基本信息
        /// </summary>
        private void looking()
        {
            Tables_BLL bll = new Tables_BLL();

            int zs= bll.Looking();

            lblzd.Text =zs.ToString();
            int kg = bll.JiSuang(0);
            lblkg.Text = kg.ToString();
            int kgg = bll.JiSuang(1);
            lblyd.Text = bll.JiSuang(2).ToString();
            lbldy.Text = bll.JiSuang(3).ToString();
            int dd = zs / kg;
            lblky.Text = kgg.ToString();
            lblszl.Text = dd.ToString() + "%";
        }

        /// <summary>
        /// 绑定房间类型
        /// </summary>
        public void BinRoomType()
        {
            //清除所有控件
            pMax.Controls.Clear();
            RoomType_BLL bll = new RoomType_BLL();
            //动态创建Tap控件
            TabControl tap = new TabControl();
            //将Tap控件添加到面板中
            pMax.Controls.Add(tap);
            //让Tap控件默认填充全部
            tap.Dock = DockStyle.Fill;

            foreach (var item in bll.RoomTypes())
            {
                TabPage page = new TabPage();
                page.Text = item.RTName;
                page.Tag = item.RTID;
                //将创建出来的选项卡添加到Tap控件中
                tap.TabPages.Add(page);
                //根据房间类型编号绑定餐台信息
                BinTables(item.RTID,page);
            }
        }

        /// <summary>
        /// 根据房间类型编号绑定餐台信息
        /// </summary>
        /// <param name="rtid">房间编号</param>
        /// <param name="page">需要添加的选项卡</param>
        public void BinTables(int rtid, TabPage page)
        {
            ListView lvTable = new ListView();
            //绑定图片
            lvTable.LargeImageList = lvImg;
            lvTable.SmallImageList = ImgMin;
            lvTable.ContextMenuStrip = cmsRight;

            //绑定点击事件
            lvTable.Click += LvTable_Click;
            //绑定双击事件
            lvTable.DoubleClick += LvTable_DoubleClick;
            Tables_BLL bll = new Tables_BLL();
            foreach (var item in bll.RoomTypes(rtid,TableState))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Tag = item.TableID;
                lvi.Text = item.TableName;
                lvi.ImageIndex = Convert.ToInt32(item.TableState);
                lvTable.Items.Add(lvi);
            }
            //将创建出来的ListView控件添加到选项卡中
            page.Controls.Add(lvTable);
            lvTable.Dock = DockStyle.Fill;
            lvTable.View = View.LargeIcon;
            if (VieMode == -1)
                lvTable.View = View.LargeIcon;
            else
                lvTable.View = View.SmallIcon;

        }
        /// <summary>
        /// LV双击点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LvTable_DoubleClick(object sender, EventArgs e)
        {
            if ((sender as ListView).SelectedItems.Count > 0)
            {
                int staus = (sender as ListView).SelectedItems[0].ImageIndex;//餐台状态
                TalbId = (int)(sender as ListView).SelectedItems[0].Tag;//获取点击餐台编号
                switch (staus)
                {
                    case 0:
                        //开单
                       // CustomerBilling tj = new CustomerBilling();
                        //tj.Id = TalbId.ToString();
                        //tj.ShowDialog();
                        break;
                    case 1:
                        //增加消费
                       // AddConsume g = new AddConsume();
                       // g.id = TalbId.ToString();
                       // g.ShowDialog();
                        break;
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        //AddStateFrom x = new AddStateFrom();
                       // x.id = TalbId.ToString();
                       // x.Show();
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// LV单击点击事件 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LvTable_Click(object sender, EventArgs e)
        {
            // 当用户点击LV控件之后，更改右键菜单的可用状态
            if ((sender as ListView).SelectedItems.Count > 0)
            {
                cmsRight.Items[0].Enabled = false;
                cmsRight.Items[1].Enabled = false;
                cmsRight.Items[2].Enabled = false;
                cmsRight.Items[3].Enabled = false;
                cmsRight.Items[4].Enabled = false;
                cmsRight.Items[6].Enabled = false;

                int staus = (sender as ListView).SelectedItems[0].ImageIndex;//餐台状态
                TalbId = (int)(sender as ListView).SelectedItems[0].Tag;//获取点击餐台编号

                switch (staus)
                {
                    case 0:
                        cmsRight.Items[0].Enabled = true;//开单
                        cmsRight.Items[3].Enabled = true;//预订
                        cmsRight.Items[6].Enabled = true;//状态

                        break;
                    case 1:
                        cmsRight.Items[2].Enabled = true;//结账
                        cmsRight.Items[1].Enabled = true;//消费
                        cmsRight.Items[4].Enabled = true;//更换
                        break;
                    case 2:
                        cmsRight.Items[0].Enabled = true;//开单
                        cmsRight.Items[6].Enabled = true;//状态
                        break;
                    case 3:
                    case 4:
                    case 5:
                        cmsRight.Items[6].Enabled = true;//状态
                        break;
                }
            }

        }
        #region
        /// <summary>
        /// 餐台状态
        /// </summary>
        private int TableState = -1;
        /// <summary>
        /// 显示模式
        /// </summary>
        private int VieMode = -1;
        /// <summary>
        /// 餐台编号
        /// </summary>
        private int TalbId = -1;
        /// <summary>
        /// lv的坐标
        /// </summary>
        public int Xpos, Ypos;

        #endregion
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (TableState == 0)
                return;
            TableState = 0;
            BinRoomType();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (TableState == 1)
                return;
            TableState = 1;
            BinRoomType();
        }

        private void 显示脏台ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VieMode == -1)
                return;
            VieMode = -1;
            BinRoomType();
        }

        private void 小图标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (VieMode == 0)
                return;
            VieMode = 0;
            BinRoomType();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            RoomForm tj = new RoomForm();
            tj.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SystemSettingsFrom tj = new SystemSettingsFrom();
            tj.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            VipManagerForm tj = new VipManagerForm();
            tj.ShowDialog();
        }

        private void butJD_Click(object sender, EventArgs e)
        {
            Tables_BLL bll = new Tables_BLL();
            //餐台装填为可用时进行操作
            if (bll.CanTaiZT(TalbId.ToString()) == 0)
            {
                OpenForm tj = new OpenForm();
                tj.id = TalbId.ToString();
                tj.ShowDialog();
            }

        }

        private void 顾客开单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenForm tj = new OpenForm();
            tj.id = TalbId.ToString();
            tj.ShowDialog();
        }

        private void 增加消费ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddConsume g = new AddConsume();
            g.id = TalbId.ToString();
            g.ShowDialog();
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (TableState == -1)
                return;
            TableState = -1;
            BinRoomType();
        }
    }
}
