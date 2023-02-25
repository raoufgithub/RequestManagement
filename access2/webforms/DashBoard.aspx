<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="DashBoard.aspx.cs" Inherits="view.webforms.DashBoard" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FontAwesome Styles-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- Morris Chart Styles-->
    <link href="assets/js/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <!-- Custom Styles-->
    <link href="assets/css/custom-styles.css" rel="stylesheet" />
    <!-- Google Fonts-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div id="page-wrapper">--%>
            <div id="page-inner">


                <div class="row">
                    <div class="col-md-12">
                        <h1 class="page-header">
                            Tableau de Bord : <small>Résumé des Requêtes.</small></h1>
                    </div>
                </div>
                <!-- /. ROW  -->

                <div class="row">
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="panel panel-primary text-center no-boder bg-color-green">
                            <div class="panel-body">
                                <%--<i class="fa fa-bar-chart-o fa-5x"></i>--%>
                                <i style="background-image: url('request-512.png');"></i>
                                <h3>
                                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="IntrodReq_Click"></asp:LinkButton>    
                                </h3>
                            </div>
                            <div class="panel-footer back-footer-green">
                                Requêtes Introduites</div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="panel panel-primary text-center no-boder bg-color-blue">
                            <div class="panel-body">
                                <%--<i class="fa fa-shopping-cart fa-5x"></i>--%>
                                <i style="background-image: url(request-512.png);"></i>
                                <h3>
                                    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="Treating_Click"></asp:LinkButton>
                                </h3>
                            </div>
                            <div class="panel-footer back-footer-blue">
                                Requêtes En Cours de Traitement</div>
                        </div>
                    </div>
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="panel panel-primary text-center no-boder bg-color-red">
                            <div class="panel-body">
                                <%--<i class="fa fa fa-comments fa-5x"></i>--%>
                                <i style="background-image: url(request-512.png);"></i>
                                <h3>
                                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="Treated_Click"></asp:LinkButton>
                                </h3>
                            </div>
                            <div class="panel-footer back-footer-red">
                                Requêtes Clôturées

                            </div>
                        </div>
                    </div>
                    
                    <div class="col-md-3 col-sm-12 col-xs-12">
                        <div class="panel panel-primary text-center no-boder bg-color-brown">
                            <div class="panel-body">
                                <%--<i class="fa fa-users fa-5x"></i>--%>
                                <i style="background-image: url(request-512.png);"></i>
                                <h3>

                                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="NonFond_Click"></asp:LinkButton>
                                </h3>
                            </div>
                            <div class="panel-footer back-footer-brown">
                                Requêtes Non Fondées

                            </div>
                        </div>
                    </div>
                </div>
                <div>
                        <div class="panel panel-primary text-center no-boder bg-color-brown">
                            
                                                        <div class="panel-body col-md-3 col-sm-12 col-xs-12">

                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Height="246px" Width="827px">
                                    <Columns>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label40" runat="server" Text="Numero de la Requête"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton28" runat="server" Text='<%# GetIdRequest(Eval("NumWilaya_Request").ToString(), Eval("Year_Request").ToString(), Eval("id_request").ToString()) %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Traité par l'Agent CNAC">
                                            <EditItemTemplate>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            </EditItemTemplate>
                                            <HeaderTemplate>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label41" runat="server" Text="Traité par l'Agent CNAC"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton29" runat="server" Text='<%# GetUserName(Eval("id_user").ToString()) %>'></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:Label ID="Label43" runat="server" Text="Structure de l'Agent"></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:LinkButton ID="LinkButton30" runat="server" Text='<%# getAgentStructure(Eval("id_user").ToString()) %>' ></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="En Cours de Traitement depuis ...">
                                            <HeaderTemplate>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Label ID="Label42" runat="server" Text="	En Cours de Traitement depuis ..."></asp:Label>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="Label39" runat="server" Text='<%# DurationTreating(Eval("date_action").ToString()) %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                                            </asp:GridView>

                                                            <br />
                                                            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="deleteRequest" InsertMethod="GetCountAttachmentRequest" OldValuesParameterFormatString="original_{0}" SelectMethod="GetUsersLate" TypeName="controller.requete_controller" UpdateMethod="getNextNumRequest">
                                                                <DeleteParameters>
                                                                    <asp:Parameter Name="guid" Type="Int32" />
                                                                </DeleteParameters>
                                                                <InsertParameters>
                                                                    <asp:Parameter Name="Id_Request" Type="Int32" />
                                                                    <asp:Parameter Name="NumWilaya_Request" Type="Int32" />
                                                                    <asp:Parameter Name="Year" Type="Int32" />
                                                                </InsertParameters>
                                                                <UpdateParameters>
                                                                    <asp:Parameter Name="NumWilaya" Type="Int32" />
                                                                    <asp:Parameter Name="Year" Type="Int32" />
                                                                </UpdateParameters>
                                                            </asp:ObjectDataSource>

                                                            <br />

                                
                            </div>
                            
                        </div>
                    </div>
                </div>
                <!-- /. ROW  -->

                <!-- /. ROW  -->
				<footer></footer>
            </div>
            <!-- /. PAGE INNER  -->
        <%--</div>--%>

    
</asp:Content>