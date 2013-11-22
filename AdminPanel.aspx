<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="AdminPanel.aspx.cs" Inherits="AdminPanel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Админ панель</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="utf-8" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    
    <div>
   
        
    
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [Id_user], [name], [email] FROM [User] WHERE ([confirm] = @confirm)">
            <SelectParameters>
                <asp:Parameter DefaultValue="False" Name="confirm" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:Label ID="Label1" runat="server" Text="Незарегистрированые пользователи"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="Id_user">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:BoundField DataField="Id_user" HeaderText="Id_user" SortExpression="Id_user" InsertVisible="False" ReadOnly="True" Visible="False" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" Visible="False" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString1 %>" SelectCommand="SELECT [name], [login], [password], [email], [rating], [confirm], [Id_user] FROM [User] WHERE ([Id_user] = @Id_user)"
            UpdateCommand="Update [User] SET [confirm]=@confirm">
            <SelectParameters>
                <asp:ControlParameter ControlID="GridView1" Name="Id_user" PropertyName="SelectedValue" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
        <br />
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="SqlDataSource2" Height="50px" Width="125px" AutoGenerateEditButton="True" EnablePagingCallbacks="True" OnItemUpdating="DetailsView1_ItemUpdating">
            <Fields>
<asp:BoundField DataField="name" HeaderText="name" SortExpression="name"></asp:BoundField>
                <asp:BoundField DataField="login" HeaderText="login" SortExpression="login" />
                <asp:BoundField DataField="password" HeaderText="password" SortExpression="password" />
                <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                <asp:BoundField DataField="rating" HeaderText="rating" SortExpression="rating" />
                <asp:CheckBoxField DataField="confirm" HeaderText="confirm" SortExpression="confirm" />
            </Fields>
        </asp:DetailsView>
   
        
    
    </div>
 

</asp:Content> 
