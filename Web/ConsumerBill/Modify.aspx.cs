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
namespace EateryManager.Web.ConsumerBill
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					string CBID= Request.Params["id"];
					ShowInfo(CBID);
				}
			}
		}
			
	private void ShowInfo(string CBID)
	{
		EateryManager.BLL.ConsumerBill bll=new EateryManager.BLL.ConsumerBill();
		EateryManager.Model.ConsumerBill model=bll.GetModel(CBID);
		this.lblCBID.Text=model.CBID;
		this.txtTableID.Text=model.TableID.ToString();
		this.txtCBNum.Text=model.CBNum;
		this.txtVipID.Text=model.VipID.ToString();
		this.txtCBDiscount.Text=model.CBDiscount;
		this.txtCBStartDate.Text=model.CBStartDate.ToString();
		this.txtCBEndDate.Text=model.CBEndDate.ToString();
		this.txtAdminID.Text=model.AdminID.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtTableID.Text))
			{
				strErr+="餐桌编号格式错误！\\n";	
			}
			if(this.txtCBNum.Text.Trim().Length==0)
			{
				strErr+="顾客人数不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtVipID.Text))
			{
				strErr+="会员编号格式错误！\\n";	
			}
			if(this.txtCBDiscount.Text.Trim().Length==0)
			{
				strErr+="会员折扣不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCBStartDate.Text))
			{
				strErr+="开单时间格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCBEndDate.Text))
			{
				strErr+="结账时间格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtAdminID.Text))
			{
				strErr+="收银员编号格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string CBID=this.lblCBID.Text;
			int TableID=int.Parse(this.txtTableID.Text);
			string CBNum=this.txtCBNum.Text;
			int VipID=int.Parse(this.txtVipID.Text);
			string CBDiscount=this.txtCBDiscount.Text;
			DateTime CBStartDate=DateTime.Parse(this.txtCBStartDate.Text);
			DateTime CBEndDate=DateTime.Parse(this.txtCBEndDate.Text);
			int AdminID=int.Parse(this.txtAdminID.Text);


			EateryManager.Model.ConsumerBill model=new EateryManager.Model.ConsumerBill();
			model.CBID=CBID;
			model.TableID=TableID;
			model.CBNum=CBNum;
			model.VipID=VipID;
			model.CBDiscount=CBDiscount;
			model.CBStartDate=CBStartDate;
			model.CBEndDate=CBEndDate;
			model.AdminID=AdminID;

			EateryManager.BLL.ConsumerBill bll=new EateryManager.BLL.ConsumerBill();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
