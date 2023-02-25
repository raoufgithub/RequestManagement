<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Request_Types.aspx.cs" Inherits="view.Reporting.Request_Types" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Le Rapport : Nombre de Requêtes par Type de Requête.<br />
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" ProcessingMode="Remote" Font-Names="Verdana" Font-Size="8pt" Height="580px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="1045px" style="margin-left: 0px">
        <ServerReport ReportPath="/Access/Request_Types" ReportServerUrl="http://menasri/reportserver" />
    </rsweb:ReportViewer>
</asp:Content>
