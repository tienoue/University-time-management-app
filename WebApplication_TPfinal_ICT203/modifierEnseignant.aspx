<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="modifierEnseignant.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.modifierEnseignant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        .parent{
            position:relative;
            align-content:center;
            align-items:center;

        }
        .enfant{
            position:relative;
            width:300px;
            margin-left:auto;
            margin-right:auto;
            border-radius:10px;
            border-right:1px solid blue;
            box-shadow:-10px 0 1px;
            padding-left:10px;
            color:blue;
        }/*
        .bouton{
            position:relative;
            width:300px;
            margin-left:auto;
            margin-right:auto;
        }*/

    </style>

    <asp:Panel ID="PanelCompteUtilisateur" runat="server" CssClass="parent">
        <br />
        <asp:Panel ID="Panel1" runat="server" CssClass="enfant">
            <asp:Panel ID="PanelInformations" runat="server">
                <br />
                <div id="image" runat="server" style="height:150px;">
                </div>
                &nbsp;<br />&nbsp;
                <br />
                &nbsp;<br /></asp:Panel>
            <br />
            <asp:Button ID="boutonSupprimerEnseignant" runat="server" BackColor="Red" BorderStyle="None" ForeColor="White" Height="35px" OnClick="Button4_Click" Text="Supprimer cet enseignant" Width="300px" />
            
            <br />
            <br />
        </asp:Panel>
        <br />
        <br />
    </asp:Panel>

</asp:Content>
