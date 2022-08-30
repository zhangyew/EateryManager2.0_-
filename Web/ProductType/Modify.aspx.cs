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
namespace EateryManager.Web.ProductType
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int PTID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(PTID);
				}
			}
		}
			
	private void ShowInfo(int PTID)
	{
		EateryManager.BLL.ProductType bll=new EateryManager.BLL.ProductType();
		EateryManager.Model.ProductType model=bll.GetModel(PTID);
		this.lblPTID.Text=model.PTID.ToString();
		this.txtPTName.Text=model.PTName;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtPTName.Text.Trim().Length==0)
			{
				strErr+="类型名称不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int PTID=int.Parse(this.lblPTID.Text);
			string PTName=this.txtPTName.Text;


			EateryManager.Model.ProductType model=new EateryManager.Model.ProductType();
			model.PTID=PTID;
			model.PTName=PTName;

			EateryManager.BLL.ProductType bll=new EateryManager.BLL.ProductType();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
