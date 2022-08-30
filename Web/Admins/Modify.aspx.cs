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
namespace EateryManager.Web.Admins
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int UserID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(UserID);
				}
			}
		}
			
	private void ShowInfo(int UserID)
	{
		EateryManager.BLL.Admins bll=new EateryManager.BLL.Admins();
		EateryManager.Model.Admins model=bll.GetModel(UserID);
		this.lblUserID.Text=model.UserID.ToString();
		this.txtUserName.Text=model.UserName;
		this.txtUserPwd.Text=model.UserPwd;
		this.txtTrueName.Text=model.TrueName;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="用户名不能为空！\\n";	
			}
			if(this.txtUserPwd.Text.Trim().Length==0)
			{
				strErr+="用户密码不能为空！\\n";	
			}
			if(this.txtTrueName.Text.Trim().Length==0)
			{
				strErr+="真实姓名不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UserID=int.Parse(this.lblUserID.Text);
			string UserName=this.txtUserName.Text;
			string UserPwd=this.txtUserPwd.Text;
			string TrueName=this.txtTrueName.Text;


			EateryManager.Model.Admins model=new EateryManager.Model.Admins();
			model.UserID=UserID;
			model.UserName=UserName;
			model.UserPwd=UserPwd;
			model.TrueName=TrueName;

			EateryManager.BLL.Admins bll=new EateryManager.BLL.Admins();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
