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
    public partial class AddConsume : Form
    {
        public AddConsume()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 餐台编号
        /// </summary>
        public string id { set; get; }
        private void label25_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddConsume_Load(object sender, EventArgs e)
        {
            //加载餐台对应基本信息
            LookingCT();
            //加载点单商品
            LookingDD();
            ChangeListViewColor(lvXX);
            ChangeListViewColor(lvDD);
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


        /// <summary>
        /// 加载点单商品
        /// </summary>
        private void LookingDD()
        {
            //获取最新订单编号
            string bh = bll.lookDingDanHao(id);
            lvDD.Items.Clear();
            int h = 0;
            foreach (var item in bll.LookDianDanCP(bh))
            {
                ListViewItem lvi = new ListViewItem();
                //获取序号
                for (int i = 0; i < 100;)
                {
                    h++;
                    lvi.Text = h.ToString();
                    break;
                }
                Double dj = Double.Parse(item.CDPrice.ToString());
                Double je = Double.Parse(item.CDMoney.ToString());
                lvi.SubItems.AddRange(new[] {
                item.name.ToString(),
                dj.ToString("f2"),
                item.CDNum.ToString(),
                je.ToString("f2"),
                item.CDDate.ToString(),
                item.LeiBie,
                item.ProductID.ToString()
                });
                lvDD.Items.Add(lvi);

               
            }
            try
            {
                double dc = bll.LookJE(id);
                lblJE.Text = dc.ToString("f2");

                int sl = bll.LookDD(id);
                lblSL.Text = sl.ToString();
            }
            catch (Exception)
            {
            }
           
        }

        /// <summary>
        /// 加载餐台对应基本信息
        /// </summary>
        private void LookingCT()
        {
            //餐台编号
            Tables_BLL bll = new Tables_BLL();
            txtBH.Text = bll.ChaXunCanTai(id);
            //绑定商品信息
            Products_BLL _bll = new Products_BLL();
            lvXX.Items.Clear();
            string mc = txtXM.Text;
            foreach (var item in _bll.Looking(0, mc))
            {
                Double x = Double.Parse(item.ProductPrice.ToString());
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.ProductID.ToString();
                lvi.SubItems.AddRange(new[]{
                 item.ProductName.ToString(),
                 x.ToString("f2"),
                 item.PTID.ToString()
                });
                lvXX.Items.Add(lvi);
            }
        }

        private void txtXM_TextChanged(object sender, EventArgs e)
        {
            LookingCT();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //添加菜品
            TianJianCaiPin();
        }
        ConsumerBill_BLL bll = new ConsumerBill_BLL();
        /// <summary>
        /// 添加菜品
        /// </summary>
        private void TianJianCaiPin()
        {
            //获取点单数量
            int sl = Convert.ToInt32(txtSL.Text);
            if (lvXX.SelectedItems.Count == 0)
            {
                return;
            }
            //获取菜品ID
            string Gid = lvXX.SelectedItems[0].SubItems[0].Text;
            //获取菜品价格
            string x = lvXX.SelectedItems[0].SubItems[2].Text;
            //string转Double
            Double mySalary = Double.Parse(x);
            //Double转int
            int jgg = (int)mySalary;
            int zjg = sl * jgg;
            //获取最新订单编号
            string bh = bll.lookDingDanHao(id);
            //MessageBox.Show($"{Gid},{x},{bh}");
            //点菜
            ConsumerDetails_BLL _bll = new ConsumerDetails_BLL();
            if (_bll.ZengJiaXioaFei(bh, Gid, jgg, sl, zjg) == true)
            {
                LookingDD();
            }
            else
            {
                MessageBox.Show("菜品添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }

        private void lvXX_Click(object sender, EventArgs e)
        {
            if (lvXX.SelectedItems.Count == 0)
            {
                return;
            }
            string s = lvXX.SelectedItems[0].SubItems[1].Text;
            lblXM.Text = "(" + s + ")";
        }
        /// <summary>
        /// 退菜
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label13_Click(object sender, EventArgs e)
        {
            if (lvDD.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string name = lvDD.SelectedItems[0].SubItems[7].Text;
            DialogResult result = MessageBox.Show("确定退菜吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == result)
            {
                ConsumerBill_BLL bll = new ConsumerBill_BLL();
                bool r = bll.DeleteRoom(bll.lookDingDanHao(id), name);
                if (r)
                {
                    MessageBox.Show("退菜成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LookingDD();
                }
                else
                {
                    MessageBox.Show("退菜失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EndConsumeForm tj = new EndConsumeForm();
            tj.id = id;
            tj.ShowDialog();

        }

        private void lvXX_DoubleClick(object sender, EventArgs e)
        {
            TianJianCaiPin();
        }
    }
}
