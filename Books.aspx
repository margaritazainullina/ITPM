<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Просмотр Книг</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="windows-1251" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    
    <div>
    </div>
 

    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1">
        <DataBindings>
            <asp:TreeNodeBinding DataMember="SiteMapNode" TextField="Description" />
        </DataBindings>
    </asp:TreeView>
 

</asp:Content> 