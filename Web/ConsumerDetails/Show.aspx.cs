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
namespace EateryManager.Web.ConsumerDetails
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
					int CDID=(Convert.ToInt32(strid));
					ShowInfo(CDID);
				}
			}
		}
		
	private void ShowInfo(int CDID)
	{
		EateryManager.BLL.ConsumerDetails bll=new EateryManager.BLL.ConsumerDetails();
		EateryManager.Model.ConsumerDetails model=bll.GetModel(CDID);
		this.lblCDID.Text=model.CDID.ToString();
		this.lblCBID.Text=model.CBID;
		this.lblProductID.Text=model.ProductID.ToString();
		this.lblCDPrice.Text=model.CDPrice.ToString();
		this.lblCDNum.Text=model.CDNum.ToString();
		this.lblCDSale.Text=model.CDSale.ToString();
		this.lblCDMoney.Text=model.CDMoney.ToString();
		this.lblCDType.Text=model.CDType.ToString();
		this.lblCDDate.Text=model.CDDate.ToString();

	}


    }
}
