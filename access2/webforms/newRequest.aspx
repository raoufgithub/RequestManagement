<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="newRequest.aspx.cs" Inherits="view.webforms.newRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>


    <link href="Test.css" rel="stylesheet" />
    
    <%--<link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.standalone.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />--%>
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">

    <script src="../bootstrap-datepicker-1.4.0-dist/js/bootstrap-datepicker.min.js"></script>
    
        <script type="text/javascript">
            $(document).ready(function () {
                $('.datepicker').datepicker({
                    format: 'dd/mm/yyyy',
                    "autoclose": true,

                })

                
                
            })


            
        </script>

    <script type="text/javascript">
        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);

            function EndRequestHandler(sender, args) {
                $('.datepicker').datepicker
                    ({
                        format: 'dd/mm/yyyy',
                        "autoclose": true

                    });
            }
        });
            </script>

    
    <div id="border" class="center-div">

          <asp:FormView ID="FormView1" runat="server" DataSourceID="OdsRequete" Width="1012px" DefaultMode="Insert">
        
        <EditItemTemplate>
            num:
            <asp:TextBox ID="numTextBox" ClientIDMode="Static" runat="server" Text='<%# Bind("num") %>' />
            <br />
            objet:
            <asp:TextBox ID="objetTextBox" runat="server" Text='<%# Bind("objet") %>' />
            <br />
            date:
            <asp:TextBox ID="dateTextBox" runat="server" Text='<%# Bind("date") %>' />
            <br />
            num_dispositif:
            <asp:TextBox ID="num_dispositifTextBox" runat="server" Text='<%# Bind("num_dispositif") %>' />
            <br />
            num_wilaya:
            <asp:TextBox ID="num_wilayaTextBox" runat="server" Text='<%# Bind("num_wilaya") %>' />
            <br />
            num_promoteur:
            <asp:TextBox ID="num_promoteurTextBox" runat="server" Text='<%# Bind("num_promoteur") %>' />
            <br />
            corp_requete:
            <asp:TextBox ID="corp_requeteTextBox" runat="server" Text='<%# Bind("corp_requete") %>' />
            <br />
            dispositif:
            <asp:TextBox ID="dispositifTextBox" runat="server" Text='<%# Bind("dispositif") %>' />
            <br />
            wilayas:
            <asp:TextBox ID="wilayasTextBox" runat="server" Text='<%# Bind("wilayas") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>

        <InsertItemTemplate>
            
            Cette page vous permet de créer une nouvelle reclamation :<br /> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <asp:Label ID="Label32" runat="server" Text="Numero de la Requête" CssClass="LabelLeft"></asp:Label>
            &nbsp;<br /> <asp:TextBox ID="numTextBox" CssClass="ComponentLeft" runat="server" Text='<%# Bind("num") %>' />
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="numTextBox" ErrorMessage="Le champs numero de la requête doit être numérique" ForeColor="Red" ValidationExpression="^\d+$" ValidationGroup="Validation">*</asp:RegularExpressionValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> &nbsp;<asp:Label ID="Label33" runat="server" CssClass="LabelRight" Text="Mode de Transmission"></asp:Label>
            &nbsp;<br /> <asp:DropDownList ID="DropDownList1" CssClass="ComponentRight" runat="server" DataSourceID="OdsModeTransmission" DataTextField="mode_trans" DataValueField="id_trans" SelectedValue='<%# Bind("dispositif") %>'>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorModeTransmission" ControlToValidate="DropDownList1" InitialValue="0" ForeColor="Red"  runat="server" ErrorMessage="Mode Transmission Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
        
            <br />
            <asp:Label ID="Label34" runat="server" CssClass="LabelLeft" Text="Dispositif de la Requête"></asp:Label>
            <br />
            <asp:DropDownList ID="DropDownList3"  CssClass="ComponentLeft" runat="server" DataSourceID="OdsDispositif" DataTextField="dispositif1" DataValueField="num" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
            </asp:DropDownList>
           
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDispositif" ControlToValidate="DropDownList3" InitialValue="0" ForeColor="Red"  runat="server" ErrorMessage="Dispositif est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:Label ID="Label35" runat="server" CssClass="LabelRight" Text="Objet de la Requête"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br /> <asp:DropDownList ID="DropDownList4" CssClass="ComponentRight"  runat="server">
                <asp:ListItem Value="0">Choisir une Dispositif</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMotifReclam" ControlToValidate="DropDownList4" InitialValue="0" ForeColor="Red"  runat="server" ErrorMessage="Motif est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            
            
            <br />
            <asp:Label ID="Label36" runat="server" CssClass="LabelLeft" Text="Date d'Envoie"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox58" CssClass="datepicker" runat="server" Height="25px" Width="246px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="DropDownList2" InitialValue="0" ForeColor="Red"  runat="server" ErrorMessage="La Date est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            
            <asp:RegularExpressionValidator ID="dateValRegex" ForeColor="Red" runat="server" ControlToValidate="TextBox58" ErrorMessage="Format Date (mm/dd/yyyy)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" ValidationGroup="Validation">*</asp:RegularExpressionValidator>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp; <asp:Label ID="Label37" runat="server" CssClass="LabelRight" Text="Wilaya"></asp:Label>
            &nbsp;&nbsp;<br /> <asp:Label ID="Label31" runat="server" Text='<%# getAgentWilaya() %>' Visible='<%# !isDGCell() %>' CssClass="ComponentRight"></asp:Label>
            &nbsp;<asp:DropDownList ID="DropDownList2" CssClass="ComponentRight"  runat="server" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num" SelectedValue='<%# Bind("wilaya") %>' Visible='<%# isDGCell() %>'>
            </asp:DropDownList>
            
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DropDownList2" InitialValue="0" ForeColor="Red"  runat="server" ErrorMessage="Wilaya est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            
            
            <br />
            <asp:Label ID="Label38" runat="server" CssClass="LabelLeft" Text="Numero du Requerant"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox11" CssClass="ComponentLeft"  runat="server"></asp:TextBox>
            &nbsp;<asp:Button ID="Button1" runat="server" data-toggle="modal" data-target="#myModal" Text="..." Width="20px" CssClass="ComponentLeft" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:Label ID="Label39" runat="server" CssClass="LabelRight" Text="Type de la Requête"></asp:Label>
            &nbsp;&nbsp;&nbsp;
            <br />
            <asp:DropDownList ID="DropDownList5" CssClass="ComponentRight"  runat="server" DataSourceID="OdsTypes" DataTextField="type" DataValueField="id_types">
            </asp:DropDownList>
            <br />
            <asp:Label ID="Label40" runat="server" CssClass="LabelLeft" Text="Motif de la Requête"></asp:Label>
            <br />
            <asp:TextBox ID="objetTextBox" CssClass="ComponentLeft"  runat="server" Text='<%# Bind("objet") %>' />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="objetTextBox"  ForeColor="Red"  runat="server" ErrorMessage="Objet de la Reclammation est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:Label ID="Label41" runat="server" CssClass="LabelRight" Text="Voie de Transmission"></asp:Label>
            &nbsp;
            <br />
            <asp:DropDownList ID="DropDownList6" CssClass="ComponentRight"  runat="server" DataSourceID="OdsVoieTransmission" DataTextField="voie_trans" DataValueField="id_voie">
            </asp:DropDownList>
            
            <br />

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label42" runat="server" CssClass="LabelLeft" Text="Résumé de la Requête"></asp:Label>
            &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4"  ControlToValidate="corp_requeteTextBox"  ForeColor="Red"  runat="server" ErrorMessage="Resumé de la reclammation est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            
            &nbsp;
            <br />
            <br />
            &nbsp;<asp:TextBox ID="corp_requeteTextBox" CssClass="ComponentDescription"  runat="server" Height="500px" Text='<%# Bind("corp_requete") %>' TextMode="MultiLine" Width="745px" />
            
            <br />
             <%--OnClientClick="return confirm('Are you sure to insert')"--%>
            <asp:LinkButton ID="InsertButton"  CssClass="datepickerTextBoxTest"  runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" ValidationGroup="Validatation" Visible="False" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" Visible="False" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;<asp:Button ID="Button2" CssClass="ButtonCss"  runat="server" Height="35px" OnClick="Button2_Click3" Text="Ajouter une Requête" ValidationGroup="Validation" Width="350px" />
            <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" ValidationGroup="Validation" />
        

        </InsertItemTemplate>

        <ItemTemplate>
            num:
            <asp:Label ID="numLabel" runat="server" Text='<%# Bind("num") %>' />
            <br />
            objet:
            <asp:Label ID="objetLabel" runat="server" Text='<%# Bind("objet") %>' />
            <br />
            date:
            <asp:Label ID="dateLabel" runat="server" Text='<%# Bind("date") %>' />
            <br />
            num_dispositif:
            <asp:Label ID="num_dispositifLabel" runat="server" Text='<%# Bind("num_dispositif") %>' />
            <br />
            num_wilaya:
            <asp:Label ID="num_wilayaLabel" runat="server" Text='<%# Bind("num_wilaya") %>' />
            <br />
            num_promoteur:
            <asp:Label ID="num_promoteurLabel" runat="server" Text='<%# Bind("num_promoteur") %>' />
            <br />
            corp_requete:
            <asp:Label ID="corp_requeteLabel" runat="server" Text='<%# Bind("corp_requete") %>' />
            <br />
            dispositif:
            <asp:Label ID="dispositifLabel" runat="server" Text='<%# Bind("dispositif") %>' />
            <br />
            wilayas:
            <asp:Label ID="wilayasLabel" runat="server" Text='<%# Bind("wilayas") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
        </ItemTemplate>
    </asp:FormView>
    
    </div>
    <asp:ObjectDataSource ID="OdsReclamation" runat="server" DataObjectTypeName="Model.reclamation" DeleteMethod="deleteRecalamation" InsertMethod="insertReclamation" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllReclamation" TypeName="controller.requete_controller" UpdateMethod="updatereclamation">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="OdsTypes" runat="server" DataObjectTypeName="Model.types" DeleteMethod="deleteType" InsertMethod="insertType" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllType" TypeName="controller.Type_Controller" UpdateMethod="updateType">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="OdsVoieTransmission" runat="server" DataObjectTypeName="Model.Voie_Transmission" DeleteMethod="deleteVoieModeTransmission" InsertMethod="insertVoieModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllVoieModeTransmission" TypeName="controller.VoieTrans_Controller" UpdateMethod="updateVoieModeTransmission">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </UpdateParameters>
