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
namespace EateryManager.Web.VipGrade
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtVGName.Text.Trim().Length==0)
			{
				strErr+="等级名称不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtVGDiscount.Text))
			{
				strErr+="等级折扣格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string VGName=this.txtVGName.Text;
			decimal VGDiscount=decimal.Parse(this.txtVGDiscount.Text);

			EateryManager.Model.VipGrade model=new EateryManager.Model.VipGrade();
			model.VGName=VGName;
			model.VGDiscount=VGDiscount;

			EateryManager.BLL.VipGrade bll=new EateryManager.BLL.VipGrade();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
