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
    public partial class ProductForm : Form
    {
        public static ProductForm productForm;
        public ProductForm()
        {
            InitializeComponent();
            productForm = this;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            //绑定下拉框
            ProductType_BLL bll = new ProductType_BLL();
            cboLB.ValueMember = "PTID";
            cboLB.DisplayMember = "PTName";
            List<ProductType> list = bll.Quanxian().ToList();
            cboLB.DataSource = list;

            ChangeListViewColor(lvLB);
            ChangeListViewColor(lvSP);

            LookingType();
            LookingProduct();
        }
        /// <summary>
        /// 绑定商品信息
        /// </summary>
        public  void LookingProduct()
        {
            int id = (int)cboLB.SelectedValue;
            lvSP.Items.Clear();
            Products_BLL bll = new Products_BLL();
            foreach (var item in bll.Looking(id,null))
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.ProductID.ToString();
                lvi.SubItems.AddRange
                    (
                    new[] {
                    item.ProductName.ToString(),
                    item.ProductPrice.ToString(),
                    item.PTID.ToString()
                    }
                    );
                lvSP.Items.Add(lvi);
            }
        }

        /// <summary>
        /// 绑定商品项目
        /// </summary>
        public  void LookingType()
        {
            lvLB.Items.Clear();
            ProductType_BLL bll = new ProductType_BLL();
            foreach (var item in bll.Looking())
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.PTID.ToString();
                lvi.SubItems.Add(item.PTName.ToString());
                lvLB.Items.Add(lvi);
            }
        }

        private void cboLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LookingProduct();
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

        private void button2_Click(object sender, EventArgs e)
        {
            ProductFormAdd tj = new ProductFormAdd();
            tj.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (lvLB.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvLB.SelectedItems[0].SubItems[0].Text;
            ProductFormUpdate tj = new ProductFormUpdate();
            tj.id = id;
            tj.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvLB.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要删除的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvLB.SelectedItems[0].SubItems[0].Text;
            DialogResult result = MessageBox.Show("确定删除该消息吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == result)
            {
                ProductType_BLL bll = new ProductType_BLL();
                bool r = bll.DeleteType(id);
                if (r)
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LookingType();
                }
                else
                {
                    MessageBox.Show("删除失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            PTypeFormAdd tj = new PTypeFormAdd();
            tj.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (lvSP.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要修改的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvSP.SelectedItems[0].SubItems[0].Text;
            PTypeFormUpdate tj = new PTypeFormUpdate();
            tj.id = id;
            tj.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (lvSP.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择需要删除的信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            string id = lvSP.SelectedItems[0].SubItems[0].Text;
            DialogResult result = MessageBox.Show("确定删除该消息吗？", "删除提示", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (DialogResult.Yes == result)
            {
                Products_BLL bll = new Products_BLL();
                bool r = bll.DeleteProduct(id);
                if (r)
                {
                    MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LookingProduct();
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
