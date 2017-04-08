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
            Operater:
            <asp:Label ID="lblOperater" runat="server" Text=""></asp:Label>
            <asp:LinkButton ID="lnkOdjava" runat="server" OnClick="lnkOdjava_Click">Odjavi se</asp:LinkButton>

            <hr class="my_hr" />

            <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>

            <div id="DataUsers">
                <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="header-grid" RowStyle-CssClass="rows-grid" AllowPaging="True" AutoGenerateColumns="false" OnRowDeleting="datagrid_RowDeleting">
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
                        <asp:CommandField Visible="true" ShowCancelButton="true" ShowDeleteButton="true" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>
