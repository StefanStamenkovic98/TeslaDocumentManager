<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="TeslaDocumentManager.AdminPage1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="AdminPageStyle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Page">
                    Operater:
                    <asp:Label ID="lblOperater" runat="server" Text=""></asp:Label>
                    <asp:LinkButton ID="lnkOdjava" runat="server" OnClick="lnkOdjava_Click">Odjavi se</asp:LinkButton>

                <hr class="my_hr" />

                <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>
                <asp:Button ID="btnKorisnici" runat="server" Text="Korisnici" OnClick="btnKorisnici_Click" />
        </div>
    </form>
</body>
</html>
