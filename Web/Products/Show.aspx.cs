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
namespace EateryManager.Web.Products
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
					int ProductID=(Convert.ToInt32(strid));
					ShowInfo(ProductID);
				}
			}
		}
		
	private void ShowInfo(int ProductID)
	{
		EateryManager.BLL.Products bll=new EateryManager.BLL.Products();
		EateryManager.Model.Products model=bll.GetModel(ProductID);
		this.lblProductID.Text=model.ProductID.ToString();
		this.lblProductName.Text=model.ProductName;
		this.lblPTID.Text=model.PTID.ToString();
		this.lblProductJP.Text=model.ProductJP;
		this.lblProductPrice.Text=model.ProductPrice.ToString();

	}


    }
}
