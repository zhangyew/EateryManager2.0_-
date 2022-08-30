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
    public partial class ProductFormAdd : Form
    {
        public ProductFormAdd()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Close();
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
            if (bll.Repeat(name) > 0)
            {
                MessageBox.Show("类型名称重复，请重新输入！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            bool r = bll.TypeAdd(name);
            if (r)
            {
                MessageBox.Show("添加成功！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                if (ProductForm.productForm != null)
                {
                    ProductForm.productForm.LookingType();
                }
            }
            else
            {
                MessageBox.Show("添加失败！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }

        }
    }
}
