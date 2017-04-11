<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="TeslaDocumentManager.AdminPage2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="AdminPageStyle.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="Page">
        <div class="header">
            <div class="header_left">
                Operater:
                <asp:Label ID="lblOperater" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnOdjava" runat="server" Text="Odjavi se" OnClick="btnOdjava_Click" />
            </div>
            <div class="header_right_double">
                <asp:Button ID="btnPrikaziKorisnike" runat="server" Text="Prikaži korisnike" CssClass="button" OnClick="btnPrikaziKorisnike_Click" />
                <asp:Button ID="btnDodajDomen" runat="server" Text="Dodaj domen" CssClass="button" OnClick="btnDodajDomen_Click" />
            </div>
        </div>
          <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>
                     <hr class="top_hr" />


                   <div id="Domen">
                <%--<asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
 HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True" AutoGenerateColumns="false" >
 OnPageIndexChanging="datagrid_PageIndexChanging"--%> <%--OnSelectedIndexChanged="datagrid_SelectedIndexChanged"
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:HiddenField ID="Id" runat="server" Value='<%# Eval("Id")  %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Domeni">
                            <ItemTemplate><%# Eval("File") %></ItemTemplate>
                        </asp:TemplateField>
                   </Columns>
                </asp:GridView>--%>
            </div>
    </div>
    </form>
</body>
</html>
