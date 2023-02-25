<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="BalanceSheet.aspx.cs" Inherits="view.Reporting.BalanceSheet" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />
    <asp:Label ID="Label35" runat="server" Font-Size="X-Large" Text="Le Rapport : Nombre de Requêtes par Wilaya."></asp:Label>
    <br />
    <asp:Label ID="Label36" runat="server" Font-Size="Large" Text="Veuillez choisir une date avec le format : 'AAAA-MM-JJ'"></asp:Label>
    <br />
    <br />
&nbsp;<rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Font-Names="Verdana" Font-Size="8pt" Height="1508px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1045px" style="margin-left: 0px">
        <%--<ServerReport ReportPath="/Access/Report4" ReportServerUrl="http://menasri/reportserver" />--%>
    <ServerReport ReportPath="/Access/WilayaRequest" ReportServerUrl="http://menasri/reportserver" />
    </rsweb:ReportViewer>
</asp:Content>
