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
    public partial class PTypeFormAdd : Form
    {
        public PTypeFormAdd()
        {
            InitializeComponent();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PTypeFormAdd_Load(object sender, EventArgs e)
        {
            //绑定下拉框
            ProductType_BLL bll = new ProductType_BLL();
            cboLB.ValueMember = "PTID";
            cboLB.DisplayMember = "PTName";
            List<ProductType> list = bll.Quanxian().ToList();
            cboLB.DataSource = list;

        }
        private void txtMC_TextChanged(object sender, EventArgs e)
        {
            string name = txtMC.Text;
            txtJP.Text = ConvertPinYin.GetSpells(name).ToUpper();
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            string name = txtMC.Text;
            string py = txtJP.Text;
            string jg =txtXS.Text;
            int lb = (int)cboLB.SelectedValue;
            
            if(string.IsNullOrEmpty(name)||
                string.IsNullOrEmpty(jg)
                )
            {
                 MessageBox.Show("请输入完整信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if(lb == 0)
            {
                 MessageBox.Show("商品类别不能为全部类别！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            Products_BLL bll = new Products_BLL();

            if (bll.Repeat(name) > 0)
            {
                MessageBox.Show("商品名相同重复，请重新输入！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

            bool r = bll.ProductAdd(name,py,jg,lb);
            if (r)
            {
                MessageBox.Show("商品添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (ProductForm.productForm != null)
                {
                    ProductForm.productForm.LookingProduct();
                }
            }
            else
            {
                MessageBox.Show("商品添加失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        }
        /// <summary>
        ///  数字验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtXS_KeyPress(object sender, KeyPressEventArgs e)
        {
            //数字有效性验证-KeyPress事件中
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
    }
}
