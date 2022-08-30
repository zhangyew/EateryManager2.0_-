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
namespace EateryManager.Web.ConsumerDetails
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int CDID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(CDID);
				}
			}
		}
			
	private void ShowInfo(int CDID)
	{
		EateryManager.BLL.ConsumerDetails bll=new EateryManager.BLL.ConsumerDetails();
		EateryManager.Model.ConsumerDetails model=bll.GetModel(CDID);
		this.lblCDID.Text=model.CDID.ToString();
		this.txtCBID.Text=model.CBID;
		this.txtProductID.Text=model.ProductID.ToString();
		this.txtCDPrice.Text=model.CDPrice.ToString();
		this.txtCDNum.Text=model.CDNum.ToString();
		this.txtCDSale.Text=model.CDSale.ToString();
		this.txtCDMoney.Text=model.CDMoney.ToString();
		this.txtCDType.Text=model.CDType.ToString();
		this.txtCDDate.Text=model.CDDate.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtCBID.Text.Trim().Length==0)
			{
				strErr+="账单编号不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtProductID.Text))
			{
				strErr+="商品编号格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtCDPrice.Text))
			{
				strErr+="商品价格格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCDNum.Text))
			{
				strErr+="商品数量格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtCDSale.Text))
			{
				strErr+="优惠金额格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtCDMoney.Text))
			{
				strErr+="消费金额格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCDType.Text))
			{
				strErr+="消费类型格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCDDate.Text))
			{
				strErr+="点单时间格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int CDID=int.Parse(this.lblCDID.Text);
			string CBID=this.txtCBID.Text;
			int ProductID=int.Parse(this.txtProductID.Text);
			decimal CDPrice=decimal.Parse(this.txtCDPrice.Text);
			int CDNum=int.Parse(this.txtCDNum.Text);
			decimal CDSale=decimal.Parse(this.txtCDSale.Text);
			decimal CDMoney=decimal.Parse(this.txtCDMoney.Text);
			int CDType=int.Parse(this.txtCDType.Text);
			DateTime CDDate=DateTime.Parse(this.txtCDDate.Text);


			EateryManager.Model.ConsumerDetails model=new EateryManager.Model.ConsumerDetails();
			model.CDID=CDID;
			model.CBID=CBID;
			model.ProductID=ProductID;
			model.CDPrice=CDPrice;
			model.CDNum=CDNum;
			model.CDSale=CDSale;
			model.CDMoney=CDMoney;
			model.CDType=CDType;
			model.CDDate=CDDate;

			EateryManager.BLL.ConsumerDetails bll=new EateryManager.BLL.ConsumerDetails();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
