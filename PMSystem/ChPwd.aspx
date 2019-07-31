<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChPwd.aspx.cs" Inherits="PMSystem.ChPwd" %>

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
            height: 20px;
        }

        .auto-style2 {
            height: 22px;
        }

        .auto-style3 {
            width: 504px;
        }

        .auto-style4 {
            width: 504px;
            height: 22px;
        }

        .auto-style5 {
            width: 504px;
            height: 11px;
        }

        .auto-style6 {
            height: 11px;
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
                                <a href="#"><i class="fa fa-gear fa-fw"></i>修改密码</a>
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
                                <div class="panel panel-info">
                                    <div class="panel-heading">
                                        <h1>
                                            <asp:Label ID="Label1" runat="server" Text="修改密码" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                                        </h1>
                                    </div>
                                    <div class="panel-body">
                                        <table style="width: 100%;">
                                            <tr align="center">
                                                <td colspan="2">&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="auto-style3">
                                                    <tr>
                                                        <td align="center" colspan="2" class="auto-style1">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style4">
                                                            <asp:Label ID="oldPwd" runat="server" Text="密 码："></asp:Label>
                                                        </td>
                                                        <td align="left" class="auto-style2">
                                                            <asp:TextBox TextMode="Password" ID="TextBox0" runat="server" Font-Size="Large"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr align="left">
                                                        <td align="center" colspan="2">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style3">
                                                            <asp:Label ID="newPwd" runat="server" Text="新 密 码："></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox TextMode="Password" ID="TextBox1" runat="server" Font-Size="Large"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style3">
                                                            <asp:Label ID="confi" runat="server" Text="确认新密码："></asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox TextMode="Password" ID="TextBox2" runat="server" Font-Size="Large"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style5">&nbsp;
                                                        </td>
                                                        <td align="left" class="auto-style6">
                                                            <asp:Label ID="tips" runat="server" Text="“确认新密码”与“新密码”必须匹配" Font-Size="Medium" ForeColor="Red"></asp:Label>

                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style3">&nbsp;</td>
                                                        <td align="left">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="auto-style3">
                                                            <asp:Button ID="Button2" runat="server" Text="确认" BackColor="#663300" ForeColor="White" Font-Size="Medium" OnClick="confirm" />

                                                        </td>
                                                        <td align="left">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                              <asp:Button ID="Button4" runat="server" Text="取消" BackColor="#663300" ForeColor="White" Font-Size="Medium" OnClick="cancel" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" class="auto-style2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            <br />
                                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                            <br />
                                                            <br />
                                                        </td>
                                                    </tr>
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
                    </div>
                    <!-- 所有的前端html的代码都写在此处  -->
                </div>
            </div>
            <!-- /. PAGE INNER  -->
        </div>
        <!-- /. PAGE WRAPPER  -->
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
