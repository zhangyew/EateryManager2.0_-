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
namespace EateryManager.Web.Vips
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
					int VipID=(Convert.ToInt32(strid));
					ShowInfo(VipID);
				}
			}
		}
		
	private void ShowInfo(int VipID)
	{
		EateryManager.BLL.Vips bll=new EateryManager.BLL.Vips();
		EateryManager.Model.Vips model=bll.GetModel(VipID);
		this.lblVipID.Text=model.VipID.ToString();
		this.lblVipName.Text=model.VipName;
		this.lblVipSex.Text=model.VipSex;
		this.lblVGID.Text=model.VGID.ToString();
		this.lblVipTel.Text=model.VipTel;
		this.lblVipStartDate.Text=model.VipStartDate.ToString();
		this.lblVipEndDate.Text=model.VipEndDate.ToString();

	}


    }
}
