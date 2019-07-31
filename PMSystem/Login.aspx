<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PMSystem.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>人事管理系统</title>
    <style type="text/css">
        .auto-style1 {
            width: 1313px;
            height: 782px;
        }

        .auto-style2 {
            height: 118px;
        }

        .auto-style3 {
            height: 89px;
        }

        .auto-style5 {
            height: 47px;
        }

        .auto-style6 {
            font-size: xx-large;
        }

        .auto-style7 {
            height: 93px;
        }

        .auto-style8 {
            width: 100%;
            position: fixed;
            left: 10px;
            top: 220px;
            height: 486px;
        }

        .auto-style9 {
            height: 98px;
        }

        .auto-style10 {
            height: 77px;
        }
    </style>
</head>
<body style="background-image: url('../../Resource/ima/background.jpg'); background-attachment: fixed; background-size: 100% 100%;">
    <%--<img src="Resource/ima/background3.jpg" />--%>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <table position: absolute;" class="auto-style8">
                    <tr align="center">
                        <td class="auto-style2">
                            <asp:Label ID="Label2" runat="server" Text="欢迎使用人事管理系统！" Font-Size="XX-Large"  CssClass="auto-style6"></asp:Label>
                        </td>
                    </tr>
                    <tr align="center">
                        <td class="auto-style3">
                            <asp:Label ID="Label0" runat="server" Font-Size="X-Large"  Text="用户账号："></asp:Label>

                            <asp:TextBox ID="TextBox0" runat="server" Font-Size="X-Large"></asp:TextBox>
                        </td>
                    </tr>
                    <tr align="center">
                        <td class="auto-style7">
                            <asp:Label ID="Label1" runat="server" Font-Size="X-Large"  Text="用户密码："></asp:Label>
                            <asp:TextBox TextMode="Password" ID="TextBox1" runat="server" Font-Size="X-Large"></asp:TextBox>
                        </td>
                    </tr>
                    <tr align="center">
                        <td class="auto-style5">
                            <asp:Label ID="Label3" runat="server" Text="登陆失败，请重新输入。" Font-Size="Large" ></asp:Label>
                        </td>
                    </tr>
                    <tr align="center">
                        <td class="auto-style10">
                            <asp:Button ID="Button1" runat="server" Text="登录" Font-Size="Large" OnClick="login" Height="40px" Width="78px" />
                        </td>
                    </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
            <br />
            <br />
            <br />
            <br />
        </div>
        <footer align="center">
            <p>Copyright &copy; 2019.Company name All rights reserved.More Informacion <a href="Help.aspx">About .</a></p>
        </footer>
    </form>
</body>
</html>
