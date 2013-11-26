<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeFile="AddBook.aspx.cs" Inherits="AddBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Панель пользователя</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="utf-8" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    
    <div>
        <asp:Table ID="Table1" runat="server" >
            <asp:TableRow runat="server">
            </asp:TableRow>
        </asp:Table>
</div>
 

</asp:Content> 