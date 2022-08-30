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
namespace EateryManager.Web.Vips
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int VipID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(VipID);
				}
			}
		}
			
	private void ShowInfo(int VipID)
	{
		EateryManager.BLL.Vips bll=new EateryManager.BLL.Vips();
		EateryManager.Model.Vips model=bll.GetModel(VipID);
		this.lblVipID.Text=model.VipID.ToString();
		this.txtVipName.Text=model.VipName;
		this.txtVipSex.Text=model.VipSex;
		this.txtVGID.Text=model.VGID.ToString();
		this.txtVipTel.Text=model.VipTel;
		this.txtVipStartDate.Text=model.VipStartDate.ToString();
		this.txtVipEndDate.Text=model.VipEndDate.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtVipName.Text.Trim().Length==0)
			{
				strErr+="会员姓名不能为空！\\n";	
			}
			if(this.txtVipSex.Text.Trim().Length==0)
			{
				strErr+="会员性别不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtVGID.Text))
			{
				strErr+="等级ID格式错误！\\n";	
			}
			if(this.txtVipTel.Text.Trim().Length==0)
			{
				strErr+="联系电话不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtVipStartDate.Text))
			{
				strErr+="办理日期格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtVipEndDate.Text))
			{
				strErr+="到期日期格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int VipID=int.Parse(this.lblVipID.Text);
			string VipName=this.txtVipName.Text;
			string VipSex=this.txtVipSex.Text;
			int VGID=int.Parse(this.txtVGID.Text);
			string VipTel=this.txtVipTel.Text;
			DateTime VipStartDate=DateTime.Parse(this.txtVipStartDate.Text);
			DateTime VipEndDate=DateTime.Parse(this.txtVipEndDate.Text);


			EateryManager.Model.Vips model=new EateryManager.Model.Vips();
			model.VipID=VipID;
			model.VipName=VipName;
			model.VipSex=VipSex;
			model.VGID=VGID;
			model.VipTel=VipTel;
			model.VipStartDate=VipStartDate;
			model.VipEndDate=VipEndDate;

			EateryManager.BLL.Vips bll=new EateryManager.BLL.Vips();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
