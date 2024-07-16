<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AjouterEnseignant.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.AjouterEnseignant" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body class="body">
        <style>
            .body{
                background-image:url(images/pic.jpg);
            }
            .rounded-textbox
            {
                 border-radius: 20px;
            }

        </style>



        <div style=" width:95%; height:500px; border-radius:15px; background-color:white; position:relative;margin-left:auto;margin-right:auto;">
            <div style="//border-right: 1px solid blue; border-radius:15px 0 0 15px; background-image:url(images2/enseignante.jpg);width:60%; height:500px; background-color:blue; position:absolute; top:0;left:0">

            </div>
            <div style="display: flex; justify-content: center; align-items: center; width:40%; height:500px; border-radius:15px; background-color:white; position:absolute; top:0;right:0">
                <div style=" width:80%; height:500px; border-radius:15px; background-color:white; position:relative; //margin-left:auto;//margin-right:auto; ">

                    
                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Enregistrer nouvel enseignant"></asp:Label>
                    <br />
                    <asp:Label ID="labelSuccess" runat="server" Font-Italic="True" Font-Size="X-Large" ForeColor="#00CC00" Text="&quot;Données enregistrées avec succès&quot;"></asp:Label>
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="matricule" runat="server" Height="42px" Width="281px" placeholder="Matricule" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="nom" runat="server" Height="42px" Width="281px" placeholder="Nom" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="motDePasse" runat="server" Height="42px" Width="281px" placeholder="Mot de passe" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
                    <br />
                    <br />
                    <br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Enregistrer" Height="55px" Width="281px" BorderStyle="Solid" CssClass="rounded-textbox" BackColor="#0000CC" ForeColor="White" OnClick="Button2_Click" />

                </div>
            </div>
        </div>

    </body>
</asp:Content>
