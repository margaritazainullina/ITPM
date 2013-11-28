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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id_book" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="author" HeaderText="author" SortExpression="author" />
                <asp:BoundField DataField="publishing" HeaderText="publishing" SortExpression="publishing" />
                <asp:BoundField DataField="book_url" HeaderText="book_url" SortExpression="book_url" />
                <asp:BoundField DataField="Id_book" HeaderText="Id_book" InsertVisible="False" ReadOnly="True" SortExpression="Id_book" Visible="False" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [name], [author], [publishing], [book_url], [Id_book] FROM [Book]"></asp:SqlDataSource>
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataKeyNames="Id_book" DataSourceID="SqlDataSource2" Height="50px" Width="125px">
            <Fields>
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="book_url" HeaderText="book_url" SortExpression="book_url" />
                <asp:BoundField DataField="Id_book" HeaderText="Id_book" InsertVisible="False" ReadOnly="True" SortExpression="Id_book" Visible="False" />
            </Fields>
        </asp:DetailsView>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [name], [book_url], [Id_book] FROM [Book] WHERE ([Id_book] = @Id_book)">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="Id_book" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Скачать файл</asp:LinkButton>
        <br />
        <asp:Label ID="State" runat="server"></asp:Label>
        <br />
    </div>
 

</asp:Content> 