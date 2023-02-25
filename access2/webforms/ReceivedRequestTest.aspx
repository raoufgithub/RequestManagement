<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="ReceivedRequestTest.aspx.cs" Inherits="view.webforms.ReceivedRequestTest" %>
<%@ MasterType VirtualPath="~/MasterPages/Site.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        

    <script type="text/javascript" src="bootstrap-3.3.4-dist/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <%--<link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker3.standalone.min.css" rel="stylesheet" />
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.standalone.min.css" rel="stylesheet" />--%>
    <%--</div>--%>
    
    <link href="../bootstrap-datepicker-1.4.0-dist/css/bootstrap-datepicker.css" rel="stylesheet" />

    <%--<link href="AddRequest.css" rel="stylesheet" />--%>
    <link href="request.css" rel="stylesheet" />

    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="//maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet" />
    
    <style type="text/css">
        .auto-style2 {
            width: 307px;
        }
    </style>

    
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            
            if (confirm("Etes vous sûr de valider la requête?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
    <script type = "text/javascript">
        function ConfirmDelRequest() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";

            if (confirm("Etes vous sûr de vouloir supprimer la requête?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>



        <script type="text/javascript">
            function ShowImage() {
                $("#Image_Click").click();
            }
        </script>

    <script type="text/javascript">
        function ShowDetails() {
            $("#button_Details").click();
        }
        </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <script src="../bootstrap-datepicker-1.4.0-dist/js/bootstrap-datepicker.min.js"></script>
    

    <script type="text/javascript">
        function UploadFile(fileUpload) {
            if (fileUpload.value != '') {
                document.getElementById("<%= (FormView1.FindControl("Button_DisplayImg")).ClientID %>").click();
                }
            }
    </script>



        <script type="text/javascript">
            $(document).ready(function () {
                $('.datepicker').datepicker({
                    format: 'dd/mm/yyyy',
                    "autoclose": true
                })
            });

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

         


        <%--the modal popup that contain the DetailView--%>

        <%--<div style="overflow-x:auto;width:1050px;overflow-y:auto; height:327px">--%>


    
    <%--</div>--%>

   <div id="border" class="center-div">
    <%--<div style="overflow-x:auto;width:1050px;overflow-y:auto; height:327px">--%>
    <asp:FormView ID="FormView1" runat="server" DataSourceID="request" DefaultMode="Insert" >
        <EditItemTemplate>
            <asp:Label ID="Label44" runat="server" Font-Size="X-Large" Text="Modification de la Requête"></asp:Label>
            <div class="row">
                
                <asp:Label ID="Label43" runat="server"  CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Numero de la Requête"></asp:Label>
            
                <asp:Label ID="Label83" runat="server" CssClass="col-lg-1 col-md-1 col-sm-5 col-xs-12 ComponentCss"  Text='<%# Bind("num_wilaya") %>'></asp:Label>
                <asp:Label ID="Label84" runat="server" CssClass="col-lg-1 col-md-1 col-sm-5 col-xs-12 ComponentCss"  Text='<%# Bind("year") %>'></asp:Label>
                <asp:TextBox ID="numTextBox" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 ComponentCss"  Text='<%# Bind("num") %>' ReadOnly="True" >&lt;%# Bind(&quot;num&quot;) %&gt;</asp:TextBox>
            
                <asp:Label ID="Label45" runat="server"  CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Date"></asp:Label>
            
                <asp:TextBox ID="TextBox10" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss datepicker" runat="server" Text='<%# Bind("date", "{0:d}") %>' AutoPostBack="True" OnTextChanged="TextBox10_TextChanged1"></asp:TextBox>
            </div>
            <div class="row">
                <asp:Label ID="Label46" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Wilaya"></asp:Label>
                <asp:Label ID="Label31" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# getAgentWilaya() %>' Visible='<%# !isDGCell() %>'></asp:Label>
                <asp:DropDownList ID="DropDownList5" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num" SelectedValue='<%# Bind("num_wilaya") %>'  Visible='<%# isDGCell() %>' AutoPostBack="True" Enabled="false" OnTextChanged="Wilaya_Changed">
                </asp:DropDownList><%--<asp:DropDownList ID="DropDownList5" CssClass="ComponentLeft"  runat="server" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num" SelectedValue='<%# Bind("wilaya") %>' Visible='<%# isDGCell() %>' Height="25px" Width="200px">
                </asp:DropDownList>--%>
                <asp:Label ID="Label47" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Requerant"></asp:Label>
            
                <asp:TextBox ID="TextBox59" runat="server" CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" AutoPostBack="True" OnTextChanged="TextBox11_TextChanged" ReadOnly="True" Text='<%# Eval("NomRequerantC").ToString()+ " "+Eval("PrenomRequerantC").ToString() %>'/>
                <%--<asp:Button ID="Button5" data-toggle="modal" data-target="#myModal" runat="server" Text="..." Width="18px" Height="25px" CssClass="ButtonCss" />--%>
                <asp:Button ID="Button5" runat="server"  CssClass="col-lg-1 col-md-1 col-sm-5 col-xs-12 ComponentCss" OnClick="Button5_Click" Text="..." />
                <asp:TextBox ID="TextBox11" runat="server" AutoPostBack="True" CssClass="ComponentLeft" Text='<%# Bind("num_requerant") %>' Visible="False" Width="200px" />
            </div>
            <div class="row">         
                <asp:Label ID="Label48" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Dispositif"></asp:Label>
            
                <asp:DropDownList ID="DropDownList8" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsDispositif" DataTextField="mission1" DataValueField="num" OnSelectedIndexChanged="DropDownList8Modif_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="0">Choisir Un Dispositif</asp:ListItem>
                </asp:DropDownList>
                                <asp:Label ID="Label8" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Phase"></asp:Label>
            
                <asp:DropDownList ID="DropDownListPhase" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsPhaseMission" DataTextField="PhaseName" DataValueField="PhaseId" OnSelectedIndexChanged="DropDownListPhaseModif_SelectedIndexChanged" AutoPostBack="True">
                    <asp:ListItem Value="0">Choisir Un Dispositif</asp:ListItem>
                </asp:DropDownList>

            </div>
            <div class="row">   
                <asp:Label ID="Label49" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Objet du Dispositif"></asp:Label>
            
                <asp:DropDownList ID="DropDownList9" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsMotifDispositif" DataTextField="objet" DataValueField="id_objet" AutoPostBack="True" OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged1">
            
                </asp:DropDownList>
      
                <asp:Label ID="Label18" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Motif"></asp:Label>
            
                <asp:DropDownList ID="DropDownListMotif" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsMotifOfObject" DataTextField="MotifName" DataValueField="MotifId" AutoPostBack="True" OnSelectedIndexChanged="DropDownListMotif_SelectedIndexChanged1">
            
                </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label ID="Label50" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Etat de la Requête"></asp:Label>
            
                <asp:Label ID="Label75" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# Bind("EtatRequestC") %>'></asp:Label>
                <asp:Label ID="Label51" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Mode de Transmission"></asp:Label>
            
                <asp:DropDownList ID="DropDownList6" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsModeTransmission" DataTextField="mode_trans" DataValueField="id_trans" SelectedValue='<%# Bind("id_trans") %>' AutoPostBack="True" OnTextChanged="ModeTrans_Changed">
                </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label ID="Label68" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Type de la Requête"></asp:Label>
            
                <asp:DropDownList ID="DropDownList14" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" DataSourceID="OdsType" DataTextField="type" DataValueField="id_types" SelectedValue='<%# Bind("id_type") %>' AutoPostBack="True" OnTextChanged="TypeRequest_Changed">
                </asp:DropDownList>
            
                <asp:Label ID="Label69" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Emetteur"></asp:Label>
            
                <asp:DropDownList ID="DropDownList15" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" DataSourceID="OdsVoieTransmission" DataTextField="voie_trans" DataValueField="id_voie" SelectedValue='<%# Bind("id_Voie_Trans") %>' AutoPostBack="True" OnTextChanged="TransVoie_Changed">
                </asp:DropDownList>
            </div>
            <div class="row"> 
                <asp:Label CssClass="col-lg-2 col-md-2 col-sm-6 col-xs-12 LabelCss" ID="Label7" runat="server" Text="Pièces jointes" ></asp:Label>     
                <asp:FileUpload ID="FileUpload1" CssClass="col-lg-5 col-md-5 col-sm-6 col-xs-12 FileUpload1"  onchange="UploadFile(this);" runat="server" AllowMultiple="True" />
                <asp:Button ID="Button_DisplayImg" runat="server" Text="Button" Style="display: none;" OnClick="Button_DisplayImg_Click"  />
            
                <asp:Label ID="Label87" runat="server"></asp:Label>
            
            
            
                <asp:Panel ID="Panel2" runat="server"></asp:Panel>
            </div> 
            <div class="row">   
                <asp:Label ID="Label53" runat="server" CssClass="col-lg-2 col-md-2 col-sm-6 col-xs-12 LabelCss" Text="Résumé"></asp:Label>   
            </div>
            <div class="row">   
                <asp:TextBox ID="corp_requeteTextBox" CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 textarea" runat="server" Text='<%# Bind("corp_requete") %>' TextMode="MultiLine" AutoPostBack="True" OnTextChanged="corp_requeteTextBox_TextChanged" />
            </div>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Modifier"/>
            
            <asp:Button ID="Button4" runat="server" Text="Annuler" CssClass="ButtonCss" OnClick="Button4_Click" />
            <br /> <br />&nbsp;<asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" Visible="False" />
            <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" Visible="False" />
        </EditItemTemplate>
        <InsertItemTemplate>
            <asp:Label ID="Label42" runat="server" CssClass="title-form" Text="Requêtes Introduites" Font-Size="X-Large"></asp:Label>
            <div class="row">
                <asp:Label ID="Label31" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Numero de la Requête"></asp:Label>
                <asp:TextBox ID="numTextBox" runat="server" AutoPostBack="True" OnTextChanged="numTextBox_TextChanged" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" ></asp:TextBox>
                <asp:Label ID="Label32" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Date(Du-Au)"></asp:Label>
                <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("date", "{0:d}") %>' CssClass="col-lg-2 col-md-2 col-sm-2 col-xs-6 ComponentCss datepicker" AutoPostBack="True" OnTextChanged="TextBox10_TextChanged" />
                <%--<asp:Label ID="Label7" runat="server" CssClass="col-lg-1 col-md-1 col-sm-1 col-xs-2 LabelCss" Text="-"></asp:Label>--%>
                <asp:TextBox ID="TextBox12" runat="server" Text='<%# Bind("date", "{0:d}") %>' CssClass="col-lg-2 col-md-2 col-sm-2 col-xs-6 ComponentCss datepicker" AutoPostBack="True" OnTextChanged="TextBox12_TextChanged" />
            
            </div>
            <div class="row">
                <asp:Label ID="Label33" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Wilaya"></asp:Label>
                <%--<asp:Label ID="LabelWilaya" runat="server" Text='<%# getAgentWilaya() %>' Visible='<%# !isDGCell() %>' CssClass="ComponentLeft"></asp:Label>--%>
                <asp:DropDownList ID="DropDownList5" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num"  Enabled='<%# isDGCell() %>' AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged">
                </asp:DropDownList>

                <asp:Label CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" ID="LabelCommune" runat="server" Text="Commune" ></asp:Label>
                    <asp:DropDownList CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" ID="DropDownListCommune" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListCommune_SelectedIndexChanged">
                        <asp:ListItem Value="00000000-0000-0000-0000-000000000000">Choisir la wilaya</asp:ListItem>
                    </asp:DropDownList>
            </div>
             
            <div class="row">
                <asp:Label ID="LabelMissions" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Missions CNAC"></asp:Label>
                <asp:DropDownList ID="DropDownList8"  CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged" SelectedValue='<%# Bind("num_mission") %>' AutoPostBack="True" DataSourceID="OdsDispositif" DataTextField="mission1" DataValueField="num">
                </asp:DropDownList>
                <asp:Label ID="LabelPhase" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Phase Missions"></asp:Label>
            
                <asp:DropDownList ID="DropDownListPhase"  CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" OnSelectedIndexChanged="DropDownListPhase_SelectedIndexChanged" AutoPostBack="True" DataSourceID="OdsPhaseMission" DataTextField="PhaseName" DataValueField="PhaseId">
                </asp:DropDownList>
                
            </div>
            <div class="row">
                <asp:Label ID="Label36" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Objet de Dispositif"></asp:Label>
            
                <asp:DropDownList ID="DropDownList9"  CssClass="col-lg-10 col-md-10 col-sm-7 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsMotifDispositif" DataTextField="objet" DataValueField="id_objet" AutoPostBack="True" OnSelectedIndexChanged="DropDownList9_SelectedIndexChanged">
                    <asp:ListItem Value="00000000-0000-0000-0000-000000000000">Choisir une mission</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label ID="LabelMotif" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Motif"></asp:Label>
                <asp:DropDownList ID="DropDownListMotif"  CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" OnSelectedIndexChanged="DropDownListMotif_SelectedIndexChanged" AutoPostBack="True" DataSourceID="OdsMotifOfObject" DataTextField="MotifName" DataValueField="MotifId">
                    <asp:ListItem Value="00000000-0000-0000-0000-000000000000">Choisir un Objet</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="LabelDispositionPrise" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="DispositionPrise"></asp:Label>
            
                <asp:DropDownList ID="DropDownListDispositionPrise"  CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" OnSelectedIndexChanged="DropDownListDispositionPrise_SelectedIndexChanged" AutoPostBack="True" DataSourceID="OdsDispositionPrise" DataTextField="DispositionName" DataValueField="DispositionPriseId">
                    <asp:ListItem Value="00000000-0000-0000-0000-000000000000">Choisir un Motif</asp:ListItem>
                </asp:DropDownList>
                
            </div>
            <div class="row">
                <asp:Label ID="Label37" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Etat de la Requête" ></asp:Label>
            
                <asp:DropDownList ID="DropDownList7"  CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsStateRequest" DataTextField="nom_state" DataValueField="id_state" SelectedValue='<%# Bind("id_state") %>' AutoPostBack="True" OnSelectedIndexChanged="DropDownList7_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:Label ID="Label38" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Mode de Transmission"></asp:Label>
            
                <asp:DropDownList ID="DropDownList6"  CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsModeTransmission" DataTextField="mode_trans" DataValueField="id_trans" SelectedValue='<%# Bind("id_trans") %>' AutoPostBack="True" OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label ID="Label39" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Type de la Requête"></asp:Label>
                <asp:DropDownList ID="DropDownList12"  CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsType" DataTextField="type" DataValueField="id_types" OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
                <asp:Label ID="Label40" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Voie de Transmission"></asp:Label>
            
                <asp:DropDownList ID="DropDownList13"  CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" runat="server" DataSourceID="OdsVoieTransmission" DataTextField="voie_trans" DataValueField="id_voie" AutoPostBack="True" OnSelectedIndexChanged="DropDownList13_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
            <div class="row">
                <asp:Label ID="Label34" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Requerant"></asp:Label>
                <asp:TextBox ID="TextBox59"  CssClass="col-lg-9 col-md-9 col-sm-5 col-xs-12 ComponentCss" runat="server" Text='<%# Bind("num_requerant") %>' AutoPostBack="True" ReadOnly="True" />
                <%--<asp:Button ID="Button5" data-toggle="modal" data-target="#myModal" runat="server" Text="..." Width="18px" Height="25px" CssClass="ButtonCss" />--%>
                <asp:Button ID="Button5"  CssClass="col-lg-1 col-md-1 col-sm-1 col-xs-1 ComponentCss" OnClick="Button5_Click" runat="server" Text="..." />
                <asp:TextBox ID="TextBox11" runat="server" AutoPostBack="True" CssClass="ComponentLeft" OnTextChanged="TextBox11_TextChanged" Text='<%# Bind("num_requerant") %>' Visible="False" />
            </div>
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" Visible="False" />
            <asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" Visible="False" />
            <asp:FileUpload ID="FileUpload1" onchange="UploadFile(this);" Style="display: none;"  runat="server" AllowMultiple="True" />
            <asp:Button ID="Button_DisplayImg" runat="server" OnClick="Button_DisplayImg_Click" Style="display: none;" Text="Button1" />
            
        </InsertItemTemplate>
        <ItemTemplate>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; formview1<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Numero de requête&nbsp; :
            <asp:TextBox ID="TextBox2" runat="server" Width="180px" Height="25px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date de Requête&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:TextBox ID="TextBox3" CssClass="datepicker" runat="server" Width="180px" Height="25px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Wilayas&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num" Width="180px" Height="25px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Numero Requerant&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
            <asp:DropDownList ID="DropDownList2" runat="server" Width="180px" Height="25px">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mission&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:DropDownList ID="DropDownList3" runat="server" Height="25px" Width="180px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mode de Transmission&nbsp;&nbsp;:&nbsp;
            <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="OdsModeTransmission" DataTextField="mode_trans" DataValueField="id_trans" Width="180px" Height="25px">
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Objet&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:TextBox ID="TextBox1" runat="server" Width="649px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" OnClick="EditButton_Click" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" Visible="False" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" Visible="False" />
        </ItemTemplate>
    </asp:FormView>
    

    <asp:FormView ID="FormView2" runat="server" DataSourceID="request" DefaultMode="Edit" >
        <EditItemTemplate>
            <asp:Label ID="Label54" runat="server" Font-Size="X-Large" Text="Validation de la Requête"></asp:Label>
            <div class="row">
                <asp:Label ID="Label55" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Numero de la Requête"></asp:Label>
               
                <asp:Label ID="Label85" runat="server"  CssClass="col-lg-1 col-md-1 col-sm-5 col-xs-12 ComponentCss" ></asp:Label>
                <asp:Label ID="Label86" runat="server" CssClass="col-lg-1 col-md-1 col-sm-5 col-xs-12 ComponentCss" ></asp:Label>
                <asp:Label ID="Label10" runat="server" Text='<%# Bind("num") %>' CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 ComponentCss" ></asp:Label>
                <asp:Label ID="Label60" runat="server"  CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Date"></asp:Label>
                <asp:Label ID="Label11" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# Bind("date", "{0:d}") %>'></asp:Label>
            </div>
            <div class="row">
                <asp:Label ID="Label56" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Wilaya"></asp:Label>
            
                <asp:Label ID="Label12" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# Bind("WilayaC") %>'></asp:Label>
                <asp:Label ID="Label61" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Requerant"></asp:Label>
            
                <asp:Label ID="Label15" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# Eval("NomRequerantC").ToString()+" "+Eval("PrenomRequerantC") %>'></asp:Label>
            </div>
            <div class="row">
                <asp:Label ID="Label57" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Dispositif"></asp:Label>
            
                <asp:Label ID="Label13" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# Bind("DispositifC") %>'></asp:Label>
                <asp:Label ID="Label63" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Mode de Transmission"></asp:Label>
            
                <asp:Label ID="Label16" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# Bind("ModeTransmissionC") %>'></asp:Label>
            </div>
            <div class="row">
                <asp:Label ID="Label62" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Objet du Dispositif"></asp:Label>
            
                <asp:Label ID="Label14" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# Bind("MotifDispositifC") %>'></asp:Label>
            
                <asp:Label ID="Label70" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Type de la Requête"></asp:Label>
                <asp:Label ID="Label71" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# Bind("TypeRequestC") %>'></asp:Label>
            </div>
            <div class="row">

                <asp:Label ID="Label72" runat="server" CssClass="col-lg-2 col-md-2 col-sm-5 col-xs-12 LabelCss" Text="Emetteur"></asp:Label>
            
                <asp:Label ID="Label73" runat="server" CssClass="col-lg-4 col-md-4 col-sm-5 col-xs-12 ComponentCss" Text='<%# Bind("VoieTransC") %>'></asp:Label>
            </div>
            <div class="row DivCssValidation">
                <asp:Label ID="Label74" runat="server" Font-Size="Large" Text="La partie des champs de validation"></asp:Label>
            </div>
            <div class="row">
                <asp:Label ID="Label64" runat="server" CssClass="col-lg-2 col-md-2 col-sm-4 col-xs-12 LabelCss" Text="Réference d'envoi&nbsp;&nbsp;&nbsp; :"></asp:Label>
            
                <asp:TextBox ID="TextBoxRefEnvoi" runat="server" CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorReference" CssClass="col-lg-1 col-md-1 col-sm-1 col-xs-12 ComponentCss" runat="server" ControlToValidate="TextBoxRefEnvoi" ErrorMessage="Réference non remplie" ForeColor="Red" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                <asp:Label ID="Label65" runat="server" CssClass="col-lg-2 col-md-2 col-sm-4 col-xs-12 LabelCss" Text="Date D'envoi&nbsp; :"></asp:Label>
            
                <asp:TextBox ID="TextBoxDateEnvoi" runat="server" CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDateEnvoi" CssClass="col-lg-1 col-md-1 col-sm-1 col-xs-12 ComponentCss" runat="server" ControlToValidate="TextBoxDateEnvoi" ErrorMessage="Date non remplie" ForeColor="Red" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <asp:Label ID="LabelDispositionValidation" runat="server" CssClass="col-lg-2 col-md-2 col-sm-12 col-xs-12 LabelCss" Text="Disposition Prise"></asp:Label>
            
                <asp:DropDownList ID="DropDownListDispositionPriseValidation" runat="server" CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss" DataSourceID="OdsDispositionPrise" DataTextField="DispositionName" DataValueField="DispositionPriseId">
                    
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDispositionPriseValidation" CssClass="col-lg-1 col-md-1 col-sm-1 col-xs-12 ComponentCss" ControlToValidate="DropDownListDispositionPriseValidation" InitialValue="00000000-0000-0000-0000-000000000000" ForeColor="Red"  runat="server" ErrorMessage="La Disposition Prise est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                <asp:Label ID="Label58" runat="server" CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 LabelCss" Text="Etat de la Requête"></asp:Label>
            
                <asp:DropDownList ID="DropDownList7" runat="server" CssClass="col-lg-3 col-md-3 col-sm-5 col-xs-12 ComponentCss">
                    <asp:ListItem Value="2">Réglée</asp:ListItem>
                    <asp:ListItem Value="3">Non Fondée</asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorStateRequest" CssClass="col-lg-1 col-md-1 col-sm-1 col-xs-12 ComponentCss" ControlToValidate="DropDownList7" InitialValue=" " ForeColor="Red"  runat="server" ErrorMessage="Etat de la Requête est Vide" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <asp:Label ID="Label67" runat="server" CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 LabelCss" Text="Le Résultat :"></asp:Label>
            
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorResult" runat="server" ControlToValidate="resultat_traitement" ErrorMessage="Résultat non rempli" ForeColor="Red" ValidationGroup="Validation">*</asp:RequiredFieldValidator>
                    <asp:TextBox ID="resultat_traitement" runat="server" CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 textarea" Text='<%# Bind("result_traitement") %>' TextMode="MultiLine"></asp:TextBox>
                    <asp:Button ID="Button3" runat="server" CssClass="col-lg-5 col-md-5 Button_SendRequest" OnClick="Button3_Click" Text="Valider" ValidationGroup="Validation" OnClientClick="Confirm()"/>
                
                    <asp:Button ID="Button6" runat="server" CssClass="col-lg-5 col-md-5 Button_SendRequest" Text="Annuler" OnClick="Button6_Click" />
            </div>
            <div class="row">   
                    <asp:ValidationSummary ID="ValidationSummary1" ForeColor="Red" runat="server" ValidationGroup="Validation" />
                    <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" Visible="False" />
                    <asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" Visible="False" />
            </div> 
        </EditItemTemplate>
        <InsertItemTemplate>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Numero de Requête&nbsp;&nbsp; :&nbsp;&nbsp;
            <asp:TextBox ID="numTextBox" runat="server" Text='<%# Bind("num") %>' Height="25px" Width="180px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox10" runat="server" Text='<%# Bind("date", "{0:d}") %>' CssClass="datepicker" Height="25px" Width="180px" />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Wilaya&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList5" runat="server" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num" Height="25px" SelectedValue='<%# Bind("num_wilaya") %>' Width="180px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Requerant&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox11" runat="server" Text='<%# Bind("num_requerant") %>' Height="25px" Width="180px" />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mission&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList8" runat="server" Height="25px" OnSelectedIndexChanged="DropDownList8_SelectedIndexChanged" SelectedValue='<%# Bind("num_mission") %>' Width="180px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Objet de Dispositif&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; &nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList9" runat="server" Height="25px" Width="180px">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Etat de la Request&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;
            <asp:DropDownList ID="DropDownList7" runat="server" DataSourceID="OdsStateRequest" DataTextField="nom_state" DataValueField="id_state" Height="25px" SelectedValue='<%# Bind("id_state") %>' Width="180px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Mode de Transmission :&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="DropDownList6" runat="server" DataSourceID="OdsModeTransmission" DataTextField="mode_trans" DataValueField="id_trans" Height="25px" SelectedValue='<%# Bind("id_trans") %>' Width="180px">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Objet&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:&nbsp;&nbsp;
            <asp:TextBox ID="objetTextBox" runat="server" Text='<%# Eval("objet") %>' Height="25px" Width="550px" />
            &nbsp;&nbsp;&nbsp;
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; La lettre :<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="corp_requeteTextBox" runat="server" Height="342px" Text='<%# Bind("corp_requete") %>' TextMode="MultiLine" Width="896px" />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>
        <ItemTemplate>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; formview2<br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Numero de requête&nbsp; :
            <asp:TextBox ID="TextBox2" runat="server" Width="180px" Height="25px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date de Requête&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:TextBox ID="TextBox3" CssClass="datepicker" runat="server" Width="180px" Height="25px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Wilayas&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="OdsWilaya" DataTextField="wilaya" DataValueField="num" Width="180px" Height="25px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" SelectedValue='<%# Bind("WilayaC") %>'>
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Numero Requerant&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;:
            <asp:DropDownList ID="DropDownList2" runat="server" Width="180px" Height="25px">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Mission&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:DropDownList ID="DropDownList3" runat="server" Height="25px" Width="180px">
            </asp:DropDownList>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Mode de Transmission&nbsp;&nbsp;:&nbsp;
            <asp:DropDownList ID="DropDownList4" runat="server" DataSourceID="OdsModeTransmission" DataTextField="mode_trans" DataValueField="id_trans" Width="180px" Height="25px">
            </asp:DropDownList>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Objet&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :
            <asp:TextBox ID="TextBox1" runat="server" Width="649px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" OnClick="EditButton_Click" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" Visible="False" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" Visible="False" />
        </ItemTemplate>
    </asp:FormView>

    <%--</div>--%>


    <div id="dialog"  runat="server" visible="true" class="GridView1">
       
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table>
                <tr runat="server">
                    <td class="auto-style2">
                        <strong>Nombre de Requêtes trouvées :&nbsp;&nbsp;
                        <asp:Label ID="RqFound" runat="server" Font-Italic="True" ForeColor="#006666"></asp:Label>
                        </strong>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        <strong>Nombre de ligne par page : </strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList10" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList10_SelectedIndexChanged">
                            <asp:ListItem Selected="True">5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        <strong> de Page : </strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList11" runat="server">
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>25</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">

                    </td>
                </tr>
                <tr>
                    <td colspan="11">
                        <asp:UpdatePanel ID="ModalPanel1" runat="server" RenderMode="Inline" UpdateMode="Conditional">
                        <ContentTemplate>
            <%--<div style="overflow-x:auto;width:1050px;overflow-y:auto; height:327px">--%>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataSourceID="OdsRequest" OnRowEditing="GridView2_RowEditing" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="5" OnDataBound="GridView1_DataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton CssClass="fa fa-thumb-tack" ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Select" OnClick="Select_Detail"></asp:LinkButton>
                    <%--<asp:LinkButton ID="LinkButtonDel" CssClass="fa fa-trash" runat="server" OnClick="LinkButtonDel_Click" Visible='<%# IsDeletable(Eval("num_wilaya").ToString(), Eval("year").ToString(), Eval("num").ToString()) %>'  OnClientClick="ConfirmDelRequest()"></asp:LinkButton>--%>
                    <asp:LinkButton ID="LinkButtonDel" CssClass="fa fa-trash" runat="server" OnClick="LinkButtonDel_Click" Visible="false"  OnClientClick="ConfirmDelRequest()"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton CssClass="fa fa-unlock" ID="LinkButton26" runat="server" OnClick="LinkButton26_Click" Visible='<%# IsEnCoursDeTraitement1((int)Eval("id_state")) %>' ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton CssClass="fa fa-wrench" ID="Modifier" runat="server" OnClick="LinkButtonUpdate_Click1" Visible='<%# IsUpdatable(Eval("num_wilaya").ToString(), Eval("year").ToString(), Eval("num").ToString()) %>' ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton CssClass="fa fa-repeat" ID="Relance" runat="server"  OnClick="LinkButton1_Click2"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton CssClass="fa fa-comments" ID="Message" runat="server"  OnClick="Message_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Numero" SortExpression="num">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("num_wilaya") %>'></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="-"></asp:Label><asp:Label ID="Label81" runat="server" Text='<%# Bind("Year") %>'></asp:Label><asp:Label ID="Label3" runat="server" Text="-"></asp:Label><asp:Label ID="Label82" runat="server" Text='<%# Bind("num") %>'></asp:Label>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Objet" SortExpression="DispositifC">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# getObjetDispositifValue1(Eval("MotifId").ToString()) %>'></asp:TextBox>

                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# getObjetDispositifValue1(Eval("MotifId").ToString()) %>' Width="150px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Motif de la Requ&#234;te" SortExpression="MotifDispositifC">
                <ItemTemplate>
                    <asp:Label ID="LabelGridMotif" runat="server" Text='<%# Bind("MotifC") %>' Width="200px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Date de Reception" SortExpression="date">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("date") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("date", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Wilaya" SortExpression="WilayaC">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("WilayaC") %>'></asp:TextBox>

                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("WilayaC", "{0}") %>'></asp:Label>





                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="Commune" SortExpression="CommuneC">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxCommune" runat="server" Text='<%# Bind("CommuneC") %>'></asp:TextBox>

                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelCommune" runat="server" Text='<%# Bind("CommuneC", "{0}") %>'></asp:Label>





                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Pi&#232;ces Jointes">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton28" runat="server" OnClick="LinkButtonAttachment_Click" Text='<%# GetCountAttachment(Convert.ToInt32(Eval("num")), Convert.ToInt32(Eval("num_wilaya")), Convert.ToInt32(Eval("year"))) %>'></asp:LinkButton>
                    <asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButtonClick_ShowAttachments">+</asp:LinkButton>

                    <asp:Panel ID="Panel1" runat="server">
                    </asp:Panel>

                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Date Envoie" SortExpression="Date_Envoi">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBoxDateEnvoi" runat="server" Text='<%# Bind("Date_Envoi") %>'></asp:TextBox>


                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="LabelDate" runat="server" Text='<%# Bind("Date_Envoi", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Etat" SortExpression="EtatRequestC">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox9" runat="server" Text='<%# Bind("EtatRequestC") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("EtatRequestC") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
                </ContentTemplate>
                </asp:UpdatePanel>
                <%--</div>--%>
                    </td>        
                </tr>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
            
        
        
        
               
        
        
       
        
        
        
               
        
        
                <caption>
                </caption>
        
                <caption>
                </caption>
        
                <caption>
                </caption>
         
                <caption>
                </caption>
            
        
                <caption>
                </caption>
                <caption>
                </caption>
             </table>
               
        </ContentTemplate>
        </asp:UpdatePanel>

        </div>
    





        <br />
        <br />
        <br />
        </div>
            <asp:ObjectDataSource ID="OdsRequerant" runat="server" DataObjectTypeName="Model.requerant" DeleteMethod="deleteRequerant" InsertMethod="insertRequerant" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRequerant" TypeName="controller.requerant_controller" UpdateMethod="updateRequerant">
                <DeleteParameters>
                    <asp:Parameter Name="num" Type="String" />
                </DeleteParameters>
        </asp:ObjectDataSource>
        
            
            <asp:ObjectDataSource ID="request" runat="server" DataObjectTypeName="Model.Request" OldValuesParameterFormatString="original_{0}" SelectMethod="getRequestByNum" TypeName="controller.requete_controller" UpdateMethod="updateRequest">
                <SelectParameters>
                    <asp:Parameter Name="Num" Type="Int32" />
                    <asp:Parameter Name="NumWilaya_Request" Type="Int32" />
                    <asp:Parameter Name="Year_Request" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsMotifDispositif" runat="server" DeleteMethod="deleteMotifDispositif" OldValuesParameterFormatString="original_{0}" SelectMethod="getMotifByPhase" TypeName="controller.MotifDispositif_Controller" DataObjectTypeName="System.Guid">
                <SelectParameters>
                    <asp:Parameter DbType="Guid" Name="PhaseId" />
                </SelectParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsMotifOfObject" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getMotifObjectByObject" TypeName="controller.MotifObjectBLL" DataObjectTypeName="System.Guid">
                <SelectParameters>
                    <asp:Parameter DbType="Guid" Name="ObjectId" />
                </SelectParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsDispositionPrise" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getDispositionPriseByMotif" TypeName="controller.DispositionPriseBLL" DataObjectTypeName="System.Guid">
                <SelectParameters>
                    <asp:Parameter DbType="Guid" Name="ObjectId" />
                </SelectParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsPhaseMission" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getPhaseByMission" TypeName="controller.PhaseObjetBLL" DataObjectTypeName="System.Guid">
                <SelectParameters>
                    <asp:Parameter DbType="Guid" Name="MissionId" />
                </SelectParameters>
        </asp:ObjectDataSource>
            
        <asp:ObjectDataSource ID="OdsWilaya" runat="server" DeleteMethod="deleteWilaya" OldValuesParameterFormatString="original_{0}" SelectMethod="GetWilayasOfStructure" TypeName="controller.wilaya_controller">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="UserName" Type="String"></asp:Parameter>

        </SelectParameters>

    </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsDispositif" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllDispositif" TypeName="controller.dispositif_controller" UpdateMethod="updateDispositif" DataObjectTypeName="Model.Mission" InsertMethod="insertDispositif">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsModeTransmission" runat="server" DataObjectTypeName="Model.Transmission" InsertMethod="insertModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllModeTransmission" TypeName="controller.ModeTranmission_Controller" UpdateMethod="updateModeTransmission">
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsRequest" runat="server" DataObjectTypeName="Model.Request" DeleteMethod="deleteRecalamation" InsertMethod="insertRequest" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRequest" TypeName="controller.requete_controller" UpdateMethod="updateRequest">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
            </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="OdsStateRequest" runat="server" DeleteMethod="deleteState_Request" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllState_Request" TypeName="controller.StateRequest_Controller" UpdateMethod="updateState_Request">
                <DeleteParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </DeleteParameters>
                <UpdateParameters>
                    <asp:Parameter Name="guid" Type="Int32" />
                </UpdateParameters>
            </asp:ObjectDataSource>
        
    

        <asp:ObjectDataSource ID="OdsType" runat="server" DataObjectTypeName="Model.types" InsertMethod="insertType" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllType" TypeName="controller.Type_Controller" UpdateMethod="updateType">
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="OdsVoieTransmission" runat="server" DataObjectTypeName="Model.Voie_Transmission" DeleteMethod="deleteVoieModeTransmission" InsertMethod="insertVoieModeTransmission" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllVoieModeTransmission" TypeName="controller.VoieTrans_Controller" UpdateMethod="updateVoieModeTransmission">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </UpdateParameters>
        </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="OdsRequestDetails" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="getRequestByNum" TypeName="controller.requete_controller" DeleteMethod="deleteRequest" InsertMethod="GetCountAttachmentRequest" UpdateMethod="getNextNumRequest">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="Id_Request" Type="Int32" />
            <asp:Parameter Name="NumWilaya_Request" Type="Int32" />
            <asp:Parameter Name="Year" Type="Int32" />
        </InsertParameters>
        <SelectParameters>
            <asp:SessionParameter Name="Num" SessionField="Id_Request_Detail" Type="Int32" />
            <asp:SessionParameter Name="NumWilaya_Request" SessionField="NumWilaya_Request_Detail" Type="Int32" />
            <asp:SessionParameter Name="Year_Request" SessionField="Year_Request_Detail" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="NumWilaya" Type="Int32" />
            <asp:Parameter Name="Year" Type="Int32" />
        </UpdateParameters>
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
          
            
            <div id="Div2" runat="server" style="overflow-x:auto;width:960px;overflow-y:auto; height:350px" visible="true">
            <asp:Image ID="Image1" runat="server" />

        </p>
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




    <%--the modal popup that contain the DetailView--%>
    <!-- Trigger the modal with a button -->
    <asp:UpdatePanel ID="UpdatePanelDetailRequest" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
<button id="button_Details" type="button" class="btn btn-info btn-lg" data-toggle="modal" data-target="#myModal_Details" style="visibility:hidden;">Open Modal</button>

<!-- Modal -->
<div id="myModal_Details" class="modal fade" role="dialog">
  <div class="modal-dialog">

    <!-- Modal content-->
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal">&times;</button>
        <h4 class="modal-title">La Requête Numero : <asp:Label ID="LabelRefRequest_Details" runat="server" Text="Label"></asp:Label></h4></h4>
      </div>
      <div class="modal-body">
          <div id="DivScroll_Details" runat="server" style="overflow-x:auto;width:960px;overflow-y:auto; height:350px" visible="true">
            
                  <asp:DetailsView ID="DetailsViewRequest" runat="server" Height="50px" Width="809px" AutoGenerateRows="False" DataSourceID="OdsRequestDetails" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
                  <EditRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White"></EditRowStyle>
                  <Fields>

                      <asp:BoundField DataField="date" HeaderText="Date de Reception" SortExpression="date" />
                      <asp:BoundField DataField="Date_Insertion" HeaderText="Date d'Insertion" SortExpression="Date_Insertion" />
                      <asp:BoundField DataField="num_requerant" HeaderText="Numero du Requerant" SortExpression="num_requerant" />
                      <asp:BoundField DataField="NomRequerantC" HeaderText="Nom du Requerant" ReadOnly="True" SortExpression="NomRequerantC" />
                      <asp:BoundField DataField="PrenomRequerantC" HeaderText="Prenom du Requerant" ReadOnly="True" SortExpression="PrenomRequerantC" />
                      <asp:BoundField DataField="VoieTransC" HeaderText="Emetteur de la Requête" SortExpression="id_Voie_Trans" />
                      <asp:BoundField DataField="User_Inserted" HeaderText="Inseré par l'Agent CNAC" SortExpression="User_Inserted" />
                      <asp:BoundField DataField="EtatRequestC" HeaderText="Etat de la Requête" ReadOnly="True" SortExpression="EtatRequestC" />
                      <asp:BoundField DataField="ModeTransmissionC" HeaderText="Transmis par" ReadOnly="True" SortExpression="ModeTransmissionC" />
                      <asp:BoundField DataField="WilayaC" HeaderText="Wilaya" ReadOnly="True" SortExpression="WilayaC" />
                      <asp:BoundField DataField="DispositifC" HeaderText="Mission" ReadOnly="True" SortExpression="DispositifC" />
                      <asp:BoundField DataField="MotifDispositifC" HeaderText="Objet de la Requête" ReadOnly="True" SortExpression="MotifDispositifC" />
                      <asp:BoundField DataField="MotifC" HeaderText="Motif de la Requête" ReadOnly="True" SortExpression="MotifC" />
                      <asp:BoundField DataField="TypeRequestC" HeaderText="Type de la Requête" ReadOnly="True" SortExpression="TypeRequestC" />
                      <asp:BoundField DataField="corp_requete" HeaderText="La description" SortExpression="corp_requete" />
                      <asp:BoundField DataField="result_traitement" HeaderText="Résultat du traitement" SortExpression="result_traitement" />
                      <asp:BoundField DataField="Date_Envoi" HeaderText="Date d'Envoi de la Réponse" SortExpression="Date_Envoi" />
                      <asp:BoundField DataField="Ref_Validation" HeaderText="Reference de la Validation" SortExpression="Ref_Validation" />
                  </Fields>
                  <FooterStyle BackColor="#CCCCCC"></FooterStyle>

                  <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White"></HeaderStyle>

                  <PagerStyle HorizontalAlign="Left" BackColor="#CCCCCC" ForeColor="Black"></PagerStyle>

                  <RowStyle BackColor="White"></RowStyle>
              </asp:DetailsView>
            
      </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
      </div>
    </div>

  </div>
</div>

    </ContentTemplate>
        </asp:UpdatePanel>

    
        <asp:ObjectDataSource ID="ODSCommune" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetCommuneByWilaya" TypeName="controller.Commune_Controller">
            <SelectParameters>
                <asp:Parameter DefaultValue="" Name="num_wilaya" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>


</asp:Content>