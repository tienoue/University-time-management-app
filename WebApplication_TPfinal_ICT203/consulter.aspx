<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="consulter.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.consulter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .conteneur{
            position:relative;
            top:50px;
            width:100%;
            height:1100px;
        }

        .jour{
            position:absolute;
            top:0;
            //text-align:center;
            left:90px;
        }
        /*.lundi{
            //display:flex; pour que les enfants s'alignent horizontalement
            flex-wrap: wrap; pour que les enfants aille a la ligne suivante quand il n'y a plus d'espace
    
            width: fit-content; pour adapter la taille du conteneur par rapport a tous les enfants qu'il contient
            //min-width: 100%;

            //background-color:rgb(240,240,240);
            //border-radius:10px;

            //color:blue;
            //box-shadow:-10px 0 1px;
        }*/
        .panelProgrammation{
            margin:20px;
            position:relative;
            //background-color:red;

            display: flex;
            justify-content: center;
            align-items: center;
            text-align: center;
        }
        .codeUE{
            width:100%;
            height:auto;
            font-size:20px;
            font-weight:bold;
        }
        .element{
            //position:absolute;
            //bottom:0;
            //text-align:center;

    
        }
        .hr{
            position:absolute; top:20px; width:100%; border-top:4px solid black;
        }

    </style>


    <asp:DropDownList AutoPostBack="true" ID="DropDownListSemestre" runat="server" Height="42px" Width="200px" OnSelectedIndexChanged="DropDownListSemestre_SelectedIndexChanged">
        <asp:ListItem >Semestre</asp:ListItem>
        <asp:ListItem>1</asp:ListItem>
        <asp:ListItem Value="2"></asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList AutoPostBack="true" ID="DropDownListFiliere" runat="server" Height="42px" Width="200px" OnSelectedIndexChanged="DropDownListFiliere_SelectedIndexChanged">
        <asp:ListItem >Filiere</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList AutoPostBack="true" ID="DropDownListNiveau" runat="server" Height="42px" Width="200px" OnSelectedIndexChanged="DropDownListNiveau_SelectedIndexChanged">
        <asp:ListItem >Niveau</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList AutoPostBack="true" ID="DropDownListEnseignant" runat="server" Height="42px" Width="200px" OnSelectedIndexChanged="DropDownListEnseignant_SelectedIndexChanged">
        <asp:ListItem >Tous les enseignants</asp:ListItem>
    </asp:DropDownList>
    <asp:DropDownList AutoPostBack="true" ID="DropDownListSalle" runat="server" Height="42px" Width="200px" OnSelectedIndexChanged="DropDownListSalle_SelectedIndexChanged">
        <asp:ListItem >Toutes les salles</asp:ListItem>
    </asp:DropDownList>
    
    <div class="conteneur">
        <div id="lundi" runat="server" class="div_jour" style="position:absolute;top:0; width:20%; height:1000px;left:0; border: 1px solid black; //background-color: green;">
            <span class="jour">Lundi</span>
            <hr class="hr"/>

        </div>
        <div id="mardi" runat="server" class="div_jour" style="position:absolute;top:0; width:20%; height:1000px;left:20%; border: 1px solid black; //background-color: red;">
            <span class="jour">Mardi</span>
            <hr class="hr"/>
        </div>
        <div id="mercredi" runat="server" class="div_jour" style="position:absolute;top:0; width:20%; height:1000px;left:40%; border: 1px solid black; //background-color: yellow;">
            <span class="jour">Mercredi</span>
            <hr class="hr"/>

        </div>
        <div id="jeudi" runat="server" class="div_jour" style="position:absolute;top:0; width:20%; height:1000px;left:60%; border: 1px solid black; //background-color: grey;">
            <span class="jour">Jeudi</span>
            <hr class="hr"/>

        </div>
        <div id="vendredi" runat="server" class="div_jour" style="position:absolute;top:0; width:20%; height:1000px;left:80%; border: 1px solid black; //background-color: pink;">
            <span class="jour">Vendredi</span>
            <hr class="hr"/>

        </div>
    </div>
</asp:Content>
