<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Books.aspx.cs" Inherits="Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Просмотр Книг</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="windows-1251" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
     <div class="contentTitle">Каталог книг</div>
    
    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="XmlDataSource1" ImageSet="Arrows" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" CssClass="simple" ForeColor="White">
        <DataBindings>
            <asp:TreeNodeBinding DataMember="SiteMapNode" TextField="Description" />
        </DataBindings>
        <HoverNodeStyle Font-Underline="True" ForeColor="#FF9955"/>
        <NodeStyle Font-Size="11pt" ForeColor="White" Font-Names="Segoe UI Light" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
        <ParentNodeStyle Font-Bold="False" />
        <SelectedNodeStyle Font-Underline="True" ForeColor="#FF5511" HorizontalPadding="0px" VerticalPadding="0px" />
    </asp:TreeView>
 

    <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/xml/categories.xml"></asp:XmlDataSource>
    <asp:XmlDataSource ID="XmlDataSource3" runat="server" DataFile="~/1.xml"></asp:XmlDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_book" DataSourceID="SqlDataSource1" BorderStyle="None">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="Id_book" HeaderText="Id_book" InsertVisible="False" ReadOnly="True" SortExpression="Id_book" Visible="False" />
            <asp:BoundField DataField="name" HeaderText="Название" SortExpression="name" />
            <asp:BoundField DataField="author" HeaderText="Автор" SortExpression="author" />
            <asp:BoundField DataField="publishing" HeaderText="Издательство" SortExpression="publishing" />
            <asp:BoundField DataField="book_url" HeaderText="Ссылка" SortExpression="book_url" />
        </Columns>
    </asp:GridView>
 

    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [Id_book], [name], [author], [publishing], [book_url] FROM [Book]"></asp:SqlDataSource>
    <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id_book" DataSourceID="SqlDataSource2" Height="50px" Width="125px" OnDataBound="DetailsView1_DataBound" BorderStyle="None" Caption="Информация о книге">
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
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" Visible="False">Скачать файл</asp:LinkButton>
        <br />
        <asp:Label ID="State" runat="server"></asp:Label>
         

</asp:Content> 