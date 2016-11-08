<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebClient.Default" %>
<link href="style.css" rel="stylesheet" />
<!DOCTYPE html>
 
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CarService(SOAP)</title>
</head>
<body>
    <form id="form" runat="server">
        <div class="form1">

            <asp:Label ID="Marklbl"  runat="server">Mark(string)</asp:Label>
            <asp:TextBox ID="_Mark" MaxLength="255" runat="server"></asp:TextBox>
            <br />
        
            <asp:Label ID="Agelbl"  runat="server">Age(int)</asp:Label>
            <asp:TextBox ID="_Age" MaxLength="255" runat="server"></asp:TextBox>
             <br />

        
            <asp:Label ID="Pricelbl"  runat="server">Price(int)</asp:Label>
            <asp:TextBox ID="_Price" MaxLength="255" runat="server"></asp:TextBox>
            <br />
        
            <asp:Label ID="MotorValuelbl"  runat="server">Motor Value(int)</asp:Label>
            <asp:TextBox ID="_MotorValue" MaxLength="255" runat="server"></asp:TextBox>
             <br />
        
            <asp:Button ID ="Button1" runat="server" OnClick="Button1_Click" Text="Add Order" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <br />
            <br /> 
        </div>
        
        <div class="form2">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Show all Orders" />
            <br />
            <br />
            <asp:Label class="Label1" ID="Label1" runat="server"></asp:Label>
   
            <br />
            <br />
            <br />
        </div>

        <div class="form3">
            <asp:Label ID="IDlbl"  runat="server">Id(int)</asp:Label>
            <asp:TextBox ID="_ID" MaxLength="255" runat="server"></asp:TextBox>
            <br />
        
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Find by Id" />
            <br />
            <br />

            <asp:Label ID="Label2" runat="server"></asp:Label>

        </div>

    </form>
</body>
</html>