</asp:ObjectDataSource>
    
    <br />






    
     

    
            <asp:ObjectDataSource ID="OdsRequete" runat="server" DeleteMethod="deleteRecalamation" OldValuesParameterFormatString="original_{0}" SelectMethod="getReclamationByNum" TypeName="controller.requete_controller" UpdateMethod="updatereclamation" DataObjectTypeName="Model.reclamation" InsertMethod="insertReclamation" OnSelecting="OdsRequete_Selecting">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="Num" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>



    <asp:ObjectDataSource ID="OdsMotifDispositif" runat="server" DataObjectTypeName="Model.Motif" DeleteMethod="deleteMotifDispositif" InsertMethod="insertMotifDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getMotifByDispositif" TypeName="controller.MotifDispositif_Controller" UpdateMethod="updateMotifDispositif">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter Name="num_dispositif" Type="Int32" />
                </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsMotifRequete" runat="server"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsModeTransmission" runat="server" DataObjectTypeName="Model.Transmission" DeleteMethod="deleteModeTransmission" InsertMethod="insertModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllModeTransmission" TypeName="controller.ModeTranmission_Controller" UpdateMethod="updateModeTransmission">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsDispositif" runat="server" DataObjectTypeName="Model.dispositif" DeleteMethod="deleteDispositif" InsertMethod="insertDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllDispositif" TypeName="controller.dispositif_controller" UpdateMethod="updateDispositif">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsWilaya" runat="server" DataObjectTypeName="Model1.wilayas" DeleteMethod="deleteWilaya" InsertMethod="insertWilaya" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllWilaya" TypeName="controller.wilaya_controller" UpdateMethod="updateWilaya">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
    </asp:Content>




