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
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="false" OnRowDeleting="datagrid_RowDeleting">
                            <Columns>
                                <asp:TemplateField >
                                    <ItemTemplate><asp:HiddenField ID="Id" runat="server" Value= '<%# Eval("Id")  %>' /></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ime">
                                    <ItemTemplate> <%# Eval("Fullname") %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Username">
                                    <ItemTemplate><%#Eval("UserName") %></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText ="Email">
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
                                <asp:CommandField  Visible="true" ShowCancelButton="true" ShowDeleteButton="true"/>
                            </Columns>
                        </asp:GridView>
                </div>
                <div>
                    <div>
                        <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                        <asp:TextBox ID="tbxUsername" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Fullname"></asp:Label>
                        <asp:TextBox ID="tbxFullname" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label8" runat="server" Text="Password"></asp:Label>
                        <asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                        <asp:TextBox ID="tbxEmail" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label4" runat="server" Text="AccessLevel"></asp:Label>
                        <asp:DropDownList ID="ddlAccessLevel" runat="server"></asp:DropDownList>
                    </div>
                    <div>
                        <asp:Label ID="Label5" runat="server" Text="Activ"></asp:Label>
                        <asp:CheckBox ID="cbxActive" runat="server" />
                    </div>
                    <div>
                        <asp:Label ID="Label6" runat="server" Text="Phone"></asp:Label>
                        <asp:TextBox ID="tbxPhone" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Label ID="Label7" runat="server" Text="Note"></asp:Label>
                        <asp:TextBox ID="tbxNote" runat="server"></asp:TextBox>
                    </div>
                    <div>
                        <asp:Button ID="btnUpdate" runat="server" Text="Izmeni" />
                        <asp:Button ID="btnSave" runat="server" Text="Sacuvaj" />
                    </div>
                </div>
        </div>
    </form>
</body>
</html>
