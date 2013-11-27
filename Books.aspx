<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Просмотр Книг</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="windows-1251" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    
    <div>
    </div>
 

    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1" ImageSet="Arrows">
        <DataBindings>
            <asp:TreeNodeBinding DataMember="SiteMapNode" TextField="Description" />
        </DataBindings>
        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
    </asp:TreeView>
 

    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/xml/categories.xml"></asp:XmlDataSource>
    <asp:XmlDataSource ID="XmlDataSource3" runat="server" DataFile="~/1.xml"></asp:XmlDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server">
    </asp:GridView>
 

</asp:Content> 