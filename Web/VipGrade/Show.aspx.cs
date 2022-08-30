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
namespace EateryManager.Web.VipGrade
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
					int VGID=(Convert.ToInt32(strid));
					ShowInfo(VGID);
				}
			}
		}
		
	private void ShowInfo(int VGID)
	{
		EateryManager.BLL.VipGrade bll=new EateryManager.BLL.VipGrade();
		EateryManager.Model.VipGrade model=bll.GetModel(VGID);
		this.lblVGID.Text=model.VGID.ToString();
		this.lblVGName.Text=model.VGName;
		this.lblVGDiscount.Text=model.VGDiscount.ToString();

	}


    }
}
