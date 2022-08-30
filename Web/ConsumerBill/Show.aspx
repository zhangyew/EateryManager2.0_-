<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="EateryManager.Web.ConsumerBill.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		账单编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCBID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		餐桌编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblTableID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		顾客人数
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCBNum" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		会员编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVipID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		会员折扣
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCBDiscount" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		开单时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCBStartDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		结账时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCBEndDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		收银员编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblAdminID" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




