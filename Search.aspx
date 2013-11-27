<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.Master"  CodeFile="Search.aspx.cs" Inherits="Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Поиск книги</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="utf-8" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    
    <div>
        <asp:Label ID="LblName" runat="server" Text="Название"></asp:Label>
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LblAuthor" runat="server" Text="Автор"></asp:Label>
        <asp:TextBox ID="Author" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LblPubl" runat="server" Text="Издательство"></asp:Label>
        <asp:TextBox ID="Publishing" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LblCat" runat="server" Text="Категория"></asp:Label>
        <asp:DropDownList ID="CatList" runat="server">
        </asp:DropDownList>
        <br />
        <asp:Button ID="ButtonSearch" runat="server" Text="Поиск" OnClick="ButtonSearch_Click" />
        <br />
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
    </div>
 

</asp:Content> 