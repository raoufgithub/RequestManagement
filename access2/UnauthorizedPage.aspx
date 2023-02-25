<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UnauthorizedPage.aspx.cs" Inherits="view.UnauthorizedPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Label ID="Label31" runat="server" Text="Vous n'avez pas d'authorisation pour accéder à cette page."></asp:Label>
    <br />
    <asp:Label ID="Label32" runat="server" Text="Veuillez vous connecter avec un compte qui a des prèvillèges suffisants."></asp:Label>


</asp:Content>
