<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="RegisterAgents.aspx.cs" Inherits="view.Account.RegisterAgents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="RegisterAgent.css" rel="stylesheet" />

        <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Etes vous sûr de supprimer cette voie de Transmission?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="center-div">
    <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
        <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label37" runat="server" Font-Size="X-Large" Text="Enregistrer de nouveaux Agents "></asp:Label>
        </p>
        <p> &nbsp;</p>
        <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:Label ID="Label31" runat="server" CssClass="LabelCss" Height="25px" Text="Nom d'utilisateur" Width="200px"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="UserName" runat="server" Width="250px" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserName" ControlToValidate="UserName" ForeColor="Red"  runat="server" ErrorMessage="Champs Nom d'Utilisateur est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
    &nbsp;
        <asp:Label ID="Label36" runat="server" CssClass="LabelCss" Height="25px" Text="Rôle de l'Agent" Width="200px"></asp:Label>
&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownList_role" runat="server" Width="250px" DataSourceID="OdsRole" DataTextField="Name" DataValueField="Id" CssClass="ComponentLeft" Height="25px">
        </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDropDownList_role" ControlToValidate="DropDownList_role" InitialValue="0" ForeColor="Red"  runat="server" ErrorMessage="DropDownList_role Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
    </p>
        <p> &nbsp;</p>
    <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label32" runat="server" CssClass="LabelCss" Height="25px" Text="Mot de passe" Width="200px"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="Password" runat="server" Width="250px" TextMode="Password" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Password" ControlToValidate="Password" ForeColor="Red"  runat="server" ErrorMessage="Champs Mot de Passe est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
        &nbsp;&nbsp;
        <asp:Label ID="Label33" runat="server" CssClass="LabelCss" Height="25px" Text="Confirmer le mot de passe" Width="200px"></asp:Label>
&nbsp;&nbsp; <asp:TextBox ID="PasswordConfirm" runat="server" Width="250px" TextMode="Password" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_PasswordConfirm" ControlToValidate="PasswordConfirm" ForeColor="Red"  runat="server" ErrorMessage="Confirmer le Mot de Passe" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="La Confirmation du Mot de Passe ne correspond pas" ControlToValidate="PasswordConfirm" ControlToCompare="Password" ForeColor="Red" ValidationGroup="Validation" >*</asp:CompareValidator>
        </p>
        <p> &nbsp;</p>
    <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label34" runat="server" CssClass="LabelCss" Height="25px" Text="Structure de l'Agent" Width="200px"></asp:Label>
        &nbsp;&nbsp; <asp:DropDownList ID="DropDownListWilaya" runat="server" DataSourceID="OdsStructure" DataTextField="IntituleFr" DataValueField="StructureId" Width="250px" CssClass="ComponentLeft" Height="25px">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidatorModeTransmission" ControlToValidate="DropDownListWilaya" InitialValue="0" ForeColor="Red"  runat="server" ErrorMessage="Wilaya Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
        &nbsp;&nbsp;
        <asp:Label ID="Label35" runat="server" CssClass="LabelCss" Height="25px" Text="E-mail de l'Agent" Width="200px"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="Email" runat="server" Width="250px" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" ControlToValidate="Email" ForeColor="Red"  runat="server" ErrorMessage="Champs Email est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
        </p>
        <p> &nbsp;</p>
        <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label38" runat="server" CssClass="LabelCss" Height="25px" Text="Matricule de l'Agent" Width="200px"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="MatriculeAgent" runat="server" Width="250px" CssClass="ComponentLeft" Height="25px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator_Matricule" ControlToValidate="MatriculeAgent" ForeColor="Red"  runat="server" ErrorMessage="Champs Matricule est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
        </p>
    <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
        <p> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Enregistrer" OnClick="Register_Onclick" CssClass="ButtonCss" Height="25px" Width="250px" ValidationGroup="Validation" />
    </p>


        <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" ValidationGroup="Validation" />
        <p>
        <asp:ObjectDataSource ID="OdsUsersAgents" runat="server"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsStructure" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllStructures" TypeName="controller.StructureBLL">
            
        </asp:ObjectDataSource>
    </p>
    <p> 
        <asp:ObjectDataSource ID="OdsRole" runat="server" DataObjectTypeName="Model.AspNetRoles" DeleteMethod="deleteRole" InsertMethod="insertRole" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRole" TypeName="controller.role_controller" UpdateMethod="updateRole">
            <DeleteParameters>
                <asp:Parameter Name="guid" Type="String" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="guid" Type="Int32" />
            </UpdateParameters>
        </asp:ObjectDataSource>
    </p>
        </div>
</asp:Content>
