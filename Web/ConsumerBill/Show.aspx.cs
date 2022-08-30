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
namespace EateryManager.Web.ConsumerBill
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
					string CBID= strid;
					ShowInfo(CBID);
				}
			}
		}
		
	private void ShowInfo(string CBID)
	{
		EateryManager.BLL.ConsumerBill bll=new EateryManager.BLL.ConsumerBill();
		EateryManager.Model.ConsumerBill model=bll.GetModel(CBID);
		this.lblCBID.Text=model.CBID;
		this.lblTableID.Text=model.TableID.ToString();
		this.lblCBNum.Text=model.CBNum;
		this.lblVipID.Text=model.VipID.ToString();
		this.lblCBDiscount.Text=model.CBDiscount;
		this.lblCBStartDate.Text=model.CBStartDate.ToString();
		this.lblCBEndDate.Text=model.CBEndDate.ToString();
		this.lblAdminID.Text=model.AdminID.ToString();

	}


    }
}
