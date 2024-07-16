<%@ Page Title="Departements" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departements.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.Departements" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
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
            .panelDepartement{
                margin:20px;
                position:relative;
                //background-color:red;

                display: flex;
                justify-content: center;
                align-items: center;
                text-align: center;
            }
            .imageDepartement{
                width:100%;
                height:200px;
            }
            .nomDepartement{
                //position:absolute;
                //bottom:0;
                //text-align:center;

            
            }
            .ajouter{
                color:rgb(0, 0, 255);
            }
            .ajouter:hover{
                color:rgb(100, 100, 100);
            }

        </style>



        <asp:Button ID="Button1" runat="server" Text="Ajouter un département..." OnClick="Button1_Click" BackColor="White" BorderStyle="None" Font-Size="Large" CssClass="ajouter" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Ajouter un niveau..."  BackColor="White" BorderStyle="None" Font-Size="Large" CssClass="ajouter" OnClick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Ajouter une UE..."  BackColor="White" BorderStyle="None" Font-Size="Large" CssClass="ajouter" OnClick="Button3_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:Button ID="Button4" runat="server" Text="Ajouter une Salle..."  BackColor="White" BorderStyle="None" Font-Size="Large" CssClass="ajouter" OnClick="Button4_Click" />

        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="DEPARTEMENTS ENREGISTRES:"></asp:Label>
        <br />
            <div runat="server" id="Panel1" class="panel1"></div>
        <br />

    </body>
</asp:Content>
