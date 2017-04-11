<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPageKorisnici.aspx.cs" Inherits="TeslaDocumentManager.AdminPage" %>

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
                    <asp:Button ID="btnDodajKorisnika" runat="server" Text="Dodaj korisnika" CssClass="button"/>
                </div>
                <%--<asp:LinkButton ID="btnDodajKorisnika" runat="server" OnClick="btnDodajKorisnika_Click">Dodaj korisnika</asp:LinkButton>
                <asp:LinkButton ID="lnkOdjava" runat="server" OnClick="lnkOdjava_Click">Odjavi se</asp:LinkButton>--%>
            </div>

            <hr class="top_hr" />

            <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>

            <div id="DataUsers">
                <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header-grid" RowStyle-CssClass="rows-grid" AlternatingRowStyle-BackColor="#dadada" BorderStyle="None" GridLines="Vertical" AllowPaging="True" AutoGenerateColumns="false" OnRowDeleting="datagrid_RowDeleting" OnRowEditing="datagrid_RowEditing">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="Id" runat="server" Value='<%# Eval("Id")  %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ime">
                            <ItemTemplate><%# Eval("Fullname") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Username">
                            <ItemTemplate><%#Eval("UserName") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                            <ItemTemplate><%#Eval("Email") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="UserGroup">
                            <ItemTemplate><%#Eval("UserGroup") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Active">
                            <ItemTemplate><%#Eval("Active") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Phone">
                            <ItemTemplate><%#Eval("Phone") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Note">
                            <ItemTemplate><%#Eval("Note") %></ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField Visible="true" ShowCancelButton="true" ShowEditButton="true" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
