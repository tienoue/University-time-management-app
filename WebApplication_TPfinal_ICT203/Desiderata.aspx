<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Desiderata.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.Desiderata" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
    <style>
        .body{
            background-image:url(images/pic.jpg);
        }
        .rounded-textbox
        {
             border-radius: 20px;
        }
        .panel{
            /*position:relative;
            width:100px;
            height:20px;
            border: 1px solid black;*/
        }
        .gridview{
            /*position:relative;
            width:100px;
            height:20px;
            border: 1px solid black;*/
        }

    </style>



    <div style=" width:95%; height:700px; border-radius:15px; background-color:white; position:relative;margin-left:auto;margin-right:auto;">
        <div style="//border-right: 1px solid blue; border-radius:15px 0 0 15px; //background-image:url(images2/enseignante.jpg);width:60%; height:500px; //background-color:blue; position:absolute; top:0;left:-100px">
            <asp:Label ID="Label6" runat="server" Text="MES PROGRAMMATIONS" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel2" runat="server" CssClass="panel">
                <asp:GridView CssClass="gridview" ID="GridView2" runat="server" CellPadding="3" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellSpacing="2">
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
            </asp:Panel>
            <br />
            <br />

            <asp:Label ID="Label5" runat="server" Text="DESIDERATAS ENVOYES" Font-Size="X-Large"></asp:Label>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" CssClass="panel">
                <asp:GridView CssClass="gridview" ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F8FAFA" />
                    <SortedAscendingHeaderStyle BackColor="#246B61" />
                    <SortedDescendingCellStyle BackColor="#D4DFE1" />
                    <SortedDescendingHeaderStyle BackColor="#15524A" />
                </asp:GridView>
            </asp:Panel>
            
        </div>
        <div style="display: flex; justify-content: center; align-items: center; width:40%; height:500px; border-radius:15px; background-color:white; position:absolute; top:50px;right:-100px">
            <div style=" width:80%; height:600px;box-shadow: -10px 0 1px; border-radius:15px; background-color:white; position:relative; margin-top:0;//margin-right:auto; ">

                <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Nouveau Desiderata"></asp:Label>
                <br />
                <asp:Label ID="labelSuccess" runat="server" Font-Italic="True" Font-Size="X-Large" ForeColor="#00CC00" Text="&quot;Données enregistrées avec succès&quot;"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ancienneDate" runat="server" Width="281px">
                    <asp:ListItem Selected="True">Ancienne date de passage</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ancienneHeure" runat="server" Width="281px">
                    <asp:ListItem Selected="True">Ancienne heure de debut</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label2" runat="server" Text="Date de passage"></asp:Label><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="date" type="date" runat="server" Height="42px" Width="281px" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label3" runat="server" Text="Heure de debut"></asp:Label><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="heureDebut" type="time" runat="server" Height="42px" Width="281px" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Heure de fin"></asp:Label><br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="heureFin" type="time" runat="server" Height="42px" Width="281px" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ue" runat="server" Width="281px">
                    <asp:ListItem Selected="True">Selectionner l'UE</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Enregistrer" Height="55px" Width="281px" BorderStyle="Solid" CssClass="rounded-textbox" BackColor="#0000CC" ForeColor="White" OnClick="Button2_Click" />

            </div>
        </div>
    </div>

</body>
</asp:Content>
