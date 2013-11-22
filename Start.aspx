<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeFile="Start.aspx.cs" Inherits="Start" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Главная страница</title>
    <meta name="description" content=" Сторінка, яка використовує майстер сторінок" />
    <meta charset="utf-8" />

</asp:Content>  

<asp:Content ID="content" ContentPlaceHolderID="contentPlaceHolder" runat="server">
    
    <div>
    <asp:Label ID="Status" runat="server" Text="Label" Visible="False"></asp:Label>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" OnCreatingUser="CreateUserWizard1_CreatingUser" MembershipProvider="accountingProvider" OnCreateUserError="CreateUserWizard1_CreateUserError">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server" />
                <asp:CompleteWizardStep runat="server" />
            </WizardSteps>
        </asp:CreateUserWizard>
    
        
    
    <asp:Image ID="Image1" runat="server" Height="120px" Width="141px" />
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <asp:FileUpload ID="FileUpload1" runat="server" OnLoad="FileUpload1_Load" />
    
        
    
    </div>
 

</asp:Content> 
