<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserMan.aspx.cs" Inherits="PMSystem.userManAndLog" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>人事管理系统</title>
    <!-- Bootstrap Styles-->
    <link href="Resource/assets/css/bootstrap.css" rel="stylesheet" />
    <link href="Resource/assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FontAwesome Styles-->
    <link href="Resource/assets/css/font-awesome.css" rel="stylesheet" />
    <!-- Morris Chart Styles-->
    <link href="Resource/assets/js/morris/morris-0.4.3.min.css" rel="stylesheet" />
    <!-- Custom Styles-->
    <link href="Resource/assets/css/custom-styles.css" rel="stylesheet" />
    <!-- Google Fonts-->
    <link href='https://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <style type="text/css">
        .auto-style1 {
            width: 50%;
            height: 46px;
        }

        .auto-style6 {
            width: 241px;
            text-align: center;
        }

        .auto-style8 {
            width: 100%;
            height: 351px;
            table-layout: fixed;
        }

        .auto-style9 {
            width: 253px;
            text-align: right;
        }

        .auto-style10 {
            width: 253px;
            height: 40px;
            text-align: right;
        }

        .auto-style14 {
            width: 253px;
            text-align: right;
            height: 49px;
        }

        .auto-style16 {
            width: 253px;
            text-align: right;
            height: 54px;
        }

        .auto-style18 {
            width: 253px;
            text-align: right;
            height: 58px;
        }

        .auto-style20 {
            text-align: center;
        }

        .auto-style21 {
            height: 40px;
            table-layout: fixed;
            width: 230px;
        }

        .auto-style22 {
            height: 49px;
            width: 230px;
        }

        .auto-style24 {
            height: 58px;
            width: 230px;
        }

        .auto-style25 {
            height: 54px;
            width: 230px;
        }

        .auto-style26 {
            width: 230px;
        }

        .auto-style27 {
            width: 201px;
            text-align: center;
        }

        .auto-style28 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <nav class="navbar navbar-default top-navbar" role="navigation">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".sidebar-collapse">
                        <span class="sr-only">Toggle navigation</span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="Home.aspx">人&nbsp;&nbsp;事&nbsp;&nbsp;管&nbsp;&nbsp;理&nbsp;&nbsp;系&nbsp;&nbsp;统</a>
                </div>
                <ul class="nav navbar-top-links navbar-right">
                    <li class="dropdown">
                        <a class="dropdown-toggle" data-toggle="dropdown" href="#" aria-expanded="false">
                            <i class="fa fa-user fa-fw"></i><i class="fa fa-caret-down"></i>
                        </a>
                        <ul class="dropdown-menu dropdown-user">
                            <li>
                                <a href="PerInfo.aspx"><i class="fa fa-user fa-fw"></i>个人信息</a>
                            </li>
                            <li>
                                <a href="ChPwd.aspx"><i class="fa fa-gear fa-fw"></i>修改密码</a>
                            </li>
                            <li class="divider"></li>
                            <li>
                                <a href="Login.aspx"><i class="fa fa-sign-out fa-fw"></i>注销</a>
                            </li>
                        </ul>
                        <!-- /.dropdown-user -->
                    </li>
                    <!-- /.dropdown -->
                </ul>
            </nav>
            <!--/. NAV TOP  -->
            <nav class="navbar-default navbar-side" role="navigation">
                <div class="sidebar-collapse">
                    <ul class="nav" id="main-menu">
                        <li>
                            <a href="InfoInquiry.aspx"><i class=""></i>信息查询<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <a href="InfoInquiry.aspx">查询员工信息</a>
                                </li>
                                <li>
                                    <a href="InfoInquiry.aspx">查询部门信息</a>
                                </li>
                            </ul>
                        </li>

                        <li id="Li9" runat="server">
                            <a href="InfoEntry.aspx"><i class=""></i>信息录入<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li id="Li1" runat="server">
                                    <a href="InfoEntry.aspx">录入员工信息</a>
                                </li>
                                <li id="Li2" runat="server">
                                    <a href="InfoEntry.aspx">录入部门信息</a>
                                </li>
                            </ul>
                        </li>

                        <li id="Li10" runat="server">
                            <a href="InfoDeletion.aspx"><i class=""></i>信息删除<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li id="Li3" runat="server">
                                    <a href="InfoDeletion.aspx">删除员工信息</a>
                                </li>
                                <li id="Li4" runat="server">
                                    <a href="InfoDeletion.aspx">删除部门信息</a>
                                </li>
                            </ul>
                        </li>

                        <li id="Li11" runat="server">
                            <a href="InfoModification.aspx"><i class=""></i>信息修改<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li id="Li5" runat="server">
                                    <a href="InfoModification.aspx">修改员工信息</a>
                                </li>
                                <li id="Li6" runat="server">
                                    <a href="InfoModification.aspx">修改部门信息</a>
                                </li>
                            </ul>
                        </li>

                        <li id="Li7" runat="server">
                            <a href="InfoBrowsing.aspx"><i class=""></i>信息浏览<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <a href="InfoBrowsing.aspx">浏览个别员工信息</a>
                                </li>
                                <li>
                                    <a href="InfoBrowsing.aspx">浏览部门所属所有员工信息</a>
                                </li>
                            </ul>
                        </li>

                        <li>
                            <a href="UserMan.aspx"><i class=""></i>用户管理与用户登陆<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li id="Li8" runat="server">
                                    <a href="UserMan.aspx">用户管理</a>
                                </li>
                                <li>
                                    <a href="ChPwd.aspx">修改密码</a>
                                </li>
                            </ul>
                        </li>

                        <li>
                            <a href="Help.aspx"><i class=""></i>系统帮助及使用说明<span class="fa arrow"></span></a>
                            <ul class="nav nav-second-level">
                                <li>
                                    <a href="Help.aspx">系统帮助与说明</a>
                                </li>
                            </ul>
                        </li>

                    </ul>
                </div>
            </nav>
            <!-- /. NAV SIDE  -->
            <div id="page-wrapper">
                <div id="page-inner">
                    <div>
                        <!-- 所有的前端html的代码都写在此处  -->
                        <div class="row">
                            <div class="col-md-12">
                                <div class="panel panel-success">
                                    <div class="panel-heading">
                                        <h1>用户管理功能模块
                                        </h1>
                                    </div>
                                    <div class="panel-body">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [did], [dname] FROM [department]"></asp:SqlDataSource>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div>
                                                    <table class="auto-style1">
                                                        <tr>
                                                            <td class="auto-style27">
                                                                <asp:Button ID="Button7" runat="server" Text="查询用户信息" OnClick="Button7_Click" />
                                                            </td>
                                                            <td class="auto-style27">
                                                                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="添加用户" />
                                                            </td>
                                                            <td class="auto-style6">
                                                                <asp:Button ID="Button5" runat="server" Text="删除用户" OnClick="Button5_Click" />
                                                            </td>
                                                            <td class="auto-style6">
                                                                <asp:Button ID="Button3" runat="server" Text="用户信息修改" OnClick="Button3_Click" />
                                                                <br />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    <br />
                                                </div>
                                                <div>
                                                    <table class="auto-style8">
                                                        <tr>
                                                            <td class="auto-style10">
                                                                <asp:Label ID="Label1" runat="server" Text="用户账号"></asp:Label>&nbsp
                                                            </td>
                                                            <td class="auto-style21" style="empty-cells: hide; border-collapse: separate;">
                                                                <asp:TextBox ID="TextBox1" runat="server" Font-Size="Medium"></asp:TextBox>
                                                            </td>
                                                            <td style="empty-cells: hide; border-collapse: separate;" rowspan="7">
                                                                <div class="auto-style28">
                                                                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="100%">
                                                                        <AlternatingRowStyle BackColor="White" />
                                                                        <EditRowStyle BackColor="#2461BF" />
                                                                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                                                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                                                        <RowStyle BackColor="#EFF3FB" />
                                                                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                                                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                                                                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                                                                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                                                                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                                                                    </asp:GridView>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr1" runat="server">
                                                            <td class="auto-style14">
                                                                <asp:Label ID="Label2" runat="server" Text="用户名字"></asp:Label>&nbsp
                                                            </td>
                                                            <td class="auto-style22">
                                                                <asp:TextBox ID="TextBox2" runat="server" Font-Size="Medium"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr2" runat="server">
                                                            <td class="auto-style9">
                                                                <asp:Label ID="Label5" runat="server" Text="所属部门"></asp:Label>&nbsp
                                                            </td>
                                                            <td class="auto-style26">
                                                                <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="dname" DataValueField="did">
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr3" runat="server">
                                                            <td class="auto-style18">
                                                                <asp:Label ID="Label3" runat="server" Text="年龄"></asp:Label>&nbsp
                                                            </td>
                                                            <td class="auto-style24">
                                                                <asp:TextBox ID="TextBox3" runat="server" Font-Size="Medium"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr4" runat="server">
                                                            <td class="auto-style16">
                                                                <asp:Label ID="Label4" runat="server" Text="密码"></asp:Label>&nbsp
                                                            </td>
                                                            <td class="auto-style25">
                                                                <asp:TextBox ID="TextBox4" runat="server" Font-Size="Medium"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr id="tr5" runat="server">
                                                            <td class="auto-style9">
                                                                <asp:Label ID="Label6" runat="server" Text="身份"></asp:Label>&nbsp
                                                            </td>
                                                            <td class="auto-style26">
                                                                <asp:DropDownList ID="DropDownList2" runat="server" Font-Size="Medium" Width="166px">
                                                                    <asp:ListItem Value=""> 请选择</asp:ListItem>
                                                                    <asp:ListItem Value="D">D(主管)</asp:ListItem>
                                                                    <asp:ListItem Value="U">U(普通员工)</asp:ListItem>
                                                                    <asp:ListItem Value="A"> A(管理员）</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style20" colspan="2">
                                                                <asp:Button ID="Button4" runat="server" Text="查询" Font-Size="Medium" Width="64px" OnClick="Button4_Click" />
                                                                &nbsp&nbsp
                                                                <asp:Button ID="Button6" runat="server" Text="取消" Font-Size="Medium" Width="64px" OnClick="Button6_Click" />
                                                                <br />
                                                                <asp:Label ID="Label7" runat="server" Text="现在是用户查询模式"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
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
                                    </div>
                                    <div class="panel-footer">
                                        &nbsp;
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- 所有的前端html的代码都写在此处  -->
                    </div>
                </div>
                <!-- /. PAGE INNER  -->
            </div>
            <!-- /. PAGE WRAPPER  -->
        </div>
        <footer align="center">
            <p>Copyright &copy; 2019.Company name All rights reserved.More Informacion <a href="Help.aspx">About .</a></p>
        </footer>
        <!-- /. WRAPPER  -->
        <!-- JS Scripts-->
        <!-- jQuery Js -->
        <script src="Resource/assets/js/jquery-1.10.2.js"></script>
        <!-- Bootstrap Js -->
        <script src="Resource/assets/js/bootstrap.min.js"></script>
        <!-- Metis Menu Js -->
        <script src="Resource/assets/js/jquery.metisMenu.js"></script>
        <!-- Morris Chart Js -->
        <script src="Resource/assets/js/morris/raphael-2.1.0.min.js"></script>
        <script src="Resource/assets/js/morris/morris.js"></script>
        <!-- Custom Js -->
        <script src="Resource/assets/js/custom-scripts.js"></script>
    </form>
</body>
</html>
