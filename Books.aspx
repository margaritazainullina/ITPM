<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Просмотр Книг</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="windows-1251" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    
    <div>
    </div>
 

    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1" ImageSet="Arrows" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_book" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Id_book" HeaderText="Id_book" InsertVisible="False" ReadOnly="True" SortExpression="Id_book" Visible="False" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
            <asp:BoundField DataField="publishing" HeaderText="publishing" SortExpression="publishing" />
            <asp:BoundField DataField="book_url" HeaderText="book_url" SortExpression="book_url" />
        </Columns>
    </asp:GridView>
 

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [Id_book], [name], [author], [publishing], [book_url] FROM [Book]"></asp:SqlDataSource>
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id_book" DataSourceID="SqlDataSource2" Height="50px" Width="125px">
        <Fields>
            <asp:BoundField DataField="Id_book" HeaderText="Id_book" InsertVisible="False" ReadOnly="True" SortExpression="Id_book" Visible="False" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
            <asp:BoundField DataField="book_url" HeaderText="book_url" SortExpression="book_url" />
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [Id_book], [name], [book_url] FROM [Book] WHERE ([Id_book] = @Id_book)">
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="Id_book" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Скачать файл</asp:LinkButton>
        <br />
        <asp:Label ID="State" runat="server"></asp:Label>
         

</asp:Content> 