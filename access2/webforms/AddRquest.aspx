<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="AddRquest.aspx.cs" Inherits="view.webforms.AddRquest" %>

<%-- to retrieve the RegisterTrigger --%>
<%@ MasterType VirtualPath="~/MasterPages/Site.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <%--<link href="../Content/bootstrap.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.10.2.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>--%>
    <script type="text/javascript" src="bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />

    <%--<link href="AddRequest.css" rel="stylesheet" />--%>

    <link href="request.css" rel="stylesheet" />
    
    <%--<link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.standalone.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />--%>
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.css" rel="stylesheet" />


     
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="MainContent">
    
    <script src="../bootstrap-datepicker-1.4.0-dist/js/bootstrap-datepicker.min.js"></script>
    
        <script type="text/javascript">
            function UploadFile(fileUpload) {
                if (fileUpload.value != '') {
                    document.getElementById("<%=Button_DisplayImg.ClientID %>").click();
                }
            }
        </script>
    

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
                        "autoclose": true,
                        
                    });
            }
        });
    </script>

    
    <div  >

          <asp:FormView ID="FormView1" runat="server" DataSourceID="OdsRequete"  DefaultMode="Insert" >
        
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
            numéro de Mission:
            <asp:TextBox ID="num_dispositifTextBox" runat="server" Text='<%# Bind("num_mission") %>' />
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
            Mission:
            <asp:TextBox ID="dispositifTextBox" runat="server" Text='<%# Bind("Mission") %>' />
            <br />
            wilayas:
            <asp:TextBox ID="wilayasTextBox" runat="server" Text='<%# Bind("wilayas") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>

        <InsertItemTemplate>
         <div class="center">
            <div class="row">
               <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label ID="Label43" runat="server" CssClass="LabelCss" Font-Size="X-Large" Text="Ajouter une nouvelle Requête"></asp:Label>
                   </div> 
                </div>
                    <br />
            <div class="row">
                 
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="Label33" runat="server" Text="Mode de Transmission"></asp:Label>
            
                     <asp:DropDownList CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" ID="DropDownList1"  runat="server" DataSourceID="OdsModeTransmission" DataTextField="mode_trans" DataValueField="id_trans" SelectedValue='<%# Bind("dispositif") %>'>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12 " ID="RequiredFieldValidatorModeTransmission" ControlToValidate="DropDownList1" InitialValue=" " ForeColor="Red"  runat="server" ErrorMessage="Mode Transmission Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                  
               
            
                
                    
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="Label41" runat="server" Text="Emetteur" ></asp:Label>
                    
                    <asp:DropDownList CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" ID="DropDownList6" runat="server" DataSourceID="OdsVoieTransmission" DataTextField="voie_trans" DataValueField="id_voie" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidator3" ControlToValidate="DropDownList6" InitialValue=" " ForeColor="Red"  runat="server" ErrorMessage="La Case Emetteur est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                
               </div>
               <div class="row">     
                
                   
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="Label34" runat="server" Text="Missions CNAC" ></asp:Label>
                    <asp:DropDownList CssClass="col-lg-9 col-md-9 col-sm-5 col-xs-12 ComponentCss" ID="DropDownList3"  runat="server" DataSourceID="OdsDispositif" DataTextField="mission1" DataValueField="num" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                    </asp:DropDownList>
           
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidatorDispositif" ControlToValidate="DropDownList3" InitialValue="00000000-0000-0000-0000-000000000000" ForeColor="Red"  runat="server" ErrorMessage="Mission est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
              </div>
             <div class="row">     
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="LabelPhase" runat="server" Text="Phase de l'Objet"></asp:Label>
                     <asp:DropDownList CssClass="col-lg-9 col-md-9 col-sm-5 col-xs-12 ComponentCss" ID="DropDownListPhase" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPhase_SelectedIndexChanged">
                        <asp:ListItem Value="00000000-0000-0000-0000-000000000000">Choisir une Mission</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidatorPhase" ControlToValidate="DropDownListPhase" InitialValue="00000000-0000-0000-0000-000000000000" ForeColor="Red"  runat="server" ErrorMessage="Phase de l'Objet est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                
            </div>
            <div class="row">     
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="Label35" runat="server" Text="Objet de la Requête"></asp:Label>
                     <asp:DropDownList CssClass="col-lg-9 col-md-9 col-sm-5 col-xs-12 ComponentCss"  OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" AutoPostBack="True" ID="DropDownList4" runat="server">
                        <asp:ListItem Value="00000000-0000-0000-0000-000000000000">Choisir une Phase</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidatorMotifReclam" ControlToValidate="DropDownList4" InitialValue="00000000-0000-0000-0000-000000000000" ForeColor="Red"  runat="server" ErrorMessage="Objet est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                    
            </div>
             <div class="row">     
                <asp:Label ID="LabelMotif" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Motif"></asp:Label>
                <asp:DropDownList ID="DropDownListMotif" CssClass="col-lg-9 col-md-9 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsMotifOfObject" DataTextField="MotifName" DataValueField="MotifId">
                    <asp:ListItem Value="00000000-0000-0000-0000-000000000000">Choisir un Objet</asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidatorMotifObjet" ControlToValidate="DropDownListMotif" InitialValue="00000000-0000-0000-0000-000000000000" ForeColor="Red"  runat="server" ErrorMessage="Motif est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            </div>
            
             <div class="row">       
                
                                  
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="Label37" runat="server" Text="Wilaya" ></asp:Label>
                    <%--<asp:Label CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" ID="Label31" runat="server" Text='<%# getAgentWilaya() %>' Visible='<%# !isDGCell() %>' ></asp:Label>--%>
                    <asp:DropDownList CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" ID="DropDownList2" runat="server" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num" Enabled='<%# isDGCell() %>' AutoPostBack="true" OnSelectedIndexChanged="DropDownListWilaya_SelectedIndexChanged" >
                    </asp:DropDownList>
            
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidatorWilaya" ControlToValidate="DropDownList2" InitialValue="0" ForeColor="Red"  runat="server" ErrorMessage="Wilaya est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                    
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="LabelCommune" runat="server" Text="Commune" ></asp:Label>
                    <asp:DropDownList CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" ID="DropDownListCommune" runat="server">
                        <asp:ListItem Value="00000000-0000-0000-0000-000000000000">Choisir la wilaya</asp:ListItem>
                    </asp:DropDownList>
            
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidator6" ControlToValidate="DropDownListCommune" InitialValue="00000000-0000-0000-0000-000000000000" ForeColor="Red"  runat="server" ErrorMessage="Commune est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>

                
               </div>
            
            <div class="row">     
                
                                      
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="Label36" runat="server" Text="Date de Réception"></asp:Label>
                    
                    <asp:TextBox CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss datepicker" ID="TextBox58" runat="server" ></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidator1" ControlToValidate="TextBox58" ForeColor="Red"  runat="server" ErrorMessage="La Date est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                    <asp:RangeValidator id="valDateRange" runat="server"  ForeColor="Red"   ControlToValidate="TextBox58" MaximumValue='<%# DateTime.Now.ToShortDateString()  %>' MinimumValue="01/01/1000" ErrorMessage="La date de Reception ne doit pas être superieur de la Date d'aujourd'huit" Type="Date" Display="Dynamic" ValidationGroup="Validation" >*</asp:RangeValidator>
                    <asp:RegularExpressionValidator ID="dateValRegex" ForeColor="Red" runat="server" ControlToValidate="TextBox58" ErrorMessage="Format Date (JJ/MM/AAAA)  exemple (21/05/1986)" ValidationExpression="^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$" ValidationGroup="Validation">*</asp:RegularExpressionValidator>

                         
                
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="Label39" runat="server" Text="Type de la Requête" ></asp:Label>
                    
                    <asp:DropDownList CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" ID="DropDownList5" runat="server" DataSourceID="OdsTypes" DataTextField="type" DataValueField="id_types" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidator5" ControlToValidate="DropDownList5" InitialValue=" " ForeColor="Red"  runat="server" ErrorMessage="Type de la Requête est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                
                    
                    <asp:TextBox CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" ID="TextBox11" runat="server" Visible="False"></asp:TextBox>
                    
               </div> 
                <div class="row"> 
                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="Label38" runat="server" Text="Requerant" ></asp:Label>
                    <asp:TextBox CssClass="col-lg-8 col-md-8 col-sm-5 col-xs-12 ComponentCss" ID="TextBox59"  runat="server"  ReadOnly="True"></asp:TextBox>
                    <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-2 col-xs-12" ID="RequiredFieldValidator2" ControlToValidate="TextBox59" ForeColor="Red"  runat="server" ErrorMessage="Les informations du Requerant sont obligatoires" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                    <asp:Button ID="Button1" CssClass="col-lg-1 col-md-1 col-sm-1 col-xs-1 ComponentCss" runat="server" Text="..."  OnClick="GetRequerant_OnClick" />
                </div>

            <div class="row">    

                    <asp:Label CssClass="col-lg-2 col-md-2 col-sm-6 col-xs-12 LabelCss" ID="Label44" runat="server" Text="Pièces jointes" ></asp:Label>
                    
                    <br />
            
                    <asp:FileUpload CssClass="col-lg-5 col-md-5 col-sm-6 col-xs-12 FileUpload1" ID="FileUpload1" runat="server"  AllowMultiple="True" onchange="UploadFile(this);" />
                            <%--<asp:Button ID="BtnLncheFileUpload" runat="server" Text="Joindre un fichier" />--%>
                            <asp:Panel ID="Panel_FileUpload" runat="server">
                            </asp:Panel>
           
                    <asp:Label CssClass="col-lg-5 col-md-5 col-sm-12 col-xs-12 LabelCss" ID="Label45" runat="server" ></asp:Label>
            </div>
                 
                <div class="row">
                        <asp:Label CssClass="col-lg-5 col-md-5 col-sm-5 col-xs-12 LabelCss" ID="Label42" runat="server" Text="Résumé de la Requête"></asp:Label>
            
                        <asp:RequiredFieldValidator CssClass="col-lg-1 col-md-1 col-sm-7 col-xs-12" ID="RequiredFieldValidator4"  ControlToValidate="corp_requeteTextBox"  ForeColor="Red"  runat="server" ErrorMessage="Resumé de la reclammation est obligatoire" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                    </div>
                <div class="row">    
                    <asp:TextBox CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 textarea" ID="corp_requeteTextBox"  runat="server"  Text='<%# Bind("corp_requete") %>' TextMode="MultiLine" />
                    
                </div>
                    
                     <%--OnClientClick="return confirm('Are you sure to insert')"--%>
                    <asp:LinkButton ID="InsertButton"  CssClass="datepickerTextBoxTest"  runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" ValidationGroup="Validatation" Visible="False" />
                    <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" Visible="False" />
                <div class="row">    
                    <asp:Button CssClass="col-lg-12 col-md-12 Button_SendRequest" ID="Button_SendRequest" runat="server" OnClick="Button2_Click3" Text="Ajouter une Requête" ValidationGroup="Validation"  />
                </div>   
                <div class="row">     
                    <asp:ValidationSummary CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12" ID="ValidationSummary1" ForeColor="Red" runat="server" ValidationGroup="Validation" />
                </div>
            </div>

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
            <asp:Label ID="num_dispositifLabel" runat="server" Text='<%# Bind("num_mission") %>' />
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
            Mission:
            <asp:Label ID="dispositifLabel" runat="server" Text='<%# Bind("mission") %>' />
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
            <asp:Parameter Name="guid" Type="String" />
        </DeleteParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="OdsVoieTransmission" runat="server" DataObjectTypeName="Model.Voie_Transmission" DeleteMethod="deleteVoieModeTransmission" InsertMethod="insertVoieModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllVoieModeTransmission" TypeName="controller.VoieTrans_Controller" UpdateMethod="updateVoieModeTransmission">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="String" />
        </DeleteParameters>
