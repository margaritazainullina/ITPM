<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeFile="AddBook.aspx.cs" Inherits="AddBook" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Панель пользователя</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="utf-8" />

</asp:Content>

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    <div class="contentTitle">Добавление книги</div>
    <div>
        <table>
            <tr>
                <td>
                    <asp:Label ID="LblName" runat="server" Text="Название"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TxtName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblAuthor" runat="server" Text="Автор"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TxtAuthor" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LblPublishing" runat="server" Text="Издательство"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TxtPublishing" runat="server"></asp:TextBox></td>
                <tr>
                    <td>
                        <asp:Label ID="LblCategory" runat="server" Text="Категория"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ListCategory" runat="server">
                        </asp:DropDownList></td>
                </tr>
            <tr>
                <td>
                    <asp:Label ID="LblInfo" runat="server" Text="Описание"></asp:Label></td>
                <td>
                    <asp:TextBox ID="TxtInfo" runat="server"></asp:TextBox></td>
            </tr>
        </table>

        <asp:Label ID="File" runat="server" Text="File"></asp:Label>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="ButtDownload" runat="server" Text="Загрузить" OnClick="FileUpload1_Load" />
        <br />
        <asp:Button ID="ButtAdd" runat="server" Text="Добавить" OnClick="ButtAdd_Click" />
        <br />
        <asp:Label ID="State" Visible="false" runat="server"></asp:Label>
    </div>


</asp:Content>
