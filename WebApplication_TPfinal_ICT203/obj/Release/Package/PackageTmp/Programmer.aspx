<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Programmer.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.Programmer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!DOCTYPE html>
<html >
<head >
    <title>Form Demo</title>
    <style>
        .overlay {
            position: fixed;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background-color: rgba(0, 0, 0, 0.5);
            display: none;
        }

        .form-container {
            position: relative;
            margin-top: 220px;
            left: 50%;          
            transform: translate(-50%, -50%);
            background-color: #fff;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            display: none;
          

        }
        .modifier{
             position: relative;
            margin-top: 220px;
            left: 50%;          
            transform: translate(-50%, -50%);
            background-color: #fff;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 5px;
            display: none;
        }

        .form-container  label {
            display: inline-block;
            margin-bottom: 10px;
              margin-left:120px
        }
        .modifier label{
            display: inline-block;
            margin-bottom: 10px;
              margin-left:90px
                    }

        .form-container input {
            width: 100%;
            padding: 5px;
            margin-bottom: 10px;
        }
        .modifier input{
              width: 100%;
              padding: 5px;
              margin-bottom: 10px;
        }
        .form-container button {
            background-color: #4CAF50;
            color: #fff;
            padding: 10px 20px;
            border: none;
            cursor: pointer;

        }
        .modifier button{
             background-color: #4CAF50;
             color: #fff;
             padding: 10px 20px;
             border: none;
             cursor: pointer;
                    }
       
    </style>
    <script>
        function showForm() {
            var overlay = document.getElementById("overlay");
            var formContainer = document.getElementById("form-container");
           
            overlay.style.display = "block";
            formContainer.style.display = "block";
           
        }
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
        function hideForm() {
            var overlay = document.getElementById("overlay");
            var formContainer = document.getElementById("form-container");

            overlay.style.display = "none";
            formContainer.style.display = "none";
        }
    </script>
     <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" >
        <div class="overlay" id="overlay"></div>
        <div class="form-container" id="form-container">
            <h2>PROGRAMMATION</h2>
            <label>Type</label>
            <asp:DropDownList ID="DropDownListType" runat="server" required="true">
                <asp:ListItem>cours</asp:ListItem>
                <asp:ListItem>CC</asp:ListItem>
                <asp:ListItem>TP</asp:ListItem>
                <asp:ListItem>SN</asp:ListItem>
            </asp:DropDownList>

            <label>Date:</label>
            <asp:TextBox ID="datecours" type="date" runat="server" required="true"></asp:TextBox>
            <label>Heure debut:</label>
             <asp:TextBox ID="heuredebut" type="time" min="07:30" max="22:00" runat="server" required="true"></asp:TextBox>
            <label>Heure Fin:</label>
             <asp:TextBox ID="heurefin"  type="time" min="07:30" max="22:00" runat="server" required="true"></asp:TextBox>
            
            <label>Code UE</label>
             <asp:DropDownList ID="UE" runat="server" required="true"></asp:DropDownList>
            
            
            <label>Code Salle</label>
           <asp:DropDownList ID="Salle" runat="server" required="true"></asp:DropDownList>
             <label>Delai de Modification</label>
            <asp:TextBox ID="modification" type="date" runat="server" required="true"></asp:TextBox>
             
            <asp:Label ID="erreurd" runat="server" CssClass="alerte"></asp:Label>
            <br /><br />
            <button type="button" onclick="hideForm()">Fermer</button>
            <asp:Button ID="enregistrer" text="Enregistrer" OnClick="Enregistrer" runat="server"/>
        </div>
        <div>
            <button type="button" onclick="showForm()">Creer un programme</button>
        </div>
      
    </form>
   
</body>
</html>   
</asp:Content>
