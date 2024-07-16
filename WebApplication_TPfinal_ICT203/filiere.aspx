<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="filiere.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.filiere" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        
        .rounded-textbox
        {
             border-radius: 20px;
        }
    </style>


    <p id="nomDepartement" runat="server" style="text-align:center; font-weight:bold;font-size:50px;">DEPARTEMENT DE </p>
    <asp:Button ID="Button1" CssClass="rounded-textbox" runat="server" Text="Supprimer ce departement" BackColor="Red" BorderStyle="None" ForeColor="White" OnClick="Button1_Click" /><br />
    <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="FILIERES ENREGISTREES:"></asp:Label>
    <div style=" width:95%; height:500px; border-radius:15px; background-color:white; position:relative;margin-left:auto;margin-right:auto;">

        <div runat="server" id="Panel1" class="panel1" style="color:blue; box-shadow:-10px 0 1px; border: 1px solid blue; border-radius:15px 0 0 15px; //background-image:url(images2/enseignante.jpg);width:60%; height:500px; //background-color:blue; position:absolute; top:0;left:0">
            
            <ul id="myList" runat="server" style="position:absolute; top:20px; width:100%">
                
            </ul>
        </div>
        <div style="display: flex; justify-content: center; align-items: center; width:40%; height:500px; border-radius:15px; background-color:white; position:absolute; top:0;right:0">
            <div runat="server" ID="fileUploadPanel" style=" width:80%; height:500px; border-radius:15px; background-color:white; position:relative; //margin-left:auto;//margin-right:auto; ">
       
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Enregistrer une filiere"></asp:Label>
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="textboxNomFiliere" runat="server" Height="42px" Width="281px" placeholder="Nom de la filiere" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Enregistrer" Height="55px" Width="281px" BorderStyle="Solid" CssClass="rounded-textbox" BackColor="#0000CC" ForeColor="White" OnClick="Enregistrer_Click" />

            </div>
        </div>
    </div>
</asp:Content>
