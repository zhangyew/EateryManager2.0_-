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
namespace EateryManager.Web.Tables
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int TableID=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(TableID);
				}
			}
		}
			
	private void ShowInfo(int TableID)
	{
		EateryManager.BLL.Tables bll=new EateryManager.BLL.Tables();
		EateryManager.Model.Tables model=bll.GetModel(TableID);
		this.lblTableID.Text=model.TableID.ToString();
		this.txtTableName.Text=model.TableName;
		this.txtRTID.Text=model.RTID.ToString();
		this.txtTableArea.Text=model.TableArea;
		this.txtTableState.Text=model.TableState.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtTableName.Text.Trim().Length==0)
			{
				strErr+="餐桌名称不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtRTID.Text))
			{
				strErr+="房间类型格式错误！\\n";	
			}
			if(this.txtTableArea.Text.Trim().Length==0)
			{
				strErr+="所在区域不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtTableState.Text))
			{
				strErr+="餐桌状态格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int TableID=int.Parse(this.lblTableID.Text);
			string TableName=this.txtTableName.Text;
			int RTID=int.Parse(this.txtRTID.Text);
			string TableArea=this.txtTableArea.Text;
			int TableState=int.Parse(this.txtTableState.Text);


			EateryManager.Model.Tables model=new EateryManager.Model.Tables();
			model.TableID=TableID;
			model.TableName=TableName;
			model.RTID=RTID;
			model.TableArea=TableArea;
			model.TableState=TableState;

			EateryManager.BLL.Tables bll=new EateryManager.BLL.Tables();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
