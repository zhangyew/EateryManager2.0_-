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
namespace EateryManager.Web.RoomType
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtRTName.Text.Trim().Length==0)
			{
				strErr+="类型名称不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtRTMin.Text))
			{
				strErr+="最低消费格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtRTNum.Text))
			{
				strErr+="容纳人数格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string RTName=this.txtRTName.Text;
			decimal RTMin=decimal.Parse(this.txtRTMin.Text);
			bool RTIsDis=this.chkRTIsDis.Checked;
			int RTNum=int.Parse(this.txtRTNum.Text);

			EateryManager.Model.RoomType model=new EateryManager.Model.RoomType();
			model.RTName=RTName;
			model.RTMin=RTMin;
			model.RTIsDis=RTIsDis;
			model.RTNum=RTNum;

			EateryManager.BLL.RoomType bll=new EateryManager.BLL.RoomType();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
