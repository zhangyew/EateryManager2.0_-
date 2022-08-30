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
namespace EateryManager.Web.RoomType
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
					int RTID=(Convert.ToInt32(strid));
					ShowInfo(RTID);
				}
			}
		}
		
	private void ShowInfo(int RTID)
	{
		EateryManager.BLL.RoomType bll=new EateryManager.BLL.RoomType();
		EateryManager.Model.RoomType model=bll.GetModel(RTID);
		this.lblRTID.Text=model.RTID.ToString();
		this.lblRTName.Text=model.RTName;
		this.lblRTMin.Text=model.RTMin.ToString();
		this.lblRTIsDis.Text=model.RTIsDis?"是":"否";
		this.lblRTNum.Text=model.RTNum.ToString();

	}


    }
}
