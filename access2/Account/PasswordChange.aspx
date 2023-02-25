<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="PasswordChange.aspx.cs" Inherits="view.Account.PasswordChange" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <link href="CssPassword.css" rel="stylesheet" />
    <style type="text/css">
        .CssPassword {
        }
    </style>

<script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Etes vous sûr de modifier votre mot de passe ?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="div-Password">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label36" runat="server" Text="Modification du Mot de Passe de l'Utilisateur : " Font-Size="X-Large"></asp:Label>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server" Text="L'ancien Mot de Passe" Height="35px" Width="200px"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox_OldPass" runat="server" CssClass="CssPassword" Height="35px" Width="400px" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_OldPass" ControlToValidate="TextBox_OldPass" ForeColor="Red"  runat="server" ErrorMessage="Champs Ancien Mot de Passe est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label33" runat="server" Height="35px" Text="Le Nouveau Mot de Passe" Width="200px"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox_NewPass" runat="server" CssClass="CssPassword" Height="35px" Width="400px" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorModeTransmission_NewPass" ControlToValidate="TextBox_NewPass" ForeColor="Red"  runat="server" ErrorMessage="Champs Nouveau Mot de Passe est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
        <asp:Label ID="Label34" runat="server" Height="35px" Text="Confirmer le Mot de Passe" Width="200px"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox_ConfirmPass" runat="server" CssClass="CssPassword" Height="35px" Width="400px" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_ConfirmPass" ControlToValidate="TextBox_ConfirmPass" ForeColor="Red"  runat="server" ErrorMessage="Confirmer le Mot de Passe" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="La Confirmation du Mot de Passe ne correspond pas" ControlToValidate="TextBox_ConfirmPass" ControlToCompare="TextBox_NewPass" ForeColor="Red" ValidationGroup="Validation" >*</asp:CompareValidator>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="35px" Text="Modifier le Mot de Passe" Width="400px" CssClass="CssButton" OnClick="PassUpdate_Click" ValidationGroup="Validation" OnClientClick="Confirm()"/>
        <br />
        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" ValidationGroup="Validation" />
        <br />
    </div>
</asp:Content>
