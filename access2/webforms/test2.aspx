<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="test2.aspx.cs" Inherits="view.webforms.test2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="ObjectDataSource1" AllowPaging="True" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="num" HeaderText="num" SortExpression="num" />
            <asp:BoundField DataField="nom_requerant" HeaderText="nom_requerant" SortExpression="nom_requerant" />
            <asp:BoundField DataField="prenom_requerant" HeaderText="prenom_requerant" SortExpression="prenom_requerant" />
            <asp:BoundField DataField="NBRE_ASSOCIES" HeaderText="NBRE_ASSOCIES" SortExpression="NBRE_ASSOCIES" />
            <asp:BoundField DataField="LIB_DR" HeaderText="LIB_DR" SortExpression="LIB_DR" />
            <asp:BoundField DataField="NOM_AGENCE_CNAC" HeaderText="NOM_AGENCE_CNAC" SortExpression="NOM_AGENCE_CNAC" />
            <asp:BoundField DataField="NOM_COMMUNE" HeaderText="NOM_COMMUNE" SortExpression="NOM_COMMUNE" />
            <asp:BoundField DataField="WILAYA" HeaderText="WILAYA" SortExpression="WILAYA" />
            <asp:BoundField DataField="Des_Act" HeaderText="Des_Act" SortExpression="Des_Act" />
            <asp:BoundField DataField="DES_SEC_ACT" HeaderText="DES_SEC_ACT" SortExpression="DES_SEC_ACT" />
            <asp:BoundField DataField="DES_SEC_ACT2" HeaderText="DES_SEC_ACT2" SortExpression="DES_SEC_ACT2" />
            <asp:BoundField DataField="NIVEAU" HeaderText="NIVEAU" SortExpression="NIVEAU" />
            <asp:BoundField DataField="LIB_SEXE" HeaderText="LIB_SEXE" SortExpression="LIB_SEXE" />
            <asp:BoundField DataField="DATE_DEPOT" HeaderText="DATE_DEPOT" SortExpression="DATE_DEPOT" />
            <asp:BoundField DataField="Date_Naissance" HeaderText="Date_Naissance" SortExpression="Date_Naissance" />
            <asp:BoundField DataField="HANDICAPE" HeaderText="HANDICAPE" SortExpression="HANDICAPE" />
            <asp:BoundField DataField="Lib_Sit_Fam" HeaderText="Lib_Sit_Fam" SortExpression="Lib_Sit_Fam" />
            <asp:BoundField DataField="Nom_Banque" HeaderText="Nom_Banque" SortExpression="Nom_Banque" />
            <asp:BoundField DataField="agencebancaire" HeaderText="agencebancaire" SortExpression="agencebancaire" />
            <asp:BoundField DataField="NUM_CPT_BANC" HeaderText="NUM_CPT_BANC" SortExpression="NUM_CPT_BANC" />
            <asp:BoundField DataField="CMT" HeaderText="CMT" SortExpression="CMT" />
            <asp:BoundField DataField="Date_Accord_PBancaire" HeaderText="Date_Accord_PBancaire" SortExpression="Date_Accord_PBancaire" />
            <asp:BoundField DataField="annéeAccord" HeaderText="annéeAccord" SortExpression="annéeAccord" />
            <asp:BoundField DataField="moisAccordBancaire" HeaderText="moisAccordBancaire" SortExpression="moisAccordBancaire" />
            <asp:BoundField DataField="JourAccordBancaire" HeaderText="JourAccordBancaire" SortExpression="JourAccordBancaire" />
            <asp:BoundField DataField="prime" HeaderText="prime" SortExpression="prime" />
            <asp:BoundField DataField="date_Prime" HeaderText="date_Prime" SortExpression="date_Prime" />
            <asp:BoundField DataField="anneePrime" HeaderText="anneePrime" SortExpression="anneePrime" />
            <asp:BoundField DataField="moisPrime" HeaderText="moisPrime" SortExpression="moisPrime" />
            <asp:BoundField DataField="JourPrime" HeaderText="JourPrime" SortExpression="JourPrime" />
            <asp:BoundField DataField="Montant_Prime" HeaderText="Montant_Prime" SortExpression="Montant_Prime" />
            <asp:BoundField DataField="REGION" HeaderText="REGION" SortExpression="REGION" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Model.requerant" DeleteMethod="deleteRequerant" InsertMethod="insertRequerant" OldValuesParameterFormatString="original_{0}" SelectMethod="getAllRequerant" TypeName="controller.requerant_controller" UpdateMethod="updateRequerant">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
