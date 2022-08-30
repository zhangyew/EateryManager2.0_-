using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace EateryManager.Web.Products
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtProductName.Text.Trim().Length==0)
			{
				strErr+="商品名称不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtPTID.Text))
			{
				strErr+="商品类别格式错误！\\n";	
			}
			if(this.txtProductJP.Text.Trim().Length==0)
			{
				strErr+="商品简拼不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtProductPrice.Text))
			{
				strErr+="商品价格格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string ProductName=this.txtProductName.Text;
			int PTID=int.Parse(this.txtPTID.Text);
			string ProductJP=this.txtProductJP.Text;
			decimal ProductPrice=decimal.Parse(this.txtProductPrice.Text);

			EateryManager.Model.Products model=new EateryManager.Model.Products();
			model.ProductName=ProductName;
			model.PTID=PTID;
			model.ProductJP=ProductJP;
			model.ProductPrice=ProductPrice;

			EateryManager.BLL.Products bll=new EateryManager.BLL.Products();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
