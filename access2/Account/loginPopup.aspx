<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPopup.aspx.cs" Inherits="view.Account.loginPopup" %>
<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../webforms/Test.css" rel="stylesheet" />
    
</head>
<body class="body">
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <form id="form1" runat="server">
        
    <div style="width: 580px; height: 388px" class="center-div" >
        
        <asp:Login ID="Login1" runat="server" BackColor="#E3EAEB" BorderColor="#E6E2D8" BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#333333" Height="382px" TextLayout="TextOnTop" Width="576px">
            
            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
            
            <LayoutTemplate>
                
                <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
                    
                    <tr>
                        
                        <td>
                            <div class="DivTitle">
                                <asp:Label CssClass="LabelTitle" Text="Application ACCES - Page d'Authentification" runat="server" />
                            </div>


                            <br />
                            <br />
                            <br />
                            <br />
                            
                            <br />
                            <br />



                            <table cellpadding="0">
                                <tr>
                                    <td align="center" colspan="2">Connexion&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nom d'Utilisateur:</asp:Label>
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="UserName" runat="server" Height="34px" Width="168px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Nom d'Utilisateur est obligatoire." ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Mot de Passe:</asp:Label>
                                        &nbsp;
                                    </td>
                                    <td>
                                        &nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password" Height="34px" Width="168px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Le Mot de Passe est obligatoire." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:CheckBox ID="RememberMe" runat="server" Text="Laissez la session ouverte." Visible="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;">
                                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="2">
                                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" OnClick="LoginButton_Click" Text="Se Connecter" ValidationGroup="Login1" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <LoginButtonStyle BackColor="White" BorderColor="#C5BBAF" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#1C5E55" />
            <TextBoxStyle Font-Size="0.8em" />
            <TitleTextStyle BackColor="#1C5E55" Font-Bold="True" Font-Size="0.9em" ForeColor="White" />
        </asp:Login>
            
            <section id="socialLoginForm">
                <%--<uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />--%>
            </section>
        

    </div>
    </form>
</body>
</html>
