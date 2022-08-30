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
namespace EateryManager.Web.Tables
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
					int TableID=(Convert.ToInt32(strid));
					ShowInfo(TableID);
				}
			}
		}
		
	private void ShowInfo(int TableID)
	{
		EateryManager.BLL.Tables bll=new EateryManager.BLL.Tables();
		EateryManager.Model.Tables model=bll.GetModel(TableID);
		this.lblTableID.Text=model.TableID.ToString();
		this.lblTableName.Text=model.TableName;
		this.lblRTID.Text=model.RTID.ToString();
		this.lblTableArea.Text=model.TableArea;
		this.lblTableState.Text=model.TableState.ToString();

	}


    }
}
