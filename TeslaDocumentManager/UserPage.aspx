<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="TeslaDocumentManager.UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="UserPage.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Page">
            <div class="header">
                <div class="header_left">
                Korisnik: 
                <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnDodajFile" runat="server" Text="Dodaj file" CssClass="button" OnClick="btnDodajFile_Click" />
                <asp:Button ID="btnOdjava" runat="server" Text="Odjavi se" OnClick="btnOdjava_Click" />
                </div>
                <div class="header_right">

                </div>
            </div>

            <hr class="top_hr" />

            <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>

            <div id="Domen">
                <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="grid-header" RowStyle-CssClass="rows" AlternatingRowStyle-BackColor="#dadada" BorderStyle="None" GridLines="Vertical" AllowPaging="True" OnRowDeleting="datagrid_RowDeleting" AutoGenerateColumns="false">
                    <%-- OnPageIndexChanging="datagrid_PageIndexChanging" OnSelectedIndexChanged="datagrid_SelectedIndexChanged"--%>
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="Id" runat="server" Value='<%# Eval("Id")  %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Fajlovi">
                            <ItemTemplate><%# Eval("File") %></ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
