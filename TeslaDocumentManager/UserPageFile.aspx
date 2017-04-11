<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPageFile.aspx.cs" Inherits="TeslaDocumentManager.UserPageFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" type="text/css" href="UserPageFile.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Page">
        <div class="header">
                User:
                <asp:Label ID="lblUser" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnDodajFile" runat="server" Text="Dodaj fajl" Height="30px" OnClick="btnDodajDomen_Click" />
                <asp:Button ID="btnOdjava" runat="server" Text="Odjavi se" Height="30px" Width="80px" OnClick="btnOdjava_Click" />        
            </div>
          <asp:Label ID="error_message" runat="server" Visible="false" Text=""></asp:Label>
                     <hr class="my_hr" />


                   <div id="Domen">
                <asp:GridView ID="datagrid" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager"
    HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="True"  AutoGenerateColumns="false" >
   <%-- OnPageIndexChanging="datagrid_PageIndexChanging" OnSelectedIndexChanged="datagrid_SelectedIndexChanged"--%> 
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
                </asp:GridView>
            </div>
    </div>
    </form>
</body>
</html>
