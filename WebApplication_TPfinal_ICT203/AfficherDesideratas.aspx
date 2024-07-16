<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AfficherDesideratas.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.AfficherDesideratas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
      <div>
          <h2>Affichage des desideratas</h2>
           <label>Id du desiderata:</label>
           <asp:DropDownList ID="DropDownListId" runat="server" required="true"></asp:DropDownList>
           <br /> <br />
          <asp:Button runat="server" ID="valider" Text="Accepter" OnClick="accepter"/>
           <asp:Button runat="server" ID="Refuser" Text="Refuser" OnClick="refuser"/>
          <br /> <br />
        
             
          <br /> <br />
          <asp:Panel ID="Panel1" runat="server">
            <asp:GridView ID="griedview1" runat="server" Width="100%" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F5F7FB" />
                <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                <SortedDescendingCellStyle BackColor="#E9EBEF" />
                <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
          </asp:Panel>
      </div>
</asp:Content>
