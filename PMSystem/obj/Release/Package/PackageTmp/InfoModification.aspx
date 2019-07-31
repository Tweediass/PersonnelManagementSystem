<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InfoModification.aspx.cs" Inherits="PMSystem.InfoModification" %>

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
            width: 393px;
        }

        .auto-style2 {
            width: 396px;
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
                                <div class="panel panel-danger">
                                    <div class="panel-heading">
                                        <h1>信息修改
                                        </h1>
                                    </div>
                                    <div class="panel-body">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <div class="auto-style1">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>

                                                    <asp:Button ID="Button1" runat="server" Text="修改员工信息" OnClick="btnUpdate_Click1" />
                                                    <br />
                                                    <asp:Label ID="Label1" runat="server" Text="员工代号："></asp:Label>
                                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                                    <div class="auto-style2">
                                                        <asp:Label ID="Label2" runat="server" Text="员工姓名："></asp:Label>
                                                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="Label3" runat="server" Text="所属部门："></asp:Label>
                                                        <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource1" DataTextField="dname" DataValueField="did" Width="70px">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [dname], [did] FROM [department]"></asp:SqlDataSource>
                                                        <br />
                                                        <asp:Label ID="Label4" runat="server" Text="年龄："></asp:Label>
                                                        &nbsp;&nbsp;
                                                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="Label5" runat="server" Text="登入密码："></asp:Label>
                                                        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="Label6" runat="server" Text="权限："></asp:Label>
                                                        <asp:DropDownList ID="DropDownList2" runat="server">
                                                        </asp:DropDownList>
                                                        <br />
                                                        <asp:Label ID="Label7" runat="server" ForeColor="Red"></asp:Label>
                                                        <br />
                                                        <asp:GridView ID="GridView1" runat="server">
                                                        </asp:GridView>
                                                        <br />
                                                        <br />
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="Button1" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
                                        <hr />
                                        <hr />
                                        <div>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Button ID="Button2" runat="server" Text="修改部门信息" OnClick="btnUpdate_Click2" />
                                                    <br />
                                                    <div>
                                                        <asp:Label ID="Label8" runat="server" Text="部门代号："></asp:Label>
                                                        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="Label9" runat="server" Text="部门名称："></asp:Label>
                                                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="Label10" runat="server" Text="部门主管："></asp:Label>
                                                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                                                        <br />
                                                        <asp:Label ID="Label11" runat="server" ForeColor="Red"></asp:Label>
                                                        <br />
                                                        <asp:GridView ID="GridView2" runat="server">
                                                        </asp:GridView>
                                                        <br />
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="Button2" EventName="Click" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </div>
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

