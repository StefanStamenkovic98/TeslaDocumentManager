<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaveUser.aspx.cs" Inherits="TeslaDocumentManager.SaveUser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link href="AdminPageStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="Page">
            <div class="header">
                <div class="header_left">
                    Operater:
                    <asp:Label ID="lblOperater" runat="server" Text=""></asp:Label>
                    <asp:Button ID="btnOdjava" runat="server" Text="Odjavi se" />
                </div>
                <div class="header_right">
                    <asp:Button ID="btnKorisnici" runat="server" Text="Korisnici" OnClick="btnKorisnici_Click" CssClass="button"/>
                </div>
            </div>

            <hr class="top_hr" />

            <asp:Label ID="error_message" runat="server"></asp:Label>

            <div>
                <div class="row">
                    <asp:Label ID="Label1" runat="server" Text="Username: "></asp:Label>
                    <asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Label ID="Label2" runat="server" Text="Full Name: "></asp:Label>
                    <asp:TextBox ID="tbxFullname" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Label ID="Label8" runat="server" Text="Password: "></asp:Label>
                    <asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Label ID="Label3" runat="server" Text="E-mail: "></asp:Label>
                    <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Label ID="Label4" runat="server" Text="Access Level: "></asp:Label>
                    <asp:DropDownList ID="ddlAccessLevel" runat="server"></asp:DropDownList>
                </div>
                <div class="row">
                    <asp:Label ID="Label5" runat="server" Text="Active: "></asp:Label>
                    <asp:CheckBox ID="cbxActive" runat="server" />
                </div>
                <div class="row">
                    <asp:Label ID="Label6" runat="server" Text="Phone: "></asp:Label>
                    <asp:TextBox ID="tbxPhone" runat="server"></asp:TextBox>
                </div>
                <div class="row">
                    <asp:Label ID="Label7" runat="server" Text="Note: "></asp:Label>
                    <asp:TextBox ID="tbxNote" runat="server"></asp:TextBox>
                </div>
                <div class="row_buttons">
                    <asp:Button ID="btnSave" runat="server" Text="Sačuvaj" CssClass="button" OnClick="btnSave_Click"/>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
