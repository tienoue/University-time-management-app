<%@ Page Title="Enseignants" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Enseignants.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.Enseignants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
        <style>
            .panel1{
                display:flex; /*pour que les enfants s'alignent horizontalement*/
                flex-wrap: wrap; /*pour que les enfants aille a la ligne suivante quand il n'y a plus d'espace*/
                
                width: fit-content; /*pour adapter la taille du conteneur par rapport a tous les enfants qu'il contient*/
                //min-width: 100%;

                //background-color:rgb(240,240,240);
                border-radius:10px;

                color:blue;
                box-shadow:-10px 0 1px;
            }
            .panelEnseignant{
                margin:10px;
                position:relative;
                //background-color:red;

                display: flex;
                justify-content: center;
                align-items: center;
            }
            .imageEnseignant{
                width:140px;
                height:auto;
            }
            .nomEnseignant{
                position:absolute;
                bottom:0;
                left:0;
            }
            .ajouter{
                color:rgb(0, 0, 255);
            }
            .ajouter:hover{
                color:rgb(100, 100, 100);
            }

        </style>



        <asp:Button ID="Button1" runat="server" Text="Ajouter un enseignant..." OnClick="Button1_Click" BackColor="White" BorderStyle="None" Font-Size="Large" CssClass="ajouter" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="ENSEIGNANTS ENREGISTRES:"></asp:Label>
        <br />
            <div runat="server" id="Panel1" class="panel1"></div>
        <br />

    </body>
</asp:Content>
