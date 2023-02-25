<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="ByObject.aspx.cs" Inherits="view.Reporting.ByObject" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Label ID="Label35" runat="server" Font-Size="X-Large" Text="Le Rapport : Nombre de Requêtes par Objet."></asp:Label>
        <br />
        <asp:Label ID="Label36" runat="server" Font-Size="Large" Text="Veuillez choisir une date avec le format : 'AAAA-MM-JJ'"></asp:Label>
        <br />
        <br />
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Font-Names="Verdana" Font-Size="8pt" Height="739px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1045px" style="margin-left: 0px">
        <ServerReport ReportPath="/Access/Bilan" ReportServerUrl="http://menasri/reportserver" />
    </rsweb:ReportViewer>
</asp:Content>