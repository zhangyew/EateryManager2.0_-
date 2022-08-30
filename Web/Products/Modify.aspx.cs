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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int ProductID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(ProductID);
				}
			}
		}
			
	private void ShowInfo(int ProductID)
	{
		EateryManager.BLL.Products bll=new EateryManager.BLL.Products();
		EateryManager.Model.Products model=bll.GetModel(ProductID);
		this.lblProductID.Text=model.ProductID.ToString();
		this.txtProductName.Text=model.ProductName;
		this.txtPTID.Text=model.PTID.ToString();
		this.txtProductJP.Text=model.ProductJP;
		this.txtProductPrice.Text=model.ProductPrice.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int ProductID=int.Parse(this.lblProductID.Text);
			string ProductName=this.txtProductName.Text;
			int PTID=int.Parse(this.txtPTID.Text);
			string ProductJP=this.txtProductJP.Text;
			decimal ProductPrice=decimal.Parse(this.txtProductPrice.Text);


			EateryManager.Model.Products model=new EateryManager.Model.Products();
			model.ProductID=ProductID;
			model.ProductName=ProductName;
			model.PTID=PTID;
			model.ProductJP=ProductJP;
			model.ProductPrice=ProductPrice;

			EateryManager.BLL.Products bll=new EateryManager.BLL.Products();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
