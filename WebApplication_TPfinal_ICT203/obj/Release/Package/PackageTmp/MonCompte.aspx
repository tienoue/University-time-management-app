<%@ Page Title="MonCompte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MonCompte.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.MonCompte" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .centeredPanel {
            position:relative;
            width:300px;
        }
    </style>


    <main aria-labelledby="title">
        <h2 id="title"><%: Title %>.</h2>
    <asp:Panel ID="PanelConnexion" runat="server">
        <br />
        <asp:Panel ID="Panel3" runat="server" Height="146px">
            <br />
            <table class="w-80" style="width: 60%">
                <tr>
                    <td style="width: 320px; height: 21px;">Login</td>
                    <td style="height: 21px">&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 320px">
                        <asp:TextBox ID="TextBox_Poste" runat="server" BorderStyle="Solid" Width="286px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 320px">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 320px; height: 21px;">Mot de passe</td>
                    <td style="height: 21px"></td>
                </tr>
                <tr>
                    <td style="width: 320px">
                        <asp:TextBox ID="TextBox_Salaire" runat="server" BorderStyle="Solid" type="password" Width="286px"></asp:TextBox>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        </asp:Panel>
        <br />
        <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red" Text="errorMessage"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" BackColor="#00CC00" BorderStyle="None" ForeColor="White" OnClick="Button2_Click" Text="Se connecter" Width="294px" Height="35px" />
</asp:Panel>
<br />
<asp:Panel ID="PanelCompteAdministrateur" runat="server">
    Modifier le mot de passe:<br />
    <br />
    <table class="w-80" style="width: 60%">
        
        <tr>
            <td style="width: 320px; height: 21px;">Ancien mot de passe</td>
            <td style="height: 21px"></td>
        </tr>
        <tr>
            <td style="width: 320px">
                <asp:TextBox ID="TextBoxPassword" runat="server" BorderStyle="Solid" type="password" Width="286px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 320px">
                <asp:Label ID="lblErrorMessage0" runat="server" ForeColor="Red" Text="Mot de passe incorrect"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
                <tr>
            <td style="width: 320px">Nouveau mot de passe</td>
            <td>&nbsp;</td>
        </tr>
                <tr>
            <td style="width: 320px">
                <asp:TextBox ID="TextBoxNewPassword" runat="server" BorderStyle="Solid" type="password" Width="286px"></asp:TextBox>
                    </td>
            <td>&nbsp;</td>
        </tr>

    </table>
    <br />
    <br />
    <asp:Button ID="Button3" runat="server" BackColor="#0066FF" BorderStyle="None" ForeColor="White" Height="35px" OnClick="Button3_Click" Text="Modifier" Width="294px" />
    </asp:Panel>
        <asp:Label ID="LabelMAJ" runat="server" ForeColor="Lime" Text="Mise à jour effectuée avec succès" Font-Italic="True" Font-Size="X-Large"></asp:Label>
<br />
<asp:Panel ID="PanelCompteUtilisateur" runat="server">
    <br />
    <asp:Panel ID="PanelInformations" runat="server" BorderStyle="Solid" Width="300px" CssClass="centeredPanel">
        <br />
        <div id="image" runat="server" style="height:150px;">

        </div>
        <input type="file" id="fileUpload" runat="server" />
        <asp:Button ID="modifier" runat="server" Text="Modifier" OnClick="modifier_Click" />
        <asp:DataList ID="datalist1" runat="server" RepeatDirection="Vertical">
            <ItemTemplate>
                <div>
                    <h5><span style="font-weight:bold;">Matricule: </span><%#Eval("matricule") %></h5>
                    <h5><span style="font-weight:bold;">Nom: </span><%#Eval("nom") %></h5>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <br />
        &nbsp;<asp:Button ID="Button4" runat="server" BackColor="#0066FF" BorderStyle="None" ForeColor="White" Height="35px" Text="Modifier mon mot de passe" Width="294px" OnClick="Button4_Click" />
        <br />
        <br />
    </asp:Panel>
    <br />
    <asp:Panel ID="PanelModifierMotDePasse" runat="server">
        <table class="w-80" style="width: 60%">
            <tr>
                <td style="width: 320px; height: 21px;">Ancien mot de passe</td>
                <td style="height: 21px"></td>
            </tr>
            <tr>
                <td style="width: 320px; height: 27px;">
                    <asp:TextBox ID="TextBoxPassword0" runat="server" BorderStyle="Solid" type="password" Width="286px"></asp:TextBox>
                </td>
                <td style="height: 27px"></td>
            </tr>
            <tr>
                <td style="width: 320px; height: 21px;">
                    <asp:Label ID="lblErrorMessage1" runat="server" ForeColor="Red" Text="Mot de passe incorrect"></asp:Label>
                </td>
                <td style="height: 21px"></td>
            </tr>
            <tr>
                <td style="width: 320px">Nouveau mot de passe</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td style="width: 320px">
                    <asp:TextBox ID="TextBoxNewPassword0" runat="server" BorderStyle="Solid" type="password" Width="286px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <br />
        <asp:Button ID="Button5" runat="server" BackColor="#0066FF" BorderStyle="None" ForeColor="White" Height="35px" Text="Modifier" Width="294px" OnClick="Button5_Click" />
    </asp:Panel>
    <br />
    </asp:Panel>
<br />
    </main>
</asp:Content>
