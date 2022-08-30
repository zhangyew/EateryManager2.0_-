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
namespace EateryManager.Web.Admins
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int UserID=(Convert.ToInt32(strid));
					ShowInfo(UserID);
				}
			}
		}
		
	private void ShowInfo(int UserID)
	{
		EateryManager.BLL.Admins bll=new EateryManager.BLL.Admins();
		EateryManager.Model.Admins model=bll.GetModel(UserID);
		this.lblUserID.Text=model.UserID.ToString();
		this.lblUserName.Text=model.UserName;
		this.lblUserPwd.Text=model.UserPwd;
		this.lblTrueName.Text=model.TrueName;

	}


    }
}
