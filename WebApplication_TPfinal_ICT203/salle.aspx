<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="salle.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.salle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <style>
    
    .rounded-textbox
    {
         border-radius: 20px;
    }
</style>


<p id="titre" runat="server" style="text-align:center; font-weight:bold;font-size:50px;">&#39;ENREGISTRER SALLE&#39;</p>
<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="X-Large" Text="SALLES ENREGISTREES:"></asp:Label>
<div style=" width:100%; height:500px; border-radius:15px; //background-color:yellow; position:relative; left:-100px;margin-left:auto;margin-right:auto;">
    <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="600px" GridLines="Vertical">
        <AlternatingRowStyle BackColor="#DCDCDC" />
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
    <div runat="server" id="Panel1" class="panel1" style="color:blue; //box-shadow:-10px 0 1px; //border: 1px solid blue; //border-radius:15px 0 0 15px;width:100px; height:500px; //background-color:blue; position:absolute; top:0;left:605px;//right:30%">
        
        <ul id="myList" runat="server" style="position:absolute; top:20px; width:100%">
            
        </ul>
    </div>
    <div style="display: flex; justify-content: center; align-items: center; width:40%; height:500px;box-shadow:-10px 0 1px; border-radius:15px 0 0 15px; //background-color:grey; position:absolute; top:-40px;right:-200px">
        <div runat="server" ID="fileUploadPanel" style=" width:80%; height:500px; border-radius:15px; background-color:white; position:relative; //margin-left:auto;//margin-right:auto; ">
   
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Enregistrer une salle"></asp:Label>
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="textboxCode" runat="server" Height="42px" Width="281px" placeholder="Code salle" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="textboxCapacite" type="number" runat="server" Height="42px" Width="281px" placeholder="Capacite de la salle" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
            <br />
            <br />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="Enregistrer" Height="55px" Width="281px" BorderStyle="Solid" CssClass="rounded-textbox" BackColor="#0000CC" ForeColor="White" OnClick="Enregistrer_Click" />

        </div>
    </div>
</div>
</asp:Content>
