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
namespace EateryManager.Web.Vips
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtVipName.Text.Trim().Length==0)
			{
				strErr+="会员姓名不能为空！\\n";	
			}
			if(this.txtVipSex.Text.Trim().Length==0)
			{
				strErr+="会员性别不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtVGID.Text))
			{
				strErr+="等级ID格式错误！\\n";	
			}
			if(this.txtVipTel.Text.Trim().Length==0)
			{
				strErr+="联系电话不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtVipStartDate.Text))
			{
				strErr+="办理日期格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtVipEndDate.Text))
			{
				strErr+="到期日期格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string VipName=this.txtVipName.Text;
			string VipSex=this.txtVipSex.Text;
			int VGID=int.Parse(this.txtVGID.Text);
			string VipTel=this.txtVipTel.Text;
			DateTime VipStartDate=DateTime.Parse(this.txtVipStartDate.Text);
			DateTime VipEndDate=DateTime.Parse(this.txtVipEndDate.Text);

			EateryManager.Model.Vips model=new EateryManager.Model.Vips();
			model.VipName=VipName;
			model.VipSex=VipSex;
			model.VGID=VGID;
			model.VipTel=VipTel;
			model.VipStartDate=VipStartDate;
			model.VipEndDate=VipEndDate;

			EateryManager.BLL.Vips bll=new EateryManager.BLL.Vips();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
