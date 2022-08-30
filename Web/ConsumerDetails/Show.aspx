<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="EateryManager.Web.ConsumerDetails.Show" Title="显示页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <table style="width: 100%;" cellpadding="2" cellspacing="1" class="border">
                <tr>                   
                    <td class="tdbg">
                               
<table cellSpacing="0" cellPadding="0" width="100%" border="0">
	<tr>
	<td height="25" width="30%" align="right">
		编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCDID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		账单编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCBID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		商品编号
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblProductID" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		商品价格
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCDPrice" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		商品数量
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCDNum" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		优惠金额
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCDSale" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		消费金额
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCDMoney" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		消费类型
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCDType" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td height="25" width="30%" align="right">
		点单时间
	：</td>
	<td height="25" width="*" align="left">
		<asp:Label id="lblCDDate" runat="server"></asp:Label>
	</td></tr>
</table>

                    </td>
                </tr>
            </table>
</asp:Content>
<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceCheckright" runat="server">
</asp:Content>--%>




