<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Test.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="view.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <link href="../calendar/css/jquery-ui.css" rel="stylesheet" />
    <script src="../calendar/js/jquery-1.10.2.js"></script>
    <script src="../calendar/js/jquery-ui.js"></script>
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('.datepicker').datepicker()
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
 <asp:ScriptManager EnablePartialRendering="true"
 ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <div>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server"
 UpdateMode="Conditional">
 <ContentTemplate>
 <asp:Label ID="Label1" runat="server" /><br />
 <asp:Button ID="Button1" runat="server"
 Text="Update Both Panels" OnClick="Button1_Click" />
 <asp:Button ID="Button2" runat="server"
 Text="Update This Panel" OnClick="Button2_Click" />
 <asp:CheckBox ID="cbDate" runat="server"
 Text="Include Date" AutoPostBack="false"
 OnCheckedChanged="cbDate_CheckedChanged" />
 </ContentTemplate>
 </asp:UpdatePanel>
 <asp:UpdatePanel ID="UpdatePanel2" runat="server"
 UpdateMode="Conditional">
 <ContentTemplate>
 <asp:Label ID="Label2" runat="server"
 ForeColor="red" />
 </ContentTemplate>
 <Triggers>
 <asp:AsyncPostBackTrigger ControlID="Button1" 
 EventName="Click" />
 <asp:AsyncPostBackTrigger ControlID="ddlColor" 
 EventName="SelectedIndexChanged" />
 </Triggers>
 </asp:UpdatePanel>
 <asp:DropDownList ID="ddlColor" runat="server"
 AutoPostBack="true"
 OnSelectedIndexChanged="ddlColor_SelectedIndexChanged">
 <asp:ListItem Selected="true" Value="Red" />
 <asp:ListItem Value="Blue" />
 <asp:ListItem Value="Green" />
 </asp:DropDownList>
 </div>
 
        
</asp:Content>
