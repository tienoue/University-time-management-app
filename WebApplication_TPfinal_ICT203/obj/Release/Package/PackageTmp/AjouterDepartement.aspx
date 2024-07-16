<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AjouterDepartement.aspx.cs" Inherits="WebApplication_TPfinal_ICT203.AjouterDepartement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <body>
    <style>
        .body{
            background-image:url(images2/pic.jpg);
        }
        .rounded-textbox
        {
             border-radius: 20px;
             //style="background-image:url(images2/image.jpg)";
        }

    </style>



    <div style=" width:95%; height:500px; border-radius:15px; background-color:white; position:relative;margin-left:auto;margin-right:auto;">
        <div style="//border-right: 1px solid blue; border-radius:15px 0 0 15px; background-image:url(images2/enseignante.jpg);width:60%; height:500px; background-color:blue; position:absolute; top:0;left:0">

        </div>
        <div style="display: flex; justify-content: center; align-items: center; width:40%; height:500px; border-radius:15px; background-color:white; position:absolute; top:0;right:0">
            <div runat="server" ID="fileUploadPanel" style=" width:80%; height:500px; border-radius:15px; background-color:white; position:relative; //margin-left:auto;//margin-right:auto; ">
               
                <br />
                <asp:Label ID="Label1" runat="server" Font-Size="X-Large" Text="Enregistrer nouveau departement"></asp:Label>
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="textboxNomDepartement" runat="server" Height="42px" Width="281px" placeholder="Nom du departement" BorderStyle="Solid" CssClass="rounded-textbox"></asp:TextBox>
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <!--<input type="file" ID="imageFile" name="imageFile" accept="image/*" />-->
                <input type="file" id="fileUpload" runat="server" />
                <br />
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
