<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Page1.aspx.cs" Inherits="Page1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<html>
<head id="Head2" runat="server">
    <title>AsyncFileUpload Example</title>
    <script type="text/javascript">
        function uploadComplete(sender) {
            $get("<%=lblMesg.ClientID%>").style.color = "white";
             $get("<%=lblMesg.ClientID%>").innerHTML = "Файл удачно загружен";
         }

         function uploadError(sender) {
             $get("<%=lblMesg.ClientID%>").style.color = "red";
            $get("<%=lblMesg.ClientID%>").innerHTML = "Загрузка файла не удалась";
        }
    </script>
    <link href="css/menu.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Poiret+One&subset=latin,cyrillic' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Lobster&subset=cyrillic,latin' rel='stylesheet' type='text/css' />
</head>
<body>
    &nbsp;<form id="form1" runat="server">

        <div id="allContent">
            <div class="title">Книжный клуб</div>

            <div id="menu">
                <ul class="menu">
                    <li><a href="Index.aspx"><span>Главная</span></a></li>
                    <li><a href="Books.aspx"><span>Книги</span></a> </li>
                    <li><a href="Search.aspx"><span>Поиск</span></a> </li>
                    <li></li>
                </ul>
            </div>

            <div class="wrapper">
                <div class="content">
                    <div class="contentTitle">
                    </div>

                    <div class="contentTitle">Мой профиль</div>
                    <div>
                        <asp:Label ID="Status" runat="server"></asp:Label>
                        <br />
                        <asp:Image ID="userPhoto" runat="server" Height="107px" Width="114px" />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                        <br />

                        <br />
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="LblName" runat="server" Text="Имя"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="NameText" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LblEmail" runat="server" Text="Email"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="EmailText" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="LblPassword" runat="server" Text="Пароль"></asp:Label></td>
                                <td>
                                    <asp:TextBox ID="Password1" runat="server" TextMode="Password"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Save" runat="server" Text="Сохранить" OnClick="Save_Click" /></td>
                            </tr>

                        </table>
                         <asp:Label ID="Label3" runat="server" Text="Загрузить фотографию"></asp:Label>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <cc1:AsyncFileUpload OnClientUploadError="uploadError"
                            OnClientUploadComplete="uploadComplete" runat="server"
                            ID="AsyncFileUpload1" Width="400px" UploaderStyle="Modern"
                            CompleteBackColor="White"
                            UploadingBackColor="#CCFFFF" ThrobberID="imgLoader"
                            OnUploadedComplete="FileUploadComplete" />
                        <asp:Image ID="imgLoader" runat="server" ImageUrl="~/images/loader.gif" />
                        <br />
                        <asp:Label ID="lblMesg" runat="server" Text=""></asp:Label>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Загруженные книги"></asp:Label>
                        <br />
                        <asp:ListBox ID="ListBooks" runat="server"></asp:ListBox>
                        <br />
                        <br />

                    </div>

                </div>

                <div class="sidePanel" onload="Load()">
                    <br />
                    <div class="sidePanelСontent" onload="Load">


                        <asp:LoginName ID="LoginName1" runat="server" FormatString="Welcome, {0}" Visible="False" Font-Names="Segoe WP SemiLight" />
                        <br />
                        <asp:Label ID="Rating" runat="server" Text="Label" Visible="False"></asp:Label>
                        <br />

                        <asp:Label ID="StatusLb" runat="server" Width="300">Пожалуйста, авторизуйтесь</asp:Label><br />
                        <asp:Button ID="Registration" runat="server" OnClick="Button1_Click" Text="Регистрация" />
                        <asp:Button ID="AdminPanelButton" runat="server" OnClick="Button2_Click" Text="Панель управления" Visible="False" />
                        <br />
                        <asp:Button ID="UserPanelButton" runat="server" Text="Мой профиль" Visible="False" OnClick="UserPanelButton_Click" />
                        <br />
                        <asp:Button ID="Exit" runat="server" Text="Выход" Visible="False" OnClick="Exit_Click" />
                        <br />
                        <asp:Label ID="ErrorLb" runat="server" Width="300" ForeColor="Red"></asp:Label>

                        <asp:Login ID="Login1" runat="server" Height="192px" Style="font-size: medium"
                            OnAuthenticate="Login1_Authenticate">
                        </asp:Login>

                    </div>
                </div>

            </div>

            <footer>
                <div class="footerContent">
                    Книжный клуб, 2013<br />
                    Все права защищены
                </div>
            </footer>
        </div>
    </form>

</body>
</html>
