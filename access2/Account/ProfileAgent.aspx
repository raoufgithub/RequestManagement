<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="ProfileAgent.aspx.cs" Inherits="view.Account.ProfileAgent" %>
<%-- to retrieve the RegisterTrigger --%>
<%@ MasterType VirtualPath="~/MasterPages/Site.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="AgentSetting.css" rel="stylesheet" />


    <script type="text/javascript">
            function ShowImageProfile() {
                $("#ImageProfile_Click").click();
            }
        </script>


    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            if (confirm("Etes vous sûr de vouloir modifier le Profile de l'Utilisateur?")) {
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
    <asp:Label ID="Label32" runat="server" Font-Size="Large" Text="Cette Page permet de Modifier le Profile de l'Utilisateur"></asp:Label>
    <br />
        <br />
        <asp:Label ID="Label35" runat="server" CssClass="LabelCss" Height="25px" Text="Nom d'Utilisateur" Width="200px"></asp:Label>
        &nbsp;
        <asp:TextBox ID="TextBox_UserName" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px" ReadOnly='<%# VisibilityUserNameMatricule() %>'></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label38" runat="server" CssClass="LabelCss" Height="25px" Text="Structure" Width="200px"></asp:Label>
&nbsp;
        <asp:DropDownList ID="DropDownList_Structure" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px" DataSourceID="OdsStructure" DataTextField="wilaya" DataValueField="num"></asp:DropDownList>
        <br />
    <br />
    <asp:Label ID="Label33" runat="server" Text="Nom de l'Agent" CssClass="LabelCss" Height="25px" Width="200px"></asp:Label>
    &nbsp;
        <asp:TextBox ID="TextBox_AgentName" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label34" runat="server" CssClass="LabelCss" Height="25px" Text="Prenom de l'Agent" Width="200px"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox_AgentFirstName" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px"></asp:TextBox>
    <br />
        <br />
        <asp:Label ID="Label39" runat="server" CssClass="LabelCss" Height="25px" Text="L'adresse E-mail" Width="200px"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox_Email" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="Label40" runat="server" CssClass="LabelCss" Height="25px" Text="Matricule de l'Agent" Width="200px"></asp:Label>
&nbsp;
        <asp:TextBox ID="TextBox_AgentMatricule" runat="server" CssClass="ComponentLeft" Height="25px" Width="200px" ReadOnly='<%# VisibilityUserNameMatricule() %>'></asp:TextBox>
        <br />
    <br />

        <asp:Label ID="Label1" runat="server" Text="Charger la Photo" CssClass="LabelCss"></asp:Label>
        <br />
    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="LabelCss" Width="400px" />
        <asp:Label ID="Label31" runat="server"></asp:Label>
        <br />
        <asp:Panel ID="Panel1" runat="server">
        </asp:Panel>
    <br />

        <asp:Button ID="Button_AddPhotoProfile" runat="server" CssClass="CssButton" OnClick="ButtonPhotoProfile_Click" Text="Modifier la Photo de Profile" />

        <br />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        </asp:UpdatePanel>
        <asp:ObjectDataSource ID="OdsMessages" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMessages" TypeName="controller.Messaging_Controller" InsertMethod="InsertMessages">
            <InsertParameters>
                <asp:Parameter Name="IdUser_Sending" Type="String" />
                <asp:Parameter Name="IdUser_Receiving" Type="String" />
                <asp:Parameter Name="link" Type="String" />
                <asp:Parameter Name="message" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="IdUser_Sending" Type="String" />
                <asp:Parameter Name="IdUser_Receiving" Type="String" DefaultValue="" />
            </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="OdsMessageDetails" runat="server" InsertMethod="InsertMessages" OldValuesParameterFormatString="original_{0}" SelectMethod="GetMessageByUserName" TypeName="controller.Messaging_Controller">
            <InsertParameters>
                <asp:Parameter Name="IdUser_Sending" Type="String" />
                <asp:Parameter Name="IdUser_Receiving" Type="String" />
                <asp:Parameter Name="link" Type="String" />
                <asp:Parameter Name="message" Type="String" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter Name="IdUserName_Sending" Type="String" DefaultValue="" />
                <asp:Parameter Name="IdUserName_Receiving" Type="String" DefaultValue="" />
                <asp:Parameter Name="DateSending" Type="DateTime" DefaultValue="" />
            </SelectParameters>
        </asp:ObjectDataSource>




        <asp:ObjectDataSource ID="OdsStructure" runat="server" DataObjectTypeName="Model.wilayas" DeleteMethod="deleteWilaya" InsertMethod="insertWilaya" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllWilayaWithDG" TypeName="controller.wilaya_controller" UpdateMethod="updateWilaya">
            <DeleteParameters>
                <asp:Parameter Name="guid" Type="Int32" />
            </DeleteParameters>
        </asp:ObjectDataSource>




        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button_ModifyProfileAgent" runat="server" CssClass="ButtonCss" Height="30px" OnClick="ModifyButton_Click" Text="Modifier" Width="200px"  OnClientClick="Confirm()"/>




        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" CssClass="ButtonCss" Text="Annuler" Width="250px" Height="30px" OnClick="CancalButton_Click" />




        </div>




          <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

        <!-- Trigger the modal with a button -->
<button id="ImageProfile_Click" type="button" class="btn btn-primary btn-lg"
                data-toggle="modal" data-target="#myModal_Images" style="visibility:hidden;">Open Modal</button>

<!-- Modal -->
<div id="myModal_Images" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">
            <asp:Label ID="Label17" runat="server" Text="Label"></asp:Label></h4>
      </div>
      <div class="modal-body">
        <p>
          
            
            <div id="Div2" runat="server" style="overflow-x:auto;width:960px;overflow-y:auto; height:350px" visible="true">
            <asp:Image ID="Image1" runat="server" /></p>
                </div>
       
        
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Fermer</button>
      </div>
    </div>

  </div>
</div>
             </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
