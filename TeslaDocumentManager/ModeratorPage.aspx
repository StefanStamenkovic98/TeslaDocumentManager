<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModeratorPage.aspx.cs" Inherits="TeslaDocumentManager.ModeratorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" type="text/css" href="AdminPageStyle.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="Page">
            <div class="header">
                <div class="header_left">
                    Moderator:
                    <asp:Label ID="lblModerator" runat="server" Text=""></asp:Label>
                    <asp:Button ID="btnOdjava" runat="server" Text="Odjavi se" OnClick="btnOdjava_Click" />
                </div>
                <div class="header_right">
                    <asp:Button ID="btnDodajDomen" runat="server" Text="Dodaj domen" CssClass="button" OnClick="btnDodajDomen_Click" />
                </div>
            </div>
            <hr class="top_hr" />
            <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
