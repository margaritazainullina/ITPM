<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeFile="Index.aspx.cs" Inherits="Index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Главная страница</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="utf-8" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    
    <div>
        <asp:Label ID="TxtLabel" runat="server"></asp:Label>
    </div>
 

</asp:Content> 