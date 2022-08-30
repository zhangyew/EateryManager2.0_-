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
    public partial class ProductFormUpdate : Form
    {
        public ProductFormUpdate()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string id { set; get; }

        private void ProductFormUpdate_Load(object sender, EventArgs e)
        {
            ProductType_BLL bll = new ProductType_BLL();
            // 显示修改信息
            foreach (var item in bll.LookType(id))
            {
                txtMC.Text = item.PTName;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtMC.Text;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("请输入信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            ProductType_BLL bll = new ProductType_BLL();
            bool r = bll.UpdateType(name,id);
            if (r)
            {
                MessageBox.Show("修改成功！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (ProductForm.productForm != null)
                {
                    ProductForm.productForm.LookingType();
                }
            }
            else
            {
                MessageBox.Show("修改失败！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        }
        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
