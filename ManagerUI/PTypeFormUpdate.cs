using common;
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
    public partial class PTypeFormUpdate : Form
    {
        public PTypeFormUpdate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string id { set; get; }

        private void txtMC_TextChanged(object sender, EventArgs e)
        {
            string name = txtMC.Text;
            txtJP.Text = ConvertPinYin.GetSpells(name).ToUpper();
        }

        private void PTypeFormUpdate_Load(object sender, EventArgs e)
        {
            //绑定下拉框
            ProductType_BLL bll = new ProductType_BLL();
            cboLB.ValueMember = "PTID";
            cboLB.DisplayMember = "PTName";
            List<ProductType> list = bll.Quanxian().ToList();
            cboLB.DataSource = list;
            // 显示需要修改的信息
            Products_BLL _bll = new Products_BLL();
            foreach (var item in _bll.LookProductsUpdate(id))
            {
                txtMC.Text = item.ProductName;
                txtXS.Text = item.ProductPrice.ToString();
                cboLB.SelectedValue =Convert.ToInt32(item.PTID);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtXS_KeyPress(object sender, KeyPressEventArgs e)
        {
             //只能输入数字和点的判断
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 45 && e.KeyChar != 46)
                e.Handled = true;
            //输入为负号时，只能输入一次且只能输入一次
            if (e.KeyChar == 45 && (((TextBox)sender).SelectionStart != 0 || ((TextBox)sender).Text.IndexOf("-") <= 0))
                e.Handled = true;
            //点只能出现一次的判断
            if (e.KeyChar == 46 && ((TextBox)sender).Text.IndexOf(".") >= 0)
                e.Handled = true;
            //点不能出现在最前面的判断
            if (e.KeyChar == 46 && ((TextBox)sender).Text.Length == 0)
                e.Handled = true;
            //数字0不能出现在最前面的判断
            if (e.KeyChar == 48 && ((TextBox)sender).Text.Length == 0)
                e.Handled = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string name = txtMC.Text;
            string py = txtJP.Text;
            string jg = txtXS.Text;
            int lb = (int)cboLB.SelectedValue;

            if (string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(jg)
                )
            {
                MessageBox.Show("请输入完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (lb == 0)
            {
                MessageBox.Show("商品类别不能为全部类别！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            Products_BLL bll = new Products_BLL();
            bool r = bll.ProductUpdate(name, py, jg, lb,id);
            if (r)
            {
                MessageBox.Show("商品修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (ProductForm.productForm != null)
                {
                    ProductForm.productForm.LookingProduct();
                }
            }
            else
            {
                MessageBox.Show("商品修改失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
        }
    }
}