</asp:ObjectDataSource>
    
      
     

    
            <asp:ObjectDataSource ID="OdsRequete" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getRequestByNum" TypeName="controller.requete_controller" OnSelecting="OdsRequete_Selecting" DeleteMethod="deleteRequest" InsertMethod="insertRequest" UpdateMethod="getNextNumRequest">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="r" Type="Object" />
                    <asp:Parameter Name="id_user" Type="String" />
                    <asp:Parameter Name="name_user" Type="String" />
                    <asp:Parameter Name="FilesUpload" Type="Object" />
                </InsertParameters>
        <SelectParameters>
            <asp:Parameter Name="Num" Type="Int32" />
            <asp:Parameter Name="NumWilaya_Request" Type="Int32" />
            <asp:Parameter Name="Year_Request" Type="Int32" />
        </SelectParameters>
                <UpdateParameters>
                    <asp:Parameter Name="NumWilaya" Type="Int32" />
                    <asp:Parameter Name="Year" Type="Int32" />
                </UpdateParameters>
    </asp:ObjectDataSource>



    <asp:ObjectDataSource ID="OdsMotifDispositif" runat="server" DeleteMethod="deleteMotifDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getMotifByPhase" TypeName="controller.MotifDispositif_Controller">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="String" />
                </DeleteParameters>
                <SelectParameters>
                    <asp:Parameter Name="PhaseId" DbType="Guid" />
                </SelectParameters>
            </asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsMotifOfObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMotifObjectByObject" TypeName="controller.MotifObjectBLL" DataObjectTypeName="System.Guid">
                <SelectParameters>
                    <asp:Parameter DbType="Guid" Name="ObjectId" />
                </SelectParameters>
        </asp:ObjectDataSource>

        <asp:ObjectDataSource ID="OdsPhaseMission" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getPhaseByMission" TypeName="controller.PhaseObjetBLL" DataObjectTypeName="System.Guid">
                <SelectParameters>
                    <asp:Parameter DbType="Guid" Name="MissionId" />
                </SelectParameters>
        </asp:ObjectDataSource>

            <asp:ObjectDataSource ID="OdsMotifRequete" runat="server"></asp:ObjectDataSource>
        <asp:ObjectDataSource ID="OdsModeTransmission" runat="server" DataObjectTypeName="Model.Transmission" DeleteMethod="deleteModeTransmission" InsertMethod="insertModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllModeTransmission" TypeName="controller.ModeTranmission_Controller" UpdateMethod="updateModeTransmission">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="String" />
                </DeleteParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsDispositif" runat="server" DataObjectTypeName="Model.Mission" DeleteMethod="deleteDispositif" InsertMethod="insertDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllDispositif" TypeName="controller.dispositif_controller" UpdateMethod="updateDispositif">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="String" />
                </DeleteParameters>
            </asp:ObjectDataSource>
        <asp:Button ID="Button_DisplayImg" runat="server" Text="Button" Style="display: none;" OnClick="Button_DisplayImg_Click" />


    <asp:ObjectDataSource ID="OdsWilaya" runat="server" DeleteMethod="deleteWilaya" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWilayasOfStructure" TypeName="controller.wilaya_controller">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="UserName" Type="String"></asp:Parameter>

        </SelectParameters>

    </asp:ObjectDataSource>

    <br />
    <asp:ObjectDataSource ID="ODSCommune" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCommuneByWilaya" TypeName="controller.Commune_Controller">
        <SelectParameters>
            <asp:Parameter DefaultValue="" Name="num_wilaya" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>



    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
        <ContentTemplate>

        <!-- Trigger the modal with a button -->
<button id="Image_Click" type="button" class="btn btn-primary btn-lg"
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
      <div class="modal-body" style="overflow:scroll; vertical-align:central">
        <p>
          
            
            <%--<div id="Div2" runat="server" style="overflow-x:auto;width:960px;overflow-y:auto; height:350px" visible="true">--%>
            <asp:Image ID="Image1" runat="server" />

        </p>
                <%--</div>--%>
       
        
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Fermer</button>
      </div>
    </div>

  </div>
</div>
             </ContentTemplate>
        </asp:UpdatePanel>



   
    <%--<asp:FileUpload  ID="FileUpload2" runat="server"  onchange="UploadFile(this);"  />
    <asp:Button ID="Button2" runat="server" Text="Button" />--%>


    
    
 
    </asp:Content>




