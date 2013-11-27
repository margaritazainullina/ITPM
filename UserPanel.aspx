<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="UserPanel.aspx.cs" Inherits="UserPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Панель пользователя</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="utf-8" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    
    <div>
        <asp:Label ID="Status" runat="server"></asp:Label>
        <br />
        <asp:Image ID="userPhoto" runat="server" Height="107px" Width="114px" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <br />
        <asp:Button ID="Download" runat="server" Text="Загрузить" OnClick="FileUpload1_Load" />
        <br />
        <asp:Label ID="LblName" runat="server" Text="Имя"></asp:Label>
        <asp:TextBox ID="NameText" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label>
        <asp:TextBox ID="EmailText" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="LblPassword" runat="server" Text="Пароль"></asp:Label>
        <asp:TextBox ID="Password1" runat="server" TextMode="Password"></asp:TextBox><br />
        <asp:Button ID="Save" runat="server" Text="Сохранить" OnClick="Save_Click" />

        <br />
        <asp:Label ID="Label2" runat="server" Text="Загруженные книги"></asp:Label>
        <br />
        <asp:ListBox ID="ListBooks" runat="server"></asp:ListBox>
        <br />
        <br />
        <asp:Button ID="Download0" runat="server" Text="Загрузить новую" OnClick="Download0_Click" />

    </div>
 

</asp:Content> 
