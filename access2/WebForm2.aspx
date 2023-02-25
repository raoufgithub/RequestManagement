<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="view.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

        <link href="../calendar/css/jquery-ui.css" rel="stylesheet" />
    <script src="../calendar/js/jquery-1.10.2.js"></script>
    <script src="../calendar/js/jquery-ui.js"></script>
    
    <script type="text/javascript">
        $(document).ready (function(){
            $('.datepicker').datepicker()
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        <asp:TextBox ID="TextBox2" CssClass="datepicker" runat="server" ></asp:TextBox>
    <asp:Button ID="Button2" runat="server" Text="Button" OnClick="Button2_Click" />
    <asp:LinkButton ID="LinkButton1" CssClass="datepicker" runat="server" OnClick="LinkButton1_Click">LinkButton</asp:LinkButton>




    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
<asp:FileUpload ID="FileUpload1"  runat="server" />
    <asp:Button ID="Button4" runat="server" OnClick="Upload_Click" Text="Button" />
    <br />
    <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>

            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
