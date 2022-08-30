<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="EateryManager.Web.Vips.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		会员编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVipID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		会员姓名
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVipName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		会员性别
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVipSex" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		等级ID
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVGID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		联系电话
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVipTel" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		办理日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVipStartDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		到期日期
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblVipEndDate" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




