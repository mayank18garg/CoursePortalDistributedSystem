<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
body {
  font-family: Arial;
  color: red;
}

.split {
  height: 100%;
  width: 50%;
  position: fixed;
  z-index: 1;
  top: 0;
  overflow-x: hidden;
  padding-top: 20px;
}

.left {
  left: 0;
  background-color: #111;
}

.right {
  right: 0;
  background-color: white;
}

.centered {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  text-align: center;
}

</style>
    
    <div class="split left">
        <div class="centered">
            <h2><asp:Label ID="Label1" runat="server" Text="Add Course Service"></asp:Label></h2>
            <h4><asp:Label ID="Label2" runat="server" Text="Enter Course Code"></asp:Label></h4><br>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br><br>
            <h4><asp:Label ID="Label3" runat="server" Text="Enter Course Name"></asp:Label></h4><br>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox><br><br>
            <h4> <asp:Label ID="Label4" runat="server" Text="No of Seats(int)"></asp:Label></h4><br>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox><br><br>
            <h4><asp:Label ID="Label5" runat="server" Text="Instructor Name"></asp:Label></h4><br>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox> <br><br>
            <b><asp:Button ID="Button1" runat="server" Text="Add Course" OnClick="Button1_Click" /></b><br><br>
            <asp:Label ID="Label6" runat="server"></asp:Label>
        </div>
     </div>
    <div class="split right">
        <div class="centered">
            <h2><asp:Label ID="Label7" runat="server" Text="Register Course Service"></asp:Label></h2>
            <h4><asp:Label ID="Label8" runat="server" Text="Enter Course Code"></asp:Label></h4><br>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox><br><br>
            <h4><asp:Label ID="Label9" runat="server" Text="Enter Username"></asp:Label></h4><br>
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox><br><br>
            <asp:Button ID="Button2" runat="server" Text="Register Course" OnClick="Button2_Click" /><br><br>
            <asp:Label ID="Label10" runat="server"></asp:Label>
        </div>
    </div>
    
</asp:Content>
