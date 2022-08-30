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
namespace EateryManager.Web.ProductType
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
					int PTID=(Convert.ToInt32(strid));
					ShowInfo(PTID);
				}
			}
		}
		
	private void ShowInfo(int PTID)
	{
		EateryManager.BLL.ProductType bll=new EateryManager.BLL.ProductType();
		EateryManager.Model.ProductType model=bll.GetModel(PTID);
		this.lblPTID.Text=model.PTID.ToString();
		this.lblPTName.Text=model.PTName;

	}


    }
}
