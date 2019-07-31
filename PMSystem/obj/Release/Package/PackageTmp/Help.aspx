<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="PMSystem.Help" %>

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
        .auto-style2 {
            width: 353px;
        }

        .auto-style3 {
            height: 20px;
            width: 382px;
        }

        .auto-style4 {
            width: 382px;
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
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h1>
                                            <asp:Label ID="permission" runat="server" Text="您的用户权限为：" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                                        </h1>
                                    </div>
                                    <div class="panel-body">
                                        <table style="width: 100%;">
                                            <tr align="center">
                                                <td colspan="2">
                                                    <asp:Label ID="info0" runat="server" Text=" " Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style2"></td>
                                                <td>
                                                    <table style="width: 50%;">
                                                        <tr align="left">
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style3"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">
                                                                <asp:Label ID="hel" runat="server" Text="帮助与说明：" Font-Bold="True" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">
                                                                <asp:Label ID="perA" runat="server" Text="权限“A”：管理员，所拥有的权限是最大的，可以对各个部门，各个员工，执行增删查改等操作；" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left" class="auto-style4">
                                                                <asp:Label ID="perD" runat="server" Text="权限“D”：部门主管，权限仅次于管理员，可以对各个员工，执行增删查改等操作，但仅限于对自己所在的部门员工进行管理，无法管理其他的部门，也无法对自己的部门进行任何操作；" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">
                                                                <asp:Label ID="perU" runat="server" Text="权限“U”：普通用户，仅仅拥有查询操作等基本操作，无法执行任何修改" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">
                                                                <asp:Label ID="about" runat="server" Text="参与人员：" Font-Bold="True" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">
                                                                <asp:Label ID="p1" runat="server" Text="张远亮 201624131338" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">
                                                                <asp:Label ID="p2" runat="server" Text="何志健 201624131326" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">
                                                                <asp:Label ID="p3" runat="server" Text="蔡酉波 201624131328" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">
                                                                <asp:Label ID="p4" runat="server" Text="卢淇珍 201624131353" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">
                                                                <asp:Label ID="p5" runat="server" Text="周伟珍 201624131337" Font-Size="Large"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                        <tr align="left">
                                                            <td class="auto-style4">&nbsp;</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
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
