<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifierProgrammation.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.ModifierProgrammation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        /*.overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5);
            display: none;
        }
        */
    
        .modifier{
            position: relative;
            margin-top: 220px;
            left: 50%;          
            transform: translate(-50%, -50%);
            background-color: #fff;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            //display: none;
        }

     
        .modifier label{
            display: inline-block;
            margin-bottom: 10px;
            margin-left:90px
        }

  
        .modifier input{
            width: 100%;
            padding: 5px;
            margin-bottom: 10px;
        }
    
        .modifier button{
            background-color: #4CAF50;
            color: #fff;
            padding: 10px 20px;
            border: none;
            cursor: pointer;
        }
        .Panel1{
            position:relative;
            left:-80px;
        }
    
    </style>
 <!--<script>
    
     function showFormm() {
         var formmodifier = document.getElementById("modifier");
         var overlay = document.getElementById("overlay");
         overlay.style.display = "block";
         formmodifier.style.display = "block";

     }

     function hideFormm() {
         var overlay = document.getElementById("overlay");
         var formmodifier = document.getElementById("modifier");

         overlay.style.display = "none";
         formmodifier.style.display = "none";
     }
   
 </script>-->
    
        <div class="modifier" >
            <label>Id de la programmation:</label>
            <asp:DropDownList ID="dropdownListId" runat="server"></asp:DropDownList>    
            <br />
            <label>Nouvelle Date du cours:</label>
              <asp:TextBox ID="datemodifie" type="date" runat="server" ></asp:TextBox>
              <br /><label> Nouvelle Heure debut:</label>
               <asp:TextBox ID="heuredebutmodifie" type="time" min="07:30" max="22:00" runat="server" ></asp:TextBox>
              <br /><label>Nouvelle Heure Fin:</label>
                 <asp:TextBox ID="heurefinmodifie"  type="time" min="07:30" max="22:00" runat="server" ></asp:TextBox>                              
               <br />
               <br /><br />
             <asp:Button ID="modifierbtn" text="Modifier" OnClick="Modifier" runat="server"/>
        </div>
    <asp:Panel ID="Panel1" runat="server" CssClass="Panel1" Width="110%" Height="500px" ScrollBars="Auto" BorderStyle="Solid">
        <asp:GridView ID="GridView1" runat="server" Width="90%" CellPadding="4" ForeColor="#333333" GridLines="None" >
            <AlternatingRowStyle BackColor="White" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <SortedAscendingCellStyle BackColor="#FDF5AC" />
            <SortedAscendingHeaderStyle BackColor="#4D0000" />
            <SortedDescendingCellStyle BackColor="#FCF6C0" />
            <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
        
            <ul id="myList" runat="server" style="position:absolute; top:20px; right:0; width:100px; //background-color:yellow;">
        
            </ul>

    </asp:Panel>
</asp:Content>
