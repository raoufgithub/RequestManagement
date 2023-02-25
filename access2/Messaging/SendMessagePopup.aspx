<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendMessagePopup.aspx.cs" Inherits="view.Messaging.SendMessagePopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    <asp:Button ID="Button1" runat="server" OnClick="Upload_Click" Text="Button" />
    <br />
    <asp:Label ID="Label31" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
