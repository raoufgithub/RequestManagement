<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="CustomFormView.aspx.cs" Inherits="view.webforms.CustomFormView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="FormView1" runat="server" 
DataSourceID="ObjectDataSource1" 

    AllowPaging="True" EnableViewState="False" DefaultMode="Insert">

        <EditItemTemplate>
            num:
            <asp:TextBox ID="numTextBox" runat="server" Text='<%# Bind("num") %>' />
            <br />
            id_state:
            <asp:TextBox ID="id_stateTextBox" runat="server" Text='<%# Bind("id_state") %>' />
            <br />
            objet:
            <asp:TextBox ID="objetTextBox" runat="server" Text='<%# Bind("objet") %>' />
            <br />
            date:
            <asp:TextBox ID="dateTextBox" runat="server" Text='<%# Bind("date") %>' />
            <br />
            id_type:
            <asp:TextBox ID="id_typeTextBox" runat="server" Text='<%# Bind("id_type") %>' />
            <br />
            num_wilaya:
            <asp:TextBox ID="num_wilayaTextBox" runat="server" Text='<%# Bind("num_wilaya") %>' />
            <br />
            num_requerant:
            <asp:TextBox ID="num_requerantTextBox" runat="server" Text='<%# Bind("num_requerant") %>' />
            <br />
            id_motif:
            <asp:TextBox ID="id_motifTextBox" runat="server" Text='<%# Bind("id_motif") %>' />
            <br />
            corp_requete:
            <asp:TextBox ID="corp_requeteTextBox" runat="server" Text='<%# Bind("corp_requete") %>' />
            <br />
            id_trans:
            <asp:TextBox ID="id_transTextBox" runat="server" Text='<%# Bind("id_trans") %>' />
            <br />
            result_traitement:
            <asp:TextBox ID="result_traitementTextBox" runat="server" Text='<%# Bind("result_traitement") %>' />
            <br />
            Date_Validation:
            <asp:TextBox ID="Date_ValidationTextBox" runat="server" Text='<%# Bind("Date_Validation") %>' />
            <br />
            Ref_Validation:
            <asp:TextBox ID="Ref_ValidationTextBox" runat="server" Text='<%# Bind("Ref_Validation") %>' />
            <br />
            id_Voie_Trans:
            <asp:TextBox ID="id_Voie_TransTextBox" runat="server" Text='<%# Bind("id_Voie_Trans") %>' />
            <br />
            action_User_Request:
            <asp:TextBox ID="action_User_RequestTextBox" runat="server" Text='<%# Bind("action_User_Request") %>' />
            <br />
            Motif:
            <asp:TextBox ID="MotifTextBox" runat="server" Text='<%# Bind("Motif") %>' />
            <br />
            requerant:
            <asp:TextBox ID="requerantTextBox" runat="server" Text='<%# Bind("requerant") %>' />
            <br />
            State_Request:
            <asp:TextBox ID="State_RequestTextBox" runat="server" Text='<%# Bind("State_Request") %>' />
            <br />
            Transmission:
            <asp:TextBox ID="TransmissionTextBox" runat="server" Text='<%# Bind("Transmission") %>' />
            <br />
            types:
            <asp:TextBox ID="typesTextBox" runat="server" Text='<%# Bind("types") %>' />
            <br />
            wilayas:
            <asp:TextBox ID="wilayasTextBox" runat="server" Text='<%# Bind("wilayas") %>' />
            <br />
            relances:
            <asp:TextBox ID="relancesTextBox" runat="server" Text='<%# Bind("relances") %>' />
            <br />
            Voie_Transmission:
            <asp:TextBox ID="Voie_TransmissionTextBox" runat="server" Text='<%# Bind("Voie_Transmission") %>' />
            <br />
            EtatReclamationC:
            <asp:TextBox ID="EtatReclamationCTextBox" runat="server" Text='<%# Bind("EtatReclamationC") %>' />
            <br />
            ModeTransmissionC:
            <asp:TextBox ID="ModeTransmissionCTextBox" runat="server" Text='<%# Bind("ModeTransmissionC") %>' />
            <br />
            WilayaC:
            <asp:TextBox ID="WilayaCTextBox" runat="server" Text='<%# Bind("WilayaC") %>' />
            <br />
            MotifDispositifC:
            <asp:TextBox ID="MotifDispositifCTextBox" runat="server" Text='<%# Bind("MotifDispositifC") %>' />
            <br />
            DispositifC:
            <asp:TextBox ID="DispositifCTextBox" runat="server" Text='<%# Bind("DispositifC") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </EditItemTemplate>
        <InsertItemTemplate>
            num:
            <asp:TextBox ID="numTextBox" runat="server" Text='<%# Bind("num") %>' />
            <br />
            id_state:
            <asp:TextBox ID="id_stateTextBox" runat="server" Text='<%# Bind("id_state") %>' />
            <br />
            objet:
            <asp:TextBox ID="objetTextBox" runat="server" Text='<%# Bind("objet") %>' />
            <br />
            date:
            <asp:TextBox ID="dateTextBox" runat="server" Text='<%# Bind("date") %>' />
            <br />
            id_type:
            <asp:TextBox ID="id_typeTextBox" runat="server" Text='<%# Bind("id_type") %>' />
            <br />
            num_wilaya:
            <asp:TextBox ID="num_wilayaTextBox" runat="server" Text='<%# Bind("num_wilaya") %>' />
            <br />
            num_requerant:
            <asp:TextBox ID="num_requerantTextBox" runat="server" Text='<%# Bind("num_requerant") %>' />
            <br />
            id_motif:
            <asp:TextBox ID="id_motifTextBox" runat="server" Text='<%# Bind("id_motif") %>' />
            <br />
            corp_requete:
            <asp:TextBox ID="corp_requeteTextBox" runat="server" Text='<%# Bind("corp_requete") %>' />
            <br />
            id_trans:
            <asp:TextBox ID="id_transTextBox" runat="server" Text='<%# Bind("id_trans") %>' />
            <br />
            result_traitement:
            <asp:TextBox ID="result_traitementTextBox" runat="server" Text='<%# Bind("result_traitement") %>' />
            <br />
            Date_Validation:
            <asp:TextBox ID="Date_ValidationTextBox" runat="server" Text='<%# Bind("Date_Validation") %>' />
            <br />
            Ref_Validation:
            <asp:TextBox ID="Ref_ValidationTextBox" runat="server" Text='<%# Bind("Ref_Validation") %>' />
            <br />
            id_Voie_Trans:
            <asp:TextBox ID="id_Voie_TransTextBox" runat="server" Text='<%# Bind("id_Voie_Trans") %>' />
            <br />
            action_User_Request:
            <asp:TextBox ID="action_User_RequestTextBox" runat="server" Text='<%# Bind("action_User_Request") %>' />
            <br />
            Motif:
            <asp:TextBox ID="MotifTextBox" runat="server" Text='<%# Bind("Motif") %>' />
            <br />
            requerant:
            <asp:TextBox ID="requerantTextBox" runat="server" Text='<%# Bind("requerant") %>' />
            <br />
            State_Request:
            <asp:TextBox ID="State_RequestTextBox" runat="server" Text='<%# Bind("State_Request") %>' />
            <br />
            Transmission:
            <asp:TextBox ID="TransmissionTextBox" runat="server" Text='<%# Bind("Transmission") %>' />
            <br />
            types:
            <asp:TextBox ID="typesTextBox" runat="server" Text='<%# Bind("types") %>' />
            <br />
            wilayas:
            <asp:TextBox ID="wilayasTextBox" runat="server" Text='<%# Bind("wilayas") %>' />
            <br />
            relances:
            <asp:TextBox ID="relancesTextBox" runat="server" Text='<%# Bind("relances") %>' />
            <br />
            Voie_Transmission:
            <asp:TextBox ID="Voie_TransmissionTextBox" runat="server" Text='<%# Bind("Voie_Transmission") %>' />
            <br />
            EtatReclamationC:
            <asp:TextBox ID="EtatReclamationCTextBox" runat="server" Text='<%# Bind("EtatReclamationC") %>' />
            <br />
            ModeTransmissionC:
            <asp:TextBox ID="ModeTransmissionCTextBox" runat="server" Text='<%# Bind("ModeTransmissionC") %>' />
            <br />
            WilayaC:
            <asp:TextBox ID="WilayaCTextBox" runat="server" Text='<%# Bind("WilayaC") %>' />
            <br />
            MotifDispositifC:
            <asp:TextBox ID="MotifDispositifCTextBox" runat="server" Text='<%# Bind("MotifDispositifC") %>' />
            <br />
            DispositifC:
            <asp:TextBox ID="DispositifCTextBox" runat="server" Text='<%# Bind("DispositifC") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
        </InsertItemTemplate>

    <ItemTemplate>

        num:
        <asp:Label ID="numLabel" runat="server" Text='<%# Bind("num") %>' />
        <br />
        id_state:
        <asp:Label ID="id_stateLabel" runat="server" Text='<%# Bind("id_state") %>' />
        <br />
        objet:
        <asp:Label ID="objetLabel" runat="server" Text='<%# Bind("objet") %>' />
        <br />
        date:
        <asp:Label ID="dateLabel" runat="server" Text='<%# Bind("date") %>' />
        <br />
        id_type:
        <asp:Label ID="id_typeLabel" runat="server" Text='<%# Bind("id_type") %>' />
        <br />
        num_wilaya:
        <asp:Label ID="num_wilayaLabel" runat="server" Text='<%# Bind("num_wilaya") %>' />
        <br />
        num_requerant:
        <asp:Label ID="num_requerantLabel" runat="server" Text='<%# Bind("num_requerant") %>' />
        <br />
        id_motif:
        <asp:Label ID="id_motifLabel" runat="server" Text='<%# Bind("id_motif") %>' />
        <br />
        corp_requete:
        <asp:Label ID="corp_requeteLabel" runat="server" Text='<%# Bind("corp_requete") %>' />
        <br />
        id_trans:
        <asp:Label ID="id_transLabel" runat="server" Text='<%# Bind("id_trans") %>' />
        <br />
        result_traitement:
        <asp:Label ID="result_traitementLabel" runat="server" Text='<%# Bind("result_traitement") %>' />
        <br />
        Date_Validation:
        <asp:Label ID="Date_ValidationLabel" runat="server" Text='<%# Bind("Date_Validation") %>' />
        <br />
        Ref_Validation:
        <asp:Label ID="Ref_ValidationLabel" runat="server" Text='<%# Bind("Ref_Validation") %>' />
        <br />
        id_Voie_Trans:
        <asp:Label ID="id_Voie_TransLabel" runat="server" Text='<%# Bind("id_Voie_Trans") %>' />
        <br />
        action_User_Request:
        <asp:Label ID="action_User_RequestLabel" runat="server" Text='<%# Bind("action_User_Request") %>' />
        <br />
        Motif:
        <asp:Label ID="MotifLabel" runat="server" Text='<%# Bind("Motif") %>' />
        <br />
        requerant:
        <asp:Label ID="requerantLabel" runat="server" Text='<%# Bind("requerant") %>' />
        <br />
        State_Request:
        <asp:Label ID="State_RequestLabel" runat="server" Text='<%# Bind("State_Request") %>' />
        <br />
        Transmission:
        <asp:Label ID="TransmissionLabel" runat="server" Text='<%# Bind("Transmission") %>' />
        <br />
        types:
        <asp:Label ID="typesLabel" runat="server" Text='<%# Bind("types") %>' />
        <br />
        wilayas:
        <asp:Label ID="wilayasLabel" runat="server" Text='<%# Bind("wilayas") %>' />
        <br />
        relances:
        <asp:Label ID="relancesLabel" runat="server" Text='<%# Bind("relances") %>' />
        <br />
        Voie_Transmission:
        <asp:Label ID="Voie_TransmissionLabel" runat="server" Text='<%# Bind("Voie_Transmission") %>' />
        <br />
        EtatReclamationC:
        <asp:Label ID="EtatReclamationCLabel" runat="server" Text='<%# Bind("EtatReclamationC") %>' />
        <br />
        ModeTransmissionC:
        <asp:Label ID="ModeTransmissionCLabel" runat="server" Text='<%# Bind("ModeTransmissionC") %>' />
        <br />
        WilayaC:
        <asp:Label ID="WilayaCLabel" runat="server" Text='<%# Bind("WilayaC") %>' />
        <br />
        MotifDispositifC:
        <asp:Label ID="MotifDispositifCLabel" runat="server" Text='<%# Bind("MotifDispositifC") %>' />
        <br />
        DispositifC:
        <asp:Label ID="DispositifCLabel" runat="server" Text='<%# Bind("DispositifC") %>' />
        <br />
        <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
        &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
        &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />

    </ItemTemplate>

</asp:FormView>
    <br />
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DataObjectTypeName="Model.reclamation" DeleteMethod="deleteRecalamation" InsertMethod="insertReclamation" OldValuesParameterFormatString="original_{0}" SelectMethod="getReclamationByNum" TypeName="controller.requete_controller" UpdateMethod="getCountRequest">
        <DeleteParameters>
            <asp:Parameter Name="guid" Type="Int32" />
        </DeleteParameters>
        <SelectParameters>
            <asp:Parameter Name="Num" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="id_state" Type="Int32" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
