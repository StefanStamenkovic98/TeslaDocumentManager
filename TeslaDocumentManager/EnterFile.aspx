<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterFile.aspx.cs" Inherits="TeslaDocumentManager.EnterFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="EnterFile.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="Page">
            <div class="header">
                <div class="header_left">
                    <asp:Button ID="btnBack" runat="server" Text="Nazad" />
                </div>
                <div class="header_mid">
                    <asp:Label ID="lblUnesi" runat="server" Text="Dodaj fajl: "></asp:Label>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </div>
                <div class="header_right">
                    <asp:Button ID="btnUnesi" runat="server" Text="Pošalji" CssClass="button"/>
                </div>
            </div>

            <hr class="top_hr" />

            <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>

            <div id="DataUsers">
                <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
                    HeaderStyle-CssClass="grid-header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="false">
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
